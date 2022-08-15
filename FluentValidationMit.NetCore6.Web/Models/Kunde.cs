namespace FluentValidationMit.NetCore6.Web.Models
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Alter { get; set; }
        public DateTime? GeburtsDatum { get; set; }
        public IList<Adresse>Adressen { get; set; }
    }
}
