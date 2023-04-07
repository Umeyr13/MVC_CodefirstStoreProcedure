using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_CodefirstStoreProcedure.Models
{
    [Table ("Kitap")]
    public class Kitap
    {
        [Key]
        public int ID { get; set; }
        [Required,StringLength (50)]
        public string Adı { get; set; }
        public string Aciklama { get; set; }
        public DateTime YayinTarihi { get; set; }


    }
}