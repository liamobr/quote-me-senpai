using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuoteMeSenpai.Models;

namespace QuoteMeSenpai.Controllers
{
    public class QuotesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("getquote")]
        public JsonResult GetQuote()
        {
            Quote quote = new Quote();
            
            return Json(quote);
        }
    }
}