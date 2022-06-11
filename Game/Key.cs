using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Key : PictureBox
    {
        public Key(int xPosition = 1455, int yPosition = 430, int width = 40, int height = 20)
        {
            this.Size = new Size(width, height);
            this.Location = new Point(xPosition, yPosition);
            this.Image = Properties.Resources.key;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

    }
}
