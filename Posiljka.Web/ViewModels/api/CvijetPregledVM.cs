using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Posiljka.Web.ViewModels.api
{
    public class CvijetPregledVM
    {
        public class Row
        {
            public int id;
            public String cvijet;
            public String cijena;
        }

        public List<Row> rows;
    }
}
