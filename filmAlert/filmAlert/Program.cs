using System.Timers;
using filmAlert;
using filmAlert.interfaces;
using filmAlert.objects;
using Microsoft.Extensions.DependencyInjection;
using System.Timers;
using System.Threading;
using filmAlert.helpers;

public class  Program
{
    static void Main(string[] args)
    {
       
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ICSVparser, CSVparser>()
            .AddSingleton<IFilmSFinder,FilmFinder>()
            .AddSingleton<ISendEmail, SendEmail>()
            .BuildServiceProvider();

        var CSVParser = serviceProvider.GetService<ICSVparser>();
        var filmFinder = serviceProvider.GetService<IFilmSFinder>();
        var sendEMail = serviceProvider.GetService<ISendEmail>();

        Console.WriteLine("film alert now started");
        Console.WriteLine("input file location of csv");
        var csvFileLocation = Console.ReadLine();

        TimeSpan midnight = new TimeSpan(0, 0, 0);
        while (true) 
        {
            if (DateTime.Now.TimeOfDay >= midnight)
            {
                var showDict = CSVParser.parseCSV(csvFileLocation);

                var showsList = filmFinder.ShowsOutToday(showDict);

                if (showsList.Count != 0 && showsList != null) 
                {
                    Console.Write("now sennding email");
                    sendEMail.send(showsList);
                }
            }
        }
        
    }

    
}
