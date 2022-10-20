using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RandevuSistemi.Models.Sinif
{
    public class Hasta
    {
        [Key]
        public int HastaId { get; set; }

        public long HastaTc { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string HastaName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string HastaSurName { get; set; }

        public long HastaTelefon { get; set; }
        public DateTime HastaDogumT { get; set; }
        public bool HastaStatus { get; set; }
        public string KanGb { get; set; }
        public string Aciklama { get; set; }
        public ICollection<Muane> Muanes { get; set; }
        public ICollection<Randevu> Randevus { get; set; }
        public ICollection<Recete> Recetes { get; set; }
        public ICollection<Rapor> Rapors { get; set; }

    }
}