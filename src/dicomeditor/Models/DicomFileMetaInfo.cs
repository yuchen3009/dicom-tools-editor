using dicomeditor.Attributes;
using FellowOakDicom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using dicomeditor.Extensions;

namespace dicomeditor.Models
{
    public class DicomFileMetaInfo
    {
        public string? PatientID { get; set; }
        public string? PatientName { get; set; }
        public string? PatientSex { get; set; }
        public string? PatientBirthDate { get; set; }
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
        public string? BodyPartExamined { get; set; }
        public string? InstanceNumber { get; set; }
        public string? SOPInstanceUID { get; set; }
        public string? WindowWidth { get; set; }
        public string? WindowsCenter { get; set; }
        public int NumberOfFrames { get; set; }
        public DateTime? ContentDate { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public string? PatientOrientation { get; set; }
        public string? ImageType { get; set; }
        public int SamplesPerPixel { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public static DicomFileMetaInfo LoadFromFile(string filename)
        {
            var target = new DicomFileMetaInfo();
            var type = target.GetType();
            PropertyInfo[] pis = type.GetProperties();

            DicomFile dicomFile = DicomFile.Open(filename);
            var ds = dicomFile.Dataset;


            ds.Each(item =>
            {
                foreach (var pi in pis)
                {
                    if (string.Equals(item.Tag.DictionaryEntry.Keyword, pi.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        pi.SetValue(target, Convert.ChangeType(ds.GetStringOrDefault(item.Tag), pi.PropertyType));
                    }
                }
            });

            return target;
        }
    }
}
