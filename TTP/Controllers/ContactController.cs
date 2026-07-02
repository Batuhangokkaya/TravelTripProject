using System.Linq;
using System.Web.Mvc;
using TTP.Models.Entities;

namespace TTP.Controllers
{
    public class ContactController : Controller
    {
        Context context  = new Context();
        IletisimAdres iA = new IletisimAdres();
        // GET: Contact
        public ActionResult Index()
        {
            iA.Deger2 = context.AdresBlogs.ToList();
            ViewBag.Aciklama = context.AdresBlogs.FirstOrDefault(x => x.ID == 1).Aciklama;
            return View(iA);
        }

        [HttpPost]
        public ActionResult IletisimGonder(Iletisim iletisim)
        {
            context.Iletisims.Add(iletisim);
            context.SaveChanges();
            return RedirectToAction("Index", "Contact");
        }
    }
}