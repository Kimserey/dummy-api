using System.ComponentModel.DataAnnotations;

namespace DummyAPI.Persistence
{
    public class PostRecord
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public int AuthorId { get; set; }
        public AuthorRecord Author { get; set; }

        public int BlogId { get; set; }
        public BlogRecord Blog { get; set; }
    }
}
