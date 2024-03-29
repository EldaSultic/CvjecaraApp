﻿using System.Collections.Specialized;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Posiljka.Data.EF;
using Posiljka.Data.EntityModels;

namespace Posiljka.Web.Helper.webapi
{
    [Route("api/[controller]/[action]")]
    public abstract class MyWebApiBaseController : Controller
    {
        protected readonly MyContext _db;

        protected MyWebApiBaseController(MyContext db)
        {
            _db = db;
        }

        protected KorisnickiNalog AuthKorisnickiNalog => HttpContext.GetKorisnikOfAuthToken();
       // protected Kategorija AuthKorisnik => _db.Korisnik.SingleOrDefault(s => s.KorisnickiNalogId == AuthKorisnickiNalog.Id);
    }
}
