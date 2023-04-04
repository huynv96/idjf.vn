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
using System.Threading.Tasks;
using Piranha.Models;

namespace Piranha.Repositories
{
    public interface IApplyRepository
    {
        /// <summary>
        /// Gets all available models.
        /// </summary>
        /// <param name="siteId">The optional site id</param>
        /// <returns>The available models</returns>
        Task<IEnumerable<Apply>> GetAll(Guid siteId);

    }
}
