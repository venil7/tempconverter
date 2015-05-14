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
            var any = _farenheit.Any();
            if (!any || (any && _farenheit.Last() != value))
            {
                _farenheit.Add(value);
            }
        }

        public void AddCelsius(double value)
        {
            var any = _celsius.Any();
            if (!any || (any && _celsius.Last() != value))
            {
                _celsius.Add(value);
            }
        }

        public IEnumerable<TempPair> GetPairs()
        {
            return _farenheit
                .Zip(_celsius, (f, c) => new TempPair() { Celsius = c, Farenheit = f });
        }
    }
}
