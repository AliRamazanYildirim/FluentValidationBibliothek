namespace FluentValidationMit.NetCore6.Web.Models
{
    public class Adresse
    {
        public int Id { get; set; }
        public string Inhalt { get; set; }
        public string Provinz { get; set; }
        public string PostleitZahl { get; set; }
        public virtual Kunde Kunde { get; set; }
        //Wir können die Entität überwachen, die sich auf den virtuellen Parameter bezieht.(Tracking)
    }
}
