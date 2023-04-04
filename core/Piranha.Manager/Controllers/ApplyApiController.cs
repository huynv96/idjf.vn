/*
 * Copyright (c) 2019 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * https://github.com/piranhacms/piranha.core
 *
 */

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Piranha.Manager.Models;
using Piranha.Manager.Services;

namespace Piranha.Manager.Controllers
{
    /// <summary>
    /// Api controller for alias management.
    /// </summary>
    [Area("Manager")]
    [Route("manager/api/apply")]
    [Authorize(Policy = Permission.Admin)]
    [ApiController]
    public class ApplyApiController : Controller
    {
        private readonly IApi _api;
        private readonly ApplyService _service;
        private readonly ManagerLocalizer _localizer;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ApplyApiController(IApi api, ApplyService service, ManagerLocalizer localizer)
        {
            _api = api;
            _service = service;
            _localizer = localizer;
        }

        /// <summary>
        /// Gets the list model.
        /// </summary>
        /// <returns>The list model</returns>
        [Route("list/{siteId?}")]
        [HttpGet]
        // [Authorize(Policy = Permission.Contacts)]
        public async Task<ApplyListModel> List(Guid? siteId = null)
        {
            return await _service.GetList(siteId);
        }
    }
}