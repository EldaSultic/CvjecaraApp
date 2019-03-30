using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Posiljka.Data.EntityModels
{
   public class VrstaCvijeta_Boja
    {
        public int Id { get; set; }

        [ForeignKey(nameof(VrstaCvijeta))]
        public int VrstaCvijetaId { get; set; }
        public VrstaCvijeta VrstaCvijeta { get; set; }

        [ForeignKey(nameof(Boja))]
        public int BojaId { get; set; }
        public Boja Boja { get; set; }


    }
}
