using System;
using System.Threading;
public class TimeSimulator
{
    public event EventHandler TimeEnded;
    public void StartTime()
    {
        Console.WriteLine("Time started ...");
        Thread.Sleep(2000);
        OnTimeEnded(EventArgs.Empty);
    }
    protected virtual void OnTimeEnded(EventArgs e)
    {
        TimeEnded?.Invoke(this, e);
    }
}

class Example
{
    public static void Run()
    {
        TimeSimulator timer = new TimeSimulator();
        timer.TimeEnded += Timer_TimerEnded;
        timer.StartTime();
    }

    static void Timer_TimerEnded(object sender, EventArgs e)
    {
        Console.WriteLine("Timer has ended!");
    }
}
