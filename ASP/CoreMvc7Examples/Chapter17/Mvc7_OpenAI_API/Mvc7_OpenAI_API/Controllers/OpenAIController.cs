using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Mvc7_OpenAI_API.Controllers
{
    public class OpenAIController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OpenAIController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CallApi()
        {

            var httpClient = _httpClientFactory.CreateClient();

            // 設定API的URL
            var apiUrl = "https://api.openai.com/v1/chat/completions";

            // 建立要傳遞的資料物件
            var data = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "user", content = "為什麼歐美舉例程式變數名稱時, 喜歡用foo , bar來命名？能說說是什麼典故嗎？" }
                }
            };

            // 將資料物件轉換成JSON字串
            var jsonContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            // 設定Content-type及Authorization標頭
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "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");

            // 發送POST請求並取得回應
            var response = await httpClient.PostAsync(apiUrl, jsonContent);

            // 確認回應狀態碼是否成功
            if (response.IsSuccessStatusCode)
            {
                // 讀取回應內容
                var responseContent = await response.Content.ReadAsStringAsync();

                // 處理回應內容，例如將JSON字串轉換成物件
                var result = JsonConvert.DeserializeObject<CompletionViewModel>(responseContent);

                // 返回結果
                return Ok(result);
            }
            else
            {
                // 處理回應失敗的情況
                // 可以根據需要自訂錯誤處理邏輯
                return StatusCode((int)response.StatusCode);
            }
        }
    }
}
