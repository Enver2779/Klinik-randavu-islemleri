using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace RandevuSistemi.Models.Sinif
{
    public class Muane
    {
        [Key]
        public int MuaneId { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
        public int IlacId { get; set; }
        public virtual Ilac Ilac { get; set; }
        public int HastaId { get; set; }
        public virtual Hasta Hasta { get; set; }
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }
    }
}