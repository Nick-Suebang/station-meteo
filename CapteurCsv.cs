using System;
using System.Collections.Generic;

namespace station_meteo
{
    /// <summary>
    /// Rejoue une à une les mesures d'une colonne ; une fois la fin atteinte, renvoie la dernière mesure.
    /// </summary>
    class CapteurCsv : ICapteur
    {
        private readonly List<float> _donnees;
        private int _index;

        public CapteurCsv(string nomCapteur, IDonnees donnees)
        {
            if (donnees == null)
                throw new ArgumentNullException(nameof(donnees));
            _donnees = donnees.RecupererDonnees(nomCapteur);
        }

        public float LireMesure()
        {
            if (_donnees.Count == 0)
                return 0f;
            if (_index < _donnees.Count)
                return _donnees[_index++];
            return _donnees[_donnees.Count - 1];
        }
    }
}
