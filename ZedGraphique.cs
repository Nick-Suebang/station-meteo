using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace station_meteo
{
    class ZedGraphique : IGraphique
    {
        private ZedGraphControl _zedGraph;
        private PointPairList _points;

        public ZedGraphique(ZedGraphControl zedGraph)
        {
            _zedGraph = zedGraph;
            _points = new PointPairList();
            _zedGraph.GraphPane.CurveList.Clear();
            _zedGraph.GraphPane.AddCurve("", _points, System.Drawing.Color.Black, SymbolType.Diamond);
            _zedGraph.GraphPane.XAxis.Type = AxisType.Date;
            _zedGraph.GraphPane.XAxis.Scale.Format = "HH:mm:ss";
        }

        public void Configurer(string titre, string axeX, string axeY, System.Drawing.Color couleur)
        {
            var pane = _zedGraph.GraphPane;
            pane.Title.Text = titre;
            pane.XAxis.Title.Text = axeX;
            pane.YAxis.Title.Text = axeY;
            ((LineItem)pane.CurveList[0]).Color = couleur;
        }

        public void Effacer()
        {
            _points.Clear();
        }

        public void Afficher(IEnumerable<(DateTime instant, float valeur)> valeurs)
        {
            Effacer();
            foreach (var (instant, valeur) in valeurs)
            {
                double x = instant.ToOADate();
                _points.Add(x, valeur);
            }
            _zedGraph.AxisChange();
            _zedGraph.Invalidate();
        }
    }
}
