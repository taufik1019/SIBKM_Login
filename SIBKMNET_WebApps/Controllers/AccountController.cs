using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIBKMNET_WebApps.Repositories.Data;
using SIBKMNET_WebApps.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebApps.Controllers
{
    public class AccountController : Controller
    {
        AccountRepository accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login login)
        {
            // statement mengambil data dari database sesuai dengan email dan password
            var data = accountRepository.Login(login);
            if (data != null)
            {
                HttpContext.Session.SetString("Role", data.Role);
                return RedirectToAction("Index", "Province");
            }
            return View();
            // return -> Id Employee, FullName, Email, Role -> Viewmodels
            // inisialisasi nilai padaa session

        }
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(Register register)
        {
            var data = accountRepository.Register(register);
            if (data > 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public IActionResult Forgot()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Forgot(Forgot forgot)
        {
            if (ModelState.IsValid)
            {
                //statement mengambil data dari database sesuai dengan email dan password
                //return Id employee, FullName, Email, Role -> Masukkan ke ViewModels
                var data = accountRepository.Forgot(forgot);

                if (data != null)
                {
                    //inisialisasi nilai pada session
                    HttpContext.Session.SetString("Role", data.Role);
                    return RedirectToAction("Index", "Province");
                }
                return RedirectToAction("Unautorized", "ErrorPage");
            }
            return View();
        }

        public IActionResult ChangePass()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePass(int id, ChangePass changePass)
        {
            var data = accountRepository.ChangePass(id, changePass);
                if (data > 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}
