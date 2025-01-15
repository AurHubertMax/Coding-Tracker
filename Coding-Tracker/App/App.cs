using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coding_Tracker.DataAccess;
using Coding_Tracker.Views;


public class App
{
    private DatabaseManager dbManager = new DatabaseManager();

    private CodingSessionController CodingSessionController = new CodingSessionController();
    internal void Run()
    {
        dbManager.CreateDatabase();

        bool running = true;
        while (running)
        {
            Menus.DisplayMainMenu();
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    //StartCodingSession();
                    Menus.DisplaySessionMenu();
                    break;
                case "2":
                    Menus.ViewCodingSessions();
                    break;
                //case "3":
                //    Menus.EditCodingSession();
                //    break;
                case "4":
                    Environment.Exit(0);
                    break;
                case "5":
                    CodingSessionController.AddCodingSession(GenerateRandomCodingSessions());
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

    }

    private void StartCodingSession()
    {
        Console.WriteLine("Elapsed Time: ");
        LiveTracker.Start();
        Console.WriteLine("Press any key to stop the session");
        LiveTracker.DisplayElapsedTime();
        LiveTracker.Reset();

    }

    private CodingSession GenerateRandomCodingSessions()
    {
        Random random = new Random();

        string[] languages = { "C#", "Python", "JavaScript", "Java", "C++" };
        string language = languages[random.Next(0, languages.Length)];

        DateTime day = DateTime.Now.AddDays(-random.Next(0, 30));

        DateTime start_time = DateTime.Now.AddHours(-random.Next(0, 12));

        DateTime end_time = start_time.AddHours(random.Next(1, 4));

        TimeSpan duration = end_time - start_time;

        string notes = $"Random notes {random.Next(0, 100)}";

        return new CodingSession
        {
            Language = language,
            Day = day,
            StartTime = start_time,
            EndTime = end_time,
            Duration = duration,
            Notes = notes
        };
    }
}

