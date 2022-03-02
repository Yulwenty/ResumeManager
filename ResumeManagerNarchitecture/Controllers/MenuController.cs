using Framework.Service;
using FrameworkCore.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeManagerNarchitecture.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuListService _menuListService;
        public MenuController()
        {
            _menuListService = ObjServiceExtension.CreateInstanceMenuListService();
        }
        // GET: Menu
        public ActionResult Index()
        {
           var coll = _menuListService.getMenus();
            return View("Menu",coll);
        }
    }
}