namespace Minesweeper
{
    public partial class Form1 : Form
    {
        Button[] btnGrid = new Button[100];
        Tile[] tilesGrid = new Tile[100];
        bool[] flagged = new bool[100];
        bool[] mine = new bool[100];
        bool[] clear = new bool[100];
        int numMines;
        Random rnd = new Random();
        bool firstClick = false;
        public int btnNum;
        string Position;

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 100; i++)
            {
                btnGrid[i] = (Button)Controls["button" + (i + 1).ToString()];
                btnGrid[i].BackColor = Color.Silver;
                tilesGrid[i] = new Tile(btnGrid[i]);
                flagged[i] = false;
                mine[i] = false;
                clear[i] = false;
            }


        }
        private void clickedButton(Button inputbutton)
        {
            findButton(inputbutton);
            if (firstClick == false)
            {
                firstClick = true;
                clear[btnNum] = true;
                for (int i = 0; i < 10; i++)
                {
                    mineSpawner();
                }
                for (int i = 0; i < 100; i++)
                {
                    if (mine[i])
                    {
                        numMines++;
                        btnGrid[i].BackColor = Color.Red;
                    }
                }
                mineFinder(inputbutton, btnNum);
                if (inputbutton.Text == "0")
                {
                    largeClear(inputbutton);
                }
                testLabel.Text = inputbutton.Name;
            }
            else if (mine[btnNum] != true)
            {
                mineFinder(inputbutton, btnNum);
                if (inputbutton.Text == "0")
                {
                    largeClear(inputbutton);
                }
            }
            else
            {

            }
        }
        private void mineSpawner()
        {
            Random rnd = new Random();
            int r = 0;
            r = rnd.Next(99);
            if (clear[r] != true && mine[r] != true)
            {
                mine[r] = true;
            }
            else
            {
                mineSpawner();
            }



        }

        private void findButton(Button inputbutton)
        {
            string b = inputbutton.Name.Substring(6);
            int.TryParse(b, out btnNum);
            btnNum -= 1;
        }

        private void largeClear(Button inputButton)
        {
            int clearNum;
            clearNum = btnNum - 1;
            if (Position == "center")
            {
                mineFinder(inputButton, clearNum);


            }

        }

        private void flagClick(Button inputbutton)
        {
            findButton(inputbutton);
            if (flagged[btnNum])
            {
                inputbutton.BackgroundImage = null;
                flagged[btnNum] = false;
            }
            else
            {
                inputbutton.BackgroundImage = flagPicture.Image;
                flagged[btnNum] = true;
            }
        }
        private void mineFinder(Button inputButton, int clearNum)
        {
            int nearbyMines = 0;
            inputButton.BackColor = Color.White;
            if (clearNum >= 11 && clearNum <= 88 && clearNum % 10 != 9 && clearNum != 9 && clearNum % 10 != 0)// only using this section to find mines in the center, avoiding the edges

            {
                if (mine[clearNum - 11])
                {
                    nearbyMines++;
                }
                if (mine[clearNum - 10])
                {
                    nearbyMines++;
                }
                if (mine[clearNum - 9])
                {
                    nearbyMines++;
                }
                if (mine[clearNum - 1])
                {
                    nearbyMines++;
                }
                if (mine[clearNum + 1])
                {
                    nearbyMines++;

                }
                if (mine[clearNum + 9])
                {
                    nearbyMines++;
                }
                if (mine[clearNum + 10])
                {
                    nearbyMines++;
                }
                if (mine[clearNum + 11])
                {
                    nearbyMines++;
                }
                Position = "center";

            }
            else if (clearNum <= 8 && clearNum >= 1) // finding the mines for the top row except for the corners
            {
                if (mine[clearNum - 1])
                {
                    nearbyMines++;
                }
                if (mine[clearNum + 1])
                {
                    nearbyMines++;

                }
                if (mine[clearNum + 9])
                {
                    nearbyMines++;
                }
                if (mine[clearNum + 10])
                {
                    nearbyMines++;
                }
                if (mine[clearNum + 11])
                {
                    nearbyMines++;
                }
                Position = "topCenter";


            }
            else if (clearNum >= 91 && clearNum <= 98) // finding the bottom row
            {
                if (mine[clearNum - 11])
                {
                    nearbyMines++;
                }
                if (mine[clearNum - 10])
                {
                    nearbyMines++;
                }
                if (mine[clearNum - 9])
                {
                    nearbyMines++;
                }
                if (mine[clearNum - 1])
                {
                    nearbyMines++;
                }
                if (mine[clearNum + 1])
                {
                    nearbyMines++;

                }
                Position = "bottomCenter";


            }
            else if (clearNum % 10 == 0 && clearNum != 90 && clearNum != 0) //finding left edge
            {
                if (mine[clearNum - 10])
                {
                    nearbyMines++;
                }
                if (mine[clearNum - 9])
                {
                    nearbyMines++;
                }
                if (mine[clearNum + 1])
                {
                    nearbyMines++;

                }
                if (mine[clearNum + 10])
                {
                    nearbyMines++;
                }
                if (mine[clearNum + 11])
                {
                    nearbyMines++;
                }
                Position = "leftCenter";



            }
            else if (clearNum % 10 == 9 && clearNum != 99 && clearNum != 9)//finding right edge
            {
                if (mine[clearNum - 10])
                {
                    nearbyMines++;
                }
                if (mine[clearNum - 11])
                {
                    nearbyMines++;
                }
                if (mine[clearNum - 1])
                {
                    nearbyMines++;
                }
                if (mine[clearNum + 9])
                {
                    nearbyMines++;
                }
                if (mine[clearNum + 10])
                {
                    nearbyMines++;
                }
                Position = "rightCenter";


            }
            else if (clearNum == 0)// finding top left corner
            {
                if (mine[clearNum + 1])
                {
                    nearbyMines++;

                }
                if (mine[clearNum + 10])
                {
                    nearbyMines++;
                }
                if (mine[clearNum + 11])
                {

                    nearbyMines++;
                }
                Position = "topleft";


            }
            else if (clearNum == 9)// finding top right corner
            {
                if (mine[clearNum - 1])
                {
                    nearbyMines++;

                }
                if (mine[clearNum + 10])
                {
                    nearbyMines++;
                }
                if (mine[clearNum + 9])
                {
                    nearbyMines++;
                }
                Position = "topRight";


            }
            else if (clearNum == 90)// finding bottom left corner
            {
                if (mine[clearNum + 1])
                {
                    nearbyMines++;

                }
                if (mine[clearNum - 10])
                {
                    nearbyMines++;
                }
                if (mine[clearNum - 11])
                {
                    nearbyMines++;
                }
                Position = "bottomLeft";


            }
            else if (clearNum == 99)// finding bottom right corner
            {
                if (mine[clearNum - 1])
                {
                    nearbyMines++;

                }
                if (mine[clearNum - 10])
                {
                    nearbyMines++;
                }
                if (mine[clearNum - 9])
                {
                    nearbyMines++;
                }
                Position = "bottomRight";


            }
            inputButton.Text = nearbyMines.ToString();
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
            testLabel.Text = b.Name;
        }

        private void button44_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                clickedButton(button44);
            }
            else
            {
                flagClick(button44);
            }
        }
    }
}
