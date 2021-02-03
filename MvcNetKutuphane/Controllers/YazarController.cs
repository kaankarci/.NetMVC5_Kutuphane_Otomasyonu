using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcNetKutuphane.Models.Entity;


namespace MvcNetKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public ActionResult Index()
        {
            var yzr = db.TBLYAZAR.ToList();

            return View(yzr);
        }
        [HttpGet]
        public ActionResult YazarEkle() {

            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TBLYAZAR p) {

            db.TBLYAZAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarSil(int id) {

            var silinen=db.TBLYAZAR.Find(id);
            db.TBLYAZAR.Remove(silinen);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yzr = db.TBLYAZAR.Find(id);
            return View("YazarGetir", yzr);
        }

        public ActionResult YazarGuncelle(TBLYAZAR p) {
            var yzr = db.TBLYAZAR.Find(p.ID);
            yzr.ID = yzr.ID;
            yzr.AD = p.AD;
            yzr.SOYAD = p.SOYAD;
            yzr.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}