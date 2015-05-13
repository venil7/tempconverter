using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TempConverter.Services
{
    public interface ITempStorage
    {
        void AddPair(TempPair pair);
        
        IEnumerable<TempPair> GetPairs();
    }
}
