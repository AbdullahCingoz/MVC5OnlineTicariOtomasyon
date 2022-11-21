using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_TicaretBeyazEsya.Models.Tablolar
{
    public class Fatura
    {
        [Key]
        public int Fatura_ID { get; set; }

        [Display(Name ="Sıra No")]
        [Column(TypeName = "Varchar")]
        [StringLength(9)]
        public string Fatura_SıraNo { get; set; }

        [Display(Name = "Seri No")]
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string Fatura_SeriNo { get; set; }
        [Display(Name = "Tarih")]
        public DateTime Fatura_Tarih { get; set; }
        [Display(Name = "Saat")]
        [Column(TypeName ="Char")]
        [StringLength(5)]
        public string Fatura_Saat { get; set; }

        [Display(Name = "Vergi Dairesi")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Fatura_VergiDairesi { get; set; }
        [Display(Name = "Teslim Alan")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Fatura_TeslimAlan { get; set; }
        [Display(Name = "Teslim Eden")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Fatura_TeslimEden { get; set; }
      
        public decimal Toplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}