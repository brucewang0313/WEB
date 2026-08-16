using System.Globalization;

namespace IntToStringSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 123456;
            // 直接呼叫 i.ToString() 結果是 123456
            Console.WriteLine(i.ToString());

            // 呼叫 i.ToString(string)，並使用標準數值格式字串
            // 參考 MSDN 標準數值格式字串
            // "C" 代表貨幣, 會依照 Windows 本身的國別設定中的貨幣格式
            // 如果你的國別是台灣，沒有特別修改過的話
            // 結果應該是 NT$123,456.00
            Console.WriteLine(i.ToString("C"));

            // 呼叫 i.ToString(string)，並使用標準數值格式字串
            // "P" 代表百分比
            // 結果應該是 12,345,600.00%
            Console.WriteLine(i.ToString("P"));

            // 呼叫 i.ToString(String, IFormatProvider)
            // 第二個參數代表的是特定的文化特性,參考 MSDN CultureInfo 類別
            // 這個例子使用的是 日本
            // 所以結果是 ￥123,456
            Console.WriteLine(i.ToString("C", CultureInfo.CreateSpecificCulture("ja-JP")));

            // 呼叫 i.ToString(string)，並使用自訂數值格式字串
            // 參考 MSDN 自訂數值格式字串
            // 結果是 123456.000
            Console.WriteLine(i.ToString("#.000"));
            // 結果是 123,456
            Console.WriteLine(i.ToString("#,###.###"));
            // 結果是 123,456.000
            Console.WriteLine(i.ToString("#,###.000"));
            // 結果是 12345600.00%
            Console.WriteLine(i.ToString("00.00%"));
            // 結果是 123456.00小丸子
            Console.WriteLine(i.ToString("00.00小丸子"));
            Console.ReadLine();
        }
    }
}
