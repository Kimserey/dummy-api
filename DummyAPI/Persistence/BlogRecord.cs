using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DummyAPI.Persistence
{
    public class BlogRecord
    {
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }

        public ICollection<PostRecord> Posts { get; set; }
    }
}
