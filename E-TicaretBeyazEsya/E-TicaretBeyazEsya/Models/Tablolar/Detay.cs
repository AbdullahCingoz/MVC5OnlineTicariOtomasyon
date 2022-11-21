using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_TicaretBeyazEsya.Models.Tablolar
{
    public class Detay
    {
        [Key]
        public int Detay_ID { get; set; }
        [Display(Name ="Ürün Ad")]
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string Urun_Ad { get; set; }
        [Display(Name ="Ürün Bilgisi")]
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string UrunBilgisi { get; set; }
    }
}