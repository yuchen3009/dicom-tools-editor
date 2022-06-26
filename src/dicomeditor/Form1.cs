using dicomeditor.components;
using FellowOakDicom;

namespace dicomeditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources/ct.dcm");
            var dataset = DicomFile.Open(filename).Dataset;
            var idCtl = new ImageDisplayCtl(dataset)
            {
                Dock = DockStyle.Fill
            };
            mainSplitContainer.Panel2.Controls.Add(idCtl);


            //var img = Bitmap.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources/pic-01.bmp"));
            //var idCtl = new ImageDisplayCtl(img);
            //idCtl.Dock = DockStyle.Fill;
            //mainSplitContainer.Panel2.Controls.Add(idCtl);

            for (int i = 0; i < 10; i++)
            {
                var thumbnailImage = Bitmap.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources/t1.bmp"));
                var thumbnail = new ImageThumbsCtl(thumbnailImage);
                thumbnail.Margin = new Padding(5);
                thumbnailPanel.Controls.Add(thumbnail);

            }
        }
    }
}