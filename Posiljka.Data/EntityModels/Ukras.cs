using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Posiljka.Data.EntityModels
{
    public class Ukras
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        // public int MyProperty { get; set; }

        [ForeignKey(nameof(Cijena))]
        public int CijenaId { get; set; }
        public Cijena Cijena { get; set; }
    }
}
