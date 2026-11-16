using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace station_meteo
{
    interface IDonnees
    {
        List<float> RecupererDonnees(string nomCapteur);
    }
}
