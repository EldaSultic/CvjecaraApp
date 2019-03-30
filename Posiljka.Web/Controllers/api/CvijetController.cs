using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Posiljka.Data.EF;
using Posiljka.Web.Helper.webapi;
using Posiljka.Web.ViewModels.api;

namespace Posiljka.Web.Controllers.api
{
    public class CvijetController : MyWebApiBaseController
    {
        public CvijetController(MyContext db) : base(db)
        {
        }
          [HttpGet]
        [Produces(typeof(CvijetPregledVM))]
        public ActionResult<CvijetPregledVM> Index()
        {
            var model = new CvijetPregledVM
            {
                rows = _db.VrstaCvijeta_Boja
                     .Include(x => x.Boja)
                    .Include(x=>x.VrstaCvijeta)
                    .ThenInclude(x=>x.Cijena)
                    .OrderByDescending(s => s.Id)                    
                    .Select(s => new CvijetPregledVM.Row
                    {
                        id=s.VrstaCvijetaId,
                        cvijet = s.VrstaCvijeta.Vrsta+ "/"+s.Boja.Naziv,
                        cijena = s.VrstaCvijeta.Cijena.CijenaPoKomadu.ToString(),               

                    }).ToList()
            };


            return Json(model);
        }

    }
}