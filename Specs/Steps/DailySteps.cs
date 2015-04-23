using System;
using System.Linq;
using ApiClient;
using Model;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace Specs.Steps
{
    [Binding]
    public class DailySteps
    {
        private V1Client _client;
        private Daily _daily;
        private DateTime _aujourdhui;
        private IRestResponse<Daily> _result;

        public DailySteps(WebClientContext context)
        {
            _client = context.WebClient;
        }

        [Given(@"que nous sommes le '(.*)'")]
        public void SoitQueNousSommesLe(DateTime date)
        {
            _aujourdhui = date;
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
            _client.PosterDaily(_daily);
            _result = _client.RecupererDaily(_daily.Projet, _aujourdhui);
            Assert.That(_result.Data, Is.Not.Null); // Sanity check
        }

        [Then(@"la partie est (.*)")]
        public void AlorsLaPartieEst(string resultat)
        {
            Assert.That(_result.Data.ResultatDePartie, Is.EqualTo(resultat));
        }


    }
}
