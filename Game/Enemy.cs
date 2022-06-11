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
    class Enemy : PictureBox
    {
        bool goLeft = true, goRight;
        int enemySpeed = 5;

        public Enemy(int xPosition, int yPosition,int width = 50,int height = 50)
        {
            this.Size = new Size(width,height);
            this.Location = new Point(xPosition,yPosition);
            this.Image = Properties.Resources.enemyVert;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        
        public void Move(Form form)
        {
            foreach (Control x in form.Controls)
            {
                if (x is Platform)
                {
                    if (Bounds.IntersectsWith(x.Bounds)){
                        if (this.Location.X == x.Location.X)
                        {
                            goLeft = false;
                            goRight = true;
                            this.Image = Properties.Resources.enemy;
                        }
                        if (this.Location.X + this.Width == x.Location.X + x.Width)
                        {
                            goLeft = true;
                            goRight = false;
                            this.Image = Properties.Resources.enemyVert;
                        }
                        
                    } 
                }
            }
            if (goLeft == true)
                Left -= enemySpeed;

            if (goRight == true)
                Left += enemySpeed;
        }
    }
}
