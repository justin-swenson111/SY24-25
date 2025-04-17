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
    public partial class Form1 : Form
    {

        private DatabaseHelper _dbHelper;
        private List<Athlete> _athletes;
        public Form1()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper("athlete.xml");
            LoadAthletes();
        }

        private void LoadAthletes()
        {
            _athletes = _dbHelper.GetAllAthletes();
            dgvAthletes.DataSource = _athletes;
            // Optionally, congure the DataGridView columns (e.g., hide the AthleteID column, set column headers). This improves the display.
            dgvAthletes.Columns["AthleteID"].Visible = false; // Hide the AthleteID column. It's used internally.
            dgvAthletes.Columns["BibNumber"].HeaderText = "Bib #";
            dgvAthletes.Columns["FirstName"].HeaderText = "First Name";
            dgvAthletes.Columns["LastName"].HeaderText = "Last Name";
            dgvAthletes.Columns["Team"].HeaderText = "Team";
            dgvAthletes.Columns["Age"].HeaderText = "Age";
            dgvAthletes.Columns["Gender"].HeaderText = "Gender";
            dgvAthletes.Columns["ContactInfo"].HeaderText = "Contact Info";
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            // Create a new AddEditAthleteForm, passing null to indicate that we are adding a new athlete.
            using (var addEditForm = new AddEditAthleteForm(null))
            {
                // Show the form as a dialog. If the user clicks the Save buon, the DialogResult will be OK.
                if (addEditForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAthletes(); // Reload the list of athletes from the XML le to reect the new addition.
                }
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            // Check if any row is selected in the DataGridView.
            if (dgvAthletes.SelectedRows.Count > 0)
            {
                // Get the AthleteID of the selected athlete from the DataGridView.
                int selectedAthleteId = (int)dgvAthletes.SelectedRows[0].Cells["AthleteID"].Value;
                // Retrieve the Athlete object from the XML le using the ID.
                Athlete athleteToEdit = _dbHelper.GetAthleteById(selectedAthleteId);
                // Check if the athlete was found.
                if (athleteToEdit != null)
                {
                    // Create an AddEditAthleteForm, passing the athlete object to be edited.
                    using (var addEditForm = new AddEditAthleteForm(athleteToEdit))
                    {
                        // Show the form as a dialog.
                        if (addEditForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadAthletes(); // Reload the athlete list aer the edit.
                        }
                    }
                }
                else
                {
                    // Display an error message if the athlete to edit was not found. This should not normally happen, but it's good to have error handling.
                    MessageBox.Show("Could not nd the selected athlete.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else
            {
                // Display a message to the user to select an athlete to edit.
                MessageBox.Show("Please select an athlete to edit.", "Information", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            // Check if any row is selected in the DataGridView.
            if (dgvAthletes.SelectedRows.Count > 0)
            {
                // Get the AthleteID of the selected athlete.
                int selectedAthleteId = (int)dgvAthletes.SelectedRows[0].Cells["AthleteID"].Value;
                Athlete athleteToDelete = _dbHelper.GetAthleteById(selectedAthleteId);
                // Conrm the deletion with the user.
                if (athleteToDelete != null && MessageBox.Show($"Are you sure you want to delete {athleteToDelete.FullName} (Bib: {athleteToDelete.BibNumber})?", "Conrm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // Delete the athlete from the XML le.
                    _dbHelper.DeleteAthlete(selectedAthleteId);
                    LoadAthletes(); // Reload the athlete list.
                }
            }
            else
            {
                // Prompt the user to select an athlete to delete.
                MessageBox.Show("Please select an athlete to delete.", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            // Get the text from the search TextBox.
            string searchText = txtSearch.Text.ToLower();
            // Filter the list of athletes based on the search text. Use ToLower() for case-insensitive search.
            var lteredAthletes = _athletes.FindAll(a =>
            a.FirstName.ToLower().Contains(searchText) ||
            a.LastName.ToLower().Contains(searchText) ||
            a.BibNumber.ToLower().Contains(searchText));
            // Display the ltered athletes in the DataGridView.
            dgvAthletes.DataSource = lteredAthletes;
        }
        // (Optional) Implement ltering by Team and Gender using ComboBoxes (cmbTeamFilter, cmbGenderFilter).
        // private void cmbTeamFilter_SelectedIndexChanged(object sender, EventArgs e) { ... }
        // private void cmbGenderFilter_SelectedIndexChanged(object sender, EventArgs e) { ... }
    }
}