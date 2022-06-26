using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dicomeditor.components
{
    public partial class ImageThumbsCtl : UserControl
    {
        public ImageThumbsCtl(Image img)
        {
            InitializeComponent();

           pictureBox1.Image = img;
        }
    }
}
