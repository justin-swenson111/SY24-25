using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Button[] btnGrid = new Button[100];
        Tile[] tileGrid = new Tile[100];
        Random rnd = new Random();
        int mineCount = 0;
        bool first=true;
        bool lost = false;
        int flags=0;
        int dugAmt = 0;



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
            if (first)
            {
                firstClick(b);

            }
            
            if (e.Button == System.Windows.Forms.MouseButtons.Right && !first)
            {
                t.setFlag();
                if (t.getFlag())
                {
                    flags++;
                }
                else
                {
                    flags--;
                }
                FlagLabel.Text = "Flags:" + flags.ToString();
                checkWin();
            }

            else if (e.Button == System.Windows.Forms.MouseButtons.Left && !first)
            {
                if (!tileGrid[getIndex(b)].getDug()) { dugAmt++; }

                t.setDug();
                

                if (t.getNearby() == 0)
                {
                    findRight(getIndex(b));
                    findLeft(getIndex(b));
                    findDown(getIndex(b));
                    findUp(getIndex(b));
                    findUpLeft(getIndex(b));
                    findUpRight(getIndex(b));
                    findDownLeft(getIndex(b));
                    findDownRight(getIndex(b));
                }
                if (tileGrid[getIndex(b)].getNearby() != 0 && !tileGrid[getIndex(b)].GetMine())
                {
                    btnGrid[getIndex(b)].Text = tileGrid[getIndex(b)].getNearby().ToString();
                }
                if (tileGrid[getIndex(b)].GetMine())
                {
                    btnGrid[getIndex(b)].BackgroundImage=minePicture.Image;
                    lose();

                }
                checkWin();
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Middle && !first)
            {
                int check= getIndex(b);
                if (check < 90 && check > 10 && check % 10 != 0 && check % 10 != 9)
                {
                    if (countFlags(getIndex(b)) == tileGrid[getIndex(b)].getNearby())
                    {
                        if (!tileGrid[getIndex(b) + 1].GetMine())
                        {
                            findRight(getIndex(b));

                        }
                        if (!tileGrid[getIndex(b) - 1].GetMine())
                        {
                            findLeft(getIndex(b));

                        }
                        if (!tileGrid[getIndex(b) + 10].GetMine())
                        {
                            findDown(getIndex(b));

                        }
                        if (!tileGrid[getIndex(b) - 10].GetMine())
                        {
                            findUp(getIndex(b));

                        }
                        if (!tileGrid[getIndex(b) - 11].GetMine())
                        {
                            findUpLeft(getIndex(b));

                        }
                        if (!tileGrid[getIndex(b) - 9].GetMine())
                        {
                            findUpRight(getIndex(b));

                        }
                        if (!tileGrid[getIndex(b) + 9].GetMine())
                        {
                            findDownLeft(getIndex(b));

                        }
                        if (!tileGrid[getIndex(b) + 11].GetMine())
                        {
                            findDownRight(getIndex(b));

                        }
                    }
                }
            }
            
            
            label1.Text = getIndex(b).ToString();
            //dugLabel.Text=dugAmt.ToString();
        }
        private void checkWin()
        {
            if (dugAmt==90 && flags == 10)
            {
                outcomeLabel.Text = "You Won! hit Reset to play again";
            }
        }
        public void lose()
        {
            for (int i = 0; i < 100; i++)
            {
                if (tileGrid[i].GetMine())
                {
                    btnGrid[i].BackColor= Color.Red;
                }
            }
            outcomeLabel.Text = "You hit a Mine! You lose!";
        }
        private void findRight(int check)
        {
            if ( check < 90 && check > 10 && check % 10 != 0 && check % 10 != 9)
            {
                if (!tileGrid[check].getDug()) { dugAmt++; }
                tileGrid[check].setDug();
                if (tileGrid[check].getNearby() == 0)
                {
                    findRight(check+1);
                    findDownRight(check + 11);
                    findUpRight(check - 9);

                }
                if (tileGrid[check].getNearby() != 0)
                {
                    btnGrid[check].Text= tileGrid[check].getNearby().ToString();
                }

            }
            if (check<10 && check > 0)
            {
                if (!tileGrid[check].getDug()) { dugAmt++; }
                tileGrid[check].setDug();
                if (tileGrid[check].getNearby() == 0)
                {
                    findRight(check + 1);
                    findDownRight(check + 11);

                }
                if (tileGrid[check].getNearby() != 0)
                {
                    btnGrid[check].Text = tileGrid[check].getNearby().ToString();
                }

            }
            if (check%10==0)
            {
                if (!tileGrid[check].getDug()) { dugAmt++; }
                tileGrid[check].setDug();
                if (tileGrid[check].getNearby() == 0)
                {
                    findUpRight(check - 9);
                    findRight(check + 1);
                    findDownRight(check + 11);

                }
                if (tileGrid[check].getNearby() != 0)
                {
                    btnGrid[check].Text = tileGrid[check].getNearby().ToString();
                }

            }

        }
        private void findLeft(int check)
        {
            if (check < 90 && check > 10 && check % 10 != 0 && check % 10 != 9)
            {
                if (!tileGrid[check].getDug()) { dugAmt++; }

                tileGrid[check].setDug();

                if (tileGrid[check].getNearby() == 0)
                {
                    findLeft(check - 1);
                    findUpLeft(check -11);
                    findDownLeft(check+9);

                }
                if (tileGrid[check].getNearby() != 0)
                {
                    btnGrid[check].Text = tileGrid[check].getNearby().ToString();
                }

            }
            if (check < 10 && check > 0)
            {
                if (!tileGrid[check].getDug()) { dugAmt++; }
                tileGrid[check].setDug();
                if (tileGrid[check].getNearby() == 0)
                {
                    findLeft(check - 1);
                    findDownLeft(check + 9);

                }
                if (tileGrid[check].getNearby() != 0)
                {
                    btnGrid[check].Text = tileGrid[check].getNearby().ToString();
                }
            }
        }
        private void findDown(int check)
        {
            if (check < 90 && check > 10 && check % 10 != 0 && check % 10 != 9)
            {
                if (!tileGrid[check].getDug()) { dugAmt++; }

                

                tileGrid[check].setDug();
                if (tileGrid[check].getNearby() == 0)
                {
                    findDown(check + 10);
                findDownLeft(check + 9);
                findDownRight(check + 11);

                }
                if (tileGrid[check].getNearby() != 0)
                {

                    btnGrid[check].Text = tileGrid[check].getNearby().ToString();
                }


            }
            if (check>0 && check < 10)
            {
                if (!tileGrid[check].getDug()) { dugAmt++; }
                tileGrid[check].setDug();
                if (tileGrid[check].getNearby() == 0)
                {
                    findDown(check + 10);
                    findDownLeft(check + 9);
                    findDownRight(check + 11);

                }
                if (tileGrid[check].getNearby() != 0)
                {
                    btnGrid[check].Text = tileGrid[check].getNearby().ToString();
                }
            }
            if (check % 10 == 0)
            {

            }
        }
        private void findUp(int check)
        {
            

            if (check < 90 && check > 10 && check % 10 != 0 && check % 10 != 9)
            {
                if (!tileGrid[check].getDug()) { dugAmt++; }

                tileGrid[check].setDug();
                if (tileGrid[check].getNearby() == 0)
                {
                    findUp(check - 10);
                findUpLeft(check - 11);
                findUpRight(check - 9);

                }
                if (tileGrid[check].getNearby() != 0)
                {
                    btnGrid[check].Text = tileGrid[check].getNearby().ToString();
                }


            }
            if (check>0 && check < 10)
            {
                if (!tileGrid[check].getDug()) { dugAmt++; }

                tileGrid[check].setDug();
                if (tileGrid[check].getNearby() == 0)
                {
                    findLeft(check - 1);
                    findRight(check + 1);
                }
                if (tileGrid[check].getNearby() != 0)
                {
                    btnGrid[check].Text = tileGrid[check].getNearby().ToString();
                }
            }
            if (check%10 == 0)
            {

            }
        }
        private void findUpLeft(int check)
        {
            if (check < 90 && check > 10 && check % 10 != 0 && check % 10 != 9)
            {
                if (!tileGrid[check].getDug()) { dugAmt++; }


                tileGrid[check].setDug();
                if (tileGrid[check].getNearby() == 0)
                {
                    findUpLeft(check - 11);

                }
                if (tileGrid[check].getNearby() != 0)
                {
                    btnGrid[check].Text = tileGrid[check].getNearby().ToString();
                }


            }
        }
        private void findUpRight(int check)
        {
            if (check < 90 && check > 10 && check % 10 != 0 && check % 10 != 9)
            {
                if (!tileGrid[check].getDug()) { dugAmt++; }

                tileGrid[check].setDug();
                

                if (tileGrid[check].getNearby() == 0)
                {
                findUpRight(check - 9);


                }
                if (tileGrid[check].getNearby() != 0)
                {
                    btnGrid[check].Text = tileGrid[check].getNearby().ToString();
                }

            }
        }
        private void findDownLeft(int check)
        {
            if (check < 90 && check > 10 && check % 10 != 0 && check % 10 != 9)
            {
                if (!tileGrid[check].getDug()) { dugAmt++; }

                tileGrid[check].setDug();
                

                if (tileGrid[check].getNearby() == 0)
                {
                findDownLeft(check + 9);


                }
                if (tileGrid[check].getNearby() != 0)
                {
                    btnGrid[check].Text = tileGrid[check].getNearby().ToString();
                }

            }
        }
        private void findDownRight(int check)
        {
            if (check < 90 && check > 10 && check % 10 != 0 && check % 10 != 9)
            {
                if (!tileGrid[check].getDug()) { dugAmt++; }

                tileGrid[check].setDug();


                if (tileGrid[check].getNearby() == 0)
                {
                findDownRight(check + 11);

                }
                if (tileGrid[check].getNearby() != 0)
                {
                    btnGrid[check].Text = tileGrid[check].getNearby().ToString();
                }

            }
        }
        private void firstClick(Button clicked)
        {
            createMines(10);
            first = false;
            int safeTile = getIndex(clicked);
            tileGrid[safeTile].setDug();
            dugAmt++;


            setCounts();
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
                        for (int i = 0; i < 10; i++)
                        {
                            tileGrid[idx].setNearby();
                        }

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
                if (tileGrid[getIndex(getButton(r - 1, c-1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r - 1, c - 1))].setNearby();
                    btnGrid[getIndex(getButton(r - 1, c - 1))].Text = tileGrid[getIndex(getButton(r - 1, c - 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r - 1, c))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r - 1, c))].setNearby();
                    btnGrid[getIndex(getButton(r - 1, c))].Text = tileGrid[getIndex(getButton(r - 1, c))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r - 1, c+1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r - 1, c + 1))].setNearby();
                    btnGrid[getIndex(getButton(r - 1, c + 1))].Text = tileGrid[getIndex(getButton(r - 1, c + 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r, c-1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r, c - 1))].setNearby();
                    btnGrid[getIndex(getButton(r, c - 1))].Text = tileGrid[getIndex(getButton(r, c - 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r, c+1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r, c + 1))].setNearby();
                    btnGrid[getIndex(getButton(r, c + 1))].Text = tileGrid[getIndex(getButton(r, c + 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r + 1, c-1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r + 1, c - 1))].setNearby();
                    btnGrid[getIndex(getButton(r + 1, c - 1))].Text = tileGrid[getIndex(getButton(r + 1, c - 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r + 1, c))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r + 1, c))].setNearby();
                    btnGrid[getIndex(getButton(r + 1, c))].Text = tileGrid[getIndex(getButton(r + 1, c))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r + 1, c+1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r + 1, c + 1))].setNearby();
                    btnGrid[getIndex(getButton(r + 1, c + 1))].Text = tileGrid[getIndex(getButton(r + 1, c + 1))].getNearby().ToString();
                }
            }
            if (r == 1 && c > 1 && c < 10)
            {
                if (tileGrid[getIndex(getButton(r, c-1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r, c - 1))].setNearby();
                    btnGrid[getIndex(getButton(r, c - 1))].Text = tileGrid[getIndex(getButton(r, c - 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r, c+1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r, c + 1))].setNearby();
                    btnGrid[getIndex(getButton(r, c + 1))].Text = tileGrid[getIndex(getButton(r, c + 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r + 1, c-1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r + 1, c - 1))].setNearby();
                    btnGrid[getIndex(getButton(r + 1, c - 1))].Text = tileGrid[getIndex(getButton(r + 1, c - 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r + 1, c))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r + 1, c))].setNearby();
                    btnGrid[getIndex(getButton(r + 1, c))].Text = tileGrid[getIndex(getButton(r + 1, c))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r + 1, c+1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r + 1, c + 1))].setNearby();
                    btnGrid[getIndex(getButton(r + 1, c + 1))].Text = tileGrid[getIndex(getButton(r + 1, c + 1))].getNearby().ToString();
                }

                /*               getButton(r, c - 1).BackColor = Color.Green;
                               getButton(r, c + 1).BackColor = Color.Green;
                               getButton(r + 1, c - 1).BackColor = Color.Green;
                               getButton(r + 1, c).BackColor = Color.Green;
                               getButton(r + 1, c + 1).BackColor = Color.Green;*/
            }
            if (r == 10 && c > 1 && c < 10)
            {
                /*                getButton(r, c - 1).BackColor = Color.Blue;
                                getButton(r, c + 1).BackColor = Color.Blue;
                                getButton(r - 1, c - 1).BackColor = Color.Blue;
                                getButton(r - 1, c).BackColor = Color.Blue;
                                getButton(r - 1, c + 1).BackColor = Color.Blue;*/
                if (tileGrid[getIndex(getButton(r, c-1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r, c - 1))].setNearby();
                    btnGrid[getIndex(getButton(r, c - 1))].Text = tileGrid[getIndex(getButton(r, c - 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r, c+1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r, c + 1))].setNearby();
                    btnGrid[getIndex(getButton(r, c + 1))].Text = tileGrid[getIndex(getButton(r, c + 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r-1, c - 1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r - 1, c - 1))].setNearby();
                    btnGrid[getIndex(getButton(r - 1, c - 1))].Text = tileGrid[getIndex(getButton(r - 1, c - 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r - 1, c))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r - 1, c))].setNearby();
                    btnGrid[getIndex(getButton(r - 1, c))].Text = tileGrid[getIndex(getButton(r - 1, c))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r - 1, c+1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r - 1, c + 1))].setNearby();
                    btnGrid[getIndex(getButton(r - 1, c + 1))].Text = tileGrid[getIndex(getButton(r - 1, c + 1))].getNearby().ToString();
                }
            }
            if (c == 1 && r > 1 && r < 10)
            {
                /*                getButton(r + 1, c).BackColor = Color.Orange;
                                getButton(r + 1, c + 1).BackColor = Color.Orange;
                                getButton(r, c + 1).BackColor = Color.Orange;
                                getButton(r - 1, c + 1).BackColor = Color.Orange;
                                getButton(r - 1, c).BackColor = Color.Orange;*/
                if (tileGrid[getIndex(getButton(r + 1, c))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r + 1, c))].setNearby();
                    btnGrid[getIndex(getButton(r + 1, c))].Text = tileGrid[getIndex(getButton(r + 1, c))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r + 1, c+1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r + 1, c + 1))].setNearby();
                    btnGrid[getIndex(getButton(r + 1, c + 1))].Text = tileGrid[getIndex(getButton(r + 1, c + 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r, c + 1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r, c + 1))].setNearby();
                    btnGrid[getIndex(getButton(r, c + 1))].Text = tileGrid[getIndex(getButton(r, c + 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r - 1, c))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r - 1, c))].setNearby();
                    btnGrid[getIndex(getButton(r - 1, c))].Text = tileGrid[getIndex(getButton(r - 1, c))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r - 1, c + 1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r - 1, c + 1))].setNearby();
                    btnGrid[getIndex(getButton(r - 1, c + 1))].Text = tileGrid[getIndex(getButton(r - 1, c + 1))].getNearby().ToString();
                }
            }
            if (c == 10 && r > 1 && r < 10)
            {
                /*                getButton(r+1, c).BackColor = Color.Purple;
                                getButton(r+1, c - 1).BackColor = Color.Purple;
                                getButton(r, c - 1).BackColor = Color.Purple;
                                getButton(r - 1, c - 1).BackColor = Color.Purple;
                                getButton(r - 1, c).BackColor = Color.Purple;*/
                if (tileGrid[getIndex(getButton(r + 1, c))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r + 1, c))].setNearby();
                    btnGrid[getIndex(getButton(r + 1, c))].Text = tileGrid[getIndex(getButton(r + 1, c))].getNearby().ToString();
                }

                if (tileGrid[getIndex(getButton(r + 1, c-1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r + 1, c - 1))].setNearby();
                    btnGrid[getIndex(getButton(r + 1, c - 1))].Text = tileGrid[getIndex(getButton(r + 1, c - 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r, c-1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r, c - 1))].setNearby();
                    btnGrid[getIndex(getButton(r, c - 1))].Text = tileGrid[getIndex(getButton(r, c - 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r - 1, c-1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r - 1, c - 1))].setNearby();
                    btnGrid[getIndex(getButton(r - 1, c - 1))].Text = tileGrid[getIndex(getButton(r - 1, c - 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r - 1, c))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r - 1, c))].setNearby();
                    btnGrid[getIndex(getButton(r - 1, c))].Text = tileGrid[getIndex(getButton(r - 1, c))].getNearby().ToString();
                }
            }
            if (r==1 && c == 1)
            {
                if (tileGrid[getIndex(getButton(r + 1, c))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r + 1, c))].setNearby();
                    btnGrid[getIndex(getButton(r + 1, c))].Text = tileGrid[getIndex(getButton(r + 1, c))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r + 1, c+1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r + 1, c+1))].setNearby();
                    btnGrid[getIndex(getButton(r + 1, c+1))].Text = tileGrid[getIndex(getButton(r + 1, c+1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r, c + 1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r, c + 1))].setNearby();
                    btnGrid[getIndex(getButton(r, c + 1))].Text = tileGrid[getIndex(getButton(r, c+1))].getNearby().ToString();
                }
            }
            if (r == 1 && c == 10)
            {
                if (tileGrid[getIndex(getButton(r + 1, c))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r + 1, c))].setNearby();
                    btnGrid[getIndex(getButton(r + 1, c))].Text = tileGrid[getIndex(getButton(r + 1, c))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r + 1, c-1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r + 1, c - 1))].setNearby();
                    btnGrid[getIndex(getButton(r + 1, c - 1))].Text = tileGrid[getIndex(getButton(r + 1, c - 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r, c - 1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r, c - 1))].setNearby();
                    btnGrid[getIndex(getButton(r, c - 1))].Text = tileGrid[getIndex(getButton(r, c-1))].getNearby().ToString();
                }
            }
            if (r == 10 && c == 1)
            {
                if (tileGrid[getIndex(getButton(r - 1, c))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r - 1, c))].setNearby();
                    btnGrid[getIndex(getButton(r - 1, c))].Text = tileGrid[getIndex(getButton(r - 1, c))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r - 1, c+1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r - 1, c + 1))].setNearby();
                    btnGrid[getIndex(getButton(r - 1, c + 1))].Text = tileGrid[getIndex(getButton(r - 1, c + 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r, c + 1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r, c + 1))].setNearby();
                    btnGrid[getIndex(getButton(r, c + 1))].Text = tileGrid[getIndex(getButton(r, c+1))].getNearby().ToString();
                }
            }
            if (r == 10 && c == 10)
            {
                if (tileGrid[getIndex(getButton(r - 1, c))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r - 1, c))].setNearby();
                    btnGrid[getIndex(getButton(r - 1, c))].Text = tileGrid[getIndex(getButton(r - 1, c))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r - 1, c-1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r - 1, c - 1))].setNearby();
                    btnGrid[getIndex(getButton(r - 1, c - 1))].Text = tileGrid[getIndex(getButton(r - 1, c - 1))].getNearby().ToString();
                }
                if (tileGrid[getIndex(getButton(r, c - 1))].GetMine() != true)
                {
                    tileGrid[getIndex(getButton(r, c - 1))].setNearby();
                    btnGrid[getIndex(getButton(r, c - 1))].Text = tileGrid[getIndex(getButton(r, c-1))].getNearby().ToString();
                }
            }
            for (int i = 0; i<100; i++)
            {
                btnGrid[i].Text = "";
            }
            return 0;
        }

        private int countFlags(int check)
        {
            int flags = 0;
            if (tileGrid[check - 11].getFlag())
            {
                flags++;
            }
            if (tileGrid[check - 10].getFlag())
            {
                flags++;
            }
            if (tileGrid[check - 9].getFlag())
            {
                flags++;
            }
            if (tileGrid[check - 1].getFlag())
            {
                flags++;
            }
            if (tileGrid[check + 1].getFlag())
            {
                flags++;
            }
            if (tileGrid[check + 9].getFlag())
            {
                flags++;
            }
            if (tileGrid[check + 10].getFlag())
            {
                flags++;
            }
            if (tileGrid[check + 11].getFlag())
            {
                flags++;
            }
            return flags;
        }
        private void resetButton_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            mineCount = 0;
            first = true;
            for (int i = 0; i < 100; i++)
            {
                btnGrid[i] = (Button)Controls["button" + (i + 1)];
                tileGrid[i] = new Tile(btnGrid[i]);
                tileGrid[i].setFlagImage(flagPicture.Image);
                tileGrid[i].setMineImage(minePicture.Image);
                tileGrid[i].setMine(false);
                tileGrid[i].resetCount();
                    btnGrid[i].Text = "";
                outcomeLabel.Text = "";
                //dugLabel.Text = "";
                FlagLabel.Text = "Flags:";
                dugAmt = 0;
                flags = 0;
                
                /*                btnGrid[i].Text = tileGrid[i].getNearby().ToString();*/
            }
            //creates numMines amount of mines
            setCounts();

        }
        public void createMines(int numMines)
        {

            while (mineCount < numMines)
            {
                int ran = rnd.Next(0, 100);
                //chooses a random tile in the grid
                if (tileGrid[ran].GetMine() == false && tileGrid[ran].getDug()!=true)
                {
                    mineCount++;
                    //if there isnt already a mine there it assigns it a mine
                    tileGrid[ran].setMine(true);
/*                    btnGrid[ran].BackColor = Color.Red;*/
                    //else it will choose a new number and try again
                }
            }


        }
    }

}
