using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIBKMNET_WebApps.Context;
using SIBKMNET_WebApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebApps.Controllers
{
    public class CountryController : Controller
    {
        MyContext myContext;

        public CountryController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        // GET ALL
        // GET
        public IActionResult Index()
        {
            var data = myContext.Countries.Include(x => x.Area).ToList();
            return View(data);
        }

        // GET BY ID
        //GET
        public IActionResult Details(int id)
        {
            var data = myContext.Countries.Include(x => x.Area).FirstOrDefault(x => x.Id.Equals(id));
            return View(data);
        }

        // CREATE 
        // GET
        public IActionResult Create()
        {
            return View();
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                myContext.Countries.Add(country);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        // Update
        // Get
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = myContext.Countries.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        // POST
        [HttpPost]
        public ActionResult Edit(Country Model)
        {
            var data = myContext.Countries.Where(x => x.Id == Model.Id).FirstOrDefault();
            if (data != null)
            {
                data.Id = Model.Id;
                data.Name = Model.Name;
                data.AreaId = Model.AreaId;

                myContext.SaveChanges();
            }

            return RedirectToAction("index");
        }

        // Delete
        public ActionResult Delete(int id)
        {
            var data = myContext.Countries.Where(x => x.Id == id).FirstOrDefault();
            myContext.Countries.Remove(data);
            myContext.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }
    }
}
