using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace binary_converter
{
    public partial class Form1 : Form
    {
        private double fin = 0;
        private double Subfin = 0;

        private string cmnd = "add";


        List<string> inputs = new List<string>();
        List<string> Subinputs = new List<string>();

        List<double> num = new List<double>();
        List<double> Subnum = new List<double>();

        List<bool> upd = new List<bool>();
        List<bool> Subupd = new List<bool>();

        public Form1()
        {
            InitializeComponent();
            foreach (Control tb in Controls.OfType<TextBox>())
            {
                if (tb is TextBox)
                {
                    if (inputs.Count < 8)
                    {
                        inputs.Add(tb.Text);
                        ((TextBox)tb).TextChanged += inp_TextChanged;
                        ((TextBox)tb).MouseClick += clicked;

                        tb.Text = "0";

                        upd.Add(false);
                        num.Add(0);

                    }
                    else
                    {
                        Subinputs.Add(tb.Text);
                        ((TextBox)tb).TextChanged += inp2_TextChanged;
                        ((TextBox)tb).MouseClick += clicked;
                        tb.Text = "0";

                        Subupd.Add(false);
                        Subnum.Add(0);
                    }

                }

            }
            updateNum1();
            updateNum2();


        }
        private void inp_TextChanged(object sender, EventArgs e)
        {
            updateNum2();
        }
        private void inp2_TextChanged(object sender, EventArgs e)
        {
            updateNum1();
        }
        private void clicked(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = textBox.Text == "0" ? "1" : "0";
        }
        private void updateNum1()
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                var temp = (TextBox)Controls["textBox" + i.ToString()];
                inputs[i] = temp.Text;
            }
            for (int i = 0; i < inputs.Count; i++)
            {
                if (inputs[i] == "1" && upd[i] == false)
                {
                    num[i] = Math.Pow(2, i);
                    upd[i] = true;
                    double updNum = num[i];
                    fin += updNum;
                }
                else if (inputs[i] == "0")
                {
                    upd[i] = false;
                    fin -= num[i];
                    num[i] = 0;
                }
            }
            inputLabel.Text = fin.ToString();
            if (cmnd == "add")
            {
                addNum();
            }
            else if (cmnd == "or")
            {
                orNum();
            }
            else if (cmnd == "and")
            {
                andNum();
            }
            else
            {
                xorNum();
            }
        }
        private void updateNum2()
        {
            for (int i = 0; i < Subinputs.Count; i++)
            {
                var temp = (TextBox)Controls["textBox" + (i+8).ToString()];
                Subinputs[i] = temp.Text;
                //label1.Text += temp.Text;
            }
            for (int i = 0; i < Subinputs.Count; i++)
            {
                if (Subinputs[i] == "1" && Subupd[i] == false)
                {
                    Subnum[i] = Math.Pow(2, i);
                    Subupd[i] = true;
                    double updNum = Subnum[i];
                    Subfin += updNum;
                }
                else if (Subinputs[i] == "0")
                {
                    Subupd[i] = false;
                    Subfin -= Subnum[i];
                    Subnum[i] = 0;
                }
            }
            subInputLabel.Text=Subfin.ToString();
            if (cmnd == "add")
            {
                addNum();
            }
            else if(cmnd == "or")
            {
                orNum();
            }
            else if (cmnd == "and")
            {
                andNum();
            }
            else
            {
                xorNum();
            }

        }
        private void addNum()
        {
            for (int i = 0; i<= Subinputs.Count; i++)
            {
                Label temp = (Label)Controls["label" + (i + 1)];
                temp.Text = "0";
            }
            string str = "";
            double added = fin + Subfin;
            outputLabel.Text = added.ToString();
            double exp = Math.Floor(Math.Log(added,2));
            for (double i = exp; i >= 0; i--)
            {
                if (added >= Math.Pow(2, i) && added > 0)
                {
                    added -= Math.Pow(2, i);
                    str += "1";
                }
                else
                {
                    str += "0";
                }
            }
            char[] arr= str.ToCharArray();
            Array.Reverse(arr);
            str = string.Join("", arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Label temp = (Label)Controls["label" + (i+1)];
                temp.Text = arr[i].ToString();
            }

        }
        private void orNum()
        {
            double outFin = 0;

            for (int i = 0; i <= Subinputs.Count; i++)
            {
                Label temp = (Label)Controls["label" + (i + 1)];
                temp.Text = "0";
            }
            for (int i = 0;i < Subinputs.Count; i++)
            {
                Label temp = (Label)Controls["label" + (i + 1)];

                if (inputs[i] == "1" || Subinputs[i]=="1")
                {
                    temp.Text = "1";
                    outFin += Math.Pow(2, i);

                }
                else
                {
                    temp.Text = "0";
                }
            }
            outputLabel.Text = outFin.ToString();

        }
        private void xorNum()
        {
            double outFin = 0;

            for (int i = 0; i <= Subinputs.Count; i++)
            {
                Label temp = (Label)Controls["label" + (i + 1)];
                temp.Text = "0";
            }
            for (int i = 0; i < Subinputs.Count; i++)
            {
                Label temp = (Label)Controls["label" + (i + 1)];

                if (inputs[i] ==Subinputs[i])
                {

                    temp.Text = "0";

                }
                else
                {
                    temp.Text = "1";
                    outFin += Math.Pow(2, i);
                }
            }
            outputLabel.Text = outFin.ToString();

        }
        private void andNum()
        {
            double outFin = 0;

            for (int i = 0; i <= Subinputs.Count; i++)
            {
                Label temp = (Label)Controls["label" + (i + 1)];
                temp.Text = "0";
            }
            for (int i = 0; i < Subinputs.Count; i++)
            {
                Label temp = (Label)Controls["label" + (i + 1)];

                if (inputs[i] == "1" && Subinputs[i] == "1")
                {
                    temp.Text = "1";
                    outFin += Math.Pow(2, i);
                }
                else
                {
                    temp.Text = "0";
                }
            }
            outputLabel.Text = outFin.ToString();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Subinputs.Count; i++)
            {
                var temp = (TextBox)Controls["textBox" + (i).ToString()];
                temp.Text = "0";
                updateNum1();
            }
        }

        private void subClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Subinputs.Count; i++)
            {
                var temp = (TextBox)Controls["textBox" + (i + 8).ToString()];
                temp.Text = "0";
                updateNum2();
            }
        }

        private void shiftR_Click(object sender, EventArgs e)
        {
            for(int i = 0;i < inputs.Count;i++)
            {
                var temp = (TextBox)Controls["textBox" + (i).ToString()];

                if (i+1<inputs.Count)
                {
                    temp.Text=inputs[i+1].ToString();
                }
                if(i + 1>= inputs.Count)
                {
                    temp.Text = "0";
                }
            }
            updateNum1();
        }

        private void subShiftR_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                var temp = (TextBox)Controls["textBox" + (i+8).ToString()];

                if (i + 1 < Subinputs.Count)
                {
                    temp.Text = Subinputs[i + 1].ToString();
                }
                if (i + 1 >= Subinputs.Count)
                {
                    temp.Text = "0";
                }
            }
            updateNum2();
        }

        private void shiftL_Click(object sender, EventArgs e)
        {
            for (int i = inputs.Count-1; i >=0; i--)
            {
                var temp = (TextBox)Controls["textBox" + (i).ToString()];
                if (i != 0)
                {
                    temp.Text = inputs[i-1];
                }
                else if (i == 0) 
                {
                    temp.Text = "0";
                }
            }
            updateNum1();
        }

        private void subShiftL_Click(object sender, EventArgs e)
        {
            for (int i = Subinputs.Count - 1; i >= 0; i--)
            {
                var temp = (TextBox)Controls["textBox" + (i+8).ToString()];
                if (i != 0)
                {
                    temp.Text = Subinputs[i - 1];
                }
                else if (i == 0)
                {
                    temp.Text = "0";
                }
            }
            updateNum2();
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            cmnd = "add";
            addNum();
        }

        private void orButton_Click(object sender, EventArgs e)
        {
            cmnd = "or";
            orNum();
        }

        private void andButton_Click(object sender, EventArgs e)
        {
            cmnd = "and";
            andNum();
        }

        private void xOrButton_Click(object sender, EventArgs e)
        {
            cmnd = "xor";
            xorNum();
        }
    }

}


