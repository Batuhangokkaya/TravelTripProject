using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTP.Models.Entities;

namespace TTP.Controllers
{
    public class AboutController : Controller
    {
        Context context = new Context();

        // GET: About
        public ActionResult Index()
        {
            var degerler = context.Hakkimizdas.ToList();
            return View(degerler);
        }
    }
}