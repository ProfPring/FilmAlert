using filmAlert.objects;
using System.Collections;

namespace filmAlert.interfaces
{
    public interface ICSVparser
    {
        public Dictionary<int, show> parseCSV(string csvFileLocation);
    }
}
