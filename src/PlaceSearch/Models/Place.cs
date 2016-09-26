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
        public Place(string placeName, ApplicationUser user, int placeId = 0)
        {
            PlaceName = placeName;
            User = user;
            PlaceId = placeId;
        }

        public Place() { }
    }
}