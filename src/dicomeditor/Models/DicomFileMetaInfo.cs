using dicomeditor.Attributes;
using FellowOakDicom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicomeditor.Models
{
    public class DicomFileMetaInfo
    {
        public string? PatientID { get; set; }
        public string? PatientName { get; set; }
        public string? PatientSex { get; set; }
        public string? PatientBirthday { get; set; }
        public string? AccessionNumber { get; set; }
        public string? StudyID { get; set; }
        public string? StudyInstanceUID { get; set; }
        public DateTime? StudyDateTime { get; set; }
        public string? PatientAge { get; set; }
        public string? StudyDescription { get; set; }
        public int SeriesNumber { get; set; }
        public string? SeriesInstanceUID { get; set; }
        public string? Modality { get; set; }
        public string? SeriesDescription { get; set; }
        public string? BodyPartExamination { get; set; }
        public string? InstanceNumber { get; set; }
        public string? SOPInstanceUID { get; set; }
        public string? WindowWidth { get; set; }
        public string? WindowsCenter { get; set; }
        public int NumberOfFrames { get; set; }
        public DateTime? ContentDateTime { get; set; }
        public DateTime? AcquisitionDateTime { get; set; }
        public string? PatientOrientation { get; set; }
        public string? ImageType { get; set; }
        public int SamplesPerPixel { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
    }
}
