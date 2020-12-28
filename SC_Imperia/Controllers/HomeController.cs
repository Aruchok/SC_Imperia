using SC_Imperia.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SC_Imperia.Controllers
{
    public class HomeController : Controller
    {
        IMPERIA_DB db = new IMPERIA_DB();

        //Senior_staff
        public ActionResult Index()
        {
            return View(db.Senior_staff.ToList());
        }

        //Senior_staff details
        [HttpGet]
        public ActionResult Details_SS(int? id)
        {
            return View(db.Senior_staff.Find(id));
        }

        //Senior_staff edit
        [HttpGet]
        public ActionResult Edit_SS(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (db.Senior_staff.Find(id) == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pos = new SelectList(db.Position, "ID", "pos");
            return View(db.Senior_staff.Find(id));
        }

        //Senior_staff edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_SS([Bind(Include = "ID,fname,lname,positionID")] Senior_staff SS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(SS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("/");
            }
            return View(SS);
        }

        //Senior_staff create
        public ActionResult Create_SS()
        {
            ViewBag.Pos = new SelectList(db.Position, "ID", "pos");
            return View();
        }

        //Senior_staff create post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_SS([Bind(Include = "ID,fname,lname,positionID")] Senior_staff SS)
        {

            if (ModelState.IsValid)
            {
                db.Senior_staff.Add(SS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(SS);
        }

        //Senior_staff delete
        public ActionResult Delete_SS(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (db.Senior_staff.Find(id) == null)
            {
                return HttpNotFound();
            }
            return View(db.Senior_staff.Find(id));
        }

        //Senior_staff delete post
        [HttpPost, ActionName("Delete_SS")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed_SS(int id)
        {
            Senior_staff SS = db.Senior_staff.Find(id);
            db.Senior_staff.Remove(SS);
            db.SaveChanges();
            return RedirectToAction("/");
        }






        //Supplier_sports_nutrition
        public ActionResult Supplier()
        {
            return View(db.Supplier_sports_nutrition.ToList());
        }

        [HttpGet]
        public ActionResult Details_SUP(int id)
        {
            return View(db.Supplier_sports_nutrition.Find(id));
        }




        //Sport equipment
        public ActionResult SE()
        {
            return View(db.Sports_equipment.ToList());
        }

        [HttpGet]
        public ActionResult Details_SE(int id)
        {
            return View(db.Sports_equipment.Find(id));
        }
    }
}