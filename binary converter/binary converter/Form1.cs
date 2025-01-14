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
        //private TextBox[] inputs = new TextBox[9];
        private double fin = 0;

        List<string> inputs = new List<string>();
        List<double> num = new List<double>();
        List<bool> upd = new List<bool>();
        public Form1()
        {

            InitializeComponent();
            //for (int i = 0; i < inputs.Capacity; i++)
            //{
            //    inputs[i] = (TextBox)Controls["textBox"+i.ToString()];
            //}
            //Array.Reverse(inputs);
            foreach (Control tb in Controls.OfType<TextBox>())
            {
                if (tb is TextBox)
                {
                    inputs.Add(tb.Text);
                    upd.Add(false);
                    num.Add(0);
                }

            }


        }

        private void checkBox16bin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8bin_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void checkBox4bin_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void checkBox2bin_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void checkBox1bin_CheckedChanged(object sender, EventArgs e)
        {


        }
        private void updateNum()
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                var temp = (TextBox)Controls["textBox" + i.ToString()];
                inputs[i] = temp.Text;
            }
            for (int i = 0; i < inputs.Count; i++)
            {   
                if (inputs[i] == "1" && upd[i]==false)
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

        private void textBox0_TextChanged(object sender, EventArgs e)
        {
            updateNum();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            updateNum();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            updateNum();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            updateNum();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            updateNum();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            updateNum();

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            updateNum();

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            updateNum();

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            updateNum();

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            updateNum();

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            updateNum();

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            updateNum();

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            updateNum();

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            updateNum();

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            updateNum();

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            updateNum();

        }
    }
}
