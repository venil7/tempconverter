using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempConverter.Services
{
    public interface ITempConverter
    {
        double Convert(double value, ConversionType type);
    }
}
