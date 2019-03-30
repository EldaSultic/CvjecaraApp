using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Posiljka.Web.ViewModels.api
{
    public class NarudzbaPregledVM
    {
        public class Row
        {
            public int narudzbaId;
            public int topPonudaId;
            public string naziv;
            public float cijena;
            public string datum;
        }
        public List<Row> rows;
    }
}
