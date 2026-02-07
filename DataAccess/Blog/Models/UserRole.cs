using System.ComponentModel.DataAnnotations;

namespace DesafioDapper.Models
{
    public class UserRole
    {
        [Key]
        public int UserId { get; set; }

        [Key]
        public int RoleId { get; set; }
    }
}
