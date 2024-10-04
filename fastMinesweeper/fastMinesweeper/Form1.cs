using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fastMinesweeper
{
    https://www.youtube.com/watch?v=wdSxJWuSjmg
    public partial class Form1 : Form
    {
        //positions 10 is a bomb, 1-8 is adjacent mines, 20 is no bombs adjacent
        byte[,] Positions = new byte[10,10];
        Button[,] Buttonlist = new Button[10,10];
        public Form1()
        {
            InitializeComponent();
            generateBombs();
            generatePositionValue();
            GenerateButtons();
        }
        Random rnd = new Random();
        private void generateBombs()
        {
            int bombs = 0;
            while (bombs<10)
            {
                int x = rnd.Next(0,9);
                int y = rnd.Next(0, 9);
                if (Positions[x,y] == 0)
                {
                    //if there is no assigned value to the positions, make it a mine
                    Positions[x,y] = 10;
                    bombs++;
                }
            }
        }
        private void generatePositionValue()
        {
            for (int x=0; x<10; x++)
            {
                for (int y=0; y<10; y++)
                {
                    if (Positions[x,y] == 10)
                        continue;
                    byte bombCounts = 0;
                    for (int counterX=-1; counterX<2; counterX++)
                    {
                        int checkerX = x +counterX;
                        for (int counterY=-1; counterY<2; counterY++)
                        {
                            int checkerY= y +counterY;
                            if (checkerX==-1 || checkerY==-1 || checkerX>9 || checkerY>9)
                                continue;

                            if (checkerY == y && checkerX == x)
                                continue;
                            if (Positions[checkerX,checkerY] == 10)
                                bombCounts++;
                        }
                    }
                    if (bombCounts == 0)
                        Positions[x, y] = 20;
                    else
                        Positions[x, y] = bombCounts;
                }
            }
        }

        private void GenerateButtons()
        {
            int xLoc = 3;
            int yLoc = 6;
            for (int x=0; x<10;x++)
            {
                for (int y=0; y<10;y++)
                {
                    Button btn = new Button();
                    btn.Parent = pnlBody;
                    btn.Location = new Point(xLoc, yLoc);
                    btn.Size = new Size(25, 22);
                    xLoc += 25;
                    btn.Tag = $"{x},{y}";
                    btn.Click += Btnclick;
                    btn.MouseUp += Btn_MouseUp;
                    Buttonlist[x,y]=btn;
                }
                xLoc = 3;
                yLoc += 22;
            }
        }

        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Btnclick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int x = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(0));
            int y =Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(1));
            byte value = Positions[x, y];
            if (value == 10)
            {
                btn.Image = minePic.Image;
            }
            else if (value == 20)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = SystemColors.ControlDark;

                btn.FlatAppearance.BorderSize = 1;
                btn.Enabled = false;
                openAdjacentTile(btn);
                points++;
            }
            else
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor=SystemColors.ControlDark;
                btn.FlatAppearance.MouseDownBackColor=btn.BackColor;
                btn.FlatAppearance.MouseOverBackColor = btn.BackColor;
                btn.Text = Positions[x, y].ToString();
                points++;
            }
            btn.Click -= Btnclick;
            txtScore.Text = points.ToString();
        }
        private void openAdjacentTile(Button btn)
        {
            int x = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(0));
            int y = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(1));
            List<Button> emptyButtons = new List<Button>();
            for (int counterX = -1; counterX < 2; counterX++)
            {
                int checkerX = x + counterX;
                for (int counterY = -1; counterY < 2; counterY++)
                {
                    int checkerY = y + counterY;
                    if (checkerX == -1 || checkerY == -1 || checkerX > 9 || checkerY > 9)
                        continue;

                    if (checkerY == y && checkerX == x)
                        continue;

                    Button buttonAdjacent = Buttonlist[checkerX, checkerY];

                    int xAdjacent = Convert.ToInt32(buttonAdjacent.Tag.ToString().Split(',').GetValue(0));
                    int yAdjacent = Convert.ToInt32(buttonAdjacent.Tag.ToString().Split(',').GetValue(1));

                    byte value = Positions[xAdjacent, yAdjacent];
                    if (value == 20)
                    {
                        if (buttonAdjacent.FlatStyle != FlatStyle.Flat)
                        {
                            buttonAdjacent.FlatStyle = FlatStyle.Flat;
                            btn.FlatAppearance.BorderColor = SystemColors.ControlDark;

                            btn.FlatAppearance.BorderSize = 1;
                            buttonAdjacent.Enabled = false;
                            emptyButtons.Add(buttonAdjacent);
                            points++;
                        }

                    }
                    else if (value != 10)
                    {
                        buttonAdjacent.PerformClick();
                    }

                }
            }
            foreach (var btnEmpty in emptyButtons)
            {
                openAdjacentTile(btnEmpty);
            }
            txtScore.Text = points.ToString();

        }
        int flags = 10;
        int points = 0;

        private void BtnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button btn = (Button)sender;
                if (btn.Image == null)
                {
                    btn.Image = FlagPic.Image;
                    flags--;
                }
                else
                {
                    btn.Image = null;
                    flags++;
                }
            txtScore.Text = points.ToString();

            }
        }

    }
}
