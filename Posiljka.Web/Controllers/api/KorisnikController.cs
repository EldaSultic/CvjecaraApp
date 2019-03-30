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
    public class KorisnikController : MyWebApiBaseController
    {
        public KorisnikController(MyContext db) : base(db)
        {
        }



        [HttpPost]
        public NarudzbaKreiranaVM Add([FromBody]KorisnikAddVM input)
        {
            Korisnik k = new Korisnik();
            k.Ime = input.ime;
            k.Prezime = input.prezime;
            k.Telefon = input.telefon;
            k.KorisnickiNalogId = input.korisnickiNalog;

            _db.Korisnik.Add(k);
            _db.SaveChanges();

            Narudzba n = _db.Narudzba.Include(x=>x.TopPonuda).Where(x => x.KorisnickiNalogId == k.KorisnickiNalogId).LastOrDefault();
            NarudzbaKreiranaVM result = new NarudzbaKreiranaVM();


            //Racunanje cijene
            if (n.TopPonudaId == null)
            {
                float sumaUkrasa = 0;
                float sumaCvijeca = 0;

                List<Narudzba_Stavka> stavke = new List<Narudzba_Stavka>();
                stavke = _db.Narudzba_Stavka.Where(x => x.NarudzbaId == n.Id).ToList();
                for (int i = 0; i < stavke.Count; i++)
                {
                    sumaUkrasa = 0;
                    sumaCvijeca = 0;
                    if (stavke[i].KolicinaCvjetova != 0) {
                    int stavkaBoja = stavke[i].VrstaCvijeta_BojaId ?? 0;
                    int vrstaCvijeta = _db.VrstaCvijeta_Boja.Where(x => x.Id == stavkaBoja).FirstOrDefault().VrstaCvijetaId;
                     int cijenaId= _db.VrstaCvijeta.Where(x => x.Id == vrstaCvijeta).FirstOrDefault().CijenaId;
                    sumaCvijeca+=_db.Cijena.Find(cijenaId).CijenaPoKomadu;
                    if (stavke[i].KolicinaCvjetova != 0)
                     sumaCvijeca *= stavke[i].KolicinaCvjetova??0;
                    }
                    if (stavke[i].KolicinaUkrasa != 0)
                    {
                        int ukrasId = stavke[i].UkrasId ?? 0;
                        int cijenaUkrasaId = _db.Ukras.Where(x => x.Id ==ukrasId).FirstOrDefault().CijenaId;
                        sumaUkrasa += _db.Cijena.Find(cijenaUkrasaId).CijenaPoKomadu;
                        if (stavke[i].KolicinaUkrasa != 0)
                            sumaUkrasa *= stavke[i].KolicinaUkrasa ?? 0;
                    }
                    result.konacnaCijena += (sumaUkrasa + sumaCvijeca);
                }
            }
            else
            {
                result.konacnaCijena = n.KonacnaCijena ?? 0;
            }
            result.id = n.Id;
           
            result.nalogId = n.KorisnickiNalogId;
            result.topPonudaId = n.TopPonudaId??0;
            if(n.TopPonudaId==null)
                result.nazivTopPonude = "Custom kreirana narudžba";
            else
            result.nazivTopPonude = n.TopPonuda.Naziv;
            result.posiljaoc = k.Ime + " " + k.Prezime;
            result.primaoc = n.imePrimaoca + " " + n.prezimePrimaoca;
            result.adresaPrimaoca = n.adresaPrimaoca;
            return result;
        }


    }
}