using Spectre.Console;

public class CodingSession
{
    public string? Language { get; set; }
    public DateTime Day { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Duration { get; set; }
    public string? Notes { get; set; }

    public string FormattedDay => Day.ToString("MM/dd/yyyy");
    public string FormattedStartTime => StartTime.ToString("HH:mm");
    public string FormattedEndTime => EndTime.ToString("HH:mm");

    public TimeSpan GetDuration() => TimeSpan.Parse(Duration);

    public enum CodingSessionProps
    {
        Language,
        FormattedDay,
        FormattedStartTime,
        FormattedEndTime,
        Duration,
        Notes,
    }
}
