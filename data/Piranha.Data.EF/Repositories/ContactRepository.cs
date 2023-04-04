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
    public class ContactRepository : IContactRepository
    {
        private readonly IDb _db;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="db">The current db context</param>
        public ContactRepository(IDb db)
        {
            _db = db;
        }

        /// <summary>
        /// Gets all available models for the specified site.
        /// </summary>
        /// <param name="siteId">The site id</param>
        /// <returns>The available models</returns>
        public async Task<IEnumerable<Contact>> GetAll(Guid siteId)
        {
            return await _db.Contacts
                .AsNoTracking()
                .Select(a => new Contact
                {
                    Id = a.Id,
                    SiteId = a.SiteId,
                    ContactName = a.ContactName,
                    ContactEmail = a.ContactEmail,
                    ContactTitle = a.ContactTitle,
                    ContactContent = a.ContactContent
                })
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
