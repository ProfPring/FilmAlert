using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using filmAlert.helpers;
using filmAlert.interfaces;
using filmAlert.objects;
using Microsoft.Extensions.Logging;

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

        public async Task<Boolean> CheckFilmsOutToday(Dictionary<int, show>  showDict, ILogger log)
        {
            try
            {
                var showsList = _filmFinder.ShowsOutToday(showDict);
                _sendEmail.send(showsList);

                return true;
            }
            catch (Exception ex) 
            {
                log.LogError($"an exception has been thrown {ex}");
                return false;
            }
        }
    }
}
