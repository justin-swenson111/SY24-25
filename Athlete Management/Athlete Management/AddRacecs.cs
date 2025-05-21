using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Athlete_Management
{
    public partial class AddRacecs : Form
    {
        DatabaseHelper _dbHhelper = new DatabaseHelper("athlete.xml");

        public AddRacecs()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            List<Athlete> athletes = _dbHhelper.GetAllAthletes();
            foreach (var item in athletes)
            {
                item.races(raceTxt.Text);
                _dbHhelper.UpdateAthlete(item);
                //MessageBox.Show(item.race.Count.ToString());
            }
            MessageBox.Show("event added!");
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
