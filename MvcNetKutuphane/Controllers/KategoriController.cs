using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcNetKutuphane.Models.Entity;

namespace MvcNetKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public ActionResult Index()
        {
            //degerler degıskenı tbl kategoriyi listesine eşitlenir
            var degerler = db.TBLKATEGORI.ToList(); 
            return View(degerler);
        }


        //KATEGORİ EKLE 
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORI p)
        {
            db.TBLKATEGORI.Add(p);
            db.SaveChanges();    
            return View();
        }

        //KATEGORİ SİL 
        public ActionResult KategoriSil(int id) {

            var kategori = db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //KATEGORİ GÜNCELLE
        public ActionResult KategoriGetir(int id) {
            var ktg = db.TBLKATEGORI.Find(id);
            return View("KategoriGetir", ktg); //kategorigetir sayfasını ktg ile gelen vereilere göre getir
        }

        public ActionResult KategoriGuncelle(TBLKATEGORI p) {
            var ktg = db.TBLKATEGORI.Find(p.ID);
            ktg.ADI = p.ADI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}