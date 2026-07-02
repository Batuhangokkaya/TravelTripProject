using System.Linq;
using System.Web.Mvc;
using TTP.Models.Entities;

namespace TTP.Controllers
{
    public class DefaultController : Controller
    {
        Context context = new Context();
        // GET: Default
        public ActionResult Index()
        {
            var degerler = context.Blogs.OrderByDescending(x => x.ID).Take(4).ToList();
            return View(degerler);
        }

        public PartialViewResult Partial1()
        {
            var degerler = context.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial2()
        {
            var degerler = context.Blogs.OrderByDescending(x => x.ID).Skip(2).Take(1).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial3()
        {
            var degerler = context.Blogs.OrderByDescending(x => x.ID).Take(10).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial4()
        {
            var degerler = context.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial5()
        {
            var degerler = context.Blogs.OrderByDescending(x => x.ID).Skip(3).Take(3).ToList();
            return PartialView(degerler);
        }
    }
}