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
    public class Info
    {
        [Field(Options = FieldOption.HalfWidth)]
        public StringField AddressTitle { get; set; }

        [Field(Options = FieldOption.HalfWidth)]
        public StringField Address { get; set; }

        [Field(Options = FieldOption.HalfWidth)]
        public StringField MobileTitle { get; set; }

        [Field(Options = FieldOption.HalfWidth)]
        public StringField Mobile { get; set; }
        [Field(Options = FieldOption.HalfWidth)]
        public StringField EmailTitle { get; set; }

        [Field(Options = FieldOption.HalfWidth)]
        public StringField Email { get; set; }
        [Field(Options = FieldOption.HalfWidth)]
        public StringField LinkFacebook { get; set; }
        [Field(Options = FieldOption.HalfWidth)]
        public StringField LinkTwitter { get; set; }

        [Field(Options = FieldOption.HalfWidth)]
        public StringField LinkInsagram { get; set; }
    }
}
