using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Role : IBaseEntity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)", Order = 1)]
        public string Name { get; set; }

        [Required]
        [Column(Order = 2)]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(500)", Order = 3)]
        public string Description { get; set; }
    }
}
