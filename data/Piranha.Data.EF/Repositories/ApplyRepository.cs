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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Piranha.Models;
using Piranha.Services;

namespace Piranha.Repositories
{
    public class ApplyRepository : IApplyRepository
    {
        private readonly IDb _db;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="db">The current db context</param>
        public ApplyRepository(IDb db)
        {
            _db = db;
        }

        /// <summary>
        /// Gets all available models for the specified site.
        /// </summary>
        /// <param name="siteId">The site id</param>
        /// <returns>The available models</returns>
        public async Task<IEnumerable<Apply>> GetAll(Guid siteId)
        {
            return await _db.Applies
                .AsNoTracking()
                .Select(a => new Apply
                {
                    Id = a.Id,
                    SiteId = a.SiteId,
                    ApplyName = a.ApplyName,
                    ApplyEmail = a.ApplyEmail,
                    ApplyPhone = a.ApplyPhone,
                    ApplyJob = a.ApplyJob,
                    ApplyCV = a.ApplyCV,
                    ApplyIntro = a.ApplyIntro
                })
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
