using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace station_meteo
{
    class DonneesCsv : IDonnees
    {
        private string _cheminFichier;

        public DonneesCsv(string cheminFichier)
        {
            _cheminFichier = cheminFichier;
        }

        public List<float> RecupererDonnees(string nomCapteur)
        {
            var resultat = new List<float>();
            var parser = new TextFieldParser(_cheminFichier)
            {
                TextFieldType = FieldType.Delimited,
                Delimiters = new[] { "," },
                HasFieldsEnclosedInQuotes = true,
            };

            if (parser.EndOfData)
            {
                throw new InvalidOperationException("CSV vide");
            }
            string[] header = parser.ReadFields();

            int index = Array.IndexOf(header, nomCapteur);
            if (index < 0)
                throw new ArgumentException($"Colonne '{nomCapteur}' non trouvée");

            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();

                if (fields.Length <= index)
                {
                    continue;
                }

                if (float.TryParse(fields[index], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float valeur))
                {
                    resultat.Add(valeur);
                }
            }
            return resultat;
        }
    }
}
