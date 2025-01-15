using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coding_Tracker.DataAccess;
using Spectre.Console;

namespace Coding_Tracker.Views
{
    internal class Menus
    {
        public static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Coding Tracker!");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Start Coding Session");
            Console.WriteLine("2. View Coding Sessions");
            Console.WriteLine("3. Edit Coding Sessions");
            Console.WriteLine("4. Exit");
            Console.WriteLine("5. Add Random Coding Session");
            Console.WriteLine("Enter your choice:");
        }

        public static void DisplaySessionMenu()
        {
            Console.Clear();
            Console.WriteLine("What is the language you are coding in?");
            string language = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"Start coding session in {language}? (Y/N)");

            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.Clear();
                LiveTracker.Start();
                Console.WriteLine("Press ENTER to stop the session");
                LiveTracker.DisplayElapsedTime();
                Console.WriteLine("\nEnter any notes for this session:");
                string notes = Console.ReadLine();

                var session = LiveTracker.SaveSession();
                session.Language = language;
                session.Notes = notes;

                Console.Clear();
                Console.WriteLine("Would you like to save this session? (Y/N)");
                DisplaySessionSummary(session);
                if (Console.ReadLine().ToUpper() == "Y")
                {
                    CodingSessionController CSController = new();
                    CSController.AddCodingSession(session);
                    Console.WriteLine("Session saved successfully! Press ENTER to go back to main menu");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Session not saved.");
                }
                Console.ReadLine();
            }
            else
            {
                return;
            }
        }

        public static void DisplaySessionSummary(CodingSession session)
        {
            Console.WriteLine($"Language: {session.Language}");
            Console.WriteLine($"Start Time: {session.StartTime}");
            Console.WriteLine($"End Time: {session.EndTime}");
            Console.WriteLine($"Duration: {session.Duration}");
            Console.WriteLine($"Notes: {session.Notes}");
        }

        internal static void ViewCodingSessions()
        {
            throw new NotImplementedException();
        }
    }
}
