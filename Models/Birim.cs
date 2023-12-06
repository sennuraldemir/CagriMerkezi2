using System.ComponentModel.DataAnnotations;

namespace CagriMerkezi2.Models
{
    public class Birim
    {
        [Key]  //primary key
        public int Id { get; set; }

        //not null [Required]
        public string Ad { get; set; }

        public ICollection<Departman> DepList { get; set; }

        public ICollection<Sikayet> SikayetList { get; set; }

        public ICollection<Calisan> CalisanList { get; set; }

        public ICollection<CagriMerkezi> CagriList { get; set; }    
        

    }
}
