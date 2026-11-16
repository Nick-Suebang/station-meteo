using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace station_meteo
{
    class SerieTemporelle : ISerieTemporelle
    {
        private int _maxPoints;
        private LinkedList<(DateTime, float)> _points = new LinkedList<(DateTime, float)>();

        public SerieTemporelle(int maxPoints)
        {
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
