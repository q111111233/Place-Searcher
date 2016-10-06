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
        public string Address { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ApplicationUser User { get; set; }
        public Place(string placeName, string address, ApplicationUser user, int placeId = 0)
        {
            PlaceName = placeName;
            Address = address;
            User = user;
            PlaceId = placeId;
        }

        public Place() { }
    }
}