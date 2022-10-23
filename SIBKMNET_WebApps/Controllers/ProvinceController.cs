using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIBKMNET_WebApps.Context;
using SIBKMNET_WebApps.Models;
using SIBKMNET_WebApps.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebApps.Controllers
{
    public class ProvinceController : Controller
    {
        ProvinceRepository ProvinceRepository;

        public ProvinceController(ProvinceRepository ProvinceRepository)
        {
            this.ProvinceRepository = ProvinceRepository;
        }

        // GET ALL
        // GET
        public IActionResult Index()
        {
            string role = HttpContext.Session.GetString("Role");
               if(role.Equals("Admin"))
            {
                var data = ProvinceRepository.Get();
                return View(data);
            }
            return RedirectToAction("Unautorized", "ErrorPage");
        }

        // GET BY ID
        //GET
        public IActionResult Details(int id)
        {
            var data = ProvinceRepository.Get(id);
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
        public IActionResult Create(Province province)
        {
            if (ModelState.IsValid)
            {

                var result = ProvinceRepository.Post(province);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        // UPDATE
        // GET
        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            return View();
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Province province)
        {
            if (ModelState.IsValid)
            {
                var result = ProvinceRepository.Put(id, province);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }


        // DELETE
        // GET
        public ActionResult Delete(int id)
        {
            var data = ProvinceRepository.Get(id);
            return View(data);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Province province)
        {
            var result = ProvinceRepository.Delete(province);
            if (result > 0)
                return RedirectToAction("Index");
            return View();
        }

    }
}
