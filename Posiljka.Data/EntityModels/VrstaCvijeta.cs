using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Posiljka.Data.EntityModels
{
   public class VrstaCvijeta
    {
        public int Id { get; set; }
        public string Vrsta { get; set; }

        [ForeignKey(nameof(Cijena))]
        public int CijenaId { get; set; }
        public Cijena Cijena { get; set; }
    }
}
