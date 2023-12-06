using CagriMerkezi2.Utility;

namespace CagriMerkezi2.Models
{

    public class CagriMerkeziRepository : Repository<CagriMerkezi>, ICagriMerkeziRepository
    {
        private UygulamaDbContext _uygulamaDbContext;
        public CagriMerkeziRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(CagriMerkezi cagrimerkezi)
        {
            var existingEntity = _uygulamaDbContext.CagriMerkezis.Find(cagrimerkezi.Id);

            if (existingEntity != null)
            {
                // Eğer varlık zaten takip ediliyorsa Attach veya Update yapabilirsiniz.
                _uygulamaDbContext.Entry(existingEntity).CurrentValues.SetValues(cagrimerkezi);
                // veya
                _uygulamaDbContext.Update(existingEntity);
            }
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }
    }
}  
