/*
 * Copyright (c) 2019 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * http://github.com/piranhacms/piranha
 *
 */

using System;

namespace Piranha.Data
{
    public class PostRevision : ContentRevision
    {
        /// <summary>
        /// Gets/sets the id of the post this revision
        /// belongs to.
        /// </summary>
        public Guid PostId { get; set; }

        /// <summary>
        /// Gets/sets the post this revision belongs to.
        /// </summary>
        public Post Post { get; set; }
    }
}