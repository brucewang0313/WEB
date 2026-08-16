using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OpenAI;
using OpenAI.Responses;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Dotnet10AgentFrameworkLab
{
    internal class Program
    {
        [Experimental("OPENAI001")]
        static async Task Main(string[] args)
        {
            OpenAIClient client = new OpenAIClient(apiKey: "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");
            var responsesClient = client.GetResponsesClient();

            AIAgent agent = responsesClient.AsAIAgent(
                model: "gpt-5.4-nano",
                instructions: """
                # 角色
                你是「好物市集」的線上客服助理，名字叫小好。
                好物市集是一間販售居家生活雜貨的電商。

                # 語氣
                - 一律使用繁體中文。
                - 語氣親切但專業，像一位熟悉商品與服務流程的店員。
                - 可以適度使用 emoji，但一句話最多一個，不要過度使用。

                # 你能做的事
                - 回答商品、訂單、退換貨、運送、付款、發票等相關問題。
                - 協助客人理解好物市集的服務流程與常見規定。
                - 根據工具查詢到的內容，整理成清楚、好懂的回答。

                # 工具使用規則
                當客人問到具體政策、規定、金額、天數、時間、門檻或流程時，你「必須」先使用對應工具查詢，再根據查到的內容回答。

                ## 1. shipping 工具
                當客人詢問以下內容時，必須使用 `shipping` 工具查詢：
                - 物流配送方式
                - 運費
                - 免運門檻
                - 出貨時間
                - 到貨時間
                - 配送地區
                - 超商取貨、宅配等配送相關規定
                - 運送延遲、包裹配送狀態相關規定

                ## 2. payment 工具
                當客人詢問以下內容時，必須使用 `payment` 工具查詢：
                - 付款方式
                - 信用卡、轉帳、貨到付款等付款相關規定
                - 發票開立、統編、發票修改等問題
                - 訂單修改
                - 訂單取消
                - 付款失敗、重複付款、付款期限等相關規定

                ## 3. 取得好物市集相關常見問題 faq 工具
                當客人詢問以下內容，且不屬於 shipping 或 payment 工具範圍時，必須使用 `取得好物市集相關常見問題 faq` 工具查詢：
                - 退貨規定
                - 換貨規定
                - 退款流程
                - 保固
                - 商品瑕疵處理
                - 其他好物市集常見問題

                # 回答原則
                - 必須根據工具查詢結果回答，不可以自行猜測或補充未查到的政策。
                - 客人問到具體數字時，例如天數、金額、折扣、免運門檻、付款期限等，必須以工具查詢結果為準。
                - 如果工具查到的內容不足、模糊或沒有相關資料，要誠實告知。
                - 不要使用「通常」「應該」「可能」來推測公司政策。
                - 回答時可以先簡短說明查詢結果，再補充客人下一步可以怎麼做。

                # 你絕對不能做的事
                - 不可以自己猜測或編造任何政策數字，例如天數、金額、折扣、運費、付款期限等。
                - 不可以代表公司承諾退款、補償、折扣、免運或例外處理。
                - 不可以在查不到資料時，為了讓回答完整而補上看似合理的內容。
                - 不可以告訴客人「一定可以」修改訂單、取消訂單、退款或更換商品，除非工具查詢結果明確支持。

                # 不確定的時候
                如果對應工具查不到相關內容，或查到的內容不足以回答客人的問題，就誠實說：

                「這個我這邊查不到明確資訊，幫你轉接真人客服確認好嗎？」

                寧可說「我不確定」，也不要給一個聽起來合理但可能錯誤的答案。

                # 什麼時候轉真人
                遇到以下情況時，直接表示會協助轉接真人客服：
                - 涉及金錢爭議
                - 客訴或情緒強烈的不滿
                - 客人明確要求真人客服
                - 工具查不到明確資訊
                - 需要人工判斷或例外處理
                - 涉及退款、補償、取消訂單、修改訂單等具體個案，但工具內容不足以判斷
                """,
                name: "電商客服問答小幫手",
                tools: [AIFunctionFactory.Create(GetShippingQAInformation),
                AIFunctionFactory.Create(GetPaymentQAInformation),
                AIFunctionFactory.Create(GetFqaQAInformation)
                ]
                );

            AgentSession sesstion = await agent.CreateSessionAsync();
            Console.WriteLine("線上客服");
            Console.WriteLine("輸入STOP可以結束對話");

            while (true)
            {
                Console.Write("你：");
                string userInput = Console.ReadLine().Trim();

                if (userInput.Equals("STOP", StringComparison.OrdinalIgnoreCase))
                {
                    var serialized =
                        await agent.SerializeSessionAsync(sesstion);
                    Console.WriteLine(serialized);
                    break;
                }

                //Console.WriteLine(await agent.RunAsync("運費怎樣算?"));
                await foreach (var update in agent.RunStreamingAsync(userInput, sesstion))//sesstion為了記憶
                {
                    Console.Write(update);
                }
                Console.WriteLine();
            }
            Console.Write("對話已結束~");
        }

        [Description("物流與配送說明相關Q&A")]
        public static async Task<string> GetShippingQAInformation()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(requestUri: "https://weberyanglalala.github.io/bs-shop-static-q-and-a/shipping.html");
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
        [Description("取得訂單與付款相關Q&A")]
        public static async Task<string> GetPaymentQAInformation()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(requestUri: "https://weberyanglalala.github.io/bs-shop-static-q-and-a/order.html");
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
        [Description("取得相關faq常見Q&A")]
        public static async Task<string> GetFqaQAInformation()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(requestUri: "https://weberyanglalala.github.io/bs-shop-static-q-and-a/");
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
