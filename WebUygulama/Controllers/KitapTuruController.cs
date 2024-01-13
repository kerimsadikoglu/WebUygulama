using Microsoft.AspNetCore.Mvc;
using WebUygulamaProje1.Models;
using WebUygulamaProje1.Utility;

namespace WebUygulamaProje1.Controllers
{
    public class KitapTuruController : Controller
    {

        private readonly IKitapTuruRepository _kitapTuruReposity;

        public KitapTuruController (IKitapTuruRepository context)
        {
            _kitapTuruReposity = context;
        }
        public IActionResult Index()
        {
            List<KitapTuru> objKitapTuruList = _kitapTuruReposity.GetAll().ToList();

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
                _kitapTuruReposity.Ekle(kitapTuru);
                _kitapTuruReposity.Kaydet();
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
            KitapTuru? kitapTuruVt = _kitapTuruReposity.Get(u=>u.ID==id);
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
                _kitapTuruReposity.Guncelle(kitapTuru);
                _kitapTuruReposity.Kaydet();
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
            KitapTuru? kitapTuruVt = _kitapTuruReposity.Get(u => u.ID == id);
            if (kitapTuruVt == null)
            {
                return NotFound();
            }
            return View(kitapTuruVt);
        }

        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            KitapTuru? kitapTuru = _kitapTuruReposity.Get(u => u.ID == id);
            if (kitapTuru == null)
            {
                return NotFound();
            }
            _kitapTuruReposity.Sil(kitapTuru);
            _kitapTuruReposity.Kaydet();
            TempData["basarili"] = "Kitap Silme İşlemi Başarılı!";
            return RedirectToAction("Index", "KitapTuru");


        }
    }
}
