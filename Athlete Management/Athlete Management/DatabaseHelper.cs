using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Linq;
using System.Windows.Forms;

namespace Athlete_Management
{
    public class DatabaseHelper
    {
        public readonly string _lePath;
        public DatabaseHelper(string lePath)
        {
            _lePath = lePath;
        }
        public List<Athlete> GetAllAthletes()
        {
            List<Athlete> athletes = new List<Athlete>();
            if (File.Exists(_lePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Athlete>));
                using (FileStream leStream = new FileStream(_lePath, FileMode.Open))
                {
                    try
                    {
                        athletes = (List<Athlete>)serializer.Deserialize(leStream);
                    }
                    catch (InvalidOperationException ex)
                    {
                        // Handle corrupted or empty le. Return empty list.
                        Console.WriteLine($"Error deserializing XML: {ex.Message}. Returning empty athlete list.");
                    return new List<Athlete>();
                    }
                    catch (XmlException ex)
                    {
                        Console.WriteLine($"XML Exception: {ex.Message}. Returning empty athlete list.");
                    return new List<Athlete>();
                    }
                }
            }
            return athletes;
        }
        public Athlete GetAthleteById(int id)
        {
            List<Athlete> athletes = GetAllAthletes();
            return athletes.Find(a => a.AthleteID == id);
        }
        public void AddAthlete(Athlete athlete)
        {
            List<Athlete> athletes = GetAllAthletes();
            athlete.AthleteID = GetNextAthleteId(athletes); //nd the next available ID
            athletes.Add(athlete);
            SaveAthletes(athletes);
        }
        private int GetNextAthleteId(List<Athlete> athletes)
        {
            if (athletes.Count == 0)
                return 1;
            else
                return athletes.Max(a => a.AthleteID) + 1;
        }
        public void UpdateAthlete(Athlete athlete)
        {
            List<Athlete> athletes = GetAllAthletes();
            int index = athletes.FindIndex(a => a.AthleteID == athlete.AthleteID);
            if (index != -1)
            {
                athletes[index] = athlete;
                SaveAthletes(athletes);
            }
            else
            {
                throw new ArgumentException("Athlete to update not found.");
            }
        }
        public void DeleteAthlete(int athleteId)
        {
            List<Athlete> athletes = GetAllAthletes();
            athletes.RemoveAll(a => a.AthleteID == athleteId);
            SaveAthletes(athletes);
        }
        public void SaveAthletes(List<Athlete> athletes)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Athlete>));
            using (TextWriter writer = new StreamWriter(_lePath))
            {
                serializer.Serialize(writer, athletes);
            }
        }

    }
}
