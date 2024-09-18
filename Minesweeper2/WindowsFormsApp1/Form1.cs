using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Button[] btnGrid = new Button[100];
        Tile[] tileGrid = new Tile[100];

        public Form1()
        {
            InitializeComponent();
            reset();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            if (e.Button == MouseButtons.Left)
            {
                clickedButton(b);
            }
            else
            {
                flagClick(b);
            }
        }
        private void clickedButton(Button b)
        {
            if (b.Image == null)
            {
                b.BackColor = Color.Red;

            }
        }
        private void flagClick(Button b)
        {
            if (b.BackgroundImage == null)
            {
            b.BackgroundImage = flagPicture.Image;

            }
            else
            {
                b.BackgroundImage = null;
            }
        }
        private Button getButton(int r, int c)
        {
            return (Button)getButton(r, c);
        }
        private int getIndex(Button b)
        {
            string tmp = b.Name.Substring(6);
            int retVal = 0;
            int.TryParse(tmp, out retVal);
            return retVal - 1;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            for (int i = 0; i < 100; i++)
            {
                btnGrid[i] = (Button)Controls["button" + (i + 1)];
                tileGrid[i] = new Tile(btnGrid[i]);
                btnGrid[i].BackgroundImage = null;

            }
        }
    }
}
