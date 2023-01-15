namespace Viewer.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
