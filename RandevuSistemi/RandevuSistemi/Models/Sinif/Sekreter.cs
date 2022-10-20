using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RandevuSistemi.Models.Sinif
{
    public class Sekreter
    {
        [Key]
        public int SekreterID { get; set; }


        [Display(Name = "Sekreter Adı")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Sekreter adını boş geçemezsiniz!")]
        [StringLength(30, ErrorMessage = "Sekreter adı en fazla 30 karakter girilebilir!")]
        public string SekreterAdi { get; set; }


        [Display(Name = "Sekreter Soyadı")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Sekreter soyadını boş geçemezsiniz!")]
        [StringLength(30, ErrorMessage = "Sekreter soyadı en fazla 30 karakter girilebilir!")]
        public string SekreterSoyadi { get; set; }

        [Display(Name = "Sekreter Maili")]
        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "Sekreter maili en fazla 50 karakter girilebilir!")]
        public string SekreterMaili { get; set; }


        [Display(Name = "Sekreter Şifresi")]
        [Column(TypeName = "Varchar")]
        [StringLength(20, ErrorMessage = "Sekreter şifresi en fazla 20 karakter girilebilir!")]
        public string SekreterSifresi { get; set; }
    }
}