namespace CodeWith_EFCore.EF_ORM
{
    public class BookPrice
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CurrencyId {  get; set; }
        public int Amount { get; set; }

        public Book Books { get; set; }
        public Currency Currencys { get; set; }
    }
}
