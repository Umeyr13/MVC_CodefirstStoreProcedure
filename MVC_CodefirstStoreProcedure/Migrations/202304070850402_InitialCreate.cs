namespace MVC_CodefirstStoreProcedure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kitap",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adı = c.String(nullable: false, maxLength: 50),
                        Aciklama = c.String(),
                        YayinTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateStoredProcedure(
                "dbo.KitapEkle",
                p => new
                    {
                        Adı = p.String(maxLength: 50),
                        Aciklama = p.String(),
                        YayinTarihi = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[Kitap]([Adı], [Aciklama], [YayinTarihi])
                      VALUES (@Adı, @Aciklama, @YayinTarihi)
                      
                      DECLARE @ID int
                      SELECT @ID = [ID]
                      FROM [dbo].[Kitap]
                      WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()
                      
                      SELECT t0.[ID]
                      FROM [dbo].[Kitap] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            );
            
            CreateStoredProcedure(
                "dbo.KitapGuncelle",
                p => new
                    {
                        KitapID = p.Int(),
                        Adı = p.String(maxLength: 50),
                        Aciklama = p.String(),
                        YayinTarihi = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[Kitap]
                      SET [Adı] = @Adı, [Aciklama] = @Aciklama, [YayinTarihi] = @YayinTarihi
                      WHERE ([ID] = @KitapID)"
            );
            
            CreateStoredProcedure(
                "dbo.KitapSil",
                p => new
                    {
                        KitapID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Kitap]
                      WHERE ([ID] = @KitapID)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.KitapSil");
            DropStoredProcedure("dbo.KitapGuncelle");
            DropStoredProcedure("dbo.KitapEkle");
            DropTable("dbo.Kitap");
        }
    }
}
