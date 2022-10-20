using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RandevuSistemi.Models.Sinif
{
    public class Ilac
    {
        [Key]
        public int IlacId { get; set; }
        public int PartiNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]

        public String IlacAd { get; set; }
        public bool Durum { get; set; }
        public String IlacKT { get; set; }

        public String IlacKUB { get; set; }
        public DateTime SonKullanmaTarih { get; set; }
        public short Stok { get; set; }
        public string RuhsatNo { get; set; }
        public ICollection<Muane> Muanes { get; set; }
        public ICollection<Recete> Recetes { get; set; }
    }
}