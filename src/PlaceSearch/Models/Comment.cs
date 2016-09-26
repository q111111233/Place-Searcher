using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaceSearch.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Description { get; set; }
        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }
        public Comment(string description, int placeId, int commentId = 0)
        {
            Description = description;
            PlaceId = placeId;
            CommentId = commentId;
        }

        public Comment() { }
    }
}