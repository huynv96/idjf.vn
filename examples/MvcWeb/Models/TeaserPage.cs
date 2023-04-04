/*
 * Copyright (c) 2017-2019 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * http://github.com/tidyui/coreweb
 *
 */

using System.Collections.Generic;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;

namespace MvcWeb.Models
{
    /// <summary>
    /// Basic page with main content in markdown.
    /// </summary>
    [PageType(Title = "Trang chủ", UseBlocks = false)]
    [PageTypeRoute(Title = "Default", Route = "/teaserpage")]
    public class TeaserPage : Page<TeaserPage>
    {
        /// <summary>
        /// Gets/sets the page header.
        /// </summary>
        [Region(Display = RegionDisplayMode.Full, Title = "Slides", ListTitle = "Slides", ListPlaceholder = "Slides", Icon = "fas fa-quote-right")]
        public IList<Regions.Slide> SlideModel { get; set; } = new List<Regions.Slide>();

        //[Region(Display = RegionDisplayMode.Setting)]
        //[RegionDescription("The Hero is shown on the top of your page")]
        //public Regions.Hero Hero { get; set; }
        [Region(Display = RegionDisplayMode.Full, Title = "Bài giới thiệu", ListTitle = "Giới thiệu", ListPlaceholder = "Giới thiệu", Icon = "fas fa-bookmark")]
        public Regions.Teaser Intro { get; set; } = new Regions.Teaser();

        /// <summary>
        /// Gets/sets the available teasers.
        /// </summary>
        [Region(Display = RegionDisplayMode.Full, Title = "Lĩnh vực hoạt động", ListTitle = "Lĩnh vực hoạt động", ListPlaceholder = "Hoạt động mới", Icon = "fas fa-quote-right")]
        public IList<Regions.Teaser> BusinessModel { get; set; } = new List<Regions.Teaser>();


        [Region(Display = RegionDisplayMode.Full, Title = "Tiêu đề Hoạt động đầu tư", ListTitle = "Tiêu đề Hoạt động đầu tư", ListPlaceholder = " Tiêu đề Hoạt đầu tư", Icon = "fas fa-quote-right")]
        public Regions.Intro InvestActTitle { get; set; } = new Regions.Intro();
        /// <summary>
        /// Gets/sets the available teasers.
        /// </summary>
        [Region(Display = RegionDisplayMode.Full, Title = "Hoạt động đầu tư", ListTitle = "Hoạt động đầu tư", ListPlaceholder = "Hoạt động mới", Icon = "fas fa-quote-right")]
        public IList<Regions.Teaser> InvestmentActivity { get; set; } = new List<Regions.Teaser>();

        /// <summary>
        /// Gets/sets the latest post.
        /// </summary>
        /// 
        //[Region(Display = RegionDisplayMode.Full, Title = "Tin tức", ListTitle = "Tin tức", ListPlaceholder = "Tin tức", Icon = "fas fa-quote-right")]
        //public PostArchive<DynamicPost> Archive { get; set; }

        [Region(Display = RegionDisplayMode.Full, Title = "Tin tức", ListTitle = "Tin tức", ListPlaceholder = "Tin tức", Icon = "fas fa-bookmark")]
        public Regions.News News { get; set; } = new Regions.News();
    }
}
