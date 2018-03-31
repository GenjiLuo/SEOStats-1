using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAlex.SEOStats
{
    public abstract class BaseResult
    {
        public abstract string ServiceName { get; }

        public abstract IDictionary<string, object> GetStats();

        public bool Success { get; set; }
    }
}
