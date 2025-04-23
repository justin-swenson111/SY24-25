using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AthleteManagement
{
    public partial class Form1 : Form
    {
        private DatabaseHelper _dbHelper;
        private List<Athlete> _athletes;

        public Form1()
        {
            InitializeComponent();
            // Initialize the DatabaseHelper with the XML file path. Make sure athletes.xml is in the same
            // directory as the executable, or specify the full path.
            _dbHelper = new DatabaseHelper("athletes.xml");
            LoadAthletes();
        }

        private void LoadAthletes()
        {
            _athletes = _dbHelper.GetAllAthletes();
            dgvAthletes.DataSource = _athletes;

            // Configure the DataGridView columns for better display.
            dgvAthletes.Columns["AthleteID"].Visible = false; // Hide the AthleteID column.
            dgvAthletes.Columns["BibNumber"].HeaderText = "Bib #";
            dgvAthletes.Columns["FirstName"].HeaderText = "First Name";
            dgvAthletes.Columns["LastName"].HeaderText = "Last Name";
            dgvAthletes.Columns["Team"].HeaderText = "Team";
            dgvAthletes.Columns["Age"].HeaderText = "Age";
            dgvAthletes.Columns["Gender"].HeaderText = "Gender";
            dgvAthletes.Columns["ContactInfo"].HeaderText = "Contact Info";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addEditForm = new AddEditAthleteForm(null))
            {
                if (addEditForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAthletes(); // Reload the list of athletes.
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAthletes.SelectedRows.Count > 0)
            {
                int selectedAthleteId = (int)dgvAthletes.SelectedRows[0].Cells["AthleteID"].Value;
                Athlete athleteToEdit = _dbHelper.GetAthleteById(selectedAthleteId);

                if (athleteToEdit != null)
                {
                    using (var addEditForm = new AddEditAthleteForm(athleteToEdit))
                    {
                        if (addEditForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadAthletes(); // Reload the athlete list after the edit.
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Could not find the selected athlete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an athlete to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAthletes.SelectedRows.Count > 0)
            {
                int selectedAthleteId = (int)dgvAthletes.SelectedRows[0].Cells["AthleteID"].Value;
                Athlete athleteToDelete = _dbHelper.GetAthleteById(selectedAthleteId);

                if (athleteToDelete != null && MessageBox.Show($"Are you sure you want to delete {athleteToDelete.FullName} (Bib: {athleteToDelete.BibNumber})?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _dbHelper.DeleteAthlete(selectedAthleteId);
                    LoadAthletes(); // Reload the athlete list.
                }
            }
            else
            {
                MessageBox.Show("Please select an athlete to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            var filteredAthletes = _athletes.FindAll(a =>
                a.FirstName.ToLower().Contains(searchText) ||
                a.LastName.ToLower().Contains(searchText) ||
                a.BibNumber.ToLower().Contains(searchText));

            dgvAthletes.DataSource = filteredAthletes;
        }

        private void btn_FormSwitch1_Click(object sender, EventArgs e)
        {
            AddEditAthleteForm f2 = new AddEditAthleteForm(null);
            f2.Show();
        }

        private void stopwatchBtn_Click(object sender, EventArgs e)
        {
            StopWatch stopWatch = new StopWatch();
            stopWatch.Show();
        }

        // (Optional) Implement filtering by Team and Gender using ComboBoxes (cmbTeamFilter, cmbGenderFilter).
        // private void cmbTeamFilter_SelectedIndexChanged(object sender, EventArgs e) { ... }
        // private void cmbGenderFilter_SelectedIndexChanged(object sender, EventArgs e) { ... }
    }
}