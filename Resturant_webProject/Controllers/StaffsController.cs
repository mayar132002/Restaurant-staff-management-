using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Resturant_webProject.Models;

namespace Resturant_webProject.Controllers
{
    
    public class StaffsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Staffs
        public ActionResult Index()
        {
            return View(db.Staffs.ToList());
        }
        public ActionResult Login2([Bind(Include = "C_Email,C_Password")] Staff staff)
        {
            var r = db.Staffs.Where(x => x.C_Email == staff.C_Email && x.C_Password == staff.C_Password).ToList().FirstOrDefault();
            if (r != null)
            {
                return RedirectToAction("Index");

            }
            else
            {
                return View(staff);
            }
        }


        // GET: Staffs/Create
        [HttpGet]
        [OverrideAuthentication]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Staffs.Add(staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(staff);
        }

        // GET: Staffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staff);
        }
        public ActionResult Delete(int id)
        {
            var staff = db.Staffs.Where(x => x.C_ID == id).FirstOrDefault();
            db.Staffs.Remove(staff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
