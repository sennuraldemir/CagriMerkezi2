using CagriMerkezi2.Utility;

namespace CagriMerkezi2.Models
{
    public class CalisanRepository : Repository<Calisan>, ICalisanRepository
    {
        private UygulamaDbContext _uygulamaDbContext;

        public CalisanRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;

        }

        public List<Calisan> GetFilteredCalisanlar(int birimId)
        {
            // Veritabanından ilgili birime ait sikayetleri çek
            var filteredCalisanlar = _uygulamaDbContext.Calisanlar
                .Where(s => s.BirimId == birimId)
                .ToList();

            // Sonuçları döndür
            return filteredCalisanlar;
        }

        public void Guncelle(Calisan calisan)
        {
            var existingEntity = _uygulamaDbContext.Calisanlar.Find(calisan.Id);

            if(existingEntity != null)
            {
                _uygulamaDbContext.Entry(existingEntity).CurrentValues.SetValues(calisan);

                _uygulamaDbContext.Update(existingEntity);
            }
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }  

    }
}