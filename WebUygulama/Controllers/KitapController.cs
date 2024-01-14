using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUygulamaProje1.Models;
using WebUygulamaProje1.Utility;

namespace WebUygulamaProje1.Controllers
{
    public class KitapController : Controller
    {

        private readonly IKitapRepository _kitapRepository;
        private readonly IKitapTuruRepository _kitapTuruRepository;

        public KitapController (IKitapRepository kitapRepository, IKitapTuruRepository kitapTuruRepository)
        {
            _kitapRepository = kitapRepository;
            _kitapTuruRepository = kitapTuruRepository;
        }
        public IActionResult Index()
        {
            List<Kitap> objKitapList = _kitapRepository.GetAll().ToList();
            

            return View(objKitapList);
        }
        public IActionResult EkleGuncelle(int? id)
        {
            IEnumerable<SelectListItem> KitapTuruList = _kitapTuruRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.Ad,
                    Value = k.ID.ToString()
                });
            ViewBag.KitapTuruList = KitapTuruList;

            if (id == null || id == 0)
            {
                // ekle
                return View();
            }
            else
            {
                // guncelleme
                Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id);  // Expression<Func<T, bool>> filtre
                if (kitapVt == null)
                {
                    return NotFound();
                }
                return View(kitapVt);
            }
        }

        [HttpPost]
        public IActionResult EkleGuncelle(Kitap kitap, IFormFile? file)
        {
            if(ModelState.IsValid)
            {
                _kitapRepository.Ekle(kitap);
                _kitapRepository.Kaydet();
                TempData["basarili"] = "Yeni Kitap Başarıyla Oluşturuldu!";
                return RedirectToAction("Index", "Kitap");
            }
            return View();
            
        }

        
        /*
        [HttpPost]
        public IActionResult Guncelle(Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                _kitapRepository.Guncelle(kitap);
                _kitapRepository.Kaydet();
                TempData["basarili"] = "Kitap Turu Başarıyla Guncellendi!";
                return RedirectToAction("Index", "Kitap");
            }
            return View();

        }
        */

        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id);
            if (kitapVt == null)
            {
                return NotFound();
            }
            return View(kitapVt);
        }

        [HttpPost, ActionName("Sil")]     
        public IActionResult SilPOST(int? id)
        {
            Kitap? kitap = _kitapRepository.Get(u => u.Id == id);
            if (kitap == null)
            {
                return NotFound();
            }
            _kitapRepository.Sil(kitap);
            _kitapRepository.Kaydet();
            TempData["basarili"] = "Kayıt Silme işlemi başarılı!";
            return RedirectToAction("Index", "Kitap");
        }
    }
}
