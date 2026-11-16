using System.Collections.Generic;

namespace station_meteo
{
    /// <summary>Fournit l'historique des mesures d'un capteur.</summary>
    interface IDonnees
    {
        List<float> RecupererDonnees(string nomCapteur);
    }
}
