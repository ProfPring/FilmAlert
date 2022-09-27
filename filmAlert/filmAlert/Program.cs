using filmAlert;
using filmAlert.interfaces;
using Microsoft.Extensions.DependencyInjection;

public class  Program
{ 
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ICSVparser, CSVparser>()
            .BuildServiceProvider();

        var CSVParser = serviceProvider.GetService<ICSVparser>();
        var filmFinder = serviceProvider.GetService<IFilmSFinder>();
        var sendEMail = serviceProvider.GetService<ISendEmail>();
       
        var showDict = CSVParser.parseCSV();

        var showsList = filmFinder.ShowsOutToday(showDict);

        sendEMail.send(showsList);

    }
}
