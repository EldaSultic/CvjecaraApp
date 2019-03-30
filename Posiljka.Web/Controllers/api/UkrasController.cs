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
    public class UkrasController : MyWebApiBaseController
    {
        public UkrasController(MyContext db) : base(db)
        {
        }
         [HttpGet]
        [Produces(typeof(UkrasPregledVM))]
        public ActionResult<UkrasPregledVM> Index()
        {
            var model = new UkrasPregledVM
            {
                rows = _db.Ukras
                    .Include(x=>x.Cijena)
                    .OrderByDescending(s => s.Id)                    
                    .Select(s => new UkrasPregledVM.Row
                    {
                        id=s.Id,
                        ukras = s.Naziv,
                        cijena = s.Cijena.CijenaPoKomadu.ToString(),               

                    }).ToList()
            };


            return Json(model);
        }
    }
}