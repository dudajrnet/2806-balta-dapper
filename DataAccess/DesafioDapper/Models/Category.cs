using Dapper.Contrib.Extensions;

namespace DesafioDapper.Models
{
    [Table("[Category]")]
    public class Category
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
