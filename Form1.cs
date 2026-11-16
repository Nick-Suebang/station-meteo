using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace station_meteo
{
    public partial class Form1: Form
    {
        private StationMeteo _station = new StationMeteo();
        private IGraphique[] _graphique = new IGraphique[5];
        private bool utiliseCsv = true;
        public Form1()
        {
            InitializeComponent();
            var graphiques = new[] { zedGraphControl1, zedGraphControl2, zedGraphControl3, zedGraphControl4, zedGraphControl5 };

            var boutons = new[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5 };

            var noms = new[] { "Temp (°C)", "Hum. rel (%)", "Dir. du vent (10s deg)", "Vit. du vent (km/h)", "Pression à la station (kPa)" };

            Color[] couleursArcEnCiel = new Color[] { Color.Red, Color.Purple, Color.Orange, Color.Green, Color.Blue };

            for (int i = 0; i < 5; i++)
            {

                var graphique = new ZedGraphique(graphiques[i]);
                graphique.Configurer(titre: noms[i], axeX: "Temps", axeY: noms[i], couleur: couleursArcEnCiel[i]);
                _graphique[i] = graphique;

                graphiques[i].Visible = boutons[i].Checked;

            }

            var timer = new MinuteurWinForms();
            _station.MettreMinuteur(timer);

            InitialiserCapteurs();

        }

        private void InitialiserCapteurs()
        {

            var noms = new[] { "Temp (°C)", "Hum. rel (%)", "Dir. du vent (10s deg)", "Vit. du vent (km/h)", "Pression à la station (kPa)" };

            float[,] intervalleDonnées = new float[,] { { -10f, 30f }, { 0f, 100f }, { 0f, 359f }, { 0f, 100f }, { 95f, 105f } };

            _station.Arreter();
            _station = new StationMeteo();
            var timer = new MinuteurWinForms();
            ICapteur[] _capteur = new ICapteur[5];
            _station.MettreMinuteur(timer);

            for (int i = 0; i < 5; i++)
            {
                if (utiliseCsv)
                {
                    var provider = new DonneesCsv("donnees.csv");
                    _capteur[i] = new CapteurCsv(noms[i], provider);
                }
                else
                {
                    _capteur[i] = new CapteurRandom(intervalleDonnées[i, 0], intervalleDonnées[i, 1]);
                }
                _station.Enregistrer(_capteur[i], _graphique[i]);
            }

            _station.Demarrer();
        }


        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void zedGraphControl3_Load(object sender, EventArgs e)
        {

        }

        private void zedGraphControl2_Load(object sender, EventArgs e)
        {

        }

        private void zedGraphControl4_Load(object sender, EventArgs e)
        {

        }

        private void zedGraphControl5_Load(object sender, EventArgs e)
        {

        }

        private void zedGraphControl3_Load_1(object sender, EventArgs e)
        {

        }

        private void zedGraphControl5_Load_1(object sender, EventArgs e)
        {

        }

        private void zedGraphControl4_Load_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            zedGraphControl5.Visible = checkBox5.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            zedGraphControl1.Visible = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            zedGraphControl2.Visible = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            zedGraphControl3.Visible = checkBox3.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            zedGraphControl4.Visible = checkBox4.Checked;
        }

        private void capteurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utiliseCsv = false;
            InitialiserCapteurs();
        }

        private void capteurCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utiliseCsv = true;
            InitialiserCapteurs();
        }
    }
}
