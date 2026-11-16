using System;
using System.Collections.Generic;
using System.Drawing;

namespace station_meteo
{
    /// <summary>Surface d'affichage d'une série de mesures datées.</summary>
    interface IGraphique
    {
        void Effacer();
        void Afficher(IEnumerable<(DateTime instant, float valeur)> valeurs);
        void Configurer(string titre, string axeX, string axeY, Color couleur);
    }
}
