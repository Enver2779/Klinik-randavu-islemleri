using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RandevuSistemi.Models.Sinif
{
    public class Doktor
    {
        [Key]
        public int DoktorId { get; set; }

        public long DoktorTC { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public String DoktorAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public String DoktorSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public String DoktorFoto { get; set; }
        public long DoktorTelefon { get; set; }
        public DateTime DoktorDogumT { get; set; }
        public bool DoktorStatus { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int DepartmanId { get; set; }
        public virtual Departman Departmen { get; set; }
        public ICollection<Muane> Muanes { get; set; }
        public ICollection<Randevu> Randevus { get; set; }
        public ICollection<Recete> Recetes { get; set; }
        public ICollection<Rapor> Rapors { get; set; }
    }
}