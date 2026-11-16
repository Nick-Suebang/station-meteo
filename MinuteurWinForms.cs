using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace station_meteo
{
    class MinuteurWinForms : IMinuteur
    {
        private Timer _timer;
        public event Action Tick;

        public MinuteurWinForms()
        {
            _timer = new Timer();
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
    }
}
