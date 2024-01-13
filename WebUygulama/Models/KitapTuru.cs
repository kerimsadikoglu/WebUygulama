using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebUygulamaProje1.Models
{
    public class KitapTuru
    {
        [Key]
        public int ID { get; set; }


        [MaxLength(25)]
        [Required (ErrorMessage = "Kitap Tür Adı boş olamaz")]
        [DisplayName("Kitap Türü Adı")]
        public string Ad { get; set; }
    }
}
