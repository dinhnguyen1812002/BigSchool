using BigSchool.Models;
using BigSchool.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel { 
                Categories = _dbContext.categories.ToList()
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (CourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _dbContext.categories.ToList();  
                return View("Create",model);
            }
           var course = new Course() { 
               LectureId= User.Identity.GetUserId(),
               DateTime= model.GetDateTime(),
               CategoryID = model.Category,
               Place = model.Place,


           };
            _dbContext.courses.Add(course); 
            _dbContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }


    }
}