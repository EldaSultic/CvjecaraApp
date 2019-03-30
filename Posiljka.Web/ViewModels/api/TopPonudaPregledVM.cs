using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Posiljka.Web.ViewModels.api
{
    public class TopPonudaPregledVM
    {
        public List<Row> rows { get; set; }

        public class Row
        {
            public int id { get; set; }
            public String naziv { get; set; }
            public String opis { get; set; }
            public float cijena { get; set; }
        }
    }
}
