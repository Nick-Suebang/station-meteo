using System;
using System.IO;
using System.Windows.Forms;
using ZedGraph;

namespace station_meteo
{
    public partial class FenetrePrincipale : Form
    {
        private const string FichierCsv = "donnees.csv";

        private readonly ZedGraphControl[] _controlesGraphiques;
        private readonly CheckBox[] _casesCapteurs;
        private readonly IGraphique[] _graphiques;
        private StationMeteo _station;
        private MinuteurWinForms _minuteur;

        public FenetrePrincipale()
        {
            InitializeComponent();

            // Même ordre que DefinitionCapteur.Tous.
            _controlesGraphiques = new[] { graphiqueTemperature, graphiqueHumidite, graphiqueDirectionVent, graphiqueVitesseVent, graphiquePression };
            _casesCapteurs = new[] { caseTemperature, caseHumidite, caseDirectionVent, caseVitesseVent, casePression };

            var definitions = DefinitionCapteur.Tous;
            _graphiques = new IGraphique[definitions.Count];
            for (int i = 0; i < definitions.Count; i++)
            {
                var definition = definitions[i];
                _graphiques[i] = new ZedGraphique(_controlesGraphiques[i]);
                _graphiques[i].Configurer(definition.Titre, "Temps", definition.Unite, definition.Couleur);
                _casesCapteurs[i].Text = definition.Titre;
                _controlesGraphiques[i].Visible = _casesCapteurs[i].Checked;
            }

            InitialiserCapteurs(utiliseCsv: true);
        }

        private void InitialiserCapteurs(bool utiliseCsv)
        {
            IDonnees donnees = null;
            if (utiliseCsv)
            {
                string chemin = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FichierCsv);
                if (File.Exists(chemin))
                {
                    donnees = new DonneesCsv(chemin);
                }
                else
                {
                    MessageBox.Show(this, $"Le fichier {FichierCsv} est introuvable. La station utilise des capteurs aléatoires.",
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            ArreterStation();

            _station = new StationMeteo();
            _minuteur = new MinuteurWinForms();
            _station.MettreMinuteur(_minuteur);

            var definitions = DefinitionCapteur.Tous;
            for (int i = 0; i < definitions.Count; i++)
            {
                _graphiques[i].Effacer();
                _station.Enregistrer(definitions[i].CreerCapteur(donnees), _graphiques[i]);
            }

            _station.Demarrer();
        }

        private void ArreterStation()
        {
            _station?.Arreter();
            _minuteur?.Dispose();
        }

        private void CaseCapteur_CheckedChanged(object sender, EventArgs e)
        {
            int index = Array.IndexOf(_casesCapteurs, (CheckBox)sender);
            if (index >= 0)
                _controlesGraphiques[index].Visible = _casesCapteurs[index].Checked;
        }

        private void MenuCapteurCsv_Click(object sender, EventArgs e)
        {
            InitialiserCapteurs(utiliseCsv: true);
        }

        private void MenuCapteurAleatoire_Click(object sender, EventArgs e)
        {
            InitialiserCapteurs(utiliseCsv: false);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ArreterStation();
            base.OnFormClosed(e);
        }
    }
}
