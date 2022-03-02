using FrameworkCore.Model;
using Framework.Service;
using FrameworkCore.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;


namespace ResumeManagerNarchitecture.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly IApplicantService _applicantService;
        private readonly IAppAutoNumberLastService _appAutoNumberLastService;

        public ApplicantController()
        {
            //test git
            _applicantService = ObjServiceExtension.CreateInstanceApplicantService();
            _appAutoNumberLastService = ObjServiceExtension.CreateInstanceAppAutoNumberLastService();
        }
        // GET: Applicant
        public ActionResult Index()
        {
            if (WebGlobalMembers.CurrentLoginUserName == string.Empty) return RedirectToAction("index","login" );

            var applicantColl = _applicantService.GetApplicants();

            return View(applicantColl);
        }

        public ActionResult Create()
        {
            Applicant app = new Applicant();
            app.Experiences = new List<Experience>();
            return View(app);
        }

        [HttpPost]
        public ActionResult Create(Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                var primKey = _appAutoNumberLastService.GenerateAutoNumber("ApplicantNo");

                if (!string.IsNullOrEmpty(primKey))
                {
                    applicant.Id = primKey;

                    //generate primKey grid experiences
                    _applicantService.GenerateIdforExperiences(applicant);

                    //save applicant
                    _applicantService.InsertApplicant(applicant);
                    TempData["UserMessage"] = new Message() { CssClassName = "alert-success", Title = "Success!", DisplayMessage = "Data Saved" };
                   //  return RedirectToAction("Index");
             
                }
            }
            return View();
        }
        public ActionResult ExperienceEntryRow()
        {
            return PartialView("ExperienceEditor");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var app = _applicantService.GetApplicantById(id);

            return View(app);
        }

        [HttpPost]
        public ActionResult Edit( [Bind(Exclude ="TotalExperience")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                _applicantService.UpdateApplicant(applicant);
                TempData["UserMessage"] = new Message() { CssClassName = "alert-success", Title = "Success!", DisplayMessage = "Data Saved" };
                //return RedirectToAction("Index");
            }
            return View(applicant);// viewnya hrs diisi entity krn entity sebelumnya sudah didispose jd bisa error saat loop experience
        }

        //protected override void Dispose(bool disposing)
        //{
        //    _applicantService.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}