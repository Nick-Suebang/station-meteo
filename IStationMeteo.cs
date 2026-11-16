namespace station_meteo
{
    /// <summary>Relie des capteurs à des graphiques et les met à jour au rythme d'un minuteur.</summary>
    interface IStationMeteo
    {
        void Enregistrer(ICapteur capteur, IGraphique graphique);
        void MettreMinuteur(IMinuteur minuteur);
        void Demarrer();
        void Arreter();
    }
}
