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
    public class Intro
    {
        /// <summary>
        /// Gets/sets the title.
        /// </summary>
        ///
        [Field(Options = FieldOption.HalfWidth)]
        public StringField HeaderName { get; set; }
        [Field(Options = FieldOption.HalfWidth)]
        public StringField Title { get; set; }

        /// <summary>
        /// Gets/sets the subtitle.
        /// </summary>
        [Field]
        public StringField SubTitle { get; set; }

        [Field]
        public TextField Description { get; set; }
    }
}
