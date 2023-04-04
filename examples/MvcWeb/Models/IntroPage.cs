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
    [PageType(Title = "Giới thiệu", UseBlocks = false)]
    [PageTypeRoute(Title = "IntroPage", Route = "/intropage")]
    public class IntroPage : Page<IntroPage>
    {
        [Region(Display = RegionDisplayMode.Full, Title = "Banner", ListTitle = "Banner", ListPlaceholder = "Banner", Icon = "fas fa-quote-right")]
        public Regions.Banner Banner { get; set; }
        //[Region(Display = RegionDisplayMode.Full, Title = "Tất cả thành phần")]
        //[RegionDescription("Tất cả các dữ liệu hiển thị ở Trang chủ.")]
        //public Regions.AllFields AllFields { get; set; }

        /// <summary>
        /// Gets/sets the page header.
        /// </summary>
        //[Region(Display = RegionDisplayMode.Setting)]
        //[RegionDescription("The Hero is shown on the top of your page")]
        //public Regions.Hero Hero { get; set; }
        [Region(Display = RegionDisplayMode.Full, Title = "Chúng tôi là ai", ListTitle = "Chúng tôi là ai", ListPlaceholder = "Chúng tôi là ai", Icon = "fas fa-bookmark")]
        public IList<Regions.Teaser> Intro { get; set; } = new List<Regions.Teaser>();


        /// <summary>
        /// Gets/sets the available teasers.
        /// </summary>
        [Region(Display = RegionDisplayMode.Full, Title = "Lịch sử", ListTitle = "Lịch sử", ListPlaceholder = "Lịch sử", Icon = "fas fa-quote-right")]
        public IList<Regions.Teaser> InvestmentActivity { get; set; } = new List<Regions.Teaser>();
        /// <summary>
        /// Gets/sets the available teasers.
        /// </summary>
        [Region(Display = RegionDisplayMode.Full, Title = "Tầm nhìn sứ mệnh", ListTitle = "Tầm nhìn sứ mệnh", ListPlaceholder = "Tầm nhìn sứ mệnh", Icon = "fas fa-quote-right")]
        public IList<Regions.Teaser> BusinessModel { get; set; } = new List<Regions.Teaser>();

        [Region(Display = RegionDisplayMode.Full, Title = "Giá trị cốt lõi", ListTitle = "Giá trị cốt lõi", ListPlaceholder = "Giá trị cốt lõi", Icon = "fas fa-quote-right")]
        public IList<Regions.Teaser> Projects { get; set; } = new List<Regions.Teaser>();

        /// <summary>
        /// Gets/sets the available links.
        /// </summary>
        //[Region(ListTitle = "ButtonText", ListPlaceholder = "New Link", Icon = "fas fa-quote-right")]
        //public IList<Regions.Href> Links { get; set; } = new List<Regions.Href>();

        /// <summary>
        /// Gets/sets the latest post.
        /// </summary>
        /// 
        [Region(Display = RegionDisplayMode.Full, Title = "Tin tức")]
        public PostArchive<DynamicPost> Archive { get; set; }
    }
}
