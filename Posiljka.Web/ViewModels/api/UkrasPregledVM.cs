using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Posiljka.Web.ViewModels.api
{
    public class UkrasPregledVM
    {
        public class Row
        {
            public int id;
            public String ukras;
            public String cijena;
        }

        public List<Row> rows;
    }
}
