using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace station_meteo
{
    interface IStationMeteo
    {
        void Enregistrer(ICapteur capteur, IGraphique graphique);
        void MettreMinuteur(IMinuteur minuteur);    
        void Demarrer();
        void Arreter();
    }
}
