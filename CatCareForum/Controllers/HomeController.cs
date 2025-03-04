using System.Diagnostics;
using CatCareForum.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatCareForum.Models;


namespace CatCareForum.Controllers
{
    public class HomeController : Controller
    {

        private readonly CatCareForumContext _context;

        //Constructor
        public HomeController(CatCareForumContext context)
        {
            _context = context;
        }

        //Home page
        public async Task<IActionResult> Index()
        {
            var discussions = await _context.Discussion.OrderByDescending(m => m.CreateDate).Include(d => d.Comments).ToListAsync();
            return View(discussions);
        }

        //Discussion details? .../Home/Discussion/Details/{id} for larger image
        public async Task<IActionResult> DiscussionDetails(int id)
        {
            var discussions = await _context.Discussion
                .Include(d => d.Comments)
                .FirstOrDefaultAsync(m => m.DiscussionId == id);

            if (discussions == null)
            {
                return NotFound();
            }

            return View(discussions);
        }

        //GetDiscussion (By ID) .../Home/Discussion/{id} with comments etc (I'm not sure if you wanted two different views for this instead of just one)
        public async Task<IActionResult> GetDiscussion(int id)
        {
            var discussion = await _context.Discussion
                .Include(d => d.Comments)
                .FirstOrDefaultAsync(m => m.DiscussionId == id);

            if (discussion == null)
            {
                return NotFound();
            }

            // Sort comments by CreateDate (newest first)
            discussion.Comments = discussion.Comments.OrderByDescending(c => c.CreateDate).ToList();

            return View(discussion);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}