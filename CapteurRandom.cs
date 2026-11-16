using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace station_meteo
{
    class CapteurRandom : ICapteur
    {
        private float _minimum;
        private float _maximum;
        private Random _random;

        public CapteurRandom(float minimum, float maximum)
        {
            _minimum = minimum;
            _maximum = maximum;
        }

        public float LireMesure()
        {
            _random = new Random();
            return (float)(_minimum + _random.NextDouble() * (_maximum - _minimum));
        }
    }
}
