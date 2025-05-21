using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Athlete_Management
{
    public partial class StopWatch : Form
    {
        private Stopwatch stopwatch;
        private Timer timer;
        private Form mainForm;
        DatabaseHelper _dbHhelper = new DatabaseHelper("athlete.xml");

        public StopWatch(Form main)
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            timer = new Timer();
            timer.Interval = 100; // Update every 100 milliseconds 
            timer.Tick += Timer_Tick;
            List<Athlete> athletes = _dbHhelper.GetAllAthletes();
            // Assuming you want to display the athletes in a ListBox or similar control
            for (int i =0; i < athletes.Count; i++)
            {
                // Assuming you have a ListBox named athleteListBox
                athleteCombo.Items.Add(athletes[i].BibNumber);
            }
            mainForm = main;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
            timer.Start();
            startBtn.Enabled = false;
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            stopwatch.Stop();
            timer.Stop();
            startBtn.Enabled = true;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            timerLbl.Text = "00:00:00.00";
            startBtn.Enabled = true;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the label with the stopwatch elapsed time 
            timerLbl.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.ff");
        }

        private void addBtn_Click_1(object sender, EventArgs e)
        {
            if (athleteCombo.SelectedItem != null)
            {
                string selectedAthlete = athleteCombo.SelectedItem.ToString();
                string time = stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.ff");
                List<Athlete> athletes = _dbHhelper.GetAllAthletes();
                foreach (var athlete in athletes)
                {
                    if (athlete.BibNumber == selectedAthlete)
                    {
                        var _currentAthlete = athlete;
                        MessageBox.Show($"Time saved for {athlete.FullName}: {time}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        athlete.updateTime(raceCombo.SelectedItem.ToString(), time);
                        _dbHhelper.UpdateAthlete(_currentAthlete);
                        MessageBox.Show($"Time saved for {athlete.FullName}: {time}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close(); // Close the form.
                        break;
                    }
                }

            }
            else
            {
                MessageBox.Show("Please select an athlete before saving the time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void athleteCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Athlete> athletes = _dbHhelper.GetAllAthletes();
            foreach(var athlete in athletes)
            {
                if (athlete.BibNumber == athleteCombo.SelectedItem.ToString())
                {
                    foreach (var thing in athlete.race)
                    {
                        raceCombo.Items.Add(thing);
                    }
                }
            }
        }
    }
}
