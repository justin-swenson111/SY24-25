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

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            Tile t = tileGrid[getIndex(b)];
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (tileGrid[getIndex(b)].m_flag)
                {
                    t.setFlag(false);
                }
                else
                {
                    t.setFlag(true);

                }
            }
            label1.Text = getIndex(b).ToString();
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
                tileGrid[i].setFlagImage(flagPicture.Image);
                tileGrid[i].setMineImage(minePicture.Image);
                tileGrid[i].setFlag(false);
                tileGrid[i].setMine(true);

            }
        }
    }
}
