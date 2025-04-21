using quartergame;
using Quartet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace quartet2
{
    public partial class Form1 : Form
    {
        List<CarCard> cardList = new List<CarCard>();

        CarCard A1 = new CarCard("A1", "BMW Z8", 250, 4.7, 400, 4941, 8, 6600, "a1.jpg");
        CarCard A2 = new CarCard("A2", "MG Xpower SV Club Sport", 230, 4.2, 465, 4997, 8, 6450, "a2.jpg");
        CarCard A3 = new CarCard("A3", "Ferrari F430 F1", 315, 4.0, 490, 4308, 8, 8500, "a3.jpg");
        CarCard A4 = new CarCard("A4", "Viper GTS", 285, 4.6, 411, 7990, 10, 5100, "a4.jpg");

        CarCard B1 = new CarCard("B1", "Ford GT", 325, 3.3, 550, 5403, 8, 5250, "b1.jpg");
        CarCard B2 = new CarCard("B2", "TVR Sagaris", 300, 3.9, 3966, 400, 8, 7000, "b2.jpg");
        CarCard B3 = new CarCard("B3", "Range Rover Sport", 225, 7.6, 390, 4197, 8, 5750, "b3.jpg");
        CarCard B4 = new CarCard("B4", "Rinspeed Chopster", 290, 4.4, 600, 4511, 8, 6700, "b4.jpg");

        CarCard C1 = new CarCard("C1", "Maserati Spyder", 283, 5.0, 390, 4244, 8, 7000, "c1.jpg");
        CarCard C2 = new CarCard("C2", "Toyota Celia", 205, 8.7, 143, 1794, 4, 6400, "c2.jpg");
        CarCard C3 = new CarCard("C3", "Porsche 911 Targa", 285, 5.2, 320, 3596, 6, 6800, "c3.jpg");
        CarCard C4 = new CarCard("C4", "Corvette Coupe", 281, 5.2, 344, 5665, 8, 5400, "c4.jpg");

        CarCard D1 = new CarCard("D1", "Audi RS4", 250, 4.8, 420, 4163, 8, 7800, "d1.jpg");
        CarCard D2 = new CarCard("D2", "Audi RS 6 Plus", 280, 4.6, 480, 4172, 8, 6400, "d2.jpg");
        CarCard D3 = new CarCard("D3", "Nissan 350 Z", 250, 5.9, 280, 3498, 6, 6200, "d3.jpg");
        CarCard D4 = new CarCard("D4", "Mercedes CLK DTM AMG", 320, 4.0, 582, 5439, 8, 6100, "d4.jpg");

        CarCard E1 = new CarCard("E1", "Aston Martin V8 Vantage", 280, 5.0, 4282, 385, 8, 7000, "e1.jpg");
        CarCard E2 = new CarCard("E2", "Ferrari F50", 325, 3.9, 521, 4700, 12, 8500, "e2.jpg");
        CarCard E3 = new CarCard("E3", "BMW 645 Ci", 250, 5.6, 333, 4398, 7, 6100, "e3.jpg");
        CarCard E4 = new CarCard("E4", "Bentley Azure", 241, 6.7, 6750, 388, 8, 4000, "e4.jpg");

        CarCard F1 = new CarCard("F1", "Opel Astra Coupe 2.0", 245, 7.5, 192, 1998, 4, 5400, "f1.jpg");
        CarCard F2 = new CarCard("F2", "VW Golf R32", 248, 6.2, 250, 3189, 6, 6300, "f2.jpg");
        CarCard F3 = new CarCard("F3", "Chrysler Crossfire", 250, 6.9, 218, 3199, 6, 5700, "f3.jpg");
        CarCard F4 = new CarCard("F4", "Fisker Tramonto", 325, 3.6, 610, 5439, 8, 6100, "f4.jpg");

        CarCard G1 = new CarCard("G1", "Marcos Mantara", 225, 5.4, 190, 3998, 8, 4750, "g1.jpg");
        CarCard G2 = new CarCard("G2", "Mercedes-Benz SL 500", 250, 6.3, 4966, 306, 8, 5600, "g2.jpg");
        CarCard G3 = new CarCard("G3", "Alfa Romeo Brera", 248, 6.3, 260, 3195, 6, 6200, "g3.jpg");
        CarCard G4 = new CarCard("G4", "Porsche Cayman S", 275, 5.4, 295, 3387, 6, 6250, "g4.jpg");

        CarCard H1 = new CarCard("H1", "BMW Z4", 250, 5.9, 2979, 231, 6, 5900, "h1.jpg");
        CarCard H2 = new CarCard("H2", "Alfa Romeo GT", 243, 6.7, 240, 3179, 6, 6400, "h2.jpg");
        CarCard H3 = new CarCard("H3", "Pontiac GTO", 280, 5.7, 5970, 400, 8, 5200, "h3.jpg");
        CarCard H4 = new CarCard("H4", "BMW M5", 250, 4.7, 4999, 507, 10, 7750, "h4.jpg");

        CarCard Lose = new CarCard("Player Lost all cars", "", 0, 0, 0, 0, 0, 0, "X.jpg");

        Deck carDeck;
        hand p1 = new hand(1);
        hand p2 = new hand(2);
        hand p3 = new hand(3);
        hand p4 = new hand(4);
        hand currentWin;

        bool hl = true;
        public Form1()
        {
            InitializeComponent();
            Type type = typeof(Form1);
            type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).ToList().ForEach(f =>
            {
                if (f.FieldType == typeof(CarCard))
                {
                    if (f.Name != "Lose")
                    {
                        cardList.Add((CarCard)f.GetValue(this));
                    }
                }
            });
            carDeck = new Deck(cardList);
            carDeck.Shuffle();
            for (int i = 0; i < 4; i++)
            {
                p1.add(carDeck.GetCard(0));
                p2.add(carDeck.GetCard(0));
                p3.add(carDeck.GetCard(0));
                p4.add(carDeck.GetCard(0));
                showCard(p1.topCard(), p1);
                //showCard(p2.topCard(), p2);
                //showCard(p3.topCard(), p3);
                //showCard(p4.topCard(), p4);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(CarCard.category));

        }
        private void show(hand player)
        {
            if (player.topCard() != null)
            {
                showCard(player.topCard(), player);

            }
        }
        private void hide(hand play)
        {
            int player = play.number;
            var num = (Label)Controls["Num" + player];
            var pic = (PictureBox)Controls["pictureBox" + player];
            var name = (Label)Controls["name" + player];
            var ID = (Label)Controls["ID" + player];
            var speed = (Label)Controls["speed" + player];
            var accel = (Label)Controls["accel" + player];
            var HP = (Label)Controls["HP" + player];
            var CC = (Label)Controls["CC" + player];
            var cyl = (Label)Controls["cyl" + player];
            var RPM = (Label)Controls["RPM" + player];
            pic.Image=null;
            name.Text = null;
            ID.Text = null;
            speed.Text = null;
            accel.Text = null;
            HP.Text = null;
            CC.Text = null;
            cyl.Text = null;
            RPM.Text = null;
            if (play.topCard() != Lose)
            {
                num.Text = play.carCards.Count.ToString();
            }
            else
            {
                num.Text = "0";
                pic.Load(play.topCard().pic);
                name.Text = play.topCard().name;
                ID.Text = play.topCard().id;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (carDeck.Count() > 0)
            {
                p1.next();
                p2.next();
                p3.next();
                p4.next();
                show(currentWin);
            }

        }
        private void showCard(CarCard card, hand play)
        {
            if (card != null)
            {
                int player = play.number;
                var num = (Label)Controls["Num" + player];
                var pic = (PictureBox)Controls["pictureBox" + player];
                var name = (Label)Controls["name"+player];
                var ID = (Label)Controls["ID" + player];
                var speed = (Label)Controls["speed" + player];
                var accel = (Label)Controls["accel" + player];
                var HP = (Label)Controls["HP" + player];
                var CC = (Label)Controls["CC" + player];
                var cyl = (Label)Controls["cyl" + player];
                var RPM = (Label)Controls["RPM" + player];
                num.Text = play.carCards.Count.ToString();
                pic.Load(card.pic);
                name.Text = card.name;
                ID.Text = card.id;
                speed.Text = card.maxspeed.ToString();
                accel.Text = card.zerotosixty.ToString();
                HP.Text = card.hp.ToString();
                CC.Text = card.cc.ToString();
                cyl.Text = card.cylinders.ToString();
                RPM.Text = card.rpm.ToString();


            }
        }

        private void check_Click(object sender, EventArgs e)
        {
            CarCard.category category = (CarCard.category)comboBox1.SelectedItem;
            CarCard check = Lose;
            if (hl)
            {
                check = p1.topCard().Compare(p2.topCard(), category);
                check = check.Compare(p3.topCard(), category);
                check = check.Compare(p4.topCard(), category);
            }
            else
            {
                check = p1.topCard().CompareLow(p2.topCard(), category);
                if (p1.topCard()==Lose)
                {
                    check=p2.topCard();
                }
                else if (p2.topCard() == Lose)
                {
                    check = p1.topCard();
                }
                if (p3.topCard() != Lose)
                {
                    check = check.CompareLow(p3.topCard(), category);

                }
                if (p4.topCard() != Lose)
                {
                    check = check.CompareLow(p4.topCard(), category);

                }

            }



            if (check == p1.topCard())
            {
                MessageBox.Show("p1 won");
                outcome(p1, p2, p3, p4);

            }
            else if (check == p2.topCard())
            {
                MessageBox.Show("p2 won");
                outcome(p2, p1, p3, p4);

            }
            else if (check == p3.topCard())
            {
                MessageBox.Show("p3 won");
                outcome(p3, p1, p2, p4);

            }
            else if (check == p4.topCard())
            {
                MessageBox.Show("p4 won");
                outcome(p4, p1, p2, p3);

            }
            else
            {
                MessageBox.Show("No Winner");
            }
            CheckLabel.Text = check.name;
        }
        
        private void outcome(hand win, hand lose1, hand lose2, hand lose3)
        {
            if (lose1.topCard() != Lose)
            {
                win.add(lose1.topCard());
            }
            if (lose2.topCard() != Lose)
            {
                win.add(lose2.topCard());
            }
            if (lose3.topCard() != Lose)
            {
                win.add(lose3.topCard());
            }
            lose1.remove(lose1.topCard());
            lose2.remove(lose2.topCard());
            lose3.remove(lose3.topCard());
            if (lose1.topCard() == null)
            {
                lose1.add(Lose);
            }
            if (lose2.topCard() == null)
            {
                lose2.add(Lose);
            }
            if (lose3.topCard() == null)
            {
                lose3.add(Lose);
            }
            p1.next();
            p2.next();
            p3.next();
            p4.next();
            currentWin = win;
            show(win);

            hide(lose1);
            hide(lose2);
            hide(lose3);

            if (win.carCards.Count == 16)
            {
                MessageBox.Show("Player " + win.number + " won all the cards");
            }

            
        }

        private void highRadio_CheckedChanged(object sender, EventArgs e)
        {
            hl = true;
            button1.Text = hl.ToString();

        }

        private void lowRadio_CheckedChanged(object sender, EventArgs e)
        {
            hl = false;
            button1.Text=hl.ToString();
        }
    }
}
