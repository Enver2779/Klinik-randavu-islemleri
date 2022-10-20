namespace RandevuSistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rapors",
                c => new
                    {
                        RaporId = c.Int(nullable: false, identity: true),
                        TesisKodu = c.Int(nullable: false),
                        TesisAdı = c.String(),
                        BelgeDüzenlemeTarih = c.DateTime(nullable: false),
                        AyaktaBaslama = c.DateTime(nullable: false),
                        AyaktaBitiş = c.DateTime(nullable: false),
                        HastaneYatıs = c.DateTime(nullable: false),
                        HastaneCıkıs = c.DateTime(nullable: false),
                        DoktorId = c.Int(nullable: false),
                        HastaId = c.Int(nullable: false),
                        RaporDurumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RaporId)
                .ForeignKey("dbo.Doktors", t => t.DoktorId, cascadeDelete: true)
                .ForeignKey("dbo.Hastas", t => t.HastaId, cascadeDelete: true)
                .ForeignKey("dbo.RaporDurums", t => t.RaporDurumId, cascadeDelete: true)
                .Index(t => t.DoktorId)
                .Index(t => t.HastaId)
                .Index(t => t.RaporDurumId);
            
            CreateTable(
                "dbo.RaporDurums",
                c => new
                    {
                        RaporDurumId = c.Int(nullable: false, identity: true),
                        RaporDurumu = c.String(),
                    })
                .PrimaryKey(t => t.RaporDurumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rapors", "RaporDurumId", "dbo.RaporDurums");
            DropForeignKey("dbo.Rapors", "HastaId", "dbo.Hastas");
            DropForeignKey("dbo.Rapors", "DoktorId", "dbo.Doktors");
            DropIndex("dbo.Rapors", new[] { "RaporDurumId" });
            DropIndex("dbo.Rapors", new[] { "HastaId" });
            DropIndex("dbo.Rapors", new[] { "DoktorId" });
            DropTable("dbo.RaporDurums");
            DropTable("dbo.Rapors");
        }
    }
}
