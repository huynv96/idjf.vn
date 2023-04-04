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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Piranha.Models;
using Piranha.Repositories;

namespace Piranha.Services
{
    public class ApplyService : IApplyService
    {
        private readonly IApplyRepository _repo;
        private readonly ISiteService _siteService;
        private readonly ICache _cache;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="db">The current db context</param>
        /// <param name="cache">The optional model cache</param>
        public ApplyService(IApplyRepository repo, ISiteService siteService, ICache cache = null)
        {
            _repo = repo;
            _siteService = siteService;

            if ((int)App.CacheLevel > 1)
            {
                _cache = cache;
            }
        }

        /// <summary>
        /// Gets all available models for the specified site.
        /// </summary>
        /// <param name="siteId">The optional site id</param>
        /// <returns>The available models</returns>
        public async Task<IEnumerable<Apply>> GetAllAsync(Guid? siteId = null)
        {
            if (!siteId.HasValue)
            {
                var site = await _siteService.GetDefaultAsync().ConfigureAwait(false);
                if (site != null)
                {
                    siteId = site.Id;
                }
            }

            if (siteId.HasValue)
            {
                return await _repo.GetAll(siteId.Value).ConfigureAwait(false);
            }
            return null;
        }
    }
}
