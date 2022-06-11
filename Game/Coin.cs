using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Coin : PictureBox
    {
        public Coin(int xPosition, int yPosition,  int width = 10, int height = 10)
        {
            this.Size = new Size(width, height);
            this.Location = new Point(xPosition, yPosition);
            this.Image = Properties.Resources.coin;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void SpawnCoin(Timer timer)
        {
            this.Visible = true;
            timer.Stop();
        }
    }
}
