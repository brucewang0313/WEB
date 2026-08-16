namespace EFCore_CodeFirstExistingDB.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
    }
}
