using Dapper.Contrib.Extensions;

namespace DesafioDapper.Models
{
    [Table("[Role]")]
    public class Role
    {
        [Key]
        public int Id { get; set; }     
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
