namespace LinqSample003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = CreateList();
            /*FIRST & LAST區段
            //var person1 = list.FirstOrDefault((x) => x.Age < 37);//第一個
            //Console.WriteLine($"小於37歲的人第一次被我找到：{person1.Name}");

            var person1 = list.LastOrDefault((x) => x.Age > 35);//最後一個
            Console.WriteLine($"大於35歲的人第一次被我找到：{person1.Name}");

            //var customDefault = list.FirstOrDefault((x) => x.Age < 30, new MyData { Name = "Not Found", Age = 0 });
            //Console.WriteLine($"找不到，所以回傳自訂物件：{customDefault.Name}");

            var customDefault = list.LastOrDefault((x) => x.Age > 50, new MyData { Name = "Not Found", Age = 130 });
            Console.WriteLine($"找不到，所以回傳自訂物件：{customDefault.Name}");

            //var person2 = list.First((x) => x.Age < 30);//因為沒有預設值，因為沒有30以下的所以 會有例外狀況的錯誤
            //var person2 = list.Last((x) => x.Age > 50);//因為沒有預設值，因為沒有50以上的所以 會有例外狀況的錯誤
            //Console.WriteLine($"小於 30 歲的人第一個被找到的是 : {person2.Name}");
            */

            /*Single區段
            var person1 = list.SingleOrDefault((x) => x.Name == "Tom");//找唯一值
            Console.WriteLine($"找到唯一的：{person1.Name}");

            var customDefault = list.SingleOrDefault((x) => x.Name == "Not Found", new MyData { Name = "Not Found", Age = 0 });
            Console.WriteLine($"找不到，所以回傳自訂物件：{customDefault.Name}");

            var person2 = list.Single((x) => x.Name == "Bill");//因為有兩個一樣的所以 會有例外狀況的錯誤
            Console.WriteLine($"找到唯一的 : {person2.Name}");
            */

            /*預設值設定
            var person = list.FirstOrDefault((x) => x.Name == "李小龍");
            if (person == null)
            {
                Console.WriteLine("查無此人");//null值則另外處理
            }
            else
            {
                Console.WriteLine($"找到：{person.Name} - {person.Age}");
            }
            */
            /*取出某個位置的資料
            int index = 1;
            var person = list.ElementAtOrDefault(index);
            if (person == null)
            {
                Console.WriteLine("查無此人");
            }
            else
            {
                Console.WriteLine($"找到索引為：{index}的人是{person.Name}");
            }
            */

            /*Any
            string name = "David";
            bool result = list.Any((x) => x.Name == name);
            if (result)
            {
                Console.WriteLine($"找到了：{name}");
            }
            else
            {
                Console.WriteLine($"找不到：{name}");
            }
            */

            /*All
            string name = "Bill";
            bool isAllBill = list.All((x) => x.Name == name);
            if (isAllBill)
            {
                Console.WriteLine($"全部都是{name}");
            }
            else
            {
                Console.WriteLine($"有些人不叫{name}");
            }
            int age = 10;
            bool isOverForty = list.All((x) => x.Age >= age);
            if (isOverForty)
            {
                Console.WriteLine($"大家都超過{age}歲");
            }
            else
            {
                Console.WriteLine($"有人不到{age}歲");
            }
            */

            /*四則運算、數量、平均
            var total = list.Sum((x) => x.Age);
            Console.WriteLine($"年齡的總合為：{total}");
            var minAge = list.Min((x) => x.Age);
            Console.WriteLine($"最小的年齡為：{minAge}");
            var maxAge = list.Max((x) => x.Age);
            Console.WriteLine($"最大的年齡為：{maxAge}");
            var count = list.Count;
            Console.WriteLine($"list的總數為：{count}");
            var countOfBill = list.Count((x) => x.Name == "Bill");
            Console.WriteLine($"List中的Bill總數量為:{countOfBill}");
            var average = list.Average((x) => x.Age);
            Console.WriteLine($"年齡的平均為：{average}");
            */

            /*複合有條件的運算式
            var min = list.Where((x) => x.Name == "Bill").Min((x) => x.Age);
            Console.WriteLine($"所有Bill中年紀最小的是：{min}歲");
            var total = list.Where((x) => x.Name == "Bill").Sum((x) => x.Age);
            Console.WriteLine($"所有Bill的年紀總和的是：{total}歲");
            var average = list.Where((x) => x.Name == "Bill").Average((x) => x.Age);
            Console.WriteLine($"所有Bill的年紀的平均是：{average}歲");
            */

            /*MinBy & Maxby*/
            var minAge_before = list.First((x) => x.Age == list.Min(x => x.Age));//舊寫法因為int所以可能要找兩遍效率差
            Console.WriteLine($"最小年齡的人是：{minAge_before.Name},{minAge_before.Age}歲");
            var minAge_after = list.MinBy((x) => x.Age);
            Console.WriteLine($"最小年齡的人是：{minAge_after.Name},{minAge_after.Age}歲");
            var maxAge_before = list.First((x) => x.Age == list.Max(x => x.Age));
            Console.WriteLine($"最大年齡的人是：{maxAge_before.Name},{maxAge_before.Age}歲");
            var maxAge_after = list.MaxBy((x) => x.Age);
            Console.WriteLine($"最大年齡的人是：{maxAge_after.Name},{maxAge_after.Age}歲");

            Console.ReadLine();
        }
        static List<MyData> CreateList()
        {
            //return new List<MyData>()//集合正規化
            //{
            //new MyData { Name = "Bill" , Age = 47},
            //new MyData { Name = "John", Age = 37},
            //new MyData { Name = "Tom", Age = 48},
            //new MyData { Name = "David", Age = 36},
            //new MyData { Name = "Bill", Age = 35},
            //};

            //集合運算式：C#12.0新的寫法
            return
            [
                new() { Name ="Bill", Age = 47 },
                new() { Name ="John", Age = 37 },
                new() { Name ="Tom", Age = 48 },
                new() { Name ="David", Age = 36 },
                new() { Name ="Bill", Age = 35 },
            ];
        }
    }
    
    internal class MyData
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
