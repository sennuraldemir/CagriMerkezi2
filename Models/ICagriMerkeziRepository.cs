namespace CagriMerkezi2.Models
{
    public interface ICagriMerkeziRepository : IRepository<CagriMerkezi>
    {

        void Guncelle(CagriMerkezi cagrimerkezi);

        void Kaydet();
    }
}
