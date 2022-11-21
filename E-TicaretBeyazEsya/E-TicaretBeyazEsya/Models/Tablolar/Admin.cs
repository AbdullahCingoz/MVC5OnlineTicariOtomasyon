using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_TicaretBeyazEsya.Models.Tablolar
{
    public class Admin
    {
        [Key]
        public int Admin_ID { get; set; }
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        [StringLength(maximumLength:40,ErrorMessage ="Bu alan maksimum 40 karakter olmalıdır")]
        public string Admin_KullaniciAd { get; set; }
        [Column(TypeName = "Varchar")]
        public string Admin_Sifre { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string Admin_Yetki { get; set; }
    }
}