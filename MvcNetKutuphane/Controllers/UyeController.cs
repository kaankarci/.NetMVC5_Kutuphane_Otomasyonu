﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcNetKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcNetKutuphane.Controllers
{
    public class UyeController : Controller
    {
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        // GET: Uye
        public ActionResult Index(int sayfa = 1)
        {

            //var degerler = db.TBLUYELER.ToList();
            var degerler = db.TBLUYELER.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
           
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TBLUYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TBLUYELER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UyeSil(int id)
        {

            var uye = db.TBLUYELER.Find(id);
            db.TBLUYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeGetir(int id)
        {
            var prs = db.TBLUYELER.Find(id);
            return View("UyeGetir", prs);
        }
        public ActionResult UyeGuncelle(TBLUYELER p)
        {

            var uye = db.TBLUYELER.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAIL = p.MAIL;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.SIFRE = p.SIFRE;
            uye.OKUL = p.OKUL;
            uye.TELEFON = p.TELEFON;
            uye.FOTOGRAF = p.FOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}