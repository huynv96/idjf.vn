using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcWeb.Models.ViewModel;
using Newtonsoft.Json;
using Piranha;
using Piranha.AspNetCore.Services;

namespace MvcWeb.Controllers
{
    public class SearchController : Controller
    {

        private readonly IApi _api;
        private readonly IDb _db;
        private readonly IModelLoader _loader;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="app">The current app</param>
        public SearchController(IApi api, IDb db, IModelLoader loader)
        {
            _api = api;
            _db = db;
            _loader = loader;
        }
        public async Task<IActionResult> Index(string keyword)
        {
            var listPost = _db.Posts.Where(x => x.Title.Contains(keyword)).ToList();
            var blogPost = new List<Models.BlogPost>();
            foreach (var post in listPost)
            {
                var blog = await _loader.GetPostAsync<Models.BlogPost>(post.Id, HttpContext.User, false);
                blogPost.Add(blog);
            }
            
            ViewBag.Posts = blogPost;
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetFile(string year, string id)
        {
            var Id = new Guid();
            if (Guid.TryParse(id, out Id))
            {
                var model = await _loader.GetPageAsync<Models.RelationPage>(Id, HttpContext.User, false);
                model.Info = model.Info.Where(x => x.Date.Value?.ToString("yyyy") == year).ToList();
                return Json(model.Info);
            }
            return Json(new { });
        }

        // [HttpPost]
        // public async Task<object> PostGetFile(string Id, string Year)
        // {
        //     var model = await _loader.GetPageAsync<Models.RelationPage>(Guid.Parse(Id), HttpContext.User, false);
        //     return model;
        // }
    }
}