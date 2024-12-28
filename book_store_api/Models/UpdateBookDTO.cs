namespace book_store_api.Models
{
    public class UpdateBookDTO
    {
        public string? Title { get; set; } // Nullable to allow partial updates
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public DateOnly? PublicationDate { get; set; } // Nullable DateOnly
    }
}
