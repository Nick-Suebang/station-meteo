using System.Collections.Generic;
using System.Drawing;

namespace station_meteo
{
    /// <summary>
    /// Tout ce qu'il faut savoir sur un capteur de la station : sa colonne dans le CSV,
    /// comment l'afficher et l'intervalle de ses valeurs simulées.
    /// </summary>
    sealed class DefinitionCapteur
    {
        public DefinitionCapteur(string colonneCsv, string titre, string unite, Color couleur,
                                 float minimum, float maximum, int decimales)
        {
            ColonneCsv = colonneCsv;
            Titre = titre;
            Unite = unite;
            Couleur = couleur;
            Minimum = minimum;
            Maximum = maximum;
            Decimales = decimales;
        }

        public string ColonneCsv { get; }
        public string Titre { get; }
        public string Unite { get; }
        public Color Couleur { get; }
        public float Minimum { get; }
        public float Maximum { get; }
        public int Decimales { get; }

        public ICapteur CreerCapteur(IDonnees donnees)
        {
            return donnees != null
                ? (ICapteur)new CapteurCsv(ColonneCsv, donnees)
                : new CapteurRandom(Minimum, Maximum);
        }

        /// <summary>Les cinq capteurs de la station, dans l'ordre d'affichage.</summary>
        public static IReadOnlyList<DefinitionCapteur> Tous { get; } = new[]
        {
            new DefinitionCapteur("Temp (°C)", "Température", "°C", Color.FromArgb(0xC8, 0x32, 0x2B), -10f, 30f, 1),
            new DefinitionCapteur("Hum. rel (%)", "Humidité relative", "%", Color.FromArgb(0x7A, 0x3E, 0x9D), 0f, 100f, 0),
            // Le CSV exprime la direction en dizaines de degrés (21 = 210°).
            new DefinitionCapteur("Dir. du vent (10s deg)", "Direction du vent", "× 10°", Color.FromArgb(0xC2, 0x6A, 0x12), 0f, 36f, 0),
            new DefinitionCapteur("Vit. du vent (km/h)", "Vitesse du vent", "km/h", Color.FromArgb(0x2B, 0x7A, 0x4B), 0f, 100f, 0),
            new DefinitionCapteur("Pression à la station (kPa)", "Pression", "kPa", Color.FromArgb(0x1F, 0x5F, 0xB8), 95f, 105f, 2),
        };
    }
}
