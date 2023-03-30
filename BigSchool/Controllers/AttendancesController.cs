using BigSchool.DTOs;
using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        ApplicationDbContext db;
        public AttendancesController() { 
            db = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (db.attendances.Any(a=>a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
            {
                return BadRequest("The Attendance Đã tồn tại");
            }
            var attendance = new Attendance
            {
               
                CourseId = attendanceDto.CourseId,
                AttendeeId = User.Identity.GetUserId()
            };
            db.attendances.Add(attendance); 
            db.SaveChanges();
            return Ok();
        }
    }
}
