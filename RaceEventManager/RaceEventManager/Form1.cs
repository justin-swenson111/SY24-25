using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO; //Added for file io.
namespace RaceEventManager
{
    public partial class Form1 : Form
    {
        private List<RaceEvent> raceEvents = new List<RaceEvent>();
        public Form1()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                RaceEvent newEvent = new RaceEvent
                {
                    EventID = int.Parse(txtEventID.Text),
                    EventName = txtEventName.Text,
                    EventDate = dtpEventDate.Value,
                    RaceDistance = double.Parse(txtRaceDistance.Text)
                };
                raceEvents.Add(newEvent);
                // Save to file (CSV)
                string filePath = "RaceEvents.csv";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {

                    writer.WriteLine($"{newEvent.EventID},{newEvent.EventName},{newEvent.EventDate},{newEvent.RaceDistance}");
                }
                txtEventID.Clear();
                txtEventName.Clear();
                txtRaceDistance.Clear();
                MessageBox.Show("Race event saved successfully!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input format. Please check your data.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}