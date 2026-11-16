using System;
using System.Collections.Generic;
using System.Drawing;
using ZedGraph;

namespace station_meteo
{
    /// <summary>Adapte un contrôle ZedGraph à l'interface IGraphique.</summary>
    sealed class ZedGraphique : IGraphique
    {
        private readonly ZedGraphControl _zedGraph;
        private readonly PointPairList _points = new PointPairList();
        private readonly LineItem _courbe;

        public ZedGraphique(ZedGraphControl zedGraph)
        {
            _zedGraph = zedGraph ?? throw new ArgumentNullException(nameof(zedGraph));
            var pane = _zedGraph.GraphPane;
            pane.CurveList.Clear();
            _courbe = pane.AddCurve("", _points, Color.Black, SymbolType.Diamond);
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.Format = "HH:mm:ss";
        }

        public void Configurer(string titre, string axeX, string axeY, Color couleur)
        {
            var pane = _zedGraph.GraphPane;
            pane.Title.Text = titre;
            pane.XAxis.Title.Text = axeX;
            pane.YAxis.Title.Text = axeY;
            _courbe.Color = couleur;
        }

        public void Effacer()
        {
            _points.Clear();
        }

        public void Afficher(IEnumerable<(DateTime instant, float valeur)> valeurs)
        {
            Effacer();
            foreach (var (instant, valeur) in valeurs)
                _points.Add(instant.ToOADate(), valeur);
            _zedGraph.AxisChange();
            _zedGraph.Invalidate();
        }
    }
}
