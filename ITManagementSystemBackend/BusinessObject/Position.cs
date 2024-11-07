using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Position
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string PositionName { get; set; } = string.Empty;

        public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
    }
}
