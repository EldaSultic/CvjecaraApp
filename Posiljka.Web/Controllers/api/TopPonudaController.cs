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
    public class TopPonudaController : MyWebApiBaseController
    {
        public TopPonudaController(MyContext db) : base(db)
        {
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        
        [HttpGet]
        [Produces(typeof(TopPonudaPregledVM))]
        public ActionResult<TopPonudaPregledVM> Index()
        {
            var model = new TopPonudaPregledVM
            {
                rows = _db.TopPonuda
                    .Include(x=>x.Cijena)
                    .OrderByDescending(s => s.Id)                    
                    .Select(s => new TopPonudaPregledVM.Row
                    {
                        id=s.Id,
                        naziv = s.Naziv,
                        opis = s.Opis,
                        cijena = s.Cijena.CijenaPoKomadu                

                    }).ToList()
            };


            return Json(model);
        }


    }
}