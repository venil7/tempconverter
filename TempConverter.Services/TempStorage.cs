using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TempConverter.Services
{
    public class TempStorage : ITempStorage
    {
        private readonly IList<TempPair> _pairs;

        public TempStorage()
        {
            _pairs = new List<TempPair>();
        }

        public void AddPair(TempPair pair)
        {
            _pairs.Add(pair);
        }

        public IEnumerable<TempPair> GetPairs()
        {
            return _pairs.AsEnumerable();
        }
    }
}
