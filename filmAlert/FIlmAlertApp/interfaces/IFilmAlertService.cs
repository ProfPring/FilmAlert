using filmAlert.objects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FIlmAlertApp.interfaces
{
    public interface IFilmAlertService
    {
        Task<Boolean> CheckFilmsOutToday(Dictionary<int, show> showDict);
    }
}
