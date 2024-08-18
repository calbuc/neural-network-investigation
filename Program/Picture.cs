using System;
using System.Drawing;
using System.Windows.Forms;

namespace Program
{
    public partial class Picture : Form
    {
        public Picture(Bitmap image)
        {
            InitializeComponent();
            pictureBox1.Image = image;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
