using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaceSearch.Models
{
    [Table("Places")]
    public class Place
    {
        [Key]
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}