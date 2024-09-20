﻿using System;
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

        public Tile(Button b)
        {
            m_b = b;
            m_b.BackColor = System.Drawing.Color.Silver;
        }
        public void setNearby(int n) { m_nearby = n; }
        public void setFlagImage(Image b) { m_flagImage = b; }
        public void setMineImage(Image b) { m_mineImage = b; }

        public void setMine(bool b) 
        { 
            m_mine = b;
            m_b.BackgroundImage = m_mineImage;

        }

        public void setDug(bool b) { m_dug = b; }
        public void setFlag(bool b)
        {
            m_flag = b;
            if (m_flag)
            {
                m_b.BackgroundImage = m_flagImage;
            }
            else
            {
                m_b.BackgroundImage = null;
            }
        }


    }
}
