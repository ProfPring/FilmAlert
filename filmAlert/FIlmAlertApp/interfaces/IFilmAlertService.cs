using filmAlert.objects;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIlmAlertApp.interfaces
{
    public interface IFilmAlertService
    {
        Task<Boolean> CheckFilmsOutToday(Dictionary<int, show> showDict, ILogger logger);
    }
}
