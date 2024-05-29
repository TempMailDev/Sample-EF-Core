namespace CodeWith_EFCore.EF_ORM
{
    public class Language
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string  Description { get; set; }
        
        public ICollection<Book> Books { get; set;}
    }
}
