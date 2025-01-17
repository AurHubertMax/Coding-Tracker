using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

internal class LiveTracker
{
    public static readonly Stopwatch stopwatch = new Stopwatch();

    public static void Start()
    {
        stopwatch.Start();
    }

    public static void DisplayElapsedTime()
    {
        Task.Run(() =>
        {
            while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                Console.SetCursorPosition(0, Console.CursorTop); // Move cursor to the start of the line
                Console.Write($"Elapsed Time: {stopwatch.Elapsed:hh\\:mm\\:ss\\.fff}");
                Task.Delay(1).Wait();
            }
        }).Wait();
        Stop();
    }

    public static CodingSession SaveSession()
    {
        var session = new CodingSession();
        session.Duration = stopwatch.Elapsed.ToString();
        session.StartTime = DateTime.Now - session.GetDuration();
        session.EndTime = DateTime.Now;

        return session;
    }

    public static void Stop()
    {
        stopwatch.Stop();
    }

    public static void Reset()
    {
        stopwatch.Reset();
    }

    public static TimeSpan GetElapsedTime()
    {
        return new TimeSpan(stopwatch.Elapsed.Hours, stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds, stopwatch.Elapsed.Milliseconds);
    }
}
