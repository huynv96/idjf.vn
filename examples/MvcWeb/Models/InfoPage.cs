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
    [PageType(Title = "Info", UseBlocks = false)]
    [PageTypeRoute(Title = "Info", Route = "/footerpage")]
    public class InfoPage : Page<InfoPage>
    {
        [Region(Display = RegionDisplayMode.Full, Title = "Info", ListTitle = "Info", ListPlaceholder = "Info", Icon = "fas fa-quote-right")]
        public Regions.Info Info { get; set; }
    }
}
