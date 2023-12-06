namespace CagriMerkezi2.Models
{
    public interface IDepartmanRepository : IRepository<Departman>
    {
        void Guncelle(Departman departman);

        void Kaydet();

        // Calisanlar ve Sikayetler index sayfalarında birime göre filtreleme için
        IEnumerable<Departman> GetDepartmentsByBirimId(int birimId);


        // Departman index sayfasında birime göre filtreleme için
        List<Departman> GetFilteredDep(int birimId);

    }
}
