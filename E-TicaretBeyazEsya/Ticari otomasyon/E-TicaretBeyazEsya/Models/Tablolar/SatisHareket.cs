using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_TicaretBeyazEsya.Models.Tablolar
{
    public class SatisHareket
    {
        [Key]
        public int SatisHareket_ID { get; set; }
        [Display(Name = "Tarih")]
        public DateTime SatisHareket_Tarih { get; set; }
        [Display(Name = "Adet")]
        public int SatisHareket_Adet { get; set; }
        [Display(Name = "Fiyat")]
        public decimal SatisHareket_Fiyat { get; set; }
        [Display(Name = "Toplam Tutar")]
        public decimal SatisHareket_ToplamTutar { get; set; }
        [Display(Name = "Ürün")]
        public int Urun_ID { get; set; }
        [Display(Name = "Cari")]
        public int Cari_ID { get; set; }
        [Display(Name = "Personel")]
        public int Personel_ID { get; set; }
        public virtual Urun Urun { get; set; }
        public virtual Cari Cari { get; set; }
        public virtual Personel Personel { get; set; }
    }
}