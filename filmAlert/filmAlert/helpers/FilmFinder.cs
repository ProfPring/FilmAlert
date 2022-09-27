using filmAlert.interfaces;
using filmAlert.objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filmAlert.helpers
{
    public class FilmFinder : IFilmSFinder
    {
        public List<show> ShowsOutToday(Dictionary<int, show> shows) 
        {
            List<show> showList = new List<show>(); 

            foreach (var show in shows) 
            {
                if (DateTime.UtcNow > DateTime.Parse(show.Value.ReleaseDate) && DateTime.Now.DayOfWeek.ToString() == show.Value.ShowEpisdeDay) 
                {
                    showList.Add(show.Value);
                }

            }
            return showList;
        }


    }
}
