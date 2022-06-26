using FellowOakDicom;
using FellowOakDicom.Imaging;
using FellowOakDicom.Imaging.Render;
using FellowOakDicom.Imaging.Codec;
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
    public partial class ImageDisplayCtl : UserControl
    {
        public ImageDisplayCtl(DicomDataset dataset)
        {
            InitializeComponent();

            _dataset = dataset;
            var dicomImage = new DicomImage(_dataset);
            IImage iImage = dicomImage.RenderImage(0);
            var sharpImage = iImage.AsSharpImage();

            using var output = new MemoryStream();
            sharpImage.Save(output, new SixLabors.ImageSharp.Formats.Bmp.BmpEncoder());
            output.Position = 0;

            var bitmap = Bitmap.FromStream(output);
            pictureBox1.Image = bitmap;

            ShowInfo();
        }
        public ImageDisplayCtl(Image img)
        {
            InitializeComponent();
            pictureBox1.Image = img;

            //Label lab1 = new Label();
            //lab1.Text = "测试文本显示";
            //lab1.Top = 20;
            //lab1.Left = 20;
            //lab1.AutoEllipsis = true;
            //lab1.AutoSize = true;
            //lab1.Font = new Font("宋休", 16, FontStyle.Regular, GraphicsUnit.Pixel);
            //lab1.ForeColor = Color.Red;
            //lab1.BackColor = Color.Transparent;
            //pictureBox1.Controls.Add(lab1);
            //lab1.BringToFront();

            string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources/ct.dcm");
            _dataset = DicomFile.Open(filename).Dataset;
            ShowInfo();

        }

        private void ShowInfo()
        {
            ShowInfoLeftTop();
            ShowInfoRightTop();
            ShowInfoLeftBottom();
            ShowInfoRightBottom();
        }

        private void ShowInfoLeftTop()
        {
            string patientID, patientName, patientSex;
            DateTime? patientBirthday;

            _dataset.TryGetString(DicomTag.PatientID, out patientID);
            _dataset.TryGetString(DicomTag.PatientName, out patientName);
            _dataset.TryGetString(DicomTag.PatientSex, out patientSex);
            patientBirthday = _dataset.GetDateTime(DicomTag.PatientBirthDate, DicomTag.PatientBirthTime);

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("patientid", patientID);
            data.Add("patientname", patientName);
            data.Add("patientsex", patientSex);
            data.Add("patientbirthday", patientBirthday.Value.ToString("yyyy-MM-dd HH:mm:ss"));

            int i = 0;
            foreach (KeyValuePair<string, string> kv in data)
            {
                Label lab1 = new Label();
                lab1.Text = kv.Value;
                lab1.TextAlign = ContentAlignment.MiddleLeft;
                lab1.Top = 10 + i * 16 + 2;
                lab1.Left = 10;
                lab1.AutoEllipsis = true;
                lab1.AutoSize = true;
                lab1.MaximumSize = new Size(200, 14);
                lab1.Font = new Font("宋休", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                lab1.ForeColor = Color.Red;
                lab1.BackColor = Color.Transparent;
                lab1.BackColor = Color.White;
                pictureBox1.Controls.Add(lab1);
                i++;
            }
        }

        private void ShowInfoRightTop()
        {
            string patientID, patientName, patientSex;
            DateTime? patientBirthday;

            _dataset.TryGetString(DicomTag.PatientID, out patientID);
            _dataset.TryGetString(DicomTag.PatientName, out patientName);
            _dataset.TryGetString(DicomTag.PatientSex, out patientSex);
            patientBirthday = _dataset.GetDateTime(DicomTag.PatientBirthDate, DicomTag.PatientBirthTime);

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("patientid", patientID);
            data.Add("patientname", patientName);
            data.Add("patientsex", patientSex);
            data.Add("patientbirthday", patientBirthday.Value.ToString("yyyy-MM-dd HH:mm:ss"));

            int i = 0;
            foreach (KeyValuePair<string, string> kv in data)
            {
                Label lab1 = new Label();
                lab1.Text = kv.Value;
                lab1.TextAlign = ContentAlignment.MiddleRight;
                lab1.Top = 10 + i * 16 + 2;
                lab1.Left = 300;
                lab1.AutoEllipsis = true;
                lab1.AutoSize = true;
                lab1.MaximumSize = new Size(200, 14);
                lab1.Font = new Font("宋休", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                lab1.ForeColor = Color.Red;
                lab1.BackColor = Color.Transparent;
                lab1.BackColor = Color.White;
                pictureBox1.Controls.Add(lab1);
                i++;
            }

        }

        private void ShowInfoLeftBottom()
        {
            string patientID, patientName, patientSex;
            DateTime? patientBirthday;

            _dataset.TryGetString(DicomTag.PatientID, out patientID);
            _dataset.TryGetString(DicomTag.PatientName, out patientName);
            _dataset.TryGetString(DicomTag.PatientSex, out patientSex);
            patientBirthday = _dataset.GetDateTime(DicomTag.PatientBirthDate, DicomTag.PatientBirthTime);

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("patientid", patientID);
            data.Add("patientname", patientName);
            data.Add("patientsex", patientSex);
            data.Add("patientbirthday", patientBirthday.Value.ToString("yyyy-MM-dd HH:mm:ss"));

            int i = 0;
            foreach (KeyValuePair<string, string> kv in data)
            {
                Label lab1 = new Label();
                lab1.Text = kv.Value;
                lab1.TextAlign = ContentAlignment.MiddleRight;
                lab1.Top = this.Height - 10 - 16 - 1;
                lab1.Left = 10;

                lab1.AutoEllipsis = true;
                lab1.AutoSize = true;
                lab1.MaximumSize = new Size(200, 14);
                lab1.Font = new Font("宋休", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                lab1.ForeColor = Color.Red;
                lab1.BackColor = Color.Transparent;
                lab1.BackColor = Color.White;
                pictureBox1.Controls.Add(lab1);
                i++;
            }

        }

        private void ShowInfoRightBottom()
        {
            string patientID, patientName, patientSex;
            DateTime? patientBirthday;

            _dataset.TryGetString(DicomTag.PatientID, out patientID);
            _dataset.TryGetString(DicomTag.PatientName, out patientName);
            _dataset.TryGetString(DicomTag.PatientSex, out patientSex);
            patientBirthday = _dataset.GetDateTime(DicomTag.PatientBirthDate, DicomTag.PatientBirthTime);

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("patientid", patientID);
            data.Add("patientname", patientName);
            data.Add("patientsex", patientSex);
            data.Add("patientbirthday", patientBirthday.Value.ToString("yyyy-MM-dd HH:mm:ss"));

            int i = 0;
            foreach (KeyValuePair<string, string> kv in data)
            {
                Label lab1 = new Label();
                lab1.Text = kv.Value;
                lab1.Top = 10 + i * 16 + 2;
                lab1.Left = 10;
                lab1.AutoEllipsis = true;
                lab1.AutoSize = true;
                lab1.MaximumSize = new Size(200, 14);
                lab1.Font = new Font("宋休", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                lab1.ForeColor = Color.Red;
                lab1.BackColor = Color.Transparent;
                lab1.BackColor = Color.White;
                pictureBox1.Controls.Add(lab1);
                i++;
            }

        }

        private DicomDataset _dataset;
    }
}
