using AplikacjaTrenowania.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplikacjaTrenowania.Models
{
    public class Trening
    {
        [Key]
        public int IdTreningu { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Data { get; set; } = DateTime.Now.Date.ToString("d");
        [Column(TypeName = "nvarchar(50)")]
        public string Godzina { get; set; } = DateTime.Now.ToString("HH:mm");
        [Required]
        public int IdKategorii { get; set; }
        [ForeignKey("IdKategorii")]
        public DefinicjaTreningu DefinicjaTreningu { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public List<Seria> Serie { get; set; } = [];
        public Trening() { }
        public Trening(string userId) { UserId = userId; }
    }
}
