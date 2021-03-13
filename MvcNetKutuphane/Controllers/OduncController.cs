using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcNetKutuphane.Models.Entity;

namespace MvcNetKutuphane.Views
{
    public class OduncController : Controller
    {
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();

        // GET: Odunc
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult OduncVer() {
            List<SelectListItem>uyeCek = (from i in db.TBLUYELER.ToList()
                                          select new SelectListItem { 
                                          Text=i.AD+" "+i.SOYAD, Value=i.ID.ToString()
                                          }).ToList();
            ViewBag.uyeAdi = uyeCek;

            List<SelectListItem>kitapCek = (from i in db.TBLKITAP.ToList()
                                            
                                          select new SelectListItem {
                                              
                                          Text=i.AD, Value=i.ID.ToString()
                                          }).ToList();
            ViewBag.kitapAdi = kitapCek;

            List<SelectListItem>personelCek = (from i in db.TBLPERSONEL.ToList()
                                          select new SelectListItem { 
                                          Text=i.PERSONEL, Value=i.ID.ToString()
                                          }).ToList();
            ViewBag.personelAdi = personelCek;

            return View();
        }
        [HttpPost] 
        public ActionResult OduncVer(TBLHAREKET p)
        {
            db.TBLHAREKET.Add(p);
            db.SaveChanges();
            return RedirectToAction("/OduncVer");
        }

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

        [HttpGet]
        public ActionResult OduncAl()
        {
            List<SelectListItem> uyeCek = (from i in db.TBLUYELER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + " " + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.uyeAdi = uyeCek;

            List<SelectListItem> kitapCek = (from i in db.TBLKITAP.ToList()

                                             select new SelectListItem
                                             {

                                                 Text = i.AD,
                                                 Value = i.ID.ToString()
                                             }).ToList();
            ViewBag.kitapAdi = kitapCek;

            List<SelectListItem> personelCek = (from i in db.TBLPERSONEL.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.PERSONEL,
                                                    Value = i.ID.ToString()
                                                }).ToList();
            ViewBag.personelAdi = personelCek;

            return View();
        }
        [HttpPost]
        public ActionResult OduncAl(TBLHAREKET p)
        {
            db.TBLHAREKET.Remove(p);
            db.SaveChanges();
            return RedirectToAction("/OduncVer");
        }

    }
}