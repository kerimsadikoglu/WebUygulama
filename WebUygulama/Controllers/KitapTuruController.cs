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
            if(ModelState.IsValid)
            {
                _uygulamaDBContext.KitapTurleri.Add(kitapTuru);
                _uygulamaDBContext.SaveChanges();
                TempData["basarili"] = "Yeni Kitap Turu Başarıyla Oluşturuldu!";
                return RedirectToAction("Index", "KitapTuru");
            }
            return View();
            
        }

        public IActionResult Guncelle(int? id)
        {
            if(id== null || id==0)
            {
                return NotFound();
            }
            KitapTuru? kitapTuruVt = _uygulamaDBContext.KitapTurleri.Find(id);
            if(kitapTuruVt == null) 
            { 
                return NotFound(); 
            }
            return View(kitapTuruVt);
        }

        [HttpPost]
        public IActionResult Guncelle(KitapTuru kitapTuru)
        {
            if (ModelState.IsValid)
            {
                _uygulamaDBContext.KitapTurleri.Update(kitapTuru);
                _uygulamaDBContext.SaveChanges();
                TempData["basarili"] = "Kitap Turu Başarıyla Guncellendi!";
                return RedirectToAction("Index", "KitapTuru");
            }
            return View();

        }

        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            KitapTuru? kitapTuruVt = _uygulamaDBContext.KitapTurleri.Find(id);
            if (kitapTuruVt == null)
            {
                return NotFound();
            }
            return View(kitapTuruVt);
        }

        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            KitapTuru? kitapTuru = _uygulamaDBContext.KitapTurleri.Find(id);
            if(kitapTuru == null)
            {
                return NotFound();
            }
            _uygulamaDBContext.KitapTurleri.Remove(kitapTuru);
            _uygulamaDBContext.SaveChanges();
            TempData["basarili"] = "Kitap Silme İşlemi Başarılı!";
            return RedirectToAction("Index", "KitapTuru");


        }
    }
}
