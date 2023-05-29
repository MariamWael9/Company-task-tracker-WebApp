using CompanyWebApp.Data;
using CompanyWebApp.Data.Services;
using CompanyWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApp.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService _service;
        private readonly IHttpContextAccessor contextAccessor;
        public CommentsController(ICommentService service, IHttpContextAccessor contextAccessor)
        {
            _service = service;
            this.contextAccessor = contextAccessor;
        }
        public IActionResult AddComment()
        {
            comment newComment = new comment();
            return View(newComment);
        }
        [HttpPost]
        public IActionResult AddComment(comment newComment)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("ViewTask", "Tasks", newComment.Task_Id);
            }

            _service.Add(newComment);
            return RedirectToAction("ViewTask", "Tasks", new { taskId = newComment.Task_Id });
        }
    }
}
