using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class ProjetTests
    {
        private Projet _projet;
        private DateTime _now = new DateTime(2015,4,15);

        [Test]
        public void QuandIlResteDesStorieAlorsLeProjetNEstPasTermine()
        {
            IEnumerable<Story> stories = new List<Story> { new Story("première story", 1 ), new Story("seconde story", 1) };
            _projet = new Projet("un projet", new DateTime(2015,1,1), new DateTime(2018,1,1), stories );

            Assert.That(_projet.Terminé(), Is.False );
        }

        [Test]
        public void QuandIlNeRestePlusDeStoriesAlorsLeProjetEstTermine()
        {
            IEnumerable<Story> stories = new List<Story>();
            _projet = new Projet("un projet", new DateTime(2015, 1, 1), new DateTime(2018, 1, 1), stories);

            Assert.That(_projet.Terminé(), Is.True);
        }

        [Test]
        public void QuandLaDateDeReleaseNEstPasPasséeAlorsLeProjetNEstPasEnRetard()
        {
            IEnumerable<Story> stories = new List<Story> { new Story("première story", 1), new Story("seconde story", 1) };
            _projet = new Projet("un projet", new DateTime(2015, 1, 1), new DateTime(2018, 1, 1), stories);

            Assert.That( _projet.EnRetard(_now), Is.False);
        }

        [Test]
        public void QuandLaDateDeReleaseEstPasséeAlorsLeProjetEstEnRetard()
        {
            IEnumerable<Story> stories = new List<Story> { new Story("première story", 1), new Story("seconde story", 1) };
            _projet = new Projet("un projet", new DateTime(2015, 1, 1), new DateTime(2015, 2, 1), stories);

            Assert.That(_projet.EnRetard(_now), Is.True);
        }
        [Test]
        public void QuandLaDateDeReleaseEstPasséeMaisQueLeProjetEstTerminéAlorsLeProjetNEstPasEnRetard()
        {
            IEnumerable<Story> stories = new List<Story>();
            _projet = new Projet("un projet", new DateTime(2015, 1, 1), new DateTime(2015, 2, 1), stories);

            Assert.That(_projet.EnRetard(_now), Is.False);
        }

    }
}
