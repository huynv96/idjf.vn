/*
 * Copyright (c) 2017-2018 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * http://github.com/tidyui/coreweb
 *
 */

using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;

namespace MvcWeb.Models
{
    /// <summary>
    /// Basic post with main content in markdown.
    /// </summary>
    [PostType(Title = "Tin tức")]
    public class BlogPost : Post<BlogPost>
    {
        /// <summary>
        /// Gets/sets the heading.
        /// </summary>
        [Region()]
        public Regions.Hero Hero { get; set; }

        [Region()]
        public Regions.Recruit Recruit { get; set; }

        [Region(Display = RegionDisplayMode.Full, Title = "Banner", ListTitle = "Banner", ListPlaceholder = "Banner", Icon = "fas fa-quote-right")]
        public Regions.Banner Banner { get; set; }
    }
}
