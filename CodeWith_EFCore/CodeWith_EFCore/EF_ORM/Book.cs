namespace CodeWith_EFCore.EF_ORM
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public int? NoOfPages {  get; set; }
        public string Location { get; set; }
        public DateTime? PublishedDate { get; set; }
        public DateTime? Created { get; set; }
        public Language Languages { get; set; }

    }

    
}
