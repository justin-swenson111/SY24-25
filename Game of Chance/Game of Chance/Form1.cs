using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Game_of_Chance
{
    public partial class Form1 : Form
    {
        List<string> slotItems = new List<string>();
        string slotImage;
        int slotchoice1;
        int slotchoice2;
        int slotchoice3;
        int cash;
        int repeats = 0;
        int cycles = 15;
        Random rnd = new Random();


        public Form1()
        {
            InitializeComponent();
            slotItems.Add("cherry");
            slotItems.Add("lemon");
            slotItems.Add("seven");
            slotItems.Add("watermelon");
            slotItems.Add("bar");
            cash = 100;
            cashLabel.Text = cash.ToString();
            slot1.Image=cherryPic.Image;
            slot2.Image = cherryPic.Image;
            slot3.Image=cherryPic.Image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cycles == 0)
            {
                cycles = 15;
            }
            cash -= 10;
            cashLabel.Text = "$" + cash.ToString();
            while (cycles > 0)
            {
                spin(1);
                spin(2);
                spin(3);

                Task.Delay(1500).Wait();
            }
            roll();


        }
        private void spin(int slotNum)
        {
            PictureBox slotPic = (PictureBox)Controls["slot" + slotNum.ToString()];
                if (slotPic.Image == cherryPic.Image)
                {
                    slotPic.Image = lemonPic.Image;
                }
                else if (slotPic.Image == lemonPic.Image)
                {
                    slotPic.Image = sevenPic.Image;
                }
                else if (slotPic.Image == sevenPic.Image)
                {
                    slotPic.Image = watermelonPic.Image;
                }
                else if (slotPic.Image == watermelonPic.Image)
                {
                    slotPic.Image = barPic.Image;
                }
                else if (slotPic.Image == barPic.Image)
                {
                    slotPic.Image = cherryPic.Image;
                }
            cycles--;
        }
        public void roll()
        {
                        slotchoice1 = rnd.Next(0, 5);
                        slotchoice2 = rnd.Next(0, 5);
                        slotchoice3 = rnd.Next(0, 5);
                        slotImage = slotItems[slotchoice1];
                        whatImage(1);
                        Task.Delay(1000);
                        slotImage = slotItems[slotchoice2];
                        Task.Delay(1000);
                        whatImage(2);
                        slotImage = slotItems[slotchoice3];
                        Task.Delay(1000);
                        whatImage(3);
            int prevCash = cash;
                        jackpot();
            if (prevCash == cash)//making sure they dont get 2 rewards for one spin
            {
                        minorWin();
            }
        }
        public void whatImage(int slotNum)
        {
            PictureBox slotPic = (PictureBox)Controls["slot" + slotNum.ToString()];
            if (slotImage == "cherry")
            {
                slotPic.Image = cherryPic.Image;
            }
            else if (slotImage == "lemon")
            {
                slotPic.Image = lemonPic.Image;

            }
            else if (slotImage == "watermelon")
            {
                slotPic.Image = watermelonPic.Image;

            }
            else if (slotImage == "seven")
            {
                slotPic.Image = sevenPic.Image;

            }
            else if (slotImage == "bar")
            {
                slotPic.Image = barPic.Image;

            }
        }
        public void jackpot()
        {
            if (slotchoice1 == slotchoice2 && slotchoice2 == slotchoice3)
            {
                if (slotImage == "cherry")
                {
                    cash += 75;
                    cashLabel.Text = "$" + cash.ToString();
                    winningsLabel.Text = "You won $75!";
                }
                else if (slotImage == "lemon")
                {
                    cash += 50;
                    cashLabel.Text = "$" + cash.ToString();
                    winningsLabel.Text = "You won $50!";
                }
                else if (slotImage == "watermelon")
                {
                    cash += 40;
                    cashLabel.Text = "$" + cash.ToString();
                    winningsLabel.Text = "You won $40!";

                }
                else if (slotImage == "seven")
                {
                    cash += 100;
                    cashLabel.Text = "$" + cash.ToString();
                    winningsLabel.Text = "You won $100!";
                }
                else if (slotImage == "bar")
                {
                    cash += 200;
                    cashLabel.Text = "$" + cash.ToString();
                    winningsLabel.Text = "You won $200!";
                }
            }
        }
        public void minorWin()
        {
            if (slotchoice1 == slotchoice2 || slotchoice2 == slotchoice1 || slotchoice2 == slotchoice3)
            {
                if (slotImage == "cherry")
                {
                    cash += 35;
                    cashLabel.Text = "$" + cash.ToString();
                    winningsLabel.Text = "You won $35!";
                }
                else if (slotImage == "lemon")
                {
                    cash += 20;
                    cashLabel.Text = "$" + cash.ToString();
                    winningsLabel.Text = "You won $20!";
                }
                else if (slotImage == "watermelon")
                {
                    cash += 15;
                    cashLabel.Text = "$" + cash.ToString();
                    winningsLabel.Text = "You won $15!";
                }
                else if (slotImage == "seven")
                {
                    cash += 55;
                    cashLabel.Text = "$" + cash.ToString();
                    winningsLabel.Text = "You won $55!";
                }
                else if (slotImage == "bar")
                {
                    cash += 75;
                    cashLabel.Text = "$" + cash.ToString();
                    winningsLabel.Text = "You won $75!";
                }
            }
        }
    }
}
