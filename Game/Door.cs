using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Door : PictureBox
    {
        public Door(int xPosition = 45, int yPosition = 10, int width = 60, int height = 90)
        {
            this.Size = new Size(width, height);
            this.Location = new Point(xPosition, yPosition);
            this.Image = Properties.Resources.door_closed;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

    }
}
