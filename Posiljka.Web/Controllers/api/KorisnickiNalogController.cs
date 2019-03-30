using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Posiljka.Data.EF;
using Posiljka.Data.EntityModels;
using Posiljka.Web.Helper.webapi;
using Posiljka.Web.ViewModels.api;

namespace Posiljka.Web.Controllers.api
{
    public class KorisnickiNalogController : MyWebApiBaseController
    {
        public KorisnickiNalogController(MyContext db) : base(db)
        {
        }
        [HttpPost]
        public KorisnickiNalogAddVM Add([FromBody]KorisnickiNalogAddVM input)
        {
            KorisnickiNalog nalog = new KorisnickiNalog();
            nalog.Emaik = input.Emaik;
            nalog.KorisnickoIme = input.KorisnickoIme;
            nalog.Lozinka = input.Lozinka;
            _db.KorisnickiNalog.Add(nalog);
            _db.SaveChanges();
            KorisnickiNalog nalogKreirani = _db.KorisnickiNalog
                    .Where(w => w.Id == nalog.Id).FirstOrDefault();
            KorisnickiNalogAddVM result = new KorisnickiNalogAddVM();
            result.Emaik = nalogKreirani.Emaik;
            result.KorisnickoIme = nalogKreirani.KorisnickoIme;
            result.Lozinka = nalogKreirani.Lozinka;

            return result;
           
        }

    }
}