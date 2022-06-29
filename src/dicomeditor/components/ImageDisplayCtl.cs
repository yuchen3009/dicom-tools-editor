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
using dicomeditor.Models;

namespace dicomeditor.components
{
    public partial class ImageDisplayCtl : UserControl
    {
        private List<List<DicomTag>> _leftTopCorner = new List<List<DicomTag>>();
        private List<List<DicomTag>> _rightTopCorner = new List<List<DicomTag>>();
        private List<List<DicomTag>> _leftBottomCorner = new List<List<DicomTag>>();
        private List<List<DicomTag>> _rightBottomCorner = new List<List<DicomTag>>();

        public ImageDisplayCtl()
        {
            InitializeComponent();
            Init();
            _dataset = new DicomDataset();

        }
        public ImageDisplayCtl(DicomReference dicomReference)
        {
            InitializeComponent();
            Init();
            _dataset = dicomReference.Dataset;

        }
        public ImageDisplayCtl(string filename)
        {
            InitializeComponent();
            Init();

            DicomFile dicomFile = DicomFile.Open(filename);
            _dataset = dicomFile.Dataset;

            RenderInternal();
        }

        public ImageDisplayCtl(DicomDataset dataset)
        {
            InitializeComponent();
            Init();

            _dataset = dataset;
            //var dicomImage = new DicomImage(_dataset);
            //IImage iImage = dicomImage.RenderImage(0);
            //var sharpImage = iImage.AsSharpImage();

            //using var output = new MemoryStream();
            //sharpImage.Save(output, new SixLabors.ImageSharp.Formats.Bmp.BmpEncoder());
            //output.Position = 0;

            //var bitmap = Bitmap.FromStream(output);
            //pictureBox1.Image = bitmap;

            RenderInternal();

        }

        private void Init()
        {
            _leftTopCorner = new List<List<DicomTag>> {
                new List<DicomTag>(){DicomTag.PatientName },
                new List<DicomTag>(){DicomTag.PatientID, DicomTag.PatientSex, DicomTag.PatientBirthDate },
                new List<DicomTag>(){DicomTag.InstitutionName},
                new List<DicomTag>(){DicomTag.AccessionNumber, DicomTag.StudyID, DicomTag.PatientAge},
                new List<DicomTag>(){DicomTag.Modality},
                new List<DicomTag>(){DicomTag.BodyPartExamined},
                new List<DicomTag>(){DicomTag.SeriesDescription},
                new List<DicomTag>(){DicomTag.SeriesNumber},
                new List<DicomTag>(){DicomTag.Rows, DicomTag.Columns},
                new List<DicomTag>(){DicomTag.WindowWidth, DicomTag.WindowCenter },
            };

            _rightBottomCorner= new List<List<DicomTag>> {
                new List<DicomTag>(){DicomTag.SeriesDescription }
            };
        }
        public void Render(DicomReference dicomReference)
        {
            _dataset = dicomReference.Dataset;

            RenderInternal();
        }
        public void Render(string filename)
        {
            DicomFile dicomFile = DicomFile.Open(filename);
            _dataset = dicomFile.Dataset;

            RenderInternal();
        }

        public void Render(DicomDataset dataset)
        {
            _dataset = dataset;
            RenderInternal();

        }

        private void RenderInternal()
        {
            pictureBox1.Image = Bitmap.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources/pic-01.bmp"));

            ShowInfo();
        }

        private void ShowInfo()
        {
            ShowInfoLeftTop();
            //ShowInfoRightTop();
            //ShowInfoLeftBottom();
            //ShowInfoRightBottom();
        }

        private void ShowInfoLeftTop()
        {
            pictureBox1.Controls.Clear();
            int i = 0;
            foreach (var item in _leftTopCorner)
            {
                Label lab1 = new Label();
                string text = string.Empty;
                foreach (var item2 in item)
                {
                    text += (_dataset.Contains(item2) ? _dataset.GetString(item2) : "") + ",";
                }
                lab1.Text = text.Trim(",".ToCharArray());
                lab1.TextAlign = ContentAlignment.MiddleLeft;
                lab1.Top = 10 + i * 24 + 4;
                lab1.Left = 10;
                lab1.AutoEllipsis = true;
                lab1.AutoSize = true;
                lab1.MaximumSize = new Size(this.Width/2, 24);
                lab1.Font = new Font("Verdana", 20, FontStyle.Regular, GraphicsUnit.Pixel);
                lab1.ForeColor = Color.Yellow;
                lab1.BackColor = Color.Transparent;
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
