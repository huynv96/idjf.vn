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
    [PageType(Title = "Quan hệ cổ đông", UseBlocks = false)]
    [PageTypeRoute(Title = "Default", Route = "/relationpage")]
    public class RelationPage : Page<RelationPage>
    {
        [Region(Display = RegionDisplayMode.Full, Title = "Banner", ListTitle = "Banner", ListPlaceholder = "Banner", Icon = "fas fa-quote-right")]
        public Regions.Banner Banner { get; set; }

        [Region(Display = RegionDisplayMode.Full, Title = "Mô hình", ListTitle = "Mô hình", ListPlaceholder = "Mô hình", Icon = "fas fa-quote-right")]
        public Regions.ME Model { get; set; }

        [Region(Display = RegionDisplayMode.Full, Title = "Tiêu đề ĐL", ListTitle = "Tiêu đề ĐL", ListPlaceholder = "Tiêu đề ĐL", Icon = "fas fa-quote-right")]
        public Regions.ME TitleRegulation { get; set; }

        [Region(Display = RegionDisplayMode.Full, Title = "Điều lệ", ListTitle = "Điều lệ", ListPlaceholder = "Điều lệ", Icon = "fas fa-bookmark")]
        public IList<Regions.Relation> Regulations { get; set; } = new List<Regions.Relation>();

        [Region(Display = RegionDisplayMode.Full, Title = "Tiêu đề QTNB", ListTitle = "Tiêu đề QTNB", ListPlaceholder = "Tiêu đề QTNB", Icon = "fas fa-quote-right")]
        public Regions.ME TitleManager { get; set; }
        [Region(Display = RegionDisplayMode.Full, Title = "Quản trị nội bộ", ListTitle = "Quản trị nội bộ", ListPlaceholder = "Quản trị nội bộ", Icon = "fas fa-bookmark")]
        public IList<Regions.Relation> Managers { get; set; } = new List<Regions.Relation>();

        [Region(Display = RegionDisplayMode.Full, Title = "Tiêu đề CB", ListTitle = "Tiêu đề CB", ListPlaceholder = "Tiêu đề CB", Icon = "fas fa-quote-right")]
        public Regions.ME TitleReport { get; set; }
        [Region(Display = RegionDisplayMode.Full, Title = "Cáo bạch", ListTitle = "Cáo bạch", ListPlaceholder = "Cáo bạch", Icon = "fas fa-bookmark")]
        public IList<Regions.Relation> Reports { get; set; } = new List<Regions.Relation>();

        [Region(Display = RegionDisplayMode.Full, Title = "Thông báo cổ đông", ListTitle = "Thông báo cổ đông", ListPlaceholder = "Thông báo cổ đông", Icon = "fas fa-bookmark")]
        public IList<Regions.Relation> Info { get; set; } = new List<Regions.Relation>();

        [Region(Display = RegionDisplayMode.Full, Title = "Báo cáo tài chính", ListTitle = "Báo cáo tài chính", ListPlaceholder = "Báo cáo tài chính", Icon = "fas fa-bookmark")]
        public IList<Regions.Relation> ReportFin { get; set; } = new List<Regions.Relation>();

        [Region(Display = RegionDisplayMode.Full, Title = "Báo cáo thường niên", ListTitle = "Báo cáo thường niên", ListPlaceholder = "Báo cáo thường niên", Icon = "fas fa-bookmark")]
        public IList<Regions.Relation> ReportYear { get; set; } = new List<Regions.Relation>();

        [Region(Display = RegionDisplayMode.Full, Title = "Tin tức cho nhà đầu tư", ListTitle = "Tin tức cho nhà đầu tư", ListPlaceholder = "Tin tức cho nhà đầu tư", Icon = "fas fa-bookmark")]
        public IList<Regions.Relation> Noti { get; set; } = new List<Regions.Relation>();

        [Region(Display = RegionDisplayMode.Full, Title = "Tiêu đề nghị quyết", ListTitle = "Tiêu đề nghị quyết", ListPlaceholder = "Tiêu đề nghị quyết", Icon = "fas fa-quote-right")]
        public Regions.ME TitleResolution { get; set; }

        [Region(Display = RegionDisplayMode.Full, Title = "Nghị quyết HĐQT và ĐHCĐ", ListTitle = "Nghị quyết HĐQT và ĐHCĐ", ListPlaceholder = "Nghị quyết HĐQT và ĐHCĐ", Icon = "fas fa-bookmark")]
        public IList<Regions.Relation> Resolution { get; set; } = new List<Regions.Relation>();

    }
}
