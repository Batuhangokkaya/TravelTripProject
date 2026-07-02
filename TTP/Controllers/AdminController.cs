using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTP.Models.Entities;

namespace TTP.Controllers
{
    public class AdminController : Controller
    {
        Context context = new Context();
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            var degerler = context.Blogs.ToList();
            return View(degerler);
        }

        [HttpGet]
        [Authorize]
        public ActionResult YeniBlog()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult YeniBlog(Blog blog, HttpPostedFileBase BlogImageFile)
        {
            if (BlogImageFile != null && BlogImageFile.ContentLength > 0)
            {
                string fileName = Path.GetFileName(BlogImageFile.FileName);
                string path = Server.MapPath("/web2/Images/" + fileName);

                BlogImageFile.SaveAs(path);

                blog.BlogImage = "/web2/Images/" + fileName;
            }
            context.Blogs.Add(blog);
            context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [Authorize]
        public ActionResult BlogSil(int id)
        {
            var blog = context.Blogs.Find(id);

            if (blog != null)
            {
                string path = Server.MapPath(blog.BlogImage);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                context.Blogs.Remove(blog);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Admin");
        }

        [Authorize]
        public ActionResult BlogGetir(int id)
        {
            var bl = context.Blogs.Find(id);
            return View("BlogGetir", bl);
        }

        [Authorize]
        public ActionResult BlogGuncelle(Blog blog, HttpPostedFileBase BlogImageFile)
        {
            var blg = context.Blogs.Find(blog.ID);
            blg.Baslik   = blog.Baslik;
            blg.Aciklama = blog.Aciklama;
            blg.Tarih    = blog.Tarih;
            // Diğer Alanlar...

            if (BlogImageFile != null && BlogImageFile.ContentLength > 0)
            {
                // Yeni resmi Kaydet
                string fileName = Path.GetFileName(BlogImageFile.FileName);
                string newPath = Server.MapPath("/web2/Images/" + fileName);

                BlogImageFile.SaveAs(newPath);

                // Veritabanındaki Yolu Güncelle
                blg.BlogImage = "/web2/Images/" + fileName;
            }

            context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [Authorize]
        public ActionResult YorumListesi()
        {
            var yorumlar = context.Yorumlars.ToList();
            return View(yorumlar);
        }

        [Authorize]
        public ActionResult YorumSil(int id)
        {
            var yorum = context.Yorumlars.Find(id);
            context.Yorumlars.Remove(yorum);
            context.SaveChanges();
            return RedirectToAction("YorumListesi", "Admin");
        }

        [Authorize]
        public ActionResult YorumGetir(int id)
        {
            var yr = context.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }

        [Authorize]
        public ActionResult YorumGuncelle(Yorumlar yorumlar)
        {
            var yrm = context.Yorumlars.Find(yorumlar.ID);
            yrm.KullaniciAdi = yorumlar.KullaniciAdi;
            yrm.Mail         = yorumlar.Mail;
            yrm.Yorum        = yorumlar.Yorum;

            context.SaveChanges();
            return RedirectToAction("YorumListesi", "Admin");
        }

        [HttpGet]
        public ActionResult IletisimListesi()
        {
            var iltism = context.Iletisims.ToList();
            return View(iltism);
        }

        [Authorize]
        public ActionResult IletisimSil(int id)
        {
            var iltism = context.Iletisims.Find(id);
            context.Iletisims.Remove(iltism);
            context.SaveChanges();
            return RedirectToAction("IletisimListesi", "Admin");
        }

        [Authorize]
        public ActionResult IletisimGetir(int id)
        {
            var iltism = context.Iletisims.Find(id);
            return View("IletisimGetir", iltism);
        }

        [Authorize]
        public ActionResult IletisimGuncelle(Iletisim iletisim)
        {
            var iltism = context.Iletisims.Find(iletisim.ID);
            iltism.AdSoyad = iletisim.AdSoyad;
            iltism.Mail    = iletisim.Mail;
            iltism.Konu    = iletisim.Konu;
            iltism.Mesaj   = iletisim.Mesaj;
            context.SaveChanges();
            return RedirectToAction("IletisimListesi", iletisim);
        }

        [HttpGet]
        public ActionResult HakkimizdaListesi()
        {
            var hakimzda = context.Hakkimizdas.FirstOrDefault();
            return View(hakimzda);
        }

        [Authorize]
        public ActionResult HakkimizdaSil(int id)
        {
            var hakimzda = context.Hakkimizdas.Find(id);
            context.Hakkimizdas.Remove(hakimzda);
            context.SaveChanges();
            return RedirectToAction("HakkimizdaListesi", "Admin");
        }

        [Authorize]
        public ActionResult HakkimizdaGetir(int id)
        {
            var hakimzda = context.Hakkimizdas.Find(id);
            return View("HakkimizdaGetir", hakimzda);
        }

        [Authorize]
        public ActionResult HakkimizdaGuncelle(Hakkimizda hakkimizda)
        {
            var hakimzda = context.Hakkimizdas.Find(hakkimizda.ID);
            hakimzda.FotoURL  = hakkimizda.FotoURL;
            hakimzda.Aciklama = hakkimizda.Aciklama;
            context.SaveChanges();
            return RedirectToAction("HakkimizdaListesi", hakimzda);
        }
    }
}