using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_TicaretBeyazEsya.Models.Tablolar
{
    public class Departman
    {
        [Key]
        public int Departman_ID { get; set; }
        [Display(Name ="Departman Adı")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage ="Bu alan zorunludur")]
        public string Departman_Ad { get; set; }
        [Display(Name ="Durum")]
        public bool Durum { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}