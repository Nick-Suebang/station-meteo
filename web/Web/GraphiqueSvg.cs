using System.Drawing;
using station_meteo;

namespace StationMeteoWeb.Web
{
    /// <summary>
    /// Remplace ZedGraphique : implémente la même interface IGraphique, mais
    /// garde simplement les points en mémoire. Le composant Graphique.razor
    /// les dessine ensuite en SVG.
    /// </summary>
    public class GraphiqueSvg : IGraphique
    {
        private readonly List<(DateTime instant, float valeur)> _points = new List<(DateTime instant, float valeur)>();

        public IReadOnlyList<(DateTime instant, float valeur)> Points => _points;
        public string Titre { get; private set; } = "";
        /// <summary>Unité affichée à côté de la lecture (le titre de l'axe Y).</summary>
        public string Unite { get; private set; } = "";
        public string Couleur { get; private set; } = "currentColor";

        public void Configurer(string titre, string axeX, string axeY, Color couleur)
        {
            Titre = titre;
            // L'axe X est toujours le temps : son titre n'est pas affiché.
            Unite = axeY;
            Couleur = $"#{couleur.R:X2}{couleur.G:X2}{couleur.B:X2}";
        }

        public void Effacer()
        {
            _points.Clear();
        }

        void IGraphique.Afficher(IEnumerable<(DateTime instant, float valeur)> valeurs)
        {
            Effacer();
            _points.AddRange(valeurs);
        }
    }
}
