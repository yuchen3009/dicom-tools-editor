using dicomeditor.components;
using dicomeditor.Models;
using dicomeditor.ViewModels;
using FellowOakDicom;

namespace dicomeditor
{
    public partial class Form1 : Form
    {
        private MainFormViewModel _model = new MainFormViewModel();
        private ImageDisplayCtl _displayArea;
        public Form1()
        {
            InitializeComponent();
            Rectangle rect = Screen.GetWorkingArea(this);
            this.Width = (int)(rect.Width * 0.8);
            this.Height= (int)(rect.Height * 0.8);
            this.Top = (rect.Height - this.Height)/2;
            this.Left = (rect.Width - this.Width)/2;

            //string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources/ct.dcm");
            //var dataset = DicomFile.Open(filename).Dataset;
            //var idCtl = new ImageDisplayCtl(dataset)
            //{
            //    Dock = DockStyle.Fill
            //};
            //mainSplitContainer.Panel2.Controls.Add(idCtl);


            ////var img = Bitmap.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources/pic-01.bmp"));
            ////var idCtl = new ImageDisplayCtl(img);
            ////idCtl.Dock = DockStyle.Fill;
            ////mainSplitContainer.Panel2.Controls.Add(idCtl);

            //for (int i = 0; i < 10; i++)
            //{
            //    var thumbnailImage = Bitmap.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources/t1.bmp"));
            //    var thumbnail = new ImageThumbsCtl(thumbnailImage);
            //    thumbnail.Margin = new Padding(5);
            //    thumbnailPanel.Controls.Add(thumbnail);

            //}

            _displayArea = new ImageDisplayCtl();
            _displayArea.Dock = DockStyle.Fill;
            mainSplitContainer.Panel2.Controls.Add(_displayArea);
            _displayArea.Show();

        }

        private void OpenOrAppendFile(string filename, bool append = false)
        {
            if (!append)
            {
                _model.Clear();
                //????
                thumbnailPanel.Controls.Clear();
            }

            var studyinfo = _model.AddOrAppend(filename);

            ImageThumbsCtl thumbnail = null;

            for (int i = 0; i < thumbnailPanel.Controls.Count; i++)
            {
                var ctl = thumbnailPanel.Controls[i];
                var thumbsCtl = ctl as ImageThumbsCtl;
                if (string.Equals(studyinfo.StudyInstanceUID, thumbsCtl.StudyInstanceUID))
                {
                    thumbnail = thumbsCtl;
                    break;
                }
            }

            if (thumbnail != null)
            {
                thumbnail.BackColor = Color.DarkRed;
            }
            else
            {
                thumbnail = new ImageThumbsCtl(studyinfo)
                {
                    Margin = new Padding(5)
                };
                thumbnailPanel.Controls.Add(thumbnail);
            }

            _displayArea.Render(studyinfo.Files.First());
        }

        private void meun_file_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string selectedFilename = openFileDialog.FileName;

            OpenOrAppendFile(selectedFilename);
        }

        private void menu_file_open_folder_Click(object sender, EventArgs e)
        {

        }

        private void menu_file_append_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string selectedFilename = openFileDialog.FileName;

            OpenOrAppendFile(selectedFilename, true);

        }

        private void menu_file_append_folder_Click(object sender, EventArgs e)
        {

        }

        private void menu_file_save_Click(object sender, EventArgs e)
        {

        }

        private void menu_file_save_all_Click(object sender, EventArgs e)
        {

        }

        private void menu_file_save_as_Click(object sender, EventArgs e)
        {

        }

        private void menu_file_save_as_all_Click(object sender, EventArgs e)
        {

        }

        private void menu_file_exit_Click(object sender, EventArgs e)
        {

        }

        private TagFrm _tagFrm;
        private void menu_lookup_tags_Click(object sender, EventArgs e)
        {
            _tagFrm = new TagFrm(_model.CurrentDicomReference);
            _tagFrm.ShowIcon = false;
            _tagFrm.ShowInTaskbar = false;
            _tagFrm.MaximizeBox = false;
            _tagFrm.MinimizeBox = false;
            _tagFrm.StartPosition = FormStartPosition.CenterParent;
            _tagFrm.ShowDialog();
        }
    }
}