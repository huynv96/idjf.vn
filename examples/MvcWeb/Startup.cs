using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Piranha;
using Piranha.AspNetCore.Identity.SQLServer;
using Piranha.Data.EF.SQLServer;

namespace MvcWeb
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options =>
                options.ResourcesPath = "Resources"
            );
            services.AddControllersWithViews();
            services.AddRazorPages()
                .AddPiranhaManagerOptions();

            services.AddPiranha();
            services.AddPiranhaApplication();
            services.AddPiranhaFileStorage();
            services.AddPiranhaImageSharp();
            services.AddPiranhaManager();
            services.AddPiranhaTinyMCE();
            services.AddPiranhaApi();

            services.AddPiranha(options =>
            {
                options.UseEF<SQLServerDb>(db =>
                    db.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            });

            //services.AddPiranhaIdentity<IdentitySQLServerDb>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            //});
            services.AddPiranhaIdentityWithSeed<IdentitySQLServerDb>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddMemoryCache();
            services.AddPiranhaMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApi api)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            App.Init(api);

            // Configure cache level
            App.CacheLevel = Piranha.Cache.CacheLevel.Full;

            // Build content types
            var pageTypeBuilder = new Piranha.AttributeBuilder.PageTypeBuilder(api)
                .AddType(typeof(Models.BlogArchive))
                .AddType(typeof(Models.StandardPage))
                .AddType(typeof(Models.TeaserPage))
                .AddType(typeof(Models.IntroPage))
                .AddType(typeof(Models.NewsPage))
                .AddType(typeof(Models.RecruiPage))
                .AddType(typeof(Models.RelationPage))
                .AddType(typeof(Models.ContactPage))
                .AddType(typeof(Models.InvestPage))
                .AddType(typeof(Models.LeaderPage))
                .AddType(typeof(Models.CategoryPage))
                .AddType(typeof(Models.TagPage))
                .AddType(typeof(Models.SearchPage))
                .AddType(typeof(Models.ApplyPage))
                .AddType(typeof(Models.InfoPage))
                .Build()
                .DeleteOrphans();

            var postTypeBuilder = new Piranha.AttributeBuilder.PostTypeBuilder(api)
                .AddType(typeof(Models.BlogPost))
                .Build()
                .DeleteOrphans();
            var siteTypeBuilder = new Piranha.AttributeBuilder.SiteTypeBuilder(api)
                .AddType(typeof(Models.StandardSite))
                .Build()
                .DeleteOrphans();

            /**
             *
             * Test another culture in the UI
             *
            var cultureInfo = new System.Globalization.CultureInfo("en-US");
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
             */

            // Register middleware
            app.UseStaticFiles();
            app.UsePiranha();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UsePiranhaIdentity();
            app.UsePiranhaManager();
            app.UsePiranhaTinyMCE();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapPiranhaManager();
            });

            app.UseRewriter(new RewriteOptions()
                .AddIISUrlRewrite(env.ContentRootFileProvider, "RedirectToWwwRule.xml")
                .AddRedirectToHttps()
            );
            
            //Seed.RunAsync(api).GetAwaiter().GetResult();
        }
    }
}
