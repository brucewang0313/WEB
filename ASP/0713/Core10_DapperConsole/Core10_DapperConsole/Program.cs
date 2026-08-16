using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Core10_DapperConsole
{
    internal class Program
    {
        static string connString= @"data source=(localdb)\mssqllocaldb;initial catalog=Northwind";
        static async Task Main(string[] args)
        {
            //adonet();
            //QueryStrongTyped();
            //QueryDynamicTyped();
            //QueryParameters();
            //QuerySP();

            //Employee emp = new Employee()
            //{
            //    FirstName = "David",
            //    LastName = "陳",
            //    Title = "CEO",
            //    Country = "USA"
            //};
            //int rows= ExecuteInsert(emp);
            //Console.WriteLine($"影響{rows}筆資料");

            DBTransaction();
        }
        static void adonet()
        {
            //1.建立Connection
            string connString = @"data source=(localdb)\mssqllocaldb;initial catalog=Northwind";

            //2.建立SQL命令
            string sql = """
                SELECT ProductID, UnitPrice, ProductName from dbo.products 
                Where UnitPrice > @price
                Order By UnitPrice desc
                """;

            //3.建立SqlConnection, SqlCommand
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                //SqlCommand
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@price", 5);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader(); //Select
                                                                //int result = cmd.ExecuteNonQuery(); //Insert, Update, Delete
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}", reader[0], reader[1], reader[2]);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                Console.ReadKey();
            }
        }

        // #1.查詢 --> 回傳List<Employee>強型別
        static void QueryStrongTyped()
        {
            List<Employee> employees = null;
            string sql = "select * from Employees";

            using (SqlConnection conn=new SqlConnection(connString))
            {
                employees = conn.Query<Employee>(sql).ToList();
            }
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.EmployeeID}, {emp.Title}, {emp.City}, {emp.Country}");
            }

            Console.ReadKey();
        }

        // #?. 非同步查詢
        static async Task QueryStrongTypedAsync()
        {
            IEnumerable<Employee> employees = null;

            string sql = "select * from Employees";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                employees = await conn.QueryAsync<Employee>(sql);
            }

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.EmployeeID}, {emp.Title}, {emp.City}, {emp.Country}");
            }

            Console.ReadKey();
        }

        //#2. Dynamic
        static void QueryDynamicTyped()
        {
            string sql = "select * from Employees";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                var employees = conn.Query(sql).ToList();

                foreach (var emp in employees)
                {
                    Console.WriteLine($"{emp.EmployeeID}, {emp.Title}, {emp.City}, {emp.Country}");
                }
            }
        }

        //#5. 指定多重參數
        static void QueryParameters()
        {
            List<Employee> employees;

            string sql = "select * from Employees where ";
            sql += "Country=@country and TitleOfCourtesy=@titleOfCourtesy";


            using (SqlConnection conn = new SqlConnection(connString))
            {
                employees = conn.
                    Query<Employee>(sql, new { country = "USA", titleOfCourtesy = "Ms." }).ToList();
            }

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.EmployeeID}, {emp.LastName}, {emp.Title}, {emp.Country}, {emp.TitleOfCourtesy}");
            }
        }

        //#7. 查詢預存程序
        static void QuerySP()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                var emp = conn.Query<Employee>("FindEmployeeByName",
                    new { LastName = "King", FirstName = "Robert" },
                    commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();

                Console.WriteLine($"{emp.EmployeeID}, {emp.FirstName}, {emp.LastName}, {emp.Country}");
            }

            Console.ReadKey();
        }

        //#9 Insert
        static int ExecuteInsert(Employee emp)
        {
            int affectedRow = 0;

            string sql = """
                INSERT INTO Employees(FirstName, LastName, Title, Country) 
                  VALUES ( @FirstName, @LastName, @Title, @Country)
                """;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                affectedRow = conn.Execute(sql, new
                {
                    emp.FirstName,
                    emp.LastName,
                    emp.Title,
                    emp.Country
                });
            }


            return affectedRow;
        }

        //#12.資料庫交易-使用SqlTransaction
        static void DBTransaction()
        {
            string sql = "Insert into Employees (FirstName, LastName) Values (@FirstName, @LastName)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        int affectedRow = conn.Execute(sql, new { FirstName = "Mark", LastName = "Lee" }, transaction: tran);

                        tran.Commit();// 交易寫到資料庫

                        Console.WriteLine($"影響{affectedRow}筆資料!");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();//回到原始狀態
                        Console.WriteLine(ex.ToString());
                    }
                }
                conn.Close();
            }
        }
    }
}
