using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplikacjaTrenowania.Models
{
    public class Trening
    {
        [Key]
        public int IdTreningu { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Data { get; set; } = DateTime.Now.Date.ToString("d");
        [Column(TypeName = "nvarchar(50)")]
        public string Godzina { get; set; } = DateTime.Now.ToString("HH:mm");
        [Column(TypeName = "nvarchar(100)")]
        public string RodzajTreningu { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(100)")]
        public string WybierzCwiczenie { get; set; } = string.Empty;
        public List<Seria> Serie { get; set; } = [];
        public Trening() => Serie.Add(new Seria());
    }
}
