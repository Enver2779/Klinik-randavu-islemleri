using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RandevuSistemi.Models.Sinif
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Departman> Departmen { get; set; }
        public DbSet<Doktor> Doktors { get; set; }
        public DbSet<Hasta> Hastas { get; set; }
        public DbSet<Ilac> Ilacs { get; set; }
        public DbSet<Mesaj> Mesajs { get; set; }
        public DbSet<Muane> Muanes { get; set; }
        public DbSet<Randevu> Randevus { get; set; }
        public DbSet<Recete> Recetes { get; set; }
        public DbSet<Sekreter> Sekreters { get; set; }
        public DbSet<Rapor> Rapors { get; set; }
        public DbSet<RaporDurum> RaporDurums { get; set; }

    }
}