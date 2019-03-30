using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Posiljka.Data.EntityModels
{
    public class Narudzba_Stavka
    {
        public int Id { get; set; }

        [ForeignKey(nameof(VrstaCvijeta_Boja))]
        public int? VrstaCvijeta_BojaId { get; set; }
        public VrstaCvijeta_Boja VrstaCvijeta_Boja { get; set; }

        [ForeignKey(nameof(Ukras))]
        public int? UkrasId { get; set; }
        public Ukras Ukras { get; set; }

        [ForeignKey(nameof(Narudzba))]
        public int NarudzbaId { get; set; }
        public Narudzba Narudzba { get; set; }

        public int? KolicinaCvjetova { get; set; }

        public int? KolicinaUkrasa { get; set; }


    }
}
