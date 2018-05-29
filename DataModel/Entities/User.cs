using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class User : IBaseEntity
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)", Order = 1)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)", Order = 2)]
        public string Login { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)", Order = 3)]
        public string Password { get; set; }

        public UserRole UserRole { get; set; }
    }
}
