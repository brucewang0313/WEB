namespace ArraySample001
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 定義一個尚未初始化的一維陣列 (這會一直出現警告，直到你初始化陣列為止)
            int[] array0;

            //定義一個有五個元素一維陣列
            int[] array1 = new int[5];

            // 定義一個一維陣列，同時給予陣列的內容
            int[] array2 = new int[] { 1, 3, 5, 7, 9 }; 
            /* 後面的 { 1, 3, 5, 7, 9 } 被稱為陣列初始化設定式 (array initializer) */

            // 同上，語法糖的寫法
            int[] array3 = { 1, 2, 3, 4, 5, 6 };

            // 定義一個 2X3 的二維陣列
            int[,] multiDimensionalArray1 = new int[2, 3];

            // 定義一個二維陣列，同時給予陣列的內容
            int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            // 定義一個不規則陣列
            int[][] jaggedArray = new int[6][];

            // 設定不規則陣列的內容
            jaggedArray[0] = new int[4] { 1, 2, 3, 4 };

            // C# 12 開始支援集合運算式
            int[] array4 = [1, 2, 3, 4, 5];
        }
    }
}
