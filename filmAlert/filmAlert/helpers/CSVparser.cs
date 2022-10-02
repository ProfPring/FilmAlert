using filmAlert.interfaces;
using filmAlert.objects;

namespace filmAlert
{
    public class CSVparser : ICSVparser
    {
        string binaryPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

        public Dictionary<int, show> parseCSV()
        {
            var CSVFileLocation = binaryPath.Replace(@"Debug\net6.0", @"films.csv");

            using (var reader = new StreamReader(CSVFileLocation))
            {
                var csv = reader.ReadToEnd();


                string[] lines = csv.Split(
                    new string[] { Environment.NewLine },
                    StringSplitOptions.None
                );

                var shows = getCSVData(lines[0]);
                var showRealseDates = getCSVData(lines[1]);
                var showEpisodeDays = getCSVData(lines[2]);

                return concatinateData(shows, showRealseDates, showEpisodeDays);
            }
        }

        private Dictionary<int, show> concatinateData(List<string> showNames, List<string> showDates, List<string> showDays) 
        {
            Dictionary<int, show> showTable = new Dictionary<int, show>();

            for (int i = 0; i < showNames.Count; i++) 
            {
                showTable.Add
                (
                    i,     
                    new show
                    {
                        Title = showNames[i],
                        ReleaseDate = showDates[i],
                        ShowEpisdeDay = showDays[i]
                    }
                );
            }

            return showTable;
        } 

        private List<string> getCSVData(string csv) 
        {
            string rowWord = "";
            int i = 0;

            List<string> listToRetturn = new List<string>();

            foreach (var rowLetter in csv)
            {
                if (rowLetter == ',')
                {
                    if (i != 0) 
                    {
                        listToRetturn.Add(rowWord);
                    }
                    rowWord = "";
                    i++;
                }
                else
                {
                    rowWord += rowLetter;   
                }       
            }
            listToRetturn.Add(rowWord);
            return listToRetturn;
        } 
    }
}
