using System.Drawing;
using station_meteo;

namespace StationMeteo.Tests
{
    /// <summary>Minuteur piloté à la main par les tests.</summary>
    sealed class MinuteurManuel : IMinuteur
    {
        public event Action Tick;
        public int? IntervalleDemande { get; private set; }
        public bool EnMarche { get; private set; }

        public void Demarrer(int intervalleEnSecondes)
        {
            IntervalleDemande = intervalleEnSecondes;
            EnMarche = true;
        }

        public void Arreter() => EnMarche = false;

        public void Declencher() => Tick?.Invoke();
    }

    /// <summary>Graphique qui retient simplement les derniers points affichés.</summary>
    sealed class GraphiqueEspion : IGraphique
    {
        public List<(DateTime instant, float valeur)> Points { get; } = new();

        public void Effacer() => Points.Clear();

        public void Afficher(IEnumerable<(DateTime instant, float valeur)> valeurs)
        {
            Points.Clear();
            Points.AddRange(valeurs);
        }

        public void Configurer(string titre, string axeX, string axeY, Color couleur) { }
    }

    sealed class CapteurSequence : ICapteur
    {
        private readonly Queue<float> _valeurs;
        public CapteurSequence(params float[] valeurs) => _valeurs = new Queue<float>(valeurs);
        public float LireMesure() => _valeurs.Dequeue();
    }

    sealed class DonneesFixes : IDonnees
    {
        private readonly List<float> _valeurs;
        public DonneesFixes(params float[] valeurs) => _valeurs = valeurs.ToList();
        public List<float> RecupererDonnees(string nomCapteur) => _valeurs;
    }

    /// <summary>Fichier CSV temporaire supprimé à la fin du test.</summary>
    sealed class FichierTemporaire : IDisposable
    {
        public FichierTemporaire(string contenu)
        {
            Chemin = Path.Combine(Path.GetTempPath(), $"station-meteo-{Guid.NewGuid():N}.csv");
            File.WriteAllText(Chemin, contenu);
        }

        public string Chemin { get; }

        public void Dispose() => File.Delete(Chemin);
    }
}
