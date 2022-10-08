using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using filmAlert.interfaces;
using filmAlert.objects;

namespace FIlmAlertApp.services
{
    public class FilmAlertService
    {
        private readonly ISendEmail _sendEmail;
        private readonly IFilmSFinder _filmFinder;

        public FilmAlertService(ISendEmail sendEmail, IFilmSFinder filmFinder) 
        {
            _sendEmail = sendEmail;
            _filmFinder = filmFinder;

        }

        public async Task<Boolean> CheckFilmsOutToday(Dictionary<int, show>  showDict)
        {
            try
            {
                var showsList = _filmFinder.ShowsOutToday(showDict);
                _sendEmail.send(showsList);

                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString()); 
                return false;
            }
        }
    }
}
