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
    [PageType(Title = "Danh mục", UseBlocks = false)]
    [PageTypeRoute(Title = "Danh mục", Route = "/categorypage")]
    public class CategoryPage : Page<CategoryPage>
    {
        [Region(Display = RegionDisplayMode.Full, Title = "Banner", ListTitle = "Banner", ListPlaceholder = "Banner", Icon = "fas fa-quote-right")]
        public Regions.Banner Banner { get; set; }

        [Region(Display = RegionDisplayMode.Full, Title = "Tin tức", ListTitle = "Tin tức", ListPlaceholder = "Tin tức", Icon = "fas fa-bookmark")]
        public Regions.News News { get; set; } = new Regions.News();
    }
}
