using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSample001
{
    public static class StringHelper
    {
        /// <summary>
        /// 輸入字串，將每個單字的首字母轉為大寫，其餘小寫
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToUpperTitleCase(string input)
        {

            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            return string.Join(' ', input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                         .Select(word => 
                                         char.ToUpper(word[0]) + word.Substring(1).ToLower()));

            /*
             *  StringSplitOptions.RemoveEmptyEntries 用於指定在拆分字串時是否應該忽略空的子字串。
             */
        }

        /// <summary>
        /// 擷取字串中指定分隔符號左邊的部分
        /// </summary>
        /// <param name="source"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string LeftOf(string source, string separator)
        {
            if (string.IsNullOrEmpty(source) || separator is null)
            {
                return source;
            }

            int index = source.IndexOf(separator, StringComparison.Ordinal);
            return index < 0 ? source : source.Substring(0, index);

            /*
             * StringComparison.Ordinal 代表「使用字元的 Unicode 編碼值進行比較」
             */
        }


        /// <summary>
        /// 擷取字串中指定分隔符號右邊的部分
        /// </summary>
        /// <param name="source"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string RightOf(string source, string separator)
        {
            if (string.IsNullOrEmpty(source) || separator is null)
            {
                return source;
            }

            int index = source.IndexOf(separator, StringComparison.Ordinal);
            return index < 0 ? source : source.Substring(index + separator.Length);
        }
    }
}
