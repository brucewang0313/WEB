using System;
using System.Collections.Generic;
using System.Text;

namespace BuildSchoolBizApp.Services
{
    public class OperationResult
    {
        public bool IsSuccessful { get; set; }
        public Exception? Exception { get; set; }
    }
    public static class OperationResultExtensions
    {
        public static string WriteLog(this OperationResult result)
        {
            if(result.Exception != null)
            {
                string path = $"{DateTime.Now.ToString("yyyyMMdd-HHmmss")}_log.txt";
                File.WriteAllText(path, result.Exception.ToString());
                return path;
            }
            else
            {
                return "沒有存檔";
            }
        }
    }
}
