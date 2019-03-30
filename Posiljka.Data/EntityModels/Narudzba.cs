using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Posiljka.Data.EntityModels
{
   public class Narudzba
    {
        public int Id { get; set; }

        [ForeignKey(nameof(KorisnickiNalog))]
        public int KorisnickiNalogId { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }


        [ForeignKey(nameof(TopPonuda))]
        public int? TopPonudaId { get; set; }
        public TopPonuda TopPonuda { get; set; }

        public float? KonacnaCijena { get; set; }
        public String imePrimaoca { get; set; }
        public String prezimePrimaoca { get; set; }
        public String adresaPrimaoca { get; set; }
        public String Poruka { get; set; }
        public String BrojKartice { get; set; }
        public String DatumUplate { get; set; }



    }
}
