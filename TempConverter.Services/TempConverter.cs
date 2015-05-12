using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempConverter.Services
{
    public class TempConverter : ITempConverter
    {
        private const double _conversionConst1 = 1.8;
        private const double _conversionConst2 = 32;

        private double CelsiusToFarenheit(double input)
        {
            return input * _conversionConst1 + _conversionConst2;
        }

        private double FarenheitToCelsius(double input)
        {
            return (input - _conversionConst2) / _conversionConst1;
        }

        public double Convert(double value, ConversionType type)
        {
            var raw = (type == ConversionType.CelsiusToFarenheit)
                ? CelsiusToFarenheit(value)
                : FarenheitToCelsius(value);
            return Math.Round(raw, 2);
        }
    }
}
