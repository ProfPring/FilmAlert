using filmAlert.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filmAlert.interfaces
{
    public interface IFilmSFinder
    {
        public List<show> ShowsOutToday(Dictionary<int, show> shows);
    }
}
