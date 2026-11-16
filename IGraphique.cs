using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace station_meteo
{
    interface IGraphique
    {
        void Effacer();
        void Afficher(IEnumerable<(DateTime instant, float valeur)> valeurs);
        void Configurer(string titre, string axeX, string axeY, System.Drawing.Color couleur);
    }
}
