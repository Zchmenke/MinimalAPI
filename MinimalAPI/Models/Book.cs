namespace MinimalAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public bool Available { get; set; }
        public int ReleaseYear { get; set; }
    }
}
