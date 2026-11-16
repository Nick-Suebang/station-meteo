using System;
using System.Windows.Forms;

namespace station_meteo
{
    /// <summary>Adapte le Timer de Windows Forms à l'interface IMinuteur.</summary>
    sealed class MinuteurWinForms : IMinuteur, IDisposable
    {
        private readonly Timer _timer = new Timer();

        public event Action Tick;

        public MinuteurWinForms()
        {
            _timer.Tick += (s, e) => Tick?.Invoke();
        }

        public void Demarrer(int intervalleEnSecondes)
        {
            _timer.Interval = intervalleEnSecondes * 1000;
            _timer.Start();
        }

        public void Arreter()
        {
            _timer.Stop();
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
