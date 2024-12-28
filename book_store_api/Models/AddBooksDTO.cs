namespace book_store_api.Models
{
    public class AddBooksDTO
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string ISBN { get; set; }
        public required DateOnly PublicationDate { get; set; }
    }
}
