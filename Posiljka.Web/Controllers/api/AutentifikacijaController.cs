using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Posiljka.Data.EF;
using Posiljka.Data.EntityModels;
using Posiljka.Web.Helper;
using Posiljka.Web.Helper.webapi;
using Posiljka.Web.ViewModels.api;

namespace Posiljka.Web.Controllers.api
{
    public class AutentifikacijaController : MyWebApiBaseController
    {
        public AutentifikacijaController(MyContext db) : base(db)
        {
        }

        [HttpPost]
        public ActionResult<AutentifikacijaResultVM> LoginCheck([FromBody] AutentifikacijaLoginPostVM input)
        {
            string token = Guid.NewGuid().ToString();

            AutentifikacijaResultVM model = _db.KorisnickiNalog
                .Where(w => w.KorisnickoIme == input.Username && w.Lozinka == input.Password)
                .Select(s => new AutentifikacijaResultVM
                {
                    //ime = s.Ime,
                    korisnickiNalogId = s.Id,
                   // prezime = s.Prezime,
                    username = s.KorisnickoIme,
                    token = token,
                }).SingleOrDefault();


            if (model != null)
            {
                _db.AutorizacijskiToken.Add(new AutorizacijskiToken
                {
                    Vrijednost = model.token,
                    KorisnickiNalogId = model.korisnickiNalogId.Value,
                    VrijemeEvidentiranja = DateTime.Now,
                    deviceInfo = "Mobile app - " + input.deviceInfo,
                    IpAdresa = HttpContext.Connection.RemoteIpAddress + ":" + HttpContext.Connection.RemotePort
                });
                _db.SaveChanges();
                return model;
            }
        
                AutentifikacijaResultVM akoJeNull = new AutentifikacijaResultVM();
                akoJeNull.korisnickiNalogId = 0;
            

            return akoJeNull;
        }


        [HttpDelete]
        public ActionResult Logout()
        {
            string tokenString = HttpContext.GetMyAuthToken();
            AutorizacijskiToken autorizacijskiToken = _db.AutorizacijskiToken.Where(x => x.Vrijednost == tokenString).FirstOrDefault();
            if (autorizacijskiToken != null)
            {
                _db.Remove(autorizacijskiToken);
                _db.SaveChanges();
            }
            return Ok();
        }
    }
}
