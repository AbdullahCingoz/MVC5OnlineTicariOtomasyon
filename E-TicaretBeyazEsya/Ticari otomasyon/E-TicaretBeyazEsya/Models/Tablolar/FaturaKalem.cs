using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_TicaretBeyazEsya.Models.Tablolar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalem_ID { get; set; }

        [Display(Name = "Açıklama")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        public string FaturaKalem_Aciklama { get; set; }
        [Display(Name = "Miktar")]
        public int FaturaKalem_Miktar { get; set; }
        [Display(Name = "Birim Fiyat")]
        public decimal FaturaKalem_BirimFiyat { get; set; }
        [Display(Name = "Tutar")]
        public decimal FaturaKalem_Tutar { get; set; }
        [Display(Name = "Fatura ID")]
        public int Fatura_ID { get; set; }
        public virtual Fatura Fatura { get; set; }

    }
}