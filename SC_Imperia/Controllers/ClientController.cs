using SC_Imperia.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace SC_Imperia.Controllers
{
    public class ClientController : Controller
    {
        IMPERIA_DB db = new IMPERIA_DB();

        //Clients
        public ActionResult Index()
        {
            return View(db.Client.ToList());
        }

        //Client details
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(db.Client.Find(id));
        }


        //Client edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (db.Client.Find(id) == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sub = new SelectList(db.Type_sub, "ID", "type");
            ViewBag.Hall = new SelectList(db.Type_sports_hall, "ID", "type");
            ViewBag.Staff = new SelectList(db.Senior_staff, "ID", "lname");
            return View(db.Client.Find(id));
        }

        //Client edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,fname,phone,lname,type_subID,type_sports_hallID,senior_staffID")] Client Cl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Cl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("/");
            }
            return View(Cl);
        }

        //Client create
        public ActionResult Create()
        {
            ViewBag.Sub = new SelectList(db.Type_sub, "ID", "type");
            ViewBag.Hall = new SelectList(db.Type_sports_hall, "ID", "type");
            ViewBag.Staff = new SelectList(db.Senior_staff, "ID", "lname");
            return View();
        }

        //Client create post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,fname,phone,lname,type_subID,type_sports_hallID,senior_staffID")] Client Cl)
        {

            if (ModelState.IsValid)
            {
                db.Client.Add(Cl);
                db.SaveChanges();
                return RedirectToAction("/");
            }
            return View(Cl);
        }

        //Client delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (db.Client.Find(id) == null)
            {
                return HttpNotFound();
            }
            return View(db.Client.Find(id));
        }

        //Client delete post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client Cl = db.Client.Find(id);
            db.Client.Remove(Cl);
            db.SaveChanges();
            return RedirectToAction("/");
        }
    }
}