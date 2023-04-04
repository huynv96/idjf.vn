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
    [PageType(Title = "Tuyển dụng", IsArchive = true, UseBlocks = false)]
    [PageTypeRoute(Title = "Tuyển dụng", Route = "/recruitpage")]
    public class RecruiPage : Page<RecruiPage>
    {
       
        /// <summary>
        /// Gets/sets the latest post.
        /// </summary>
        /// 
        [Region(Display = RegionDisplayMode.Full, Title = "Tuyển dụng", ListTitle = "Tuyển dụng", ListPlaceholder = "Tuyển dụng", Icon = "fas fa-quote-right")]
        public PostArchive<DynamicPost> Archive { get; set; }

        [Region(Display = RegionDisplayMode.Full, Title = "Chi tiết", ListTitle = "Chi tiết", ListPlaceholder = "Chi tiết", Icon = "fas fa-quote-right")]
        public Regions.Recruit Detail { get; set; }

        [Region(Display = RegionDisplayMode.Full, Title = "Banner", ListTitle = "Banner", ListPlaceholder = "Banner", Icon = "fas fa-quote-right")]
        public Regions.Banner Banner { get; set; }
    }
}
