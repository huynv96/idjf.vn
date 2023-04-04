/*
 * Copyright (c) 2011-2020 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * http://github.com/piranhacms/piranha
 *
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piranha.Data
{
    [Serializable]
    public sealed class Apply : Models.Apply
    {
        /// <summary>
        /// Gets/sets the site this alias is for.
        /// </summary>
        /// <returns></returns>
        public Site Site { get; set; }
    }
}
