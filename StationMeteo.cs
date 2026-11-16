using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace station_meteo
{
    class StationMeteo : IStationMeteo
    {
        private List<(ICapteur capteur, IGraphique graphique, ISerieTemporelle serie)> _liens = new List<(ICapteur capteur, IGraphique graphique, ISerieTemporelle serie)>();
        private IMinuteur _minuteur;

        public void Enregistrer(ICapteur cap, IGraphique graph)
        {
            var serie = new SerieTemporelle(10);
            _liens.Add((cap, graph, serie));
        }

        public void MettreMinuteur(IMinuteur minuteur)
        {
            _minuteur = minuteur;
            _minuteur.Tick += OnTick;
        }

        public void Demarrer()
        {
            _minuteur.Demarrer(10);
        }

        public void Arreter()
        {
            _minuteur.Arreter();
        }

        private void OnTick()
        {
            var instant = DateTime.Now;
            foreach (var (capteur, graphique, serie) in _liens)
            {
                float valeur = capteur.LireMesure();
                serie.AjouterPoint(instant, valeur);
                serie.Afficher(graphique);
            }
        }
    }
}