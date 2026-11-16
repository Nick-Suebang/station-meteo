using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualBasic.FileIO;

namespace station_meteo
{
    /// <summary>
    /// Lit les mesures d'une colonne d'un fichier CSV dont la première ligne contient les noms de colonnes.
    /// </summary>
    class DonneesCsv : IDonnees
    {
        private readonly string _cheminFichier;

        public DonneesCsv(string cheminFichier)
        {
            _cheminFichier = cheminFichier ?? throw new ArgumentNullException(nameof(cheminFichier));
        }

        /// <summary>
        /// Renvoie une valeur par ligne valide, pour que toutes les colonnes restent alignées dans le temps :
        /// une ligne dont le nombre de champs ne correspond pas à l'en-tête est ignorée, et une valeur
        /// illisible est remplacée par la dernière valeur lue.
        /// </summary>
        public List<float> RecupererDonnees(string nomCapteur)
        {
            using (var parser = new TextFieldParser(_cheminFichier))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.Delimiters = new[] { "," };
                parser.HasFieldsEnclosedInQuotes = true;

                if (parser.EndOfData)
                    throw new InvalidOperationException($"Le fichier '{_cheminFichier}' est vide.");

                string[] entete = parser.ReadFields();
                int index = Array.IndexOf(entete, nomCapteur);
                if (index < 0)
                    throw new ArgumentException($"Colonne '{nomCapteur}' introuvable dans '{_cheminFichier}'.", nameof(nomCapteur));

                var resultat = new List<float>();
                float? derniereValeur = null;
                while (!parser.EndOfData)
                {
                    string[] champs = parser.ReadFields();
                    if (champs.Length != entete.Length)
                        continue;

                    if (EssayerLireNombre(champs[index], out float valeur))
                        derniereValeur = valeur;

                    if (derniereValeur.HasValue)
                        resultat.Add(derniereValeur.Value);
                }
                return resultat;
            }
        }

        /// <summary>
        /// Accepte le point ou la virgule comme séparateur décimal et ignore les espaces parasites ("99. 76").
        /// </summary>
        internal static bool EssayerLireNombre(string texte, out float valeur)
        {
            string normalise = texte.Replace(" ", "").Replace(',', '.');
            return float.TryParse(normalise, NumberStyles.Float, CultureInfo.InvariantCulture, out valeur);
        }
    }
}
