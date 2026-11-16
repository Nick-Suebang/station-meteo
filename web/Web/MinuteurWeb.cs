using station_meteo;

namespace StationMeteoWeb.Web
{
    /// <summary>
    /// Remplace MinuteurWinForms : même interface IMinuteur, mais basé sur un
    /// minuteur qui fonctionne dans le navigateur. La vitesse permet d'accélérer
    /// la démo (10 = une mesure par seconde au lieu d'une toutes les 10 s).
    /// </summary>
    class MinuteurWeb : IMinuteur, IDisposable
    {
        private readonly System.Timers.Timer _timer = new System.Timers.Timer();
        private int _intervalleEnSecondes = 10;
        private int _vitesse = 1;

        public event Action Tick;

        public MinuteurWeb()
        {
            _timer.AutoReset = true;
            _timer.Elapsed += (s, e) => Tick?.Invoke();
        }

        public int Vitesse
        {
            get => _vitesse;
            set
            {
                _vitesse = Math.Max(1, value);
                AppliquerIntervalle();
            }
        }

        public void Demarrer(int intervalleEnSecondes)
        {
            _intervalleEnSecondes = intervalleEnSecondes;
            AppliquerIntervalle();
            _timer.Start();
            // Première mesure tout de suite, pour ne pas laisser l'écran vide.
            Tick?.Invoke();
        }

        public void Arreter()
        {
            _timer.Stop();
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        private void AppliquerIntervalle()
        {
            _timer.Interval = _intervalleEnSecondes * 1000.0 / _vitesse;
        }
    }
}
