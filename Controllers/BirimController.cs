using CagriMerkezi2.Models;
using CagriMerkezi2.Utility;
using Microsoft.AspNetCore.Mvc;

namespace CagriMerkezi2.Controllers
{
    public class BirimController : Controller
    {
        private readonly IBirimRepository _birimRepository;

        public BirimController(IBirimRepository context)
        {
            _birimRepository = context;
        }

        public IActionResult Index()
        {
            List<Birim> objBirimList = _birimRepository.GetAll().ToList();

            return View(objBirimList);
        }

        public IActionResult Ekle()
        {

            return View();

        }

        [HttpPost]
        public IActionResult Ekle(Birim birim)

        {
            if (!ModelState.IsValid) // bunu yazmadan da çalışır ama bu kod birşey yazmadan butona bastığımızda hata vermeyi önlüyor cash den alıyor yani

            {
                _birimRepository.Ekle(birim);
                _birimRepository.Kaydet(); //SaveChanges() yapmazsak bilgiler veri tabanına eklenmez!
                TempData["basarili"] = "Yeni birim başarıyla oluşturuldu!";

                return RedirectToAction("Index", "Birim");// // danger kırmızı renkte uyarı vermesi için. boş geçilemez uyarısı veriyor.(ekle.cshtml içindeki 14.satıra yazdım bunu)

            }

            return View();

        }



        public IActionResult Guncelle(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Birim? birimVt = _birimRepository.Get(u => u.Id == id);//buraya yazılan id ye eşit olan kaydı getir demek parantez içinde yazılan

            if (birimVt == null)
            {
                return NotFound();
            }

            return View(birimVt);

        }

        [HttpPost]
        public IActionResult Guncelle(Birim birim)

        {
            if (!ModelState.IsValid) // bunu yazmadan da çalışır ama bu kod birşey yazmadan butona bastığımızda hata vermeyi önlüyor cash den alıyor yani

            {
                _birimRepository.Guncelle(birim);
                _birimRepository.Kaydet(); //SaveChanges() yapmazsak bilgiler veri tabanına eklenmez!
                TempData["basarili"] = "Yeni birim başarıyla güncellendi!";

                return RedirectToAction("Index", "Birim");//tıklanınca geri döneceği sayfa // danger kırmızı renkte uyarı vermesi için. boş geçilemez uyarısı veriyor.(ekle.cshtml içindeki 14.satıra yazdım bunu)

            }

            return View();

        }
        //GET ACTION
        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Birim? birimVt = _birimRepository.Get(u => u.Id == id);

            if (birimVt == null)
            {
                return NotFound();
            }

            return View(birimVt);

        }

        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)

        {
            Birim? birim = _birimRepository.Get(u => u.Id == id);
            if (birim == null)
            {
                return NotFound();
            }
            _birimRepository.Sil(birim);
            _birimRepository.Kaydet(); //SaveChanges() yapmazsak bilgiler veri tabanına eklenmez!
            TempData["basarili"] = "Kayıt silme işlemi başarılı!";
            return RedirectToAction("Index", "Birim");


        }


    }
}
