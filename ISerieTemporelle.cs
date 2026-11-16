using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace station_meteo
{
    interface ISerieTemporelle
    {
        void AjouterPoint(DateTime instant, float valeur);
        void Afficher(IGraphique graphique);
    }
}
