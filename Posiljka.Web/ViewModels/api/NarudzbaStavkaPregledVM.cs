using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Posiljka.Web.ViewModels.api
{
    public class NarudzbaStavkaPregledVM
    {
        public class Row 
        {
        public int id;
        public int narudzbaId;
        public String cvijet;
        public String ukras;
        public int kolicina_cvijet;
        public int kolicina_ukras;
        public float cijena_poKomaduUkrasa;
        public float cijena_poKomaduCvijeta;


        }
        public List<Row> rows;
}
}
