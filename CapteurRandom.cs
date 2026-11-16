using System;

namespace station_meteo
{
    /// <summary>
    /// Capteur simulé qui renvoie une valeur aléatoire dans un intervalle.
    /// </summary>
    class CapteurRandom : ICapteur
    {
        // Un seul générateur partagé : créer un Random par lecture donnait la même valeur
        // à tous les capteurs lus dans la même milliseconde (.NET Framework se base sur l'horloge).
        private static readonly Random GenerateurPartage = new Random();

        private readonly float _minimum;
        private readonly float _maximum;
        private readonly Random _random;

        public CapteurRandom(float minimum, float maximum, Random random = null)
        {
            if (minimum > maximum)
                throw new ArgumentException("Le minimum doit être inférieur ou égal au maximum.", nameof(minimum));
            _minimum = minimum;
            _maximum = maximum;
            _random = random ?? GenerateurPartage;
        }

        public float LireMesure()
        {
            return (float)(_minimum + _random.NextDouble() * (_maximum - _minimum));
        }
    }
}
