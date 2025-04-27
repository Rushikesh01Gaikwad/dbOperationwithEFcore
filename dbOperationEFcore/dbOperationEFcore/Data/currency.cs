namespace dbOperationEFcore.Data
{
    public class currency
    {
        public int id {  get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }

        public ICollection<bookPrice> BookPrices { get; set; }
    }
}
