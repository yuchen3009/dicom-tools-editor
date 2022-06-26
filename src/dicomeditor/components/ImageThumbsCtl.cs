using dicomeditor.Models;
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
        private readonly StudyInfo _study;
        public string StudyInstanceUID
        {
            get
            {
                if (_study == null)
                    return string.Empty;
                return _study.StudyInstanceUID;
            }
        }
        public ImageThumbsCtl(StudyInfo studyInfo)
        {
            InitializeComponent();
            if (studyInfo == null)
                throw new ArgumentNullException(nameof(studyInfo));

            _study = studyInfo;
            lbl_acc.Text = $"{studyInfo.AccessionNumber}, {studyInfo.PatientSex}";
            lbl_pat.Text = $"{studyInfo.PatientName}, {studyInfo.PatientID}, {studyInfo.StudyDescription}, {studyInfo.StudyInstanceUID}";

            pictureBox1.Image = Bitmap.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources/t1.bmp"));
        }
    }
}
