using System.ComponentModel.DataAnnotations;

namespace WebUygulamaProje1.Models
{
    public class KitapTuru
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Ad { get; set; }
    }
}
