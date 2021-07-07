using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOefening_1_Web___Media_Collection.Controllers
{
    public class PlaylistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
