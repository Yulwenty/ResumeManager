using Framework.Service;
using FrameworkCore.Interface.Service;
using FrameworkCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeManagerNarchitecture.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController()
        {
            _userService = ObjServiceExtension.CreateInstanceUserService();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            if(ModelState.IsValid)
            {
              var userLogin =  _userService.TryLogin(user);
                if(userLogin != null)
                {
                    WebGlobalMembers.CurrentLoginUserName = userLogin.UserName;
                    return RedirectToAction("index", "Applicant");
                }
                else
                {
                    //data not found
                    ViewBag.Error = "Data not found";
                    ModelState.AddModelError("", "Data not found");
            
                }
               
              
            }
            return View();
        }

 

        //Logout
        public ActionResult Logout()
        {
            WebGlobalMembers.CurrentSession.Clear();
          //  Session.Clear();//remove session
            return RedirectToAction("Index");
        }

    }
}