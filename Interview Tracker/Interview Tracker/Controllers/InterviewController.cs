using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interview_Tracker.Controllers
{
    public class InterviewController : Controller
    {
        private InterviewTrackerEntities db = new InterviewTrackerEntities();

        //
        // GET: /Interview/

        public ActionResult Index()
        {
            var interviews = db.Interviews.Include(i => i.Candidate).Include(i => i.Job);
            return View(interviews.ToList());
        }

        //
        // GET: /Interview/Details/5

        public ActionResult Details(int id = 0)
        {
            Interview interview = db.Interviews.Find(id);
            if (interview == null)
            {
                return HttpNotFound();
            }
            return View(interview);
        }

        //
        // GET: /Interview/Create

        public ActionResult Create()
        {
            ViewBag.CandidateId = new SelectList(db.Candidates, "CandidateId", "FirstName");
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "PositionTitle");
            return View();
        }

        //
        // POST: /Interview/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Interview interview)
        {
            if (ModelState.IsValid)
            {
                db.Interviews.Add(interview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CandidateId = new SelectList(db.Candidates, "CandidateId", "FirstName", interview.CandidateId);
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "PositionTitle", interview.JobId);
            return View(interview);
        }

        //
        // GET: /Interview/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Interview interview = db.Interviews.Find(id);
            if (interview == null)
            {
                return HttpNotFound();
            }
            ViewBag.CandidateId = new SelectList(db.Candidates, "CandidateId", "FirstName", interview.CandidateId);
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "PositionTitle", interview.JobId);
            return View(interview);
        }

        //
        // POST: /Interview/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Interview interview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CandidateId = new SelectList(db.Candidates, "CandidateId", "FirstName", interview.CandidateId);
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "PositionTitle", interview.JobId);
            return View(interview);
        }

        //
        // GET: /Interview/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Interview interview = db.Interviews.Find(id);
            if (interview == null)
            {
                return HttpNotFound();
            }
            return View(interview);
        }

        //
        // POST: /Interview/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Interview interview = db.Interviews.Find(id);
            db.Interviews.Remove(interview);
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