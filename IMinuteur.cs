using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace station_meteo
{
    interface IMinuteur
    {
        void Demarrer(int intervalleEnSecondes);
        void Arreter();
        event Action Tick;
    }
}
