namespace book_store_api.Models.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public  string Title { get; set; }
        public  string Author { get; set; }
        public  string ISBN { get; set; }
        public  DateOnly PublicationDate { get; set; }
    }
}
