using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeautyCenterCore.Models;
using BeautyCenterCore.BLL;

namespace BeautyCenterCore.Controllers
{
    public class CargadorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
