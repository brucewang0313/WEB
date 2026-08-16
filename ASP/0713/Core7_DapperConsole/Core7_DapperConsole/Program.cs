using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using Dapper;

namespace Core7_DapperConsole
{
    internal class Program
    {
        static string connString = @"data source=(localdb)\mssqllocaldb;initial catalog=Northwind";

        static async Task Main(string[] args)
        {

            //await QueryAsyncStrongTyped();

            /*
            Employee emp = new Employee()
            {
                FirstName = "大衛",
                LastName = "王",
                Title ="CEO",
                Country = "USA"
            };

            int rows = ExecuteInsert(emp);

            Console.WriteLine($"影響{rows}筆資料");
            Console.ReadKey();
            */


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

        //#1.查詢 --> 回傳List<Employee>強型別
        static void QueryStrongTyped()
        {
            List<Employee> employees = null;

            string sql = "select * from Employees";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                employees = conn.Query<Employee>(sql).ToList();
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

        static void QueryDynamicTypedFixed()
        {
            List<dynamic> employees = null;

            string sql = "select * from Employees";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                employees = conn.Query(sql).ToList();
            }

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.EmployeeID}, {emp.Title}, {emp.City}, {emp.Country}");
            }
        }

        //#3
        static void QueryFirstRecord(string country)
        {
            string sql = "select * from Employees where Country='UK'" ;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                Employee emp = conn.QueryFirstOrDefault<Employee>(sql);

                Console.WriteLine($"{emp.EmployeeID}, {emp.Title}, {emp.City}, {emp.Country}");

                Console.ReadKey();
            }
        }

        //#4
        static void QuerySingleRecord()
        {
            string sql = "select * from Employees where LastName=@lastname";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                Employee emp = conn.QuerySingleOrDefault<Employee>(sql, new { lastname = "King" });

                Console.WriteLine($"{emp.EmployeeID}, {emp.LastName},{emp.FirstName},{emp.Title}, {emp.City}, {emp.Country}");

                Console.ReadKey();
            }
        }


        //#5 , 指定多重參數
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

        //#6, 傳遞參數集合作查詢
        static void QueryParameterList()
        {
            List<Employee> employees = null;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "Select * from Employees Where EmployeeID in @IDs";
                employees = conn.Query<Employee>(sql, new { IDs = new int[] { 1, 3, 5 } }).ToList();
            }

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.EmployeeID}, {emp.LastName}, {emp.Title}, {emp.Country}");
            }

            Console.WriteLine("--------------------------------------");

            employees = null;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "Select * from Employees Where LastName in @LastName";
                employees = conn.Query<Employee>(sql, new { LastName = new[] { "Fuller", "King" } }).ToList();
            }

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.EmployeeID}, {emp.LastName}, {emp.Title}, {emp.Country}");
            }
        }

        //#7, 查詢預存程序
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

        //#8, QueryAsync非同步查詢
        static async Task QueryAsyncStrongTyped()
        {
            string sql = "Select * From Employees Where City = @city";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                await conn.OpenAsync();

                IEnumerable<Employee> employees = await conn.QueryAsync<Employee>(sql , new { city="London"});

                foreach (var emp in employees)
                {
                    Console.WriteLine($"{emp.EmployeeID}, {emp.Title}, {emp.City}, {emp.Country}");
                }
            }
        }

        static async Task QueryAsyncStrongTypedFixed()
        {
            string sql = "select * from Employees";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                await conn.OpenAsync().ConfigureAwait(false); // 非同步開啟連線

                IEnumerable<Employee> employees = await conn.QueryAsync<Employee>(sql).ConfigureAwait(false); // 非同步查詢資料

                foreach (var emp in employees)
                {
                    Console.WriteLine($"{emp.EmployeeID}, {emp.Title}, {emp.City}, {emp.Country}");
                }
            }
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

        //非步語法
        public static async Task<int> ExecuteInsertAsync(Employee emp)
        {
            int affectedRow = 0;

            string sql = @"INSERT INTO Employees (FirstName, LastName, Title, Country) 
                           VALUES (@FirstName, @LastName, @Title, @Country)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                await conn.OpenAsync();
                affectedRow = await conn.ExecuteAsync(sql, new
                {
                    emp.FirstName,
                    emp.LastName,
                    emp.Title,
                    emp.Country
                });
            }

            return affectedRow;
        }

        //#10, Execute()執行Update
        static int ExecuteUpdate(Employee emp)
        {
            int affectedRow = 0;

            string sql = "Update Employees Set FirstName=@FirstName, LastName=@LastName, Title=@Title, Country=@Country WHERE EmployeeID = @EmployeeID";
            
            using (SqlConnection conn = new SqlConnection(connString))
            {

                affectedRow = conn.Execute(sql, new
                {
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Title = emp.Title,
                    Country = emp.Country,
                    EmployeeID = emp.EmployeeID
                });
            }

            return affectedRow;
        }

        //非同步
        public static async Task<int> ExecuteUpdateAsync(Employee emp)
        {
            int affectedRow = 0;

            string sql = "UPDATE Employees SET FirstName=@FirstName, LastName=@LastName, Title=@Title, Country=@Country WHERE EmployeeID = @EmployeeID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                await conn.OpenAsync();
                affectedRow = await conn.ExecuteAsync(sql, new
                {
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Title = emp.Title,
                    Country = emp.Country,
                    EmployeeID = emp.EmployeeID
                });
            }

            return affectedRow;
        }

        //#11, Execute()執行Delete
        static int ExecuteDelete(Employee emp)
        {
            int affectedRow = 0;

            string sql = "delete from Employees Where EmployeeID = @EmployeeID";
            
            using (SqlConnection conn = new SqlConnection(connString))
            {
                affectedRow = conn.Execute(sql, new { EmployeeID = emp.EmployeeID });
            }

            return affectedRow;
        }

        //非同步
        public static async Task<int> ExecuteDeleteAsync(Employee emp)
        {
            int affectedRow = 0;

            string sql = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                await conn.OpenAsync();
                affectedRow = await conn.ExecuteAsync(sql, new { EmployeeID = emp.EmployeeID });
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

                        tran.Commit();

                        Console.WriteLine($"影響{affectedRow}筆資料!");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        Console.WriteLine(ex.ToString());
                    }
                }
                conn.Close();
            }
        }

        //非同步
        public static async Task DBTransactionAsync()
        {
            string sql = "INSERT INTO Employees (FirstName, LastName) VALUES (@FirstName, @LastName)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                await conn.OpenAsync();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        int affectedRow = await conn.ExecuteAsync(sql, new { FirstName = "Mark", LastName = "Lee" }, transaction: tran);

                        await tran.CommitAsync();

                        Console.WriteLine($"影響{affectedRow}筆資料!");
                    }
                    catch (Exception ex)
                    {
                        await tran.RollbackAsync();
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
        }

        //13.資料庫交易-使用TransactionScope - 需要MSDTC
        static void DBTransactionScope()
        {
            string sql = "Insert into Employees (FirstName, LastName) Values (@FirstName, @LastName)";
            
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (TransactionScope tranScope = new TransactionScope())
                {
                    try
                    {
                        int affectedRow = conn.Execute(sql, new { FirstName = "Mary", LastName = "Tseng" });

                        tranScope.Complete();

                        Console.WriteLine($"影響{affectedRow}筆資料!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                conn.Close();
            }
        }

        //非同步
        public static async Task DBTransactionScopeAsync()
        {
            string sql = "INSERT INTO Employees (FirstName, LastName) VALUES (@FirstName, @LastName)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                await conn.OpenAsync();
                using (TransactionScope tranScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        int affectedRow = await conn.ExecuteAsync(sql, new { FirstName = "Mary", LastName = "Tseng" });

                        tranScope.Complete();

                        Console.WriteLine($"影響{affectedRow}筆資料!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
        }
    }


}