#if DEBUG
/*
 * Copyright (c) 2018 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 * 
 * http://github.com/piranhacms/piranha.core
 * 
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Piranha.AspNetCore.Identity.SQLServer
{
    /// <summary>
    /// Factory for creating a db context. Only used in dev mode
    /// when creating migrations.
    /// </summary>
    [NoCoverage]
    public class DbFactory : IDesignTimeDbContextFactory<IdentitySQLServerDb>
    {
        /// <summary>
        /// Creates a new db context.
        /// </summary>
        /// <param name="args">The arguments</param>
        /// <returns>The db context</returns>
        public IdentitySQLServerDb CreateDbContext(string[] args) 
        {
            var builder = new DbContextOptionsBuilder<IdentitySQLServerDb>();
            builder.UseSqlServer("Server=DESKTOP-0O2LH92\\SQLEXPRESS;Database=IDJ;User Id=sa;Password=123456aA@;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new IdentitySQLServerDb(builder.Options);
        }
    }
}
#endif