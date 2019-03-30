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
    public class NadudzbaController : MyWebApiBaseController
    {
        public NadudzbaController(MyContext db) : base(db)
        {
        }
        [HttpGet]
        [Produces(typeof(NarudzbaPregledVM))]
        public ActionResult<NarudzbaPregledVM> Index(int KorisnickiNalogId)
        {
            var model = new NarudzbaPregledVM
            {
                rows = _db.Narudzba
                .Where(x=>x.KorisnickiNalogId== KorisnickiNalogId && x.KonacnaCijena.HasValue && x.KonacnaCijena != 0 && x.DatumUplate != null)
                   .Include(x=>x.TopPonuda)
                    .OrderByDescending(s => s.Id)
                    .Select(s => new NarudzbaPregledVM.Row
                    {
                       
                        narudzbaId = s.Id,
                        topPonudaId=s.TopPonudaId??0,
                        naziv = s.TopPonuda.Naziv,
                        cijena=s.KonacnaCijena??0,
                        datum=s.DatumUplate                               
                    }).ToList()
            };


            return Json(model);
        }

        [HttpPost]
        public NarudzbaKreiranaVM Add([FromBody]NarudzbaAddVM data)
        {
            Narudzba nova = new Narudzba();
            nova.KorisnickiNalogId = data.nalogId;
            if (data.topPonudaId != 0)
            {
                nova.KonacnaCijena = data.konacnaCijena;
                nova.TopPonudaId = data.topPonudaId;
            }
           
            _db.Narudzba.Add(nova);
            _db.SaveChanges();
            Narudzba narudzba = _db.Narudzba
                    .Where(w => w.KorisnickiNalogId == nova.KorisnickiNalogId).Last();
            NarudzbaKreiranaVM result = new NarudzbaKreiranaVM();
            result.id = narudzba.Id;
            result.topPonudaId = narudzba.TopPonudaId ??0;
            result.nalogId = narudzba.KorisnickiNalogId;
            result.konacnaCijena = narudzba.KonacnaCijena??0;

            return result;

        }

        [HttpPut]
        public void PutPrimaoc([FromBody]NarudzbaUpdateAddPrimaocVM data)
        {
            Narudzba n = _db.Narudzba.Find(data.id);
            n.adresaPrimaoca = data.adresa;
            n.imePrimaoca = data.ime;
            n.prezimePrimaoca = data.prezime;

            _db.SaveChanges();


        }
        [HttpPut]
        public void PutUplata([FromBody]NarudzbaUpdateAddUplata data)
        {
            Narudzba n = _db.Narudzba.Find(data.idNarudzbe);
            n.BrojKartice = data.brojKartice;
            n.DatumUplate = data.datumUplate;
            n.Poruka = data.poruka;
            n.KonacnaCijena = 0;
 
            float sumaUkrasa = 0;
            float sumaCvijeca = 0;

            List<Narudzba_Stavka> stavke = new List<Narudzba_Stavka>();
            stavke = _db.Narudzba_Stavka.Where(x => x.NarudzbaId == data.idNarudzbe).ToList();
            for (int i = 0; i < stavke.Count; i++)
            {
                sumaUkrasa = 0;
                sumaCvijeca = 0;
                if (stavke[i].KolicinaCvjetova != 0)
                {
                    int stavkaBoja = stavke[i].VrstaCvijeta_BojaId ?? 0;
                    int vrstaCvijeta = _db.VrstaCvijeta_Boja.Where(x => x.Id == stavkaBoja).FirstOrDefault().VrstaCvijetaId;
                    int cijenaId = _db.VrstaCvijeta.Where(x => x.Id == vrstaCvijeta).FirstOrDefault().CijenaId;
                    sumaCvijeca += _db.Cijena.Find(cijenaId).CijenaPoKomadu;
                    if (stavke[i].KolicinaCvjetova != 0)
                        sumaCvijeca *= stavke[i].KolicinaCvjetova ?? 0;
                }
                if (stavke[i].KolicinaUkrasa != 0)
                {
                    int ukrasId = stavke[i].UkrasId ?? 0;
                    int cijenaUkrasaId = _db.Ukras.Where(x => x.Id == ukrasId).FirstOrDefault().CijenaId;
                    sumaUkrasa += _db.Cijena.Find(cijenaUkrasaId).CijenaPoKomadu;
                    if (stavke[i].KolicinaUkrasa != 0)
                        sumaUkrasa *= stavke[i].KolicinaUkrasa ?? 0;
                }
                n.KonacnaCijena += (sumaUkrasa + sumaCvijeca);
            }


            _db.SaveChanges();


        }
    }
}