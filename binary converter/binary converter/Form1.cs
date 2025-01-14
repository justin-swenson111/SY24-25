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
                        upd.Add(false);
                        num.Add(0);

                    }
                    else
                    {
                        Subinputs.Add(tb.Text);
                        ((TextBox)tb).TextChanged += inp2_TextChanged;
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
            outputLabel.Text = fin.ToString();
        }
        private void updateNum2()
        {
            for (int i = 0; i < Subinputs.Count; i++)
            {
                var temp = (TextBox)Controls["textBox" + (i+8).ToString()];
                Subinputs[i] = temp.Text;
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
            subOutputLabel.Text=Subfin.ToString();
        }


    }

}


