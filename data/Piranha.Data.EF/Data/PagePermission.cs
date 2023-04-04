/*
 * Copyright (c) 2020 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * https://github.com/piranhacms/piranha.core
 *
 */

using System;
using Newtonsoft.Json;

namespace Piranha.Data
{
    [Serializable]
    public sealed class PagePermission
    {
        public Guid PageId { get; set; }
        public string Permission { get; set; }

        [JsonIgnore]
        public Page Page { get; set; }
    }
}
