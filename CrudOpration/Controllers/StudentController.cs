using CrudOpration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOpration.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentHandle obj = new StudentHandle();
            ModelState.Clear();
            return View(obj.GetStudent());
        }

        // GET: Student/Details/5
        public ActionResult Edit(int id)
        {
            StudentHandle obj = new StudentHandle();
            return View(obj.GetStudent().Find(e => e.StdId == id));
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student st)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StudentHandle obj = new StudentHandle();
                    if (obj.AddStudent(st))
                    {
                        ViewBag.Message = "Student Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

     

      
        // POST: Student/Edit/5
     
     


        [HttpPost]
        public ActionResult Edit(int id, Student std)
        {
            try
            {
                StudentHandle sdb = new StudentHandle();
                sdb.UpdateDetails(std,id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                StudentHandle obj = new StudentHandle();
                if (obj.DeleteStudent(id))
                {
                    ViewBag.AlertMsg = "Student Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
