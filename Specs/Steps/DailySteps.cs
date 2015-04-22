using System;
using System.Linq;
using ApiClient;
using Model;
using TechTalk.SpecFlow;

namespace Specs.Steps
{
    [Binding]
    public class DailySteps
    {
        private V1Client _client;
        private Daily _daily;
        private DateTime _aujourdhui;

        public DailySteps(WebClientContext context)
        {
            _client = context.WebClient;
        }

        [Given(@"le daily pour le projet '(.*)'")]
        public void SoitLeDailyPourLeProjet(string projet)
        {
            _daily = new Daily
            {
                Projet = projet,
                Taches = new Tache[0],
                Date = _aujourdhui
            };

        }


        [Given(@"que '(.*)' travaille sur '(.*)'")]
        public void SoitQueTravailleSur(string developpeur, string story)
        {
            _daily.Taches = _daily.Taches.Concat(new[] { new Tache { Par = developpeur, Story = story } }).ToArray();
        }


        [When(@"la journée se termine")]
        public void QuandLaJourneeSeTermine()
        {
            var result = _client.PosterDaily(_daily);
        }

        [Then(@"le projet est terminé à temps")]
        public void AlorsLeProjetEstTermineATemps()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"le projet est en retard")]
        public void AlorsLeProjetEstEnRetard()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
