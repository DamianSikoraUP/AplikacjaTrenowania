namespace AplikacjaTrenowania.Models
{
    public class Uzytkownik
    {
        public int Id { get; set; }
        public required string Login { get; set; }
        public required string Email { get; set; }
        public int DziennyCelWody { get; set; }
        public int IleWypitoWody { get; set; }
        public int DziennyCelBialkowy { get; set; }
        public int IleZjedzonoBialka { get; set; }
    }
}
