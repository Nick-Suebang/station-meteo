namespace station_meteo
{
    /// <summary>Source d'une mesure (réelle ou simulée).</summary>
    interface ICapteur
    {
        float LireMesure();
    }
}
