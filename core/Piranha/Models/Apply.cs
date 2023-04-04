/*
 * Copyright (c) 2018-2019 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * http://github.com/piranhacms/piranha
 *
 */

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piranha.Models
{
    [Serializable]
    [Table("Piranha_Applies")]
    public class Apply
    {
        /// <summary>
        /// Gets/sets the unique id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets/sets the id of the site this alias is for.
        /// </summary>
        public Guid SiteId { get; set; }

        /// <summary>
        /// Gets/sets the alias url.
        /// </summary>
        [Required]
        [StringLength(256)]
        public string ApplyName { get; set; }

        /// <summary>
        /// Gets/sets the url of the redirect.
        /// </summary>
        [Required]
        [StringLength(256)]
        public string ApplyEmail { get; set; }

        /// <summary>
        /// Gets/sets if this is a permanent or temporary
        /// redirect.
        /// </summary>
        [Required]
        [StringLength(256)]
        public string ApplyPhone { get; set; }

        [Required]
        [StringLength(256)]
        public string ApplyJob { get; set; }

        [Required]
        [StringLength(256)]
        public string ApplyCV { get; set; }

        /// <summary>
        /// Gets/sets the url of the redirect.
        /// </summary>
        [Required]
        [StringLength(512)]
        public string ApplyIntro { get; set; }
    }
}