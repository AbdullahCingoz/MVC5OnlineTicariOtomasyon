using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_TicaretBeyazEsya.Models.Tablolar
{
    public class Kategori
    {
        [Key]
        public int Kategori_ID { get; set; }
        [Display(Name ="Kategori Adı")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [StringLength(maximumLength: 30, ErrorMessage = "Bu alan maksimum 30 karakter olmalıdır")]
        public string Kategori_Ad { get; set; }
        public ICollection<Urun> Uruns { get; set; }
    }
}