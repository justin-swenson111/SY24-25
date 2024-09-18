using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Tile
    {
        private Button m_b;
        private bool m_flag;
        private bool m_dug;
        private bool m_mine;
        private int m_nearby;
        public Tile(Button b)
        {
            m_b = b;
            m_b.BackColor = System.Drawing.Color.Silver;
        }
        public void setMine(bool b) {m_mine = b;}
        public void setDug(bool b) {m_dug = b;}
        public void setFlag(bool b) {m_flag = b; }

    }
}
