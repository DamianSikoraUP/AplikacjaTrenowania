using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplikacjaTrenowania.Models
{
    public class Seria
    {
        [Key]
        public int IdSerii { get; set; }
        [Column(TypeName = "int")]
        public int Kg { get; set; }
        [Column(TypeName = "int")]
        public int Powtorzenia { get; set; }
    }
}
