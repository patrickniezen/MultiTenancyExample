using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MultiTenancyExample.Web.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace MultiTenancyExample.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly BloggingContext _context;

        public PostsController(BloggingContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _context.Posts.ToList();
        }
    }
}
