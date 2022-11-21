using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_TicaretBeyazEsya.Models.Tablolar
{
    public class Personel
    {
        [Key]
        public int Personel_ID { get; set; }

        [Display(Name ="Personel Adı")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage ="Bu alan zorunludur")]
        [StringLength(maximumLength:40)]
        public string Personel_Ad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(maximumLength: 40)]
        [Display(Name ="Personel Soyadı")]
        public string Personel_Soyad { get; set; }
        [Display(Name ="Personel Görsel")]
        public string Personel_Gorsel { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        [Display(Name = "Departman")]
        public int Departman_ID { get; set; }
        public virtual Departman Departman { get; set; }
    }
}