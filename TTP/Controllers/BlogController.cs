using System.Linq;
using System.Web.Mvc;
using TTP.Models.Entities;

namespace TTP.Controllers
{
    public class BlogController : Controller
    {
        Context context = new Context();
        BlogYorum bY = new BlogYorum();

        // GET: Blog
        public ActionResult Index()
        {
            // var bloglar = context.Blogs.ToList();
            bY.Deger1 = context.Blogs.ToList();
            bY.Deger3 = context.Blogs.Take(3).OrderByDescending(x => x.ID).ToList();
            bY.Deger4 = context.Yorumlars.Take(3).OrderByDescending(x => x.ID).ToList();
            return View(bY);
        }

        public ActionResult BlogDetay(int id)
        {
            // var blogBul = context.Blogs.Where(x => x.ID == id).ToList();
            bY.Deger1 = context.Blogs.Where(x => x.ID == id).ToList();
            bY.Deger2 = context.Yorumlars.Where(x => x.BlogID == id).ToList();
            bY.Deger3 = context.Blogs.Take(3).OrderByDescending(x => x.ID).ToList();
            bY.Deger4 = context.Yorumlars.Take(3).OrderByDescending(x => x.ID).ToList();
            return View(bY);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.Deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar yorumlar)
        {
            context.Yorumlars.Add(yorumlar);
            context.SaveChanges();
            return PartialView();
        }
    }
}