using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RandevuSistemi.Models.Sinif
{
    public class RaporDurum
    {
        [Key]
        public int RaporDurumId { get; set; }
        public string RaporDurumu { get; set; }
        public ICollection<Rapor> Rapors { get; set; }

    }
}