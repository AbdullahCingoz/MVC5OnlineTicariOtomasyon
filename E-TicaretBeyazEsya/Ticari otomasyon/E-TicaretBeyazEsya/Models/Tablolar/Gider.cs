using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_TicaretBeyazEsya.Models.Tablolar
{
    public class Gider
    {
        [Key]
        public int Gider_ID { get; set; }
        [Display(Name = "Açıklama")]
        [Required(ErrorMessage ="Bu alan zorunludur")]
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Gider_Aciklama { get; set; }
        [Display(Name = "Tarih")]
        public DateTime Gider_Tarih { get; set; }
        [Display(Name = "Tutar")]
        public decimal Gider_Tutar { get; set; }
    }
}