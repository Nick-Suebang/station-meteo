using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace station_meteo
{
    class CapteurCsv : ICapteur
    {
        private List<float> _donnees;
        private int _index;

        public CapteurCsv(string nomCapteur, IDonnees donnees)
        {
            _donnees = donnees.RecupererDonnees(nomCapteur);
            _index = 0;
        }

        public float LireMesure()
        {
            if (_donnees.Count == 0)
            {
                return 0f;
            }
            if (_index < _donnees.Count)
            {
                return _donnees[_index++];
            }
            return _donnees[_donnees.Count - 1];
        }

    }
}