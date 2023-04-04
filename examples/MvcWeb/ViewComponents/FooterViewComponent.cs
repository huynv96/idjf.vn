using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Services;

namespace MvcWeb.Areas.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IDb _db;
        private readonly IModelLoader _loader;

        public FooterViewComponent(IDb db, IModelLoader loader)
        {
            _db = db;
            _loader = loader;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var requestId = HttpUtility.ParseQueryString(HttpContext.Request.QueryString.Value).Get("id").Split(',')[0];
            Guid id = new Guid(requestId);
            Guid blogId = GetNewsPageId(id);
            // Code to instantiate the model class.
            var listPost = _db.Posts.Where(x=>x.BlogId == blogId).ToList().OrderByDescending(x => x.Published).Take(2);
            var blogPost = new List<Models.BlogPost>();
            foreach (var post in listPost)
            {
                var blog = await _loader.GetPostAsync<Models.BlogPost>(post.Id, HttpContext.User, false);
                string urlLang = GetUrlLanguageByPost(blog.Id);
                blog.Permalink = urlLang + blog.Permalink;
                blogPost.Add(blog);
            }

            Guid infoId = GetInfoPageId(id);
            var info = await _loader.GetPageAsync<Models.InfoPage>(infoId, HttpContext.User, false);
            if (info != null)
            {
                ViewBag.AddressTitle = info.Info.AddressTitle;
                ViewBag.Address = info.Info.Address;
                ViewBag.MobileTitle = info.Info.MobileTitle;
                ViewBag.Mobile = info.Info.Mobile;
                ViewBag.EmailTitle = info.Info.EmailTitle;
                ViewBag.Email = info.Info.Email;
                ViewBag.LinkFb = info.Info.LinkFacebook;
                ViewBag.LinkTw = info.Info.LinkTwitter;
                ViewBag.LinkIns = info.Info.LinkInsagram;
            }
            else
            {
                ViewBag.AddressTitle = "";
                ViewBag.Address = "";
                ViewBag.MobileTitle = "";
                ViewBag.Mobile = "";
                ViewBag.EmailTitle = "";
                ViewBag.Email = "";
                ViewBag.LinkFb = "";
                ViewBag.LinkTw = "";
                ViewBag.LinkIns = "";
            }
            return View(blogPost);
        }

        private Guid GetInfoPageId(Guid id)
        {
            Guid infoPageId = new Guid();
            var page = _db.Pages.SingleOrDefault(x => x.Id == id);
            if (page != null)
            {
                var infoPage = _db.Pages.SingleOrDefault(x => x.SiteId == page.SiteId && x.PageTypeId == "InfoPage");
                if (infoPage != null)
                {
                    infoPageId =  infoPage.Id;
                }
            }
            else
            {
                var post = _db.Posts.SingleOrDefault(x => x.Id == id);
                if (post != null)
                {
                    var blog = _db.Pages.SingleOrDefault(x => x.Id == post.BlogId);
                    var infoPage = _db.Pages.SingleOrDefault(x => x.SiteId == blog.SiteId && x.PageTypeId == "InfoPage");
                    if (infoPage != null)
                    {
                        infoPageId = infoPage.Id;
                    }
                }
            }
            return infoPageId;
        }

        private Guid GetNewsPageId(Guid id)
        {
            Guid newsPageId = new Guid();
            var page = _db.Pages.SingleOrDefault(x => x.Id == id);
            if (page != null)
            {
                var newsPage = _db.Pages.SingleOrDefault(x => x.SiteId == page.SiteId && x.PageTypeId == "NewsPage");
                if (newsPage != null)
                {
                    newsPageId = newsPage.Id;
                }
            }
            else
            {
                var post = _db.Posts.SingleOrDefault(x => x.Id == id);
                if (post != null)
                {
                    var blog = _db.Pages.SingleOrDefault(x => x.Id == post.BlogId);
                    var newsPage = _db.Pages.SingleOrDefault(x => x.SiteId == blog.SiteId && x.PageTypeId == "NewsPage");
                    if (newsPage != null)
                    {
                        newsPageId = newsPage.Id;
                    }
                }
            }
            return newsPageId;
        }

        private string GetUrlLanguageByPost(Guid id)
        {
            Guid blogId = _db.Posts.SingleOrDefault(x => x.Id == id).BlogId;
            Guid siteId = _db.Pages.SingleOrDefault(x => x.Id == blogId).SiteId;
            string hostName = _db.Sites.SingleOrDefault(x => x.Id == siteId).Hostnames;
            return "/" + hostName.Split('/')[1];
        }
    }
}