/*
 * Copyright (c) 2017-2018 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * http://github.com/tidyui/coreweb
 *
 */

using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace MvcWeb.Models.Regions
{
    /// <summary>
    /// Simple hero region.
    /// </summary>
    public class Hero
    {
        /// <summary>
        /// Gets/sets the optional subtitle.
        /// </summary>
        [Field(Options = FieldOption.HalfWidth)]
        public StringField Subtitle { get; set; }

        /// <summary>
        /// Gets/sets the optional primary image.
        /// </summary>
        [Field(Title = "Ảnh đại diện", Options = FieldOption.HalfWidth)]
        public ImageField PrimaryImage { get; set; }

        /// <summary>
        /// Gets/sets the optional ingress.
        /// </summary>
        [Field]
        [FieldDescription("Thông tin hiển thị bên trên ảnh nền")]
        public HtmlField Ingress { get; set; }

        [Field]
        [FieldDescription("Ngày đăng")]
        public DateField PublishedDate { get; set; }
    }
}
