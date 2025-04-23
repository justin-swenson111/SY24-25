using System;
using System.Xml.Serialization;
[Serializable]
public class Athlete
{
    public int AthleteID { get; set; }
    public string BibNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Team { get; set; }
    public int? Age { get; set; }
    public string Gender { get; set; }
    public string ContactInfo { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public Athlete() { }
}
