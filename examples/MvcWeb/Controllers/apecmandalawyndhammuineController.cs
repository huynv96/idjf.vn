﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcWeb.Controllers
{
    public class apecmandalawyndhammuineController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}