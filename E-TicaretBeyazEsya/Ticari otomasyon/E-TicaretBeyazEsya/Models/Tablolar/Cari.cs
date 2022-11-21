using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_TicaretBeyazEsya.Models.Tablolar
{
    public class Cari
    {
        [Key]
        public int Cari_ID { get; set; }
        [Display(Name ="Cari Ad")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage ="Bu alan zorunludur")]
        [StringLength(maximumLength:40)]
        public string Cari_Ad { get; set; }
        [Display(Name = "Cari Soyad")]
        [Column(TypeName = "Varchar")]
        [StringLength(maximumLength: 40)]
        public string Cari_Soyad { get; set; }
        [Display(Name = "Cari Şehir")]
        [Column(TypeName = "Varchar")]
        [StringLength(maximumLength: 15)]
        public string Cari_Sehir { get; set; }
        [Display(Name = "Cari Mail")]
        [Column(TypeName = "Varchar")]
        public string Cari_Mail  { get; set; }

        [Display(Name = "Cari Şifre")]
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Cari_Sifre { get; set; }

        [Display(Name = "Cari Durum")]
        public bool Cari_Durum { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}