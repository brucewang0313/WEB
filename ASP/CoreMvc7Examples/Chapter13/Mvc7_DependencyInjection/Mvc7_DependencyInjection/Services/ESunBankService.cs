
namespace Mvc7_DependencyInjection.Services
{
    public class ESunBankService : IBankService
    {
        public string BankId { get; private set; }

        public string BankName { get; private set; }

        public ESunBankService()
        {
            BankId = "808";
            BankName = "玉山銀行";
        }

        public decimal AccountBalance(string depositorId)
        {
            decimal balance = 3000000;
            if (depositorId == "18072")
            {
                balance = 1500000;
            }

            return balance;
        }

        public bool Deposit(decimal dollars)
        {
            //Todo ...
            return true;
        }

        public bool Withdraw(decimal dollars)
        {
            //Todo ...
            return true;
        }
    }
}
