using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Platform : PictureBox
    {
        public Platform(int xPosition, int yPosition, int width = 150, int height = 50)
        {
            this.Size = new Size(width, height);
            this.Location = new Point(xPosition, yPosition);
            this.Image = Properties.Resources.platform;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

    }
}