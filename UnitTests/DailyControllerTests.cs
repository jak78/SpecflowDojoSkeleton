using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Model;
using NUnit.Framework;
using WebApi.Controllers;

namespace UnitTests
{
    [TestFixture]
    public class DailyControllerTests
    {
        private DailyController _tested;
        private DummyDailyStore _dailyStore;
        private DummyProjetStore _projetStore;

        [SetUp]
        public void Setup()
        {
            _dailyStore = new DummyDailyStore();
            _projetStore = new DummyProjetStore();
            _tested = new DailyController(_dailyStore,_projetStore);
        }

        [Test]
        public void Quand_je_poste_un_daily_je_recupere_une_200()
        {
            var projet = new Projet("Crocto", new DateTime(2012, 08, 17), new DateTime(2013, 08, 17),
                new[] { new Story("Test", 100), });

            _projetStore.Register(projet);


            HttpResponseMessage result = _tested.Post(new Daily {Projet = "Crocto", Taches = new []{new Tache{Story = "Test", Par = "Alice"}}});
            Assert.That(result.StatusCode,Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void Quand_je_poste_un_daily_je_peux_recuperer_le_detail_pour_la_journee()
        {
            var projet = new Projet("Crocto", new DateTime(2012, 08, 17), new DateTime(2013, 08, 17),
                new[] {new Story("Test", 100),});

           _projetStore.Register(projet);

            var dailyDate = DateTime.Today;
            _tested.Post(new Daily { Projet = "Crocto", Date = dailyDate, Taches = new[] { new Tache { Story = "Test", Par = "Alice" } } });

            var result = _tested.Get("Crocto",dailyDate);
            Assert.That(result.Date, Is.EqualTo(dailyDate));
            Assert.That(result.Taches.Count(),Is.EqualTo(1));
        }

        [Test]
        public void Quand_je_poste_un_daily_avec_une_tache_alors_la_charge_de_la_story_baisse()
        {
            var projet = new Projet("Crocto", new DateTime(2012, 08, 17), new DateTime(2013, 08, 17),
                new[] { new Story("Test", 100), });

            _projetStore.Register(projet);

            _tested.Post(new Daily { Projet = "Crocto", Taches = new[] { new Tache { Story = "Test", Par = "Alice" } } });

            var actualProjet = _projetStore.Get("Crocto");
            Assert.That(actualProjet.Stories.First().Charge, Is.EqualTo(99));
        }

        [Test]
        public void Quand_je_poste_un_daily_avec_2_taches_sur_2_stories_alors_la_charge_des_2_stories_baisse()
        {
            var projet = new Projet("Crocto", new DateTime(2012, 08, 17), new DateTime(2013, 08, 17),
                new[] { new Story("Test", 100), new Story("Test 2", 200), });

            _projetStore.Register(projet);

            _tested.Post(new Daily { Projet = "Crocto", Taches = new[] { new Tache { Story = "Test", Par = "Alice" }, new Tache { Story = "Test 2", Par = "Alice" } } });

            var actualProjet = _projetStore.Get("Crocto");
            Assert.That(actualProjet.Stories.First().Charge, Is.EqualTo(99));
            Assert.That(actualProjet.Stories.Last().Charge, Is.EqualTo(199));
        }

        [Test]
        public void Quand_la_charge_d_une_story_passe_a_zero_alors_elle_disparait()
        {
            var projet = new Projet("Crocto", new DateTime(2012, 08, 17), new DateTime(2013, 08, 17),
                new[] { new Story("Test", 100), new Story("Test 2", 1), });

            _projetStore.Register(projet);

            _tested.Post(new Daily { Projet = "Crocto", Taches = new[] { new Tache { Story = "Test 2", Par = "Alice" } } });

            var actualProjet = _projetStore.Get("Crocto");
            Assert.That(actualProjet.Stories.Count(), Is.EqualTo(1));
            Assert.That(actualProjet.Stories.First().Titre, Is.EqualTo("Test"));
        }


        [Test]
        public void Quand_je_poste_un_daily_pour_un_projet_qui_n_existe_pas_j_ai_une_400()
        {
            var result = _tested.Post(new Daily { Projet = "Crocto", Taches = new[] { new Tache { Story = "Test", Par = "Alice" } } });
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        
        }

        [Test]
        public void Quand_je_poste_un_daily_je_constate_que_la_partie_est_toujours_en_cours()
        {
            var dailyDate = new DateTime(2013, 1, 1);
            var projet = new Projet("Crocto", new DateTime(2012, 08, 17), new DateTime(2013, 08, 17),
                new[] { new Story("Test", 100), });

            _projetStore.Register(projet);

            _tested.Post(new Daily { Projet = "Crocto", Date = dailyDate, Taches = new[] { new Tache { Story = "Test", Par = "Alice" } } });

            var result = _tested.Get("Crocto", dailyDate);
            Assert.That(result.ResultatDePartie, Is.EqualTo("en cours"));
        }

        [Test]
        public void Quand_je_poste_un_daily_je_constate_que_la_partie_est_gagnée()
        {
            var dailyDate = new DateTime(2013,1,1);

            var projet = new Projet("Crocto", new DateTime(2012, 08, 17), new DateTime(2013, 08, 17),
                new[] { new Story("Test", 1), });

            _projetStore.Register(projet);

            _tested.Post(new Daily { Projet = "Crocto", Date = dailyDate, Taches = new[] { new Tache { Story = "Test", Par = "Alice" } } });

            var result = _tested.Get("Crocto", dailyDate);
            Assert.That(result.ResultatDePartie, Is.EqualTo("gagnée"));
        }

        [Test]
        public void Quand_je_poste_un_daily_je_constate_que_la_partie_est_perdue()
        {
            var dailyDate = new DateTime(2013, 8, 18);
            var projet = new Projet("Crocto", new DateTime(2012, 08, 17), new DateTime(2013, 08, 17),
                new[] { new Story("Test", 2), });

            _projetStore.Register(projet);

            _tested.Post(new Daily { Projet = "Crocto", Date = dailyDate, Taches = new[] { new Tache { Story = "Test", Par = "Alice" } } });

            var result = _tested.Get("Crocto", dailyDate);
            Assert.That(result.ResultatDePartie, Is.EqualTo("perdue"));
        }
    }
}
