﻿/*
 * Copyright (c) 2016-2018 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * https://github.com/piranhacms/piranha.core
 *
 */

using System;
using System.Dynamic;

namespace Piranha.Models
{
    /// <summary>
    /// Dynamic page model.
    /// </summary>
    [Serializable]
    public class DynamicPost : Post<DynamicPost>, IDynamicModel
    {
        /// <summary>
        /// Gets/sets the regions.
        /// </summary>
        public dynamic Regions { get; set; } = new ExpandoObject();
    }
}