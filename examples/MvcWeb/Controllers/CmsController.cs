using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcWeb.Models;
using Piranha;
using Piranha.AspNetCore.Services;
using Piranha.Data;
using Piranha.Models;

namespace MvcWeb.Controllers
{
    public class CmsController : Controller
    {
        private readonly IApi _api;
        private readonly IDb _db;
        private readonly IModelLoader _loader;


        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="app">The current app</param>
        public CmsController(IApi api, IDb db, IModelLoader loader)
        {
            _api = api;
            _db = db;
            _loader = loader;
        }

        /// <summary>
        /// Gets the blog archive with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        /// <param name="year">The optional year</param>
        /// <param name="month">The optional month</param>
        /// <param name="page">The optional page</param>
        /// <param name="category">The optional category</param>
        /// <param name="tag">The optional tag</param>
        [Route("archive")]
        public async Task<IActionResult> Archive(Guid id, int? year = null, int? month = null, int? page = null,
            Guid? category = null, Guid? tag = null)
        {
            var model = await _api.Pages.GetByIdAsync<Models.BlogArchive>(id);
            model.Archive = await _api.Archives.GetByIdAsync(id, page, category, tag, year, month);

            return View(model);
        }

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [Route("page")]
        public async Task<IActionResult> Page(Guid id, bool draft = false)
        {
            var model = await _loader.GetPageAsync<Models.StandardPage>(id, HttpContext.User, draft);

            return View(model);
        }

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [Route("pagewide")]
        public async Task<IActionResult> PageWide(Guid id, bool draft = false)
        {
            var model = await _loader.GetPageAsync<Models.StandardPage>(id, HttpContext.User, draft);

            return View(model);
        }

        /// <summary>
        /// Gets the post with the given id.
        /// </summary>
        /// <param name="id">The unique post id</param>
        ///
        [Route("post")]
        public async Task<IActionResult> Post(Guid id, bool draft = false)
        {
            string urlLang = GetUrlLanguageByPost(id);
            var model = await _loader.GetPostAsync<Models.BlogPost>(id, HttpContext.User, draft);
            model.Permalink = urlLang + model.Permalink;
            var host = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            ViewBag.Host = host;
            TempData["Url"] = host + model.Permalink;
            TempData["Image"] = host + (model.Hero.PrimaryImage.Media?.PublicUrl.Substring(1) ?? "");
            ViewBag.UrlLang = urlLang;
            var listCategories = await _api.Posts.GetAllCategoriesAsync(model.BlogId);
            ViewBag.ListCategories = listCategories.Select(x =>
            {
                x.Slug = urlLang.Contains("/vi")  ? (urlLang + "/danh-muc/" + x.Slug) : (urlLang + "/categories/" + x.Slug);
                return x;
            }).ToList();

            model.Tags.Select(x =>
            {
                x.Slug = urlLang.Contains("/vi") ? (urlLang + "/tu-khoa/" + x.Slug) : (urlLang + "/tags/" + x.Slug);
                return x;
            }).ToList();

            if (model.Permalink.Contains("tin-tuc") || model.Permalink.Contains("news"))
            {
                var relatePosts = await _api.Posts.GetAllByCategoryIdAsync(model.Category.Id);
                var relateBlogPost = new List<Models.BlogPost>();
                foreach (var post in relatePosts)
                {
                    if (post.Id != id)
                    {
                        var blog = await _loader.GetPostAsync<Models.BlogPost>(post.Id, HttpContext.User, draft);
                        relateBlogPost.Add(blog);
                    }
                }
                relateBlogPost = relateBlogPost.Take(3).ToList();
                ViewBag.ListRelates = relateBlogPost.Select(x =>
                {
                    x.Permalink = (urlLang + x.Permalink);
                    return x;
                }).ToList();
                return View("Post", model);
            }
            else
            {
                return View("RecruitPost", model);
            }
        }

        /// <summary>
        /// Gets the post with the given id.
        /// </summary>
        /// <param name="id">The unique post id</param>
        ///
        [Route("recruitpost")]
        public async Task<IActionResult> RecruitPost(Guid id, bool draft = false)
        {
            string urlLang = GetUrlLanguageByPost(id);
            var model = await _loader.GetPostAsync<Models.RecruitPost>(id, HttpContext.User, draft);
            model.Permalink = urlLang + model.Permalink;
            ViewBag.Host = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            ViewBag.UrlLang = urlLang;
            return View(model);
        }

        /// <summary>
        /// Gets the teaser page with the given id.
        /// </summary>
        /// <param name="id">The page id</param>
        /// <param name="startpage">If this is the startpage of the site</param>
        [Route("teaserpage")]
        public async Task<IActionResult> TeaserPage(Guid id, bool startpage = false, bool draft = false)
        {
            string urlLang = GetUrlLanguageByPage(id);
            var model = await _loader.GetPageAsync<Models.TeaserPage>(id, HttpContext.User, draft);
            model.Permalink = urlLang + model.Permalink;
            ViewBag.Host = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            ViewBag.UrlLang = urlLang;
            //model.Archive = await _api.Archives.GetByIdAsync(id);
            if (model.News.Page.Id != null)
            {
                var homePosts = await _api.Posts.GetAllAsync<DynamicPost>(model.News.Page.Id.Value);
                homePosts = homePosts.Take(4);
                var listHomePosts = homePosts.Select(x =>
                {
                    x.Permalink = (urlLang + x.Permalink);
                    return x;
                }).ToList();
                ViewBag.Posts = listHomePosts != null ? listHomePosts : new List<DynamicPost>();
            }
            else
            {
                ViewBag.Posts = new List<DynamicPost>();
            }

            if (startpage)
            {
                return View("startpage", model);
            }
            
            return View(model);
        }

        [Route("intropage")]
        public async Task<IActionResult> IntroPage(Guid id, bool startpage = false, bool draft = false)
        {
            string urlLang = GetUrlLanguageByPage(id);
            var model = await _loader.GetPageAsync<Models.IntroPage>(id, HttpContext.User, draft);
            model.Permalink = urlLang + model.Permalink;
            ViewBag.Host = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            ViewBag.UrlLang = urlLang;
            model.Archive = await _api.Archives.GetByIdAsync(id);
            return View(model);
        }

        [Route("newspage")]
        public async Task<IActionResult> NewsPage(Guid id, bool startpage = false, bool draft = false)
        {
            string urlLang = GetUrlLanguageByPage(id);
            var model = await _loader.GetPageAsync<Models.NewsPage>(id, HttpContext.User, draft);
            model.Permalink = urlLang + model.Permalink;
            ViewBag.Host = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            ViewBag.UrlLang = urlLang;
            model.Archive = await _api.Archives.GetByIdAsync(id);
            model.Archive.Posts.Select(x =>
            {
                x.Permalink = (urlLang + x.Permalink);
                return x;
            }).ToList().OrderByDescending(x=>x.Published);

            return View(model);
        }

        [Route("recruitpage")]
        public async Task<IActionResult> RecruitPage(Guid id, bool startpage = false, bool draft = false)
        {
            string urlLang = GetUrlLanguageByPage(id);
            var model = await _loader.GetPageAsync<Models.RecruiPage>(id, HttpContext.User, draft);
            ViewBag.Host = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            ViewBag.UrlLang = urlLang;
            model.Archive = await _api.Archives.GetByIdAsync(id);
            model.Archive.Posts.Select(x =>
            {
                x.Permalink = (urlLang + x.Permalink);
                return x;
            }).ToList().OrderByDescending(x => x.Published);
            model.Permalink = urlLang + model.Permalink;

            var listPost = _db.Posts.Where(x => x.BlogId == id).ToList();

            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var post in listPost)
            {
                var item = new SelectListItem { Text = post.Title, Value = post.Title };
                listItems.Add(item);
            }

            ViewBag.ListPosts = new SelectList(listItems, "Value", "Text");

            return View(model);
        }

        [Route("searchpage/{keyword?}")]
        public async Task<IActionResult> SearchPage(Guid id, string keyword, bool startpage = false, bool draft = false)
        {
            string urlLang = GetUrlLanguageByPage(id);
            var model = await _loader.GetPageAsync<Models.SearchPage>(id, HttpContext.User, draft);
            model.Permalink = urlLang + model.Permalink;
            ViewBag.Host = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            ViewBag.UrlLang = urlLang;
            var listPost = _db.Posts.Where(x => x.Title.Contains(keyword)).ToList();
            var blogPost = new List<Models.BlogPost>();
            foreach (var post in listPost)
            {
                var blog = await _loader.GetPostAsync<Models.BlogPost>(post.Id, HttpContext.User, false);
                blogPost.Add(blog);
            }

            ViewBag.Posts = blogPost.Select(x =>
            {
                x.Permalink = (urlLang + x.Permalink);
                return x;
            }).ToList(); 

            return View(model);
        }

        [Route("categorypage/{slug}")]
        public async Task<IActionResult> CategoryPage(Guid id, string slug, bool startpage = false, bool draft = false)
        {
            string urlLang = GetUrlLanguageByPage(id);
            var model = await _loader.GetPageAsync<Models.CategoryPage>(id, HttpContext.User, draft);
            model.Permalink = urlLang + model.Permalink;
            ViewBag.Host = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            ViewBag.UrlLang = urlLang;
            var category = await _api.Posts.GetCategoryBySlugAsync(model.News.Page.Id.Value, slug);

            ViewBag.Posts = await _api.Posts.GetAllByCategoryIdAsync(category.Id);

            return View(model);
        }

        [Route("tagpage/{slug}")]
        public async Task<IActionResult> TagPage(Guid id, string slug, bool startpage = false, bool draft = false)
        {
            string urlLang = GetUrlLanguageByPage(id);
            var model = await _loader.GetPageAsync<Models.TagPage>(id, HttpContext.User, draft);
            model.Permalink = urlLang + model.Permalink;
            ViewBag.Host = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            ViewBag.UrlLang = urlLang;
            List<Post> listPost = new List<Post>();
            var tags = _db.Tags.Where(x => x.Slug == slug).Select(x => x.Id).ToList();
            foreach (var item in tags)
            {
                var list = _db.PostTags.Where(x => x.TagId == item).Select(x => x.PostId).ToList();
                foreach (var sub in list)
                {
                    var post = _db.Posts.SingleOrDefault(x => x.Id == sub);
                    listPost.Add(post);
                }
            }

            var blogPost = new List<Models.BlogPost>();
            foreach (var post in listPost)
            {
                var blog = await _loader.GetPostAsync<Models.BlogPost>(post.Id, HttpContext.User, draft);
                blogPost.Add(blog);
            }

            ViewBag.Posts = blogPost.Select(x =>
            {
                x.Permalink = (urlLang + x.Permalink);
                return x;
            }).ToList(); 

            // ViewBag.Posts = await _api.Posts.GetAllByCategoryIdAsync(tag.Id);

            return View(model);
        }

        [Route("relationpage/{param?}")]
        public async Task<IActionResult> RelationPage(Guid id,string InfoYear, string ReportFin, string ReportYear, string Noti, bool startpage = false, bool draft = false)
        {
            var model = await _loader.GetPageAsync<Models.RelationPage>(id, HttpContext.User, draft);
            var urlLang = GetUrlLanguageByPage(id);
            if (urlLang.Contains("/en"))
            {
                ViewBag.ManagerEnterprise = "Manager Enterprise";
                ViewBag.Notification = "Notification";
                ViewBag.FinalcialReport = "Finalcial Report";
                ViewBag.YearlyReport = "Yearly Report";
                ViewBag.News = "News for investors";
                ViewBag.Resolutions = "Resolutions";
            }
            else
            {
                ViewBag.ManagerEnterprise = "Quản trị doanh nghiệp";
                ViewBag.Notification = "Thông báo cổ đông";
                ViewBag.FinalcialReport = "Báo cáo tài chính";
                ViewBag.YearlyReport = "Báo cáo thường niên";
                ViewBag.News = "Tin tức cho nhà đầu tư";
                ViewBag.Resolutions = "Nghị quyết HĐQT và ĐHCĐ";
            }
//            var currentYear = DateTime.Now.Year;
//            List < SelectListItem > listItems = new List<SelectListItem>();
//            for (int i = currentYear; i >= 2007; i--)
//            {
//                bool selected = i == currentYear;
//                var item = new SelectListItem {Selected = selected, Text = i.ToString(), Value = i.ToString()};
//                listItems.Add(item);
//            }
//
//            ViewBag.ListYears = new SelectList(listItems, "Value", "Text", 1);
//
//            if (InfoYear == null)
//            {
//                InfoYear = currentYear.ToString();
//            }
//            if (ReportFin == null)
//            {
//                ReportFin = currentYear.ToString();
//            }
//            if (ReportYear == null)
//            {
//                ReportYear = currentYear.ToString();
//            }
//            if (Noti == null)
//            {
//                Noti = currentYear.ToString();
//            }
//
//            model.Info = model.Info.Where(x => x.Date.Value?.ToString("yyyy") == InfoYear).OrderByDescending(x=>x.Date.Value).ToList();
//            model.ReportFin = model.ReportFin.Where(x => x.Date.Value?.ToString("yyyy") == ReportFin).OrderByDescending(x => x.Date.Value).ToList();
//            model.ReportYear = model.ReportYear.Where(x => x.Date.Value?.ToString("yyyy") == ReportYear).OrderByDescending(x => x.Date.Value).ToList();
//            model.Noti = model.Noti.Where(x => x.Date.Value?.ToString("yyyy") == Noti).OrderByDescending(x => x.Date.Value).ToList();

            return View(model);
        }

        [Route("contactpage")]
        public async Task<IActionResult> ContactPage(Guid id, bool startpage = false, bool draft = false)
        {
            var model = await _loader.GetPageAsync<Models.ContactPage>(id, HttpContext.User, draft);
            ViewBag.UrlLang = GetUrlLanguageByPage(id);
            return View(model);
        }

        [Route("investpage")]
        public async Task<IActionResult> InvestPage(Guid id, bool startpage = false, bool draft = false)
        {
            var model = await _loader.GetPageAsync<Models.InvestPage>(id, HttpContext.User, draft);
            string urlLang = GetUrlLanguageByPage(id);
            if (urlLang.Contains("/en"))
            {
                
                ViewBag.More = "More";
                ViewBag.Finish = "Finish";
                ViewBag.Location = "Location";
                ViewBag.Progress = "Progress";
            }
            else
            {
                ViewBag.More = "Xem thêm";
                ViewBag.Finish = "Hoàn thành";
                ViewBag.Location = "Vị trí";
                ViewBag.Progress = "Tiến độ";
            }
            return View(model);
        }

        [Route("leaderpage")]
        public async Task<IActionResult> LeaderPage(Guid id, bool startpage = false, bool draft = false)
        {
            var model = await _loader.GetPageAsync<Models.LeaderPage>(id, HttpContext.User, draft);
            ViewBag.UrlLang = GetUrlLanguageByPage(id);
            return View(model);
        }

        [Route("infopage")]
        public async Task<IActionResult> InfoPage(Guid id, bool startpage = false, bool draft = false)
        {
            var model = await _loader.GetPageAsync<Models.InfoPage>(id, HttpContext.User, draft);
            ViewBag.UrlLang = GetUrlLanguageByPage(id);
            return View(model);
        }

        [Route("applypage")]
        public async Task<IActionResult> ApplyPage(Guid id, string testId, string a, bool startpage = false, bool draft = false)
        {
            var model = await _loader.GetPageAsync<Models.ApplyPage>(id, HttpContext.User, draft);
            Guid siteId = model.SiteId;
            var recruitPage = _db.Pages.SingleOrDefault(x => x.PageTypeId == "RecruiPage" && x.SiteId == siteId);
            var blogId = new Guid();
            if (recruitPage != null)
            {
                blogId = recruitPage.Id;
            }
            
            ViewBag.UrlLang = GetUrlLanguageByPage(id);
            var listPost =  _db.Posts.Where(x => x.BlogId == blogId).ToList();

            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var post in listPost)
            {
                var item = new SelectListItem {  Text = post.Title, Value = post.Title };
                listItems.Add(item);
            }

            ViewBag.ListPosts = new SelectList(listItems, "Value", "Text");
            return View(model);
        }

        private string GetUrlLanguageByPage(Guid id)
        {
            Guid siteId = _db.Pages.SingleOrDefault(x => x.Id == id).SiteId;
            string hostName = _db.Sites.SingleOrDefault(x => x.Id == siteId).Hostnames;
            return "/" + hostName.Split('/')[1];
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
