using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUygulamaProje1.Models
{
    public class Kitap
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        public string KitapAdi { get; set; }

        public string Tanim { get; set; }

        [Required]
        public string Yazar {  get; set; }

        [Required]
        [Range(10,5000)]
        public double Fiyat {  get; set; }

        public int KitapTuruId { get; set; }
        [ForeignKey("KitapTuruId")]
        public KitapTuru KitapTuru { get; set; }

        public string ResimUrl { get; set; }



    }
}
