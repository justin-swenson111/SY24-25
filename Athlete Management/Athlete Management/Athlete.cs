using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;
[Serializable]
public class Athlete
{
    //List<string> races = new List<string>();
    public int AthleteID { get; set; }
    public string BibNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Team { get; set; }
    public int? Age { get; set; }
    public string Gender { get; set; }
    public string ContactInfo { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public List<string[]> raceTime { get; set; }

    public void updateTime(string EventName, string Time)
    {
        string[] array = new string[2];
        array[0] = EventName;
        array[1] = Time;
        raceTime.Add(array);
    }
    public void races(string Race) {
        race.Add(Race);
    }
    public List<string> race { get; set; }
    public Athlete() { }
}
