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
    public class FollowingsController : ApiController
    {
        ApplicationDbContext context;
        public FollowingsController()
        {
            context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if(context.followings.Any(f=> f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId)) {
                return BadRequest("Đã tồn tại");
            }
            var following = new Following { 
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            }; 
            context.followings.Add(following);
            context.SaveChanges();
            return Ok();
        }
    }
}
