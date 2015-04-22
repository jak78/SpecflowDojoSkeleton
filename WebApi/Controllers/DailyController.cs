using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using Model;

namespace WebApi.Controllers
{
    public class DailyController : ApiController
    {
        private readonly IDailyStore _dailyStore;
        private readonly IProjetStore _projectStore;

        public DailyController(IDailyStore dailyStore, IProjetStore projectStore)
        {
            _dailyStore = dailyStore;
            _projectStore = projectStore;
        }

        public HttpResponseMessage Post(Daily daily)
        {
            var project = _projectStore.Get(daily.Projet);
            if (project == null) return new HttpResponseMessage(HttpStatusCode.NotFound);

            _dailyStore.Register(daily);

            DecrementeLesChargesDesStories(daily, project);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        private void DecrementeLesChargesDesStories(Daily daily, Projet project)
        {
            var storyADecrementer = from tache in daily.Taches
                from story in project.Stories
                where tache.Story == story.Titre
                select story;
            foreach (var story in storyADecrementer)
            {
                story.DecrementeCharge();
            }
        }

        public Daily Get(string nomProjet, DateTime jour)
        {
            return _dailyStore.Get(nomProjet, jour);
        }
    }
}