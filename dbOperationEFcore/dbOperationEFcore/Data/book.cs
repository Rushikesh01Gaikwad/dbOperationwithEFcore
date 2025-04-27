namespace dbOperationEFcore.Data
{
    public class book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string description { get; set; }
        public int NoOfpages { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LanguageId { get; set; }
        public int? AuthorId { get; set; }
        public language? language { get; set; }

        public Author? author { get; set; }
    }
}
