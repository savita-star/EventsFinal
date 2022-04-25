// See https://aka.ms/new-console-template for more information
using System;

public class Program
{
    public static void Main()
    {
        var person = new Person();
        person.name = "ABC";

        var alarm = new AlarmClock();
        alarm.AlarmClockEvent += person.HandleAlarm;
        alarm.Alarm();
    }
}



public class Person
{
    public string name { get; set; }

    public void HandleAlarm(object sender, MorningAlarmArgs e)
    {
        Console.WriteLine("Time to Get up{0}", e.time);
    }
}
public class AlarmClock
{
    public event MorningAlarmRingsHandeler AlarmClockEvent;

    public void Alarm()
    {
        Console.WriteLine("Alarm went off!");
        MorningAlarmRingsHandeler alarm = AlarmClockEvent;
        if (alarm != null)
        {
            alarm(this, new MorningAlarmArgs(DateTime.Now));
        }

    }
}

public delegate void MorningAlarmRingsHandeler(object source, MorningAlarmArgs e);

public class MorningAlarmArgs : EventArgs
{
    public DateTime time { get; set; }
    public MorningAlarmArgs(DateTime time)
    {
        this.time = time;

    }
}
