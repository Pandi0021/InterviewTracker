using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interview_Tracker.Controllers
{
    public class CandidateController : Controller
    {
        private InterviewTrackerEntities db = new InterviewTrackerEntities();

        //
        // GET: /Candidate/

        public ActionResult Index()
        {
            return View(db.Candidates.ToList());
        }

        //
        // GET: /Candidate/Details/5

        public ActionResult Details(int id = 0)
        {
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        //
        // GET: /Candidate/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Candidate/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Candidates.Add(candidate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candidate);
        }

        //
        // GET: /Candidate/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        //
        // POST: /Candidate/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidate);
        }

        //
        // GET: /Candidate/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        //
        // POST: /Candidate/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidate candidate = db.Candidates.Find(id);
            db.Candidates.Remove(candidate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}