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
    [PageType(Title = "Ban điều hành", UseBlocks = false)]
    [PageTypeRoute(Title = "DBan điều hành", Route = "/leaderpage")]
    public class LeaderPage : Page<LeaderPage>
    {
        [Region(Display = RegionDisplayMode.Full, Title = "Banner", ListTitle = "Banner", ListPlaceholder = "Banner", Icon = "fas fa-quote-right")]
        public Regions.Banner Banner { get; set; }
        /// <summary>
        /// Gets/sets the page header.
        /// </summary>
        [Region(Display = RegionDisplayMode.Full, Title = "Thông tin", ListTitle = "Thông tin", ListPlaceholder = "Thông tin", Icon = "fas fa-bookmark")]
        public Regions.Intro Intro { get; set; } = new Regions.Intro();

        /// <summary>
        /// Gets/sets the available teasers.
        /// </summary>
        [Region(Display = RegionDisplayMode.Full, Title = "Ban điều hành", ListTitle = "Ban điều hành", ListPlaceholder = "Ban điều hành", Icon = "fas fa-quote-right")]
        public IList<Regions.Teaser> Leader { get; set; } = new List<Regions.Teaser>();

    }
}
