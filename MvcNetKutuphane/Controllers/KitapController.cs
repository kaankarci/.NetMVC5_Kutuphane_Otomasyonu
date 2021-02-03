using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcNetKutuphane.Models.Entity;

namespace MvcNetKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public ActionResult Index()
        {
            var kitaplar = db.TBLKITAP.ToList();

            return View(kitaplar);
        }
        [HttpGet]
        public ActionResult KitapEkle() {
            List<SelectListItem> ktgrcek = (from i in db.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ADI,
                                               Value = i.ID.ToString()
                                           }).ToList();

            List<SelectListItem> yzrcek = (from i in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + " " + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();


            ViewBag.yzrlist = yzrcek;
            ViewBag.ktgrlist = ktgrcek;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP p) {

            var ktg = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            var yzr = db.TBLYAZAR.Where(k => k.ID == p.TBLYAZAR.ID).FirstOrDefault();
            p.TBLKATEGORI = ktg;
            p.TBLYAZAR = yzr;
            db.TBLKITAP.Add(p);
            db.SaveChanges();
            

            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id) {
            var kitap = db.TBLKITAP.Find(id);
            db.TBLKITAP.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}