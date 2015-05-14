using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TempConverter.Services
{
    public interface ITempStorage
    {
        void AddFarenheit(double value);

        void AddCelsius(double value);
        
        IEnumerable<TempPair> GetPairs();
    }
}
