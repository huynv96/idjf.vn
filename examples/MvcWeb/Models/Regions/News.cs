/*
 * Copyright (c) 2017-2018 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * http://github.com/tidyui/coreweb
 *
 */

using System.Collections.Generic;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace MvcWeb.Models.Regions
{
    /// <summary>
    /// Simple region for a teaser.
    /// </summary>
    public class News
    {
        ///// <summary>
        ///// Gets/sets the title.
        ///// </summary>
        [Field(Options = FieldOption.HalfWidth)]
        public StringField Title { get; set; }

        [Field(Options = FieldOption.HalfWidth)]
        public StringField TitleLink { get; set; }

        [Field(Options = FieldOption.HalfWidth)]
        public StringField Link { get; set; }

        ///// <summary>
        ///// Gets/sets the subtitle.
        ///// </summary>
        //[Field(Options = FieldOption.HalfWidth)]
        //public StringField SubTitle { get; set; }

        ///// <summary>
        ///// Gets/sets the optional teaser image.
        ///// </summary>
        //[Field]
        //public ImageField Image { get; set; }

        ///// <summary>
        ///// Gets/sets the main body.
        ///// </summary>
        //[Field]
        //public HtmlField Body { get; set; }

        //[Field]
        //public StringField Link { get; set; }


        [Field]
        public PageField Page { get; set; }
    }
}
