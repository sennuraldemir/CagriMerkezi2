using CagriMerkezi2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CagriMerkezi2.Controllers
{
  public class DepartmanController : Controller
    { 
        private readonly IDepartmanRepository _departmanRepository;
        private readonly IBirimRepository _birimRepository;

        public DepartmanController( IDepartmanRepository departmanRepository ,IBirimRepository birimRepository )
        {
            _departmanRepository = departmanRepository;
            _birimRepository = birimRepository;

        }

        public IActionResult Index()
        {
            ViewBag.BrDepList = _birimRepository.GetAll()
        .Select(b => new SelectListItem
        {
            Text = b.Ad,
            Value = b.Id.ToString()
        }).ToList();

            List<Departman> objDepartmanList = _departmanRepository.GetAll(includeProps: "Birim").ToList();
            return View(objDepartmanList);
        }

        [HttpGet]
        public IActionResult GetFilteredDep(int birimId)
        {
            List<Departman> filteredDepList;

            if (birimId > 0)
            {
                filteredDepList = _departmanRepository.GetFilteredDep(birimId);
            }
            else
            {
                filteredDepList = _departmanRepository.GetAll(includeProps: "Birim").ToList();
            }

            return PartialView("_DepartmanListPartial", filteredDepList);
        }


        public IActionResult EkleGuncelle(int? id)
        {
            IEnumerable<SelectListItem> BirimList = _birimRepository.GetAll()
               .Select(k => new SelectListItem
               {
                   Text = k.Ad,
                   Value = k.Id.ToString()
               });

            ViewBag.BirimList = BirimList;//kitap türlerini seçip dolduruyoruz 30-36.satırlardaki kodlarla

            if (id== null || id==0)
            {
                //ekleme
                return View();
            }
            else
            {
                //guncelleme

                Departman? departmanVt = _departmanRepository.Get(u => u.Id == id);//buraya yazılan id ye eşit olan kaydı getir demek parantez içinde yazılan

                if (departmanVt == null)
                {
                    return NotFound();
                }

                return View(departmanVt);
            }
            
        
        }



        [HttpPost]
        public IActionResult EkleGuncelle(Departman departman)

        {
            //var errors=ModelState.Values.SelectMany(x=> x.Errors);

            if (!ModelState.IsValid) // bunu yazmadan da çalışır ama bu kod birşey yazmadan butona bastığımızda hata vermeyi önlüyor cash den alıyor yani
            
            {
                if (departman.Id == 0)
                {
                    _departmanRepository.Ekle(departman);
                    TempData["basarili"] = "Yeni departman bilgileri  başarıyla oluşturuldu!";

                }
                else
                {
                    _departmanRepository.Guncelle(departman);    
                    TempData["basarili"] = "Departman güncelleme  başarıyla oluşturuldu!";
                }
                
                _departmanRepository.Kaydet(); //SaveChanges() yapmazsak bilgiler veri tabanına eklenmez!
                

                return  RedirectToAction("Index","Departman");// // danger kırmızı renkte uyarı vermesi için. boş geçilemez uyarısı veriyor.(ekle.cshtml içindeki 14.satıra yazdım bunu)

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
            Departman? departmanVt = _departmanRepository.Get(u=>u.Id==id);

            if (departmanVt == null)
            {
                return NotFound();
            }

            return View(departmanVt);

        }

        [HttpPost , ActionName("Sil")]
        public IActionResult SilPOST(int? id)

        {
          Departman? departman= _departmanRepository.Get(u => u.Id == id);
            if (departman == null)
            {
                return NotFound();
            }
            _departmanRepository.Sil(departman);
            _departmanRepository.Kaydet(); //SaveChanges() yapmazsak bilgiler veri tabanına eklenmez!
            TempData["basarili"] = "Kayıt silme işlemi başarılı!";
            return RedirectToAction("Index", "Departman");

             
        }


    }
}
