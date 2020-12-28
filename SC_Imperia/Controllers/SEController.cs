using SC_Imperia.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SC_Imperia.Controllers
{
    public class SEController : Controller
    {
        IMPERIA_DB db = new IMPERIA_DB();

        // GET: SE
        public ActionResult Index()
        {
            return View(db.Sports_equipment.ToList());
        }

        //SE details
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(db.Sports_equipment.Find(id));
        }


        //SE edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (db.Sports_equipment.Find(id) == null)
            {
                return HttpNotFound();
            }
            ViewBag.Staff = new SelectList(db.Senior_staff, "ID", "lname");
            return View(db.Sports_equipment.Find(id));
        }

        //SE edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,quantity,title,senior_staffID")] Sports_equipment SE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(SE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("/");
            }
            return View(SE);
        }

        //SE create
        public ActionResult Create()
        {
            ViewBag.Staff = new SelectList(db.Senior_staff, "ID", "lname");
            return View();
        }

        //Supplier create post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,quantity,title,senior_staffID")] Sports_equipment SE)
        {

            if (ModelState.IsValid)
            {
                db.Sports_equipment.Add(SE);
                db.SaveChanges();
                return RedirectToAction("/");
            }
            return View(SE);
        }

        //SE delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (db.Sports_equipment.Find(id) == null)
            {
                return HttpNotFound();
            }
            return View(db.Sports_equipment.Find(id));
        }

        //SE delete post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sports_equipment SE = db.Sports_equipment.Find(id);
            db.Sports_equipment.Remove(SE);
            db.SaveChanges();
            return RedirectToAction("/");
        }

    }
}