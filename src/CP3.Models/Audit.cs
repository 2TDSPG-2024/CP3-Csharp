namespace CP3.Models
{
    public class Audit
    {
        public int Active { get; set; }

        public string CreationUser { get; set; } = "Keller";

        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
