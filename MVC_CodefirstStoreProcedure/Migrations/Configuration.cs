namespace MVC_CodefirstStoreProcedure.Migrations
{
    using MVC_CodefirstStoreProcedure.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_CodefirstStoreProcedure.Models.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;//false du true yaptık;
            ContextKey = "MVC_CodefirstStoreProcedure.Models.DatabaseContext";
            AutomaticMigrationDataLossAllowed = true;//her türlü data kaybını kabul ediyorum sen yine de migrate et demek.
        }

        protected override void Seed(MVC_CodefirstStoreProcedure.Models.DatabaseContext context)
        {
            //migration da bu metot tetiklenir

            for (int i = 0; i < 10; i++)
            { //context.Kitaplar.Add(new Kitap() Add olursa sayfayı her yenilemede yeni kayıt atar.
                context.Kitaplar.AddOrUpdate(new Kitap()
                {
                    ID = i
                   ,Adı = FakeData.NameData.GetCompanyName()
                   ,Aciklama = FakeData.TextData.GetSentences(1)
                   ,YayinTarihi = FakeData.DateTimeData.GetDatetime()

                });
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
