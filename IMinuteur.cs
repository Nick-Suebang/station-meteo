using System;

namespace station_meteo
{
    /// <summary>Déclenche l'événement Tick à intervalle régulier.</summary>
    interface IMinuteur
    {
        event Action Tick;
        void Demarrer(int intervalleEnSecondes);
        void Arreter();
    }
}
