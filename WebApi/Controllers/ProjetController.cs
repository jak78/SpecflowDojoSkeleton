using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using ApiClient;
using Database;
using Model;

namespace WebApi.Controllers
{
    public class ProjetController : ApiController
    {
        private readonly IProjetStore _projetStore;

        public ProjetController(IProjetStore projetStore)
        {
            _projetStore = projetStore;
        }

        public ProjetJson Post(NouveauProjet nouveauProjet)
        {
            if (nouveauProjet.DateDeRelease == null || nouveauProjet.DateDeDebut == null || !nouveauProjet.Stories.Any())
            {
                throw  new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var stories = nouveauProjet.Stories.Select(s => new Story(s.Titre,s.Charge));
            var projet = new Projet(nouveauProjet.Nom,nouveauProjet.DateDeDebut.Value,nouveauProjet.DateDeRelease.Value,stories);
            _projetStore.Register(projet);
            return ToProjetJson(projet);;
        }

        private static ProjetJson ToProjetJson(Projet projet)
        {
            DateTime aujourdhui = DateTime.Today;
            var terminé = projet.Terminé();
            var enRetard = projet.EnRetard(aujourdhui);
            var result = new ProjetJson
            {
                Date = projet.Date,
                DateDeRelease= projet.DateDeRelease,
                Nom= projet.Nom,
                Stories = projet.Stories.Select(s=>new StoryJson{Charge=s.Charge,Titre=s.Titre}).ToList(),
                Termine = terminé,
                EnRetard = enRetard,
            };
            return result;
        }

        public ProjetJson Get(string id)
        {
            var projet = _projetStore.Get(id);
            return ToProjetJson(projet);
        }
    }
}