using station_meteo;

namespace StationMeteo.Tests
{
    public class StationMeteoTests
    {
        private static readonly DateTime Midi = new DateTime(2024, 1, 1, 12, 0, 0);

        [Fact]
        public void ChaqueTicAfficheLaMesureDuCapteurSurSonGraphique()
        {
            var minuteur = new MinuteurManuel();
            var graphique = new GraphiqueEspion();
            var station = new station_meteo.StationMeteo(horloge: () => Midi);
            station.MettreMinuteur(minuteur);
            station.Enregistrer(new CapteurSequence(1f, 2f), graphique);

            minuteur.Declencher();
            minuteur.Declencher();

            Assert.Equal(new[] { (Midi, 1f), (Midi, 2f) }, graphique.Points);
        }

        [Fact]
        public void DemarrerUtiliseLIntervalleConfigure()
        {
            var minuteur = new MinuteurManuel();
            var station = new station_meteo.StationMeteo(intervalleEnSecondes: 3);
            station.MettreMinuteur(minuteur);

            station.Demarrer();

            Assert.True(minuteur.EnMarche);
            Assert.Equal(3, minuteur.IntervalleDemande);
        }

        [Fact]
        public void DemarrerSansMinuteurDonneUneErreurClaire()
        {
            var station = new station_meteo.StationMeteo();

            Assert.Throws<InvalidOperationException>(() => station.Demarrer());
        }

        [Fact]
        public void ArreterSansMinuteurNeFaitRien()
        {
            new station_meteo.StationMeteo().Arreter();
        }

        [Fact]
        public void ChangerDeMinuteurDetacheLAncien()
        {
            var ancien = new MinuteurManuel();
            var nouveau = new MinuteurManuel();
            var graphique = new GraphiqueEspion();
            var station = new station_meteo.StationMeteo();
            station.MettreMinuteur(ancien);
            station.MettreMinuteur(nouveau);
            station.Enregistrer(new CapteurSequence(5f), graphique);

            ancien.Declencher();

            Assert.Empty(graphique.Points);
        }
    }

    public class SerieTemporelleTests
    {
        [Fact]
        public void GardeSeulementLesDerniersPoints()
        {
            var serie = new SerieTemporelle(3);
            var graphique = new GraphiqueEspion();
            var debut = new DateTime(2024, 1, 1);

            for (int i = 1; i <= 5; i++)
                serie.AjouterPoint(debut.AddSeconds(i), i);
            serie.Afficher(graphique);

            Assert.Equal(new[] { 3f, 4f, 5f }, graphique.Points.Select(p => p.valeur));
        }

        [Fact]
        public void RefuseUneTailleNulle()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SerieTemporelle(0));
        }
    }

    public class CapteurTests
    {
        [Fact]
        public void CapteurCsvRejoueLesValeursPuisRepeteLaDerniere()
        {
            var capteur = new CapteurCsv("x", new DonneesFixes(1f, 2f));

            Assert.Equal(new[] { 1f, 2f, 2f }, new[] { capteur.LireMesure(), capteur.LireMesure(), capteur.LireMesure() });
        }

        [Fact]
        public void CapteurCsvSansDonneesRenvoieZero()
        {
            Assert.Equal(0f, new CapteurCsv("x", new DonneesFixes()).LireMesure());
        }

        [Fact]
        public void CapteurRandomResteDansSonIntervalle()
        {
            var capteur = new CapteurRandom(95f, 105f, new Random(42));

            for (int i = 0; i < 1000; i++)
                Assert.InRange(capteur.LireMesure(), 95f, 105f);
        }

        [Fact]
        public void DesCapteursRandomLusEnMemeTempsDonnentDesValeursDifferentes()
        {
            // Régression : chaque capteur créait son propre Random à chaque lecture.
            var capteurs = Enumerable.Range(0, 5).Select(_ => new CapteurRandom(0f, 1f)).ToList();

            var valeurs = capteurs.Select(c => c.LireMesure()).ToList();

            Assert.Equal(valeurs.Count, valeurs.Distinct().Count());
        }

        [Fact]
        public void CapteurRandomRefuseUnIntervalleInverse()
        {
            Assert.Throws<ArgumentException>(() => new CapteurRandom(10f, 0f));
        }
    }

    public class DonneesCsvTests
    {
        [Fact]
        public void LitLaColonneDemandee()
        {
            using var fichier = new FichierTemporaire("a,b\n1,\"2.5\"\n3,\"4.5\"\n");

            Assert.Equal(new[] { 2.5f, 4.5f }, new DonneesCsv(fichier.Chemin).RecupererDonnees("b"));
        }

        [Fact]
        public void IgnoreLesLignesQuiNOntPasLeBonNombreDeChamps()
        {
            using var fichier = new FichierTemporaire("a,b\n1,2\n9,8,7\n3,4\n");

            Assert.Equal(new[] { 2f, 4f }, new DonneesCsv(fichier.Chemin).RecupererDonnees("b"));
        }

        [Fact]
        public void AccepteLaVirguleEtLesEspacesDansLesNombres()
        {
            using var fichier = new FichierTemporaire("a\n\"101,44\"\n\"99. 76\"\n");

            Assert.Equal(new[] { 101.44f, 99.76f }, new DonneesCsv(fichier.Chemin).RecupererDonnees("a"));
        }

        [Fact]
        public void RemplaceUneValeurIllisibleParLaPrecedentePourResterAligne()
        {
            using var fichier = new FichierTemporaire("a\n1\nM\n3\n");

            Assert.Equal(new[] { 1f, 1f, 3f }, new DonneesCsv(fichier.Chemin).RecupererDonnees("a"));
        }

        [Fact]
        public void ColonneInconnueDonneUneErreurClaire()
        {
            using var fichier = new FichierTemporaire("a\n1\n");

            Assert.Throws<ArgumentException>(() => new DonneesCsv(fichier.Chemin).RecupererDonnees("z"));
        }

        [Fact]
        public void LeFichierEstLibereApresLaLecture()
        {
            var fichier = new FichierTemporaire("a\n1\n");
            new DonneesCsv(fichier.Chemin).RecupererDonnees("a");

            // Sous Windows, la suppression échouerait si le fichier était encore ouvert.
            fichier.Dispose();

            Assert.False(File.Exists(fichier.Chemin));
        }
    }

    public class DonneesReellesTests
    {
        [Fact]
        public void ToutesLesColonnesDuFichierOntLeMemeNombreDeValeursPlausibles()
        {
            var donnees = new DonneesCsv("donnees.csv");

            var colonnes = DefinitionCapteur.Tous.ToDictionary(d => d.Titre, d => donnees.RecupererDonnees(d.ColonneCsv));

            Assert.All(colonnes.Values, valeurs => Assert.Equal(2160, valeurs.Count));
            Assert.All(colonnes["Pression"], p => Assert.InRange(p, 95f, 105f));
            Assert.All(colonnes["Humidité relative"], h => Assert.InRange(h, 0f, 100f));
            Assert.All(colonnes["Direction du vent"], d => Assert.InRange(d, 0f, 36f));
        }
    }
}
