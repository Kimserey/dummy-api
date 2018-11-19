using System.ComponentModel.DataAnnotations;

namespace DummyAPI.Persistence
{
    public class AuthorRecord
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
