using Microsoft.AspNetCore.Mvc;
using WebUygulamaProje1.Models;
using WebUygulamaProje1.Utility;

namespace WebUygulamaProje1.Controllers
{
    public class KitapTuruController : Controller
    {

        private readonly UygulamaDBContext _uygulamaDBContext;

        public KitapTuruController (UygulamaDBContext dbContext)
        {
            _uygulamaDBContext = dbContext;
        }
        public IActionResult Index()
        {
            List<KitapTuru> objKitapTuruList = _uygulamaDBContext.KitapTurleri.ToList();

            return View(objKitapTuruList);
        }
        public IActionResult Ekle()
        {  

            return View();
        }

        [HttpPost]
        public IActionResult Ekle(KitapTuru kitapTuru)
        {
            _uygulamaDBContext.KitapTurleri.Add(kitapTuru);
            _uygulamaDBContext.SaveChanges();
            return RedirectToAction("Index", "KitapTuru");
        }
    }
}
