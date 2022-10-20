using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace RandevuSistemi.Models.Sinif
{
    public class Departman
    {
        [Key]
        public int DepartmanId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string DepartmanAd { get; set; }

        public ICollection<Doktor> Doktor { get; set; }
    }
}