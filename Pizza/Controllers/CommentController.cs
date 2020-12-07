using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pizza.Database.Managers;
using Pizza.Models;

namespace Pizza.Controllers
{
    public class CommentController : Controller
    {
        private IPizzaManager _pizzaManager;
        private ICommentManager _commentManager;
        private IHttpContextAccessor _httpContextAccessor;
        private UserManager<IdentityUser> _userManager;

        public CommentController(ICommentManager commentManager, IPizzaManager pizzaManager, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _pizzaManager = pizzaManager;
            _commentManager = commentManager;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromBody] Req req)
        {
            var id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var comment = new Comment
            {
                PublishDate = DateTime.Now,
                User = await _userManager.FindByIdAsync(id),
                Data = req.Data,
                Pizza = _pizzaManager.GetPizza(req.PizzaId)

            };
            await _commentManager.CreateComment(comment);
            return Ok(comment.Id);
        }
        public class Req
        {
            public int PizzaId { get; set; }
            public string Data { get; set; }
        }

    }
}
