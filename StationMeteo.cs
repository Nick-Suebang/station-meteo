using System;
using System.Collections.Generic;

namespace station_meteo
{
    /// <summary>
    /// À chaque tic du minuteur, lit chaque capteur, ajoute la mesure à sa série et l'affiche sur son graphique.
    /// </summary>
    class StationMeteo : IStationMeteo
    {
        public const int PointsParSerieParDefaut = 10;
        public const int IntervalleParDefautEnSecondes = 10;

        private readonly List<(ICapteur capteur, IGraphique graphique, ISerieTemporelle serie)> _liens =
            new List<(ICapteur capteur, IGraphique graphique, ISerieTemporelle serie)>();
        private readonly Func<ISerieTemporelle> _creerSerie;
        private readonly Func<DateTime> _horloge;
        private readonly int _intervalleEnSecondes;
        private IMinuteur _minuteur;

        /// <param name="creerSerie">Fabrique des séries ; par défaut, une série de 10 points.</param>
        /// <param name="horloge">Source de l'heure des mesures ; par défaut, l'heure courante.</param>
        /// <param name="intervalleEnSecondes">Temps entre deux mesures.</param>
        public StationMeteo(
            Func<ISerieTemporelle> creerSerie = null,
            Func<DateTime> horloge = null,
            int intervalleEnSecondes = IntervalleParDefautEnSecondes)
        {
            if (intervalleEnSecondes <= 0)
                throw new ArgumentOutOfRangeException(nameof(intervalleEnSecondes));
            _creerSerie = creerSerie ?? (() => new SerieTemporelle(PointsParSerieParDefaut));
            _horloge = horloge ?? (() => DateTime.Now);
            _intervalleEnSecondes = intervalleEnSecondes;
        }

        public void Enregistrer(ICapteur capteur, IGraphique graphique)
        {
            if (capteur == null)
                throw new ArgumentNullException(nameof(capteur));
            if (graphique == null)
                throw new ArgumentNullException(nameof(graphique));
            _liens.Add((capteur, graphique, _creerSerie()));
        }

        public void MettreMinuteur(IMinuteur minuteur)
        {
            if (minuteur == null)
                throw new ArgumentNullException(nameof(minuteur));
            if (_minuteur != null)
                _minuteur.Tick -= OnTick;
            _minuteur = minuteur;
            _minuteur.Tick += OnTick;
        }

        public void Demarrer()
        {
            if (_minuteur == null)
                throw new InvalidOperationException("Appelez MettreMinuteur avant Demarrer.");
            _minuteur.Demarrer(_intervalleEnSecondes);
        }

        public void Arreter()
        {
            _minuteur?.Arreter();
        }

        private void OnTick()
        {
            var instant = _horloge();
            foreach (var (capteur, graphique, serie) in _liens)
            {
                serie.AjouterPoint(instant, capteur.LireMesure());
                serie.Afficher(graphique);
            }
        }
    }
}
