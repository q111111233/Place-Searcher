using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaceSearch.Models
{
    public class Place
    {
        [Key]
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}