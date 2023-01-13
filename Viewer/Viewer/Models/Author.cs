namespace Viewer.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<Genre> Genres { get; set; }        
    }
}
