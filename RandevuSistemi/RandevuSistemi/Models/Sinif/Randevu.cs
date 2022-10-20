using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace RandevuSistemi.Models.Sinif
{
    public class Randevu
    {
        [Key]
        public int RandevuId { get; set; }
        public DateTime BaslangicZaman { get; set; }
        public DateTime BitisZaman { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Aciklama { get; set; }
        public int DoktorId { get; set; }
        public virtual Doktor Doktor { get; set; }
        public int HastaId { get; set; }
        public virtual Hasta Hasta { get; set; }
    }
}