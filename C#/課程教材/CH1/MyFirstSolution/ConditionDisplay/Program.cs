namespace ConditionDisplay
{
    /// <summary>
    /// 重點
    /// (1) 避免 magic number
    /// (2) 字串差補語法
    /// (3) int.Parse
    /// (4) if 條件式的順序
    /// (5) 有意義的命名
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            int condition = 10; /* 避免 magic number，將條件值設定為變數 
                                   甚至可以寫成 const int condition = 10; */

            int value;
            Console.WriteLine("請輸入一個數字 :");
            string input = Console.ReadLine();
            value = int.Parse(input); // 將輸入的字串轉換為整數，這裡假設輸入的字串一定是有效的整數格式
            if (value > condition)
            {
                // 使用字串插補 (String interpolation) 語法 (也稱為字串插值)，將輸入的數字與條件值顯示在訊息中
                Console.WriteLine($"輸入的數字 {value} 大於 {condition}");
                /* 以前可能會這樣寫 [複合格式化 (Composite Formatting)]：
                 * Console.WriteLine(string.Format("輸入的數字 {0} 大於 {1}", value, condition));
                 * 或是這樣寫 [字串串接 (String Concatenation)]:
                 * Console.WriteLine("輸入的數字 " + value + " 大於 " + condition); */

            }
            else if (value < condition)
            {
                Console.WriteLine($"輸入的數字 {value} 小於 {condition}");
            }
            else
            {
                Console.WriteLine($"輸入的數字 {value} 等於 {condition}");
            }
        }
    }
    /*
     語法特點
         字串插補採用 $ 前綴搭配 {} 直接嵌入變數，語法最為直觀。
         複合格式化使用數字索引 {0}, {1} 對應參數位置。
         字串串接則是用 + 運算符將字串片段連接起來。

     可讀性與維護性
         字串插補的可讀性最佳，變數直接出現在對應位置，一眼就能看出最終輸出的樣子。
         複合格式化需要在格式字串和參數之間來回對照，可讀性中等。
         字串串接在複雜情況下容易產生冗長的 + 鏈，可讀性最差。

     效能表現
         在編譯時期，字串插補和 string.Format 都會被編譯器優化為高效的實作方式。
         字串串接如果涉及多個變數，可能產生多個臨時字串物件，效能相對較差，尤其在迴圈中使用時更明顯。

     格式化功能
         字串插補支援豐富的格式化選項，例如 {value:N2} 可以格式化數字。
         string.Format 同樣支援完整的格式化語法。
         字串串接無法直接進行格式化，需要先對變數呼叫 .ToString() 方法。

     適用場景
         字串插補適合大部分現代 C# 開發場景，特別是 .NET Core 和 .NET 5+ 專案。
         複合格式化適合需要動態格式字串的情況，或維護較舊的程式碼。
         字串串接現在主要用於簡單的兩個字串併。

     版本相容性
         字串插補需要 C# 6.0 以上版本。
         string.Format 從 .NET Framework 1.0 開始就存在，相容性最好。
         字串串接是最基礎的語法，所有版本都支援。
     */
}
