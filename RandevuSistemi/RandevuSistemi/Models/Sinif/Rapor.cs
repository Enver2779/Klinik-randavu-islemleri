using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RandevuSistemi.Models.Sinif
{
    public class Rapor
    {
        [Key]
        public int RaporId { get; set; }
        public int TesisKodu { get; set; }
        public string TesisAdı { get; set; }
        public DateTime BelgeDüzenlemeTarih { get; set; }
        public DateTime AyaktaBaslama { get; set; }
        public DateTime AyaktaBitiş { get; set; }   
        public DateTime HastaneYatıs { get; set; }
        public DateTime HastaneCıkıs { get; set; }
        public int DoktorId { get; set; }
        public virtual Doktor Doktor { get; set; }
        public int HastaId { get; set; }
        public virtual Hasta Hasta { get; set; } 
        public int RaporDurumId { get; set; }
        public virtual RaporDurum RaporDurum  { get; set; }
    }
}