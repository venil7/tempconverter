using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TempConverter.Services
{
    public class TempStorage : ITempStorage
    {
        private readonly IList<double> _farenheit;
        private readonly IList<double> _celsius;

        public TempStorage()
        {
            _farenheit = new List<double>();
            _celsius = new List<double>();
        }

        public void AddFarenheit(double value)
        {
            _farenheit.Add(value);
        }

        public void AddCelsius(double value)
        {
            _celsius.Add(value);
        }

        public IEnumerable<TempPair> GetPairs()
        {
            return _farenheit
                .Zip(_celsius, (f, c) => new TempPair() { Celsius = c, Farenheit = f });
        }
    }
}
