using System.ComponentModel.DataAnnotations;

namespace TTP.Models.Entities
{
    public class Hakkimizda
    {
        [Key]
        public int ID { get; set; }
        public string FotoURL { get; set; }
        public string Aciklama { get; set; }
    }
}