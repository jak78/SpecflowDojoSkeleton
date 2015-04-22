using System;

namespace Model
{
    public class Daily
    {
        public string Projet { get; set; }
        public Tache[] Taches { get; set; }
        public DateTime Date { get; set; }
        public string ResultatDePartie { get; set; }

        public void DetermineResultatDeLaPartie(Projet project)
        {
            string resultat;
            if (project.EnRetard(Date))
            {
                resultat = "perdue";
            }
            else if (project.Terminé())
            {
                resultat = "gagnée";
            }
            else
            {
                resultat = "en cours";
            }

            ResultatDePartie = resultat;
        }
    }
}