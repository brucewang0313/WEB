
namespace Mvc7_DependencyInjection.Services
{
    public class FubonBankService : IBankService
    {
        public string BankId { get; private set; }

        public string BankName { get; private set; }

        public FubonBankService()
        {
            BankId = "012";
            BankName = "台北富邦銀行";
        }

        public decimal AccountBalance(string depositorId)
        {
            decimal balance = 1000000;
            if (depositorId == "18072")
            {
                balance = 5000000;
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