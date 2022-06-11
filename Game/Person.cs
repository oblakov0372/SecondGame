using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Person : PictureBox
    {

        public bool goLeft, goRight, jumping, keyHas, gameOver = false, move = false;
        public int jumpSpeed = 20;
        public int force = 16;
        public int playerSpeed = 10;
        public int scoreTxt = 0;

        public Person(int xPosition = 50, int yPosition = 500, int width = 50, int height = 50)
        {
            this.Size = new Size(width, height);
            this.Location = new Point(xPosition, yPosition);
            this.Image = Properties.Resources.player;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void KeyUpPerson(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                goLeft = false;

            if (e.KeyCode == Keys.D)
                goRight = false;

            if (jumping == true)
                jumping = false;
        }

        public void KeyDownPerson(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goLeft = true;
                move = true;
                Image = Properties.Resources.playerVert;
            }
            if (e.KeyCode == Keys.D)
            {
                goRight = true;
                move = true;
                Image = Properties.Resources.player;
            }
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
                move = true;
            }
        }

        public void Move()
        {
            this.Top += jumpSpeed;
            if (goLeft == true)
                Left -= playerSpeed; 

            if (goRight == true)
                Left += playerSpeed; 

            if (jumping == true)
            {
                jumpSpeed = -24;
                force -= 1;
            }
            else
            {
                jumpSpeed = 24;
            }

            if(jumping == true && force<0)
            {
                jumping = false;
            }
        }

        public void TouchPlatform(Form form)
        {
            foreach (Control x in form.Controls)
            {
                if (x is Platform)
                {
                    if (Bounds.IntersectsWith(x.Bounds) && jumping == false)
                    {
                        force = 16;
                        Top = x.Top - Height;
                        jumpSpeed = 0;
                    }
                    x.BringToFront();
                }
            }
        }

        public void TouchCoin(Form form)
        {
            foreach (Control x in form.Controls)
            {
                if (x is Coin)
                {
                    if (Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        x.Visible = false;
                        scoreTxt += 1;
                    }
                }
            }
        }

        public void TouchEnemy(Form form, Timer timer)
        {
            foreach(Control x in form.Controls)
            {
                if(x is Enemy)
                {
                    if (Bounds.IntersectsWith(x.Bounds)){
                        timer.Stop();
                        MessageBox.Show($"You were killed. Score:{scoreTxt}.\nClick Ok to play again");
                        gameOver = true;
                    }
                }
            }
        }

        public void EnterTheDoor(Key key,Door door,Timer timer)
        {
            if (Bounds.IntersectsWith(key.Bounds))
            {
                key.Visible = false;
                keyHas = true;
                door.Image = Properties.Resources.door_open;
                door.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (Bounds.IntersectsWith(door.Bounds) && keyHas == true)
            {
                timer.Stop();
                MessageBox.Show($"You Win. Score:{scoreTxt}.\nClick Ok to play again");
                gameOver = true;
            }
        }
        public void Loss(Form form, Timer timer)
        {
            if(this.Top + this.Height > form.ClientSize.Height)
            {
                timer.Stop();
                MessageBox.Show($"You Died. Score:{scoreTxt}.\nClick Ok to play again");
                gameOver = true;
            }
        }
    }
}
