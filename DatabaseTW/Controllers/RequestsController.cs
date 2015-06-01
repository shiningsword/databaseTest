using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseTW.Models;

namespace DatabaseTW.Controllers
{
    public class RequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Requests
        public ActionResult Index()
        {
            var id = Session["userID"];
            if (id == null)
            {
                return RedirectToAction("Login", "AccountController");
            }
            Request dummyRequest = new Request();
            ViewBag.currentUser = (string)id;
            ViewBag.myRequests = false;
            //var requests = db.Requests.Where(r => r.UserId ==);
            return View(db.Requests.ToList());
        }

        // GET: Requests
        public ActionResult MyRequests()
        {
            var id = Session["userID"];
            if (id == null)
            {
                return RedirectToAction("Login", "AccountController");
            }
             ViewBag.currentUser = (string)id;
            ViewBag.myRequests = true;

            var requests = db.Requests.Where(r => r.UserId == (string)id);
            return View("Index", requests);
        }

        // GET: Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "AccountController");
            }

            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestID,Message,AmountMin,AmountMax,Currency,ExpirationDate,ExchangeMode,NeedEscrow, CloseToZipcode, CompanyDomain")] Request request)
        {
            if (ModelState.IsValid)
            {
                var userId = Session["userID"];
                if (userId == null)
                {
                    return RedirectToAction("Login", "AccountController");
                }
                request.UserId = (string)userId;
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilterResult([Bind(Include = "Currency, AmountMin,AmountMax, CloseToZipcode, CompanyDomain")] Request request)
        {
            if (ModelState.IsValid)
            {
                var userId = Session["userID"];
                if (userId == null)
                {
                    return RedirectToAction("Login", "AccountController");
                }
                var result = db.Requests.Where(r => 
                    r.Currency == request.Currency &&
                    !(r.AmountMax < request.AmountMin || r.AmountMin > request.AmountMax));
                
                ViewBag.myRequests = false;
                ViewBag.currentUser = (string)userId;
                return View("Index", result);
            }

            return View(request);
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", request.UserId);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestID,Message,AmountMin,AmountMax,Currency, ExpirationDate,ExchangeMode,NeedEscrow,UserId")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", request.UserId);
            return View(request);
        }

        // GET: Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: Requests/Delete/5
        public ActionResult Close(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Create","Transactions", request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
