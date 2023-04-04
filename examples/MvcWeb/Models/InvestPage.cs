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
    [PageType(Title = "Hoạt động đầu tư", UseBlocks = false)]
    [PageTypeRoute(Title = "Hoạt động đầu tư", Route = "/investpage")]
    public class InvestPage : Page<InvestPage>
    {
        [Region(Display = RegionDisplayMode.Full, Title = "Banner", ListTitle = "Banner", ListPlaceholder = "Banner", Icon = "fas fa-quote-right")]
        public Regions.Banner Banner { get; set; }
        /// <summary>
        /// Gets/sets the available teasers.
        /// </summary>
        [Region(Display = RegionDisplayMode.Full, Title = "Thông tin", ListTitle = "Thông tin", ListPlaceholder = "Thông tin", Icon = "fas fa-bookmark")]
        public Regions.Intro Intro { get; set; } = new Regions.Intro();

        [Region(Display = RegionDisplayMode.Full, Title = "Lĩnh vực hoạt động", ListTitle = "Lĩnh vực hoạt động", ListPlaceholder = "Hoạt động mới", Icon = "fas fa-quote-right")]
        public IList<Regions.Invest> Invest { get; set; } = new List<Regions.Invest>();

    }
}
