using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Posiljka.Data.EF;
using Posiljka.Data.EntityModels;
using Posiljka.Web.Helper.webapi;
using Posiljka.Web.ViewModels.api;

namespace Posiljka.Web.Controllers.api
{
    public class NarudzbaStavkaController : MyWebApiBaseController
    {

        public NarudzbaStavkaController(MyContext db) : base(db)
        {
        }
        [HttpPost]
        public void Add([FromBody]NovaStavkaAddVM data)
        {
            Narudzba_Stavka nova = new Narudzba_Stavka();
            nova.KolicinaCvjetova = data.kolicinaCvjetova;
            nova.KolicinaUkrasa = data.kolicinaUkrasa;
            nova.NarudzbaId = data.narudzbaId;
            nova.NarudzbaId = data.narudzbaId;
            nova.UkrasId = data.ukrasId;
            nova.VrstaCvijeta_BojaId = _db.VrstaCvijeta_Boja.Where(x=>x.VrstaCvijetaId==data.vrstaCvijetaId).FirstOrDefault().Id;

            _db.Narudzba_Stavka.Add(nova);
            _db.SaveChanges();

        }
        [HttpDelete("{stavkaId}")]
        public ActionResult Remove(int stavkaId)
        {
            Narudzba_Stavka ns = _db.Narudzba_Stavka.Find(stavkaId);
            if (ns != null)
            {
                _db.Narudzba_Stavka.Remove(ns);
                _db.SaveChanges();
            }
            return Ok(stavkaId);

        }
        [HttpGet]
        [Produces(typeof(TopPonudaPregledVM))]
        public ActionResult<TopPonudaPregledVM> Index()
        {
            var model = new TopPonudaPregledVM
            {
                rows = _db.TopPonuda
                    .Include(x => x.Cijena)
                    .OrderByDescending(s => s.Id)
                    .Select(s => new TopPonudaPregledVM.Row
                    {
                        id = s.Id,
                        naziv = s.Naziv,
                        opis = s.Opis,
                        cijena = s.Cijena.CijenaPoKomadu

                    }).ToList()
            };


            return Json(model);
        }
        [HttpGet]
        [Produces(typeof(NarudzbaStavkaPregledVM))]
        public ActionResult<NarudzbaStavkaPregledVM> IndexStavka(int narudzbaId)
        {
            var model = new NarudzbaStavkaPregledVM
            {
                    rows = _db.Narudzba_Stavka
                    .Where(x=>x.NarudzbaId == narudzbaId)
                    .Include(x => x.Ukras)
                    .Include(x => x.VrstaCvijeta_Boja)
                    .ThenInclude(x=>x.VrstaCvijeta)
                    .ThenInclude(x=>x.Cijena)
                    .Include(x=>x.Ukras)
                    .ThenInclude(x=>x.Cijena)
                    .OrderByDescending(s => s.Id)
                    .Select(s => new NarudzbaStavkaPregledVM.Row
                    {
                        id=s.Id,
                        cvijet = s.VrstaCvijeta_Boja.VrstaCvijeta.Vrsta + "/" + s.VrstaCvijeta_Boja.Boja.Naziv,
                        ukras = s.Ukras.Naziv,
                        kolicina_cvijet = s.KolicinaCvjetova ??0,
                        kolicina_ukras = s.KolicinaUkrasa ?? 0,
                        cijena_poKomaduUkrasa=s.Ukras.Cijena.CijenaPoKomadu*s.KolicinaUkrasa??0,
                        cijena_poKomaduCvijeta=s.VrstaCvijeta_Boja.VrstaCvijeta.Cijena.CijenaPoKomadu*s.KolicinaCvjetova??0
                    }).ToList()
            };

            return Json(model);
        }
    }
}