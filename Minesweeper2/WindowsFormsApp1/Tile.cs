using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Tile
    {
        private Button m_b;
        public bool m_flag;
        private bool m_dug;
        private bool m_mine;
        private int m_nearby;
        private Image m_flagImage;
        private Image m_mineImage;
        private int m_flags;
        public Tile(Button b)
        {
            m_b = b;
            m_b.BackColor = System.Drawing.Color.Silver;
        }
        public void resetCount()
        {
            m_nearby = 0;
            m_flags = 0;
        }
        public void setNearby() { m_nearby += 1; }
        public int getNearby() { return m_nearby; }

        public Boolean getFlag() { return m_flag; }
        public void setFlagImage(Image b) { m_flagImage = b; }
        public void setMineImage(Image b) { m_mineImage = b; }

        public void setMine(bool b) 
        { 
            m_mine = b;
            //if (m_mine)
            //m_b.BackgroundImage = m_mineImage;
            //else
            m_b.BackgroundImage = null;

        }
        public Boolean GetMine(){ return m_mine; }

        public void setDug() 
        { 
            m_dug = true;
            if (m_mine)
                m_b.BackgroundImage = m_mineImage;
            else 
                m_b.BackColor=Color.Gray;

        }
        public Boolean getDug()
        {
            if (m_dug)
            {
                return m_dug;
            }
            else
            {
                return false;
            }
        }
        public void setFlag()
        {
            m_flag = !m_flag;
            if (m_flag)
            {
                m_b.BackgroundImage = m_flagImage;
                m_flags++;
            }
            else
            {
                m_b.BackgroundImage = null;
                m_flags--;
            }

        }
        public int getFlagNum() { return m_flags; }




    }
}
