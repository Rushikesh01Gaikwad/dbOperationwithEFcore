namespace dbOperationEFcore.Data
{
    public class bookPrice
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Amount { get; set; }
        public int CurrencyId { get; set; }

        public book Book { get; set; }
        public currency Currency { get; set; }

    }
}
