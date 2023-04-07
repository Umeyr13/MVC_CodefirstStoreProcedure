using MVC_CodefirstStoreProcedure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CodefirstStoreProcedure.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
         DatabaseContext db = new DatabaseContext();

            db.Kitaplar.ToList();

            Kitap kitap = new Kitap();
            kitap.Adı = "Varmısın?";
            kitap.Aciklama = "HomeControllerden gelen Açıklama";
            kitap.YayinTarihi = DateTime.Now.Date;
            db.Kitaplar.Add(kitap);
            db.SaveChanges();            
           // List<TariheGoreKitaplar_class> model =db.TariheGoreKitaplar(1900,2025);
            List<KitapBilgi> model = db.KitapBilgiGetir();
            
            db.KitapEkle();
            
            
            return View(model);
        }
    }
}