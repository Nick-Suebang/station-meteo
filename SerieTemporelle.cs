using System;
using System.Collections.Generic;

namespace station_meteo
{
    /// <summary>
    /// Garde les derniers points d'une mesure : au-delà de la taille maximale, le plus ancien est retiré.
    /// </summary>
    class SerieTemporelle : ISerieTemporelle
    {
        private readonly int _maxPoints;
        private readonly LinkedList<(DateTime instant, float valeur)> _points = new LinkedList<(DateTime instant, float valeur)>();

        public SerieTemporelle(int maxPoints)
        {
            if (maxPoints <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxPoints));
            _maxPoints = maxPoints;
        }

        public void AjouterPoint(DateTime instant, float valeur)
        {
            _points.AddLast((instant, valeur));
            if (_points.Count > _maxPoints)
                _points.RemoveFirst();
        }

        public void Afficher(IGraphique graphique)
        {
            graphique.Afficher(_points);
        }
    }
}
