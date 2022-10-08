using System;
using filmAlert.interfaces;
using filmAlert;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using filmAlert.objects;
using System.Collections.Generic;
using FIlmAlertApp.interfaces;

namespace FIlmAlertApp
{
    public class FilmAlertFunction
    {
        ServiceProvider serviceProvider;
        Dictionary<int, show> showDict;

        IFilmAlertService AlertService;

        public FilmAlertFunction() 
        {
          serviceProvider = new ServiceCollection()
          .AddSingleton<ICSVparser, CSVparser>()
          .BuildServiceProvider();

            var CSVParser = serviceProvider.GetService<ICSVparser>();
            serviceProvider.GetService<IFilmSFinder>();
            serviceProvider.GetService<ISendEmail>();
            AlertService = serviceProvider.GetService<IFilmAlertService>();

            showDict = CSVParser.parseCSV();
        }


        [FunctionName("FilmALert")]
        public void Run([TimerTrigger("0 0 0 * * *")] TimerInfo myTimer)
        {
            Console.WriteLine("funciton has run");
            AlertService.CheckFilmsOutToday(showDict);
        }
    }

}
