using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAlex.SEOStats
{
    public interface IBaseStats<T> where T : BaseResult
    {
        T GetStats(string domain);
    }
}
