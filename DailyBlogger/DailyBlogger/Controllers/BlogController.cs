using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DailyBlogger.Models;

namespace DailyBlogger.Controllers
{
    public class BlogController : Controller //Inheritance: new child starts off as copy of parent
    {
        private BlogContext _context; //Reference to BlogContext//
        public BlogController(BlogContext context)
        {
            _context = context; //Private Context = Context it gets when object is created.// 
        }
        public IActionResult List() //The list of all the blog posts in the database//
        {
            IEnumerable<BlogPost> post =   _context.blogPost.ToList<BlogPost>(); //Create var called post, a list of BlogPosts. Value = to database context.//
            return View(post);                                                   //Grab all blog posts and return a view//
        }

        public IActionResult New()
        {
            BlogPost blogPost = new BlogPost(); //Will create a new and empty BlogPost object//Will return empty object to the View//
            return View(blogPost);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //Similar to Key Data Annotations//
        public IActionResult Create([Bind("blogTitle,content,blogDate")] BlogPost blog) //Create Action needs to use data from the web form in that blog object//
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog); //Adds blog as a new record//
                _context.SaveChanges(); //Commits changes to the database//
                return RedirectToAction(nameof(List)); //Returns list of all blog posts//
            }
                return View(blog);
        }
        public IActionResult Details(int id)
        {
            BlogPost blogPost = _context.blogPost.Find(id);
            return View(blogPost);
        }
        public IActionResult Edit(int id)
        {
            BlogPost blogPost = _context.blogPost.Find(id);
            return View(blogPost);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("blogTitle,Content,blogDate,id")] BlogPost blog) //Added ID field to bind to update and existing blog//
        {
            if (ModelState.IsValid)
            {
                _context.Update(blog); //Similar to the Add action except "update"//
                _context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            return View(blog);
        }

        public IActionResult Delete([Bind("id")] int id)
        {
            BlogPost blogPost = _context.blogPost.Find(id);
            _context.Remove(blogPost);
            _context.SaveChanges();
            return RedirectToAction(nameof(List));
        }
         
    }
}


        