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

            return View();
        }
    }
}
