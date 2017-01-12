using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MultiTenancyExample.Web.Data;
using System.Linq;

namespace MultiTenancyExample.Web.Controllers
{
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
