using SC_Imperia.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SC_Imperia.Controllers
{
    public class SupplierController : Controller
    {
        IMPERIA_DB db = new IMPERIA_DB();

        //Supplier
        public ActionResult Index()
        {
            return View(db.Supplier_sports_nutrition.ToList());
        }

        //Supplier details
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(db.Supplier_sports_nutrition.Find(id));
        }

        //Supplier edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (db.Supplier_sports_nutrition.Find(id) == null)
            {
                return HttpNotFound();
            }
            ViewBag.Staff = new SelectList(db.Senior_staff, "ID", "lname");
            return View(db.Supplier_sports_nutrition.Find(id));
        }

        //Supplier edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,quantity,phone,price,model,senior_staffID")] Supplier_sports_nutrition Sup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Sup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("/");
            }
            return View(Sup);
        }

        //Supplier create
        public ActionResult Create()
        {
            ViewBag.Staff = new SelectList(db.Senior_staff, "ID", "lname");
            return View();
        }

        //Supplier create post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,quantity,phone,price,model,senior_staffID")] Supplier_sports_nutrition Sup)
        {

            if (ModelState.IsValid)
            {
                db.Supplier_sports_nutrition.Add(Sup);
                db.SaveChanges();
                return RedirectToAction("/");
            }
            return View(Sup);
        }

        //Supplier delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (db.Supplier_sports_nutrition.Find(id) == null)
            {
                return HttpNotFound();
            }
            return View(db.Supplier_sports_nutrition.Find(id));
        }

        //Supplier delete post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier_sports_nutrition Sup = db.Supplier_sports_nutrition.Find(id);
            db.Supplier_sports_nutrition.Remove(Sup);
            db.SaveChanges();
            return RedirectToAction("/");
        }
    }
}