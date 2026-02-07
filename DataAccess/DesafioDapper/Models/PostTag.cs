using System.ComponentModel.DataAnnotations;

namespace DesafioDapper.Models
{
    public class PostTag
    {
        [Key]
        public int PostId { get; set; }

        [Key]
        public int TagId { get; set; }
    }
}
