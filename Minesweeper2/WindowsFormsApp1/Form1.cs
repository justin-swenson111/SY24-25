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
        Random rnd = new Random();
        int mineCount = 0;



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
                t.setFlag();
            else
                t.setDug();
            label1.Text = getIndex(b).ToString();

        }
        private Button getButton(int r, int c)
        {
            int idx = (r - 1) * 10 + (c - 1);
            return btnGrid[idx];
        }
        private int getIndex(Button b)
        {
            string tmp = b.Name.Substring(6);
            int retVal = 0;
            int.TryParse(tmp, out retVal);
            return retVal - 1;
        }

        private void setCounts()
        {
            //for every tile on the board
            for (int r = 1; r < 11; r++)
            {
                for (int c = 1; c < 11; c++)
                {
                    int idx = (r - 1) * 10 + (c - 1);


                    if (tileGrid[idx].GetMine())
                    {
                        countadj(r, c);

                    }


                }

            }

            //add one for each adjacent mine
            //set that count into the tile
        }
        private int countadj(int r, int c)
        {
            if (r > 1 && c > 1 && r < 10 && c < 10)
            {
               
                tileGrid[getIndex(getButton(r - 1, c - 1))].setNearby();
                btnGrid[getIndex(getButton(r - 1, c - 1))].Text= tileGrid[getIndex(getButton(r - 1, c - 1))].getNearby().ToString();
/*add previous line after each setnearby and change the other if statements to this*/
                tileGrid[getIndex(getButton(r - 1, c))].setNearby();
                tileGrid[getIndex(getButton(r - 1, c + 1))].setNearby();
                tileGrid[getIndex(getButton(r, c - 1))].setNearby();
                tileGrid[getIndex(getButton(r, c + 1))].setNearby();
                tileGrid[getIndex(getButton(r + 1, c - 1))].setNearby();
                tileGrid[getIndex(getButton(r + 1, c))].setNearby();
                tileGrid[getIndex(getButton(r + 1, c + 1))].setNearby();
            }
            if (r==1 && c>1 && c < 10)
            {
                getButton(r, c - 1).BackColor = Color.Green;
                getButton(r, c + 1).BackColor = Color.Green;
                getButton(r + 1, c - 1).BackColor = Color.Green;
                getButton(r + 1, c).BackColor = Color.Green;
                getButton(r + 1, c + 1).BackColor = Color.Green;
            }
            if (r == 10 && c > 1 && c < 10)
            {
                getButton(r, c - 1).BackColor = Color.Blue;
                getButton(r, c + 1).BackColor = Color.Blue;
                getButton(r - 1, c - 1).BackColor = Color.Blue;
                getButton(r - 1, c).BackColor = Color.Blue;
                getButton(r - 1, c + 1).BackColor = Color.Blue;
            }
            if (c == 1 && r > 1 && r < 10)
            {
                getButton(r + 1, c).BackColor = Color.Orange;
                getButton(r + 1, c + 1).BackColor = Color.Orange;
                getButton(r, c + 1).BackColor = Color.Orange;
                getButton(r - 1, c + 1).BackColor = Color.Orange;
                getButton(r - 1, c).BackColor = Color.Orange;
            }
            if (c == 10 && r > 1 && r < 10)
            {
                getButton(r+1, c).BackColor = Color.Purple;
                getButton(r+1, c - 1).BackColor = Color.Purple;
                getButton(r, c - 1).BackColor = Color.Purple;
                getButton(r - 1, c - 1).BackColor = Color.Purple;
                getButton(r - 1, c).BackColor = Color.Purple;
            }

            return 0;
        }
        private void resetButton_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            mineCount = 0;
            for (int i = 0; i < 100; i++)
            {
                btnGrid[i] = (Button)Controls["button" + (i + 1)];
                tileGrid[i] = new Tile(btnGrid[i]);
                tileGrid[i].setFlagImage(flagPicture.Image);
                tileGrid[i].setMineImage(minePicture.Image);
                tileGrid[i].setMine(false);
            }
            createMines(10);
            //creates numMines amount of mines
            setCounts();

        }
        public void createMines(int numMines)
        {
            
            while (mineCount < numMines)
            {
                int ran = rnd.Next(0, 100);
                //chooses a random tile in the grid
                if (tileGrid[ran].GetMine() == false)
                {
                    mineCount++;
                    //if there isnt already a mine there it assigns it a mine
                    tileGrid[ran].setMine(true);
                    //else it will choose a new number and try again
                }
            }


        }
    }

}
