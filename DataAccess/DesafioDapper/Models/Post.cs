using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioDapper.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(160)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Summary { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        [StringLength(80)]
        public string Slug { get; set; }

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;
    }
}
