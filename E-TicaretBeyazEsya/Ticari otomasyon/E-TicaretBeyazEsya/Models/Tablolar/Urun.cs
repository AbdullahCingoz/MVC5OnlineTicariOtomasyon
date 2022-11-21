using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_TicaretBeyazEsya.Models.Tablolar
{
    public class Urun
    {
        [Key]
        public int Urun_ID { get; set; }
        [Display(Name = "Ürün Adı")]
        [Column(TypeName ="Varchar")]
        [Required(ErrorMessage ="Bu alan zorunludur")]
        [StringLength(maximumLength:40,ErrorMessage ="Bu alan maksimum 40 karakter olmalıdır.")]
        public string Urun_Ad { get; set; }
        [Display(Name = "Marka")]
        [Column(TypeName = "Varchar")]
        [StringLength(maximumLength: 40)]
        public string Urun_Marka { get; set; }
        [Display(Name = "Stok")]
        public short Urun_Stok { get; set; }
        [Display(Name = "Alış Fiyat")]
        public decimal Urun_AlisFiyati { get; set; }
        [Display(Name = "Satış Fiyat")]
        public decimal Urun_SatisFiyati { get; set; }
        [Display(Name = "Durum")]
        public bool Urun_Durum { get; set; }
        [Column(TypeName = "Varchar")]
        public string Urun_Gorsel { get; set; }
        [Display(Name = "Kategori")]
        public int Kategori_ID { get; set; }
        public virtual Kategori Kategori { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}