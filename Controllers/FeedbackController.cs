﻿using Kanini_Tourism.Models;
using Kanini_Tourism.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kanini_Tourism.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _context;

        public FeedbackController(IFeedbackRepository context)
        {
            _context = context;
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Feedback>> PostFeed(Feedback d)
        {
            _context.AddFeedback(d);
            return Ok(d);
        }

        [HttpGet]
        public ActionResult<ICollection<Feedback>> GetAll()
        {
            var res = _context.GetAllFeedback();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public ActionResult<ICollection<TravelAgent>> GetFeedbackById(int id)
        {
            var res = _context.GetFeedbackById(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public void DeleteFeed(int id)
        {
            _context.DeleteFeedback(id);
        }

        /*[HttpPut("{id}")]
        public IActionResult UpdateFeedback(int id, TravelAgent doctor)
        {
            _context.UpdateFeedback(id, doctor);
            return NoContent();
        }*/
    }
}
