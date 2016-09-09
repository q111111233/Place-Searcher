using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaceSearch.Models
{
    [Table("Places")]
    public class Place
    {
        public Place()
        {
            this.Comments = new HashSet<Comment>();
        }
        [Key]
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}