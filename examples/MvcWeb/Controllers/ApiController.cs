using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MvcWeb.Models.ViewModel;
using Piranha;
using Piranha.AspNetCore.Services;
using Piranha.Data;

namespace MvcWeb.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController: Controller
    {
        private readonly IApi _api;
        private readonly IDb _db;
        private readonly IModelLoader _loader;
        private readonly IHostingEnvironment hostingEnv;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="app">The current app</param>
        public ApiController(IApi api, IDb db, IModelLoader loader, IHostingEnvironment env)
        {
            _api = api;
            _db = db;
            _loader = loader;
            this.hostingEnv = env;
        }

        [HttpPost]
        [Route("postgetfile")]
        public async Task<object> PostGetFile(DocumentVM doc)
        {
            var model = await _loader.GetPageAsync<Models.RelationPage>(Guid.Parse(doc.Id), HttpContext.User, false);
            return model;
        }

        [HttpPost]
        [Route("addcontact")]
        public async Task<object> AddContact(ContactModel contact)
        {
            Contact model = new Contact();
            model.ContactName = contact.ContactName;
            model.ContactEmail = contact.ContactEmail;
            model.ContactTitle = contact.ContactTitle;
            model.ContactContent = contact.ContactContent;
            
            model.Id = Guid.NewGuid();
            model.SiteId = new Guid("10d0002b-2f57-4449-9112-6b150b23e904");
            await _db.Contacts.AddAsync(model).ConfigureAwait(false);
            await _db.SaveChangesAsync().ConfigureAwait(false);
            return 1;
        }

        [HttpPost]
        [Route("uploadfile")]
        public async Task<object> UploadFile()
        {
            string result = string.Empty;
            try
            {
                Guid id = Guid.NewGuid();
                long size = 0;
                var file = Request.Form.Files;
                var filename = ContentDispositionHeaderValue.Parse(file[0].ContentDisposition).FileName.ToString().Trim('"');
                var applyName = Request.Form["applyName"].ToString();
                var applyEmail = Request.Form["applyEmail"].ToString();
                var applyPhone = Request.Form["applyPhone"].ToString();
                var applyJob = Request.Form["applyJob"].ToString();
                var applyIntro = Request.Form["applyIntro"].ToString();
                string FilePath = hostingEnv.WebRootPath + $@"\uploads\{id + "-" + filename}";

                size += file[0].Length;

                using (FileStream fs = System.IO.File.Create(FilePath))
                {
                    file[0].CopyTo(fs);
                    fs.Flush();
                }
                result = FilePath;
                
                Apply model = new Apply();
                model.Id = Guid.NewGuid();
                model.SiteId = id;
                model.ApplyIntro = applyIntro;
                model.ApplyJob = applyJob;
                model.ApplyName = applyName;
                model.ApplyPhone = applyPhone;
                model.ApplyEmail = applyEmail;
                model.ApplyCV = id.ToString() + "-" + filename;
                await _db.Applies.AddAsync(model).ConfigureAwait(false);
                await _db.SaveChangesAsync().ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}
