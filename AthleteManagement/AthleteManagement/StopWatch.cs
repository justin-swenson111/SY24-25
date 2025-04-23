using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AthleteManagement
{
    public partial class StopWatch : Form
    {

        private Stopwatch stopwatch;
        private Timer timer;
        public StopWatch()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            timer = new Timer();
            timer.Interval = 100; // Update every 100 milliseconds
            timer.Tick += Timer_Tick;
        }



        private void startBtn_Click(object sender, EventArgs e)
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
    }
}
