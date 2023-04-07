using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVC_CodefirstStoreProcedure.Migrations;//using MVC_CodefirstStoreProcedure.Migrations; Projedeki migration kalsörünü ekledik

namespace MVC_CodefirstStoreProcedure.Models
{
    public class DatabaseContext:DbContext
    {

        public DatabaseContext()
        {
            //Database.SetInitializer(new DbIntializer()); Burada kendi seed ini çağırıyor biz buna bizimkinin yolunu verdik. 

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext,Configuration>());


        }
        public DbSet<Kitap> Kitaplar { get; set; }

        public void KitapEkle()
        {
            Database.ExecuteSqlCommand("EXEC InsertData");
        }
        public List<TariheGoreKitaplar_class> TariheGoreKitaplar(int yil1, int yil2)
        {
           return Database.SqlQuery<TariheGoreKitaplar_class>("EXEC TariheGoreKitaplar @p0, @p1", yil1,yil2).ToList();
        }
        public List<KitapBilgi> KitapBilgiGetir()
        {
            return Database.SqlQuery<KitapBilgi>("Select  * From KitapBilgiGetir").ToList();
        }

        //Database oluşurken Stored Procedure da oluşturuyor.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kitap>().MapToStoredProcedures(x=> 
            {
                x.Insert(i=>
                        i.HasName("KitapEkle"));
                x.Update(u =>
                        { u.HasName("KitapGuncelle"); u.Parameter(p =>p.ID,"KitapID"); });
                x.Delete(d => 
                        {d.HasName("KitapSil"); d.Parameter(p => p.ID,"KitapID"); });
             });
        }

    }

    public class DbIntializer:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            context.Database.ExecuteSqlCommand
                (" create Proc InsertData as begin " +
                "insert into Kitap values('Şeker Portakalı', 'ŞekerPortakalı', 2020) " +
                "insert into Kitap values('Yüzyıllık yalnızlık', 'Yüzyıllık yalnızlık', 2022) end ");
            //Herhangi bir sql sorgusu yazılabilir

            context.Database.ExecuteSqlCommand("create proc TariheGoreKitaplar (@p0 int, @p1 int) AS BEGIN SELECT YayinTarihi,COUNT(YayinTarihi)Adet FROM Kitap where year (YayinTarihi) between @p0 and @p1 group by YayinTarihi END ");

            context.Database.ExecuteSqlCommand("create view KitapBilgiGetir as select Adı 'KitapAdı',YayinTarihi from Kitap");

            //"select * from kitap where id = @id1 and id = @id2", new SqlParameter("")
        }
    }


    }