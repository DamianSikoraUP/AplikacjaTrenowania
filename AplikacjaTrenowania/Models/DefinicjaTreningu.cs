using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplikacjaTrenowania.Models
{
    public class DefinicjaTreningu
    {

        [Key]
        public int IdKategorii { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string RodzajTreningu { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(100)")]
        public string WybierzCwiczenie { get; set; } = string.Empty;
        public List<Trening> Trening { get; set; } = new List<Trening>();
    }
}
