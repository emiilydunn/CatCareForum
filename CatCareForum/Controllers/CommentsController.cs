using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatCareForum.Data;
using CatCareForum.Models;

namespace CatCareForum.Controllers
{
    public class CommentsController : Controller
    {
        private readonly CatCareForumContext _context;

        public CommentsController(CatCareForumContext context)
        {
            _context = context;
        }

        //Deleted the following functionalities (and relevant views as they are not needed for this project)
        //GET: Comments
        //GET: Comments/Details/5
        //GET: Comments/Edit/5
        //POST: Comments/Edit/5
        //GET: Comments/Delete/5
        //POST: Comments/Delete/5


        // GET: Comments/Create
        //Display form to add a comment
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["DiscussionId"] = id;

            return View();
        }

        // POST: Comments/Create
        //Create a comment a re-direct user to the "Get Discussion" page
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,Content,CreateDate,DiscussionId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.CreateDate = DateTime.Now;
                _context.Add(comment);
                await _context.SaveChangesAsync();
                
                //Redirect to /Discussions/Edit/id
                return RedirectToAction("GetDiscussion", "Home", new { id = comment.DiscussionId });
            }
            ViewData["DiscussionId"] = comment.DiscussionId;
            return View(comment);
         
        }

       
        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.CommentId == id);
        }
    }
}
