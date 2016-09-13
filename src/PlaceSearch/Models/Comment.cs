using System.ComponentModel.DataAnnotations;

namespace PlaceSearch.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Description { get; set; }
        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }
    }
}