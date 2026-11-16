using System;

namespace station_meteo
{
    /// <summary>Suite de mesures datées, limitée aux plus récentes.</summary>
    interface ISerieTemporelle
    {
        void AjouterPoint(DateTime instant, float valeur);
        void Afficher(IGraphique graphique);
    }
}
