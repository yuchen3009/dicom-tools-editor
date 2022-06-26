using FellowOakDicom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicomeditor.Models
{
    public class StudyInfo
    {
        public string? PatientID { get; set; }
        public string? PatientName { get; set; }
        public string? PatientSex { get; set; }
        public DateTime? PatientBirthday { get; set; }
        public string? AccessionNumber { get; set; }
        public string? StudyID { get; set; }
        public string StudyInstanceUID { get; set; } = string.Empty;
        public string? StudyDescription { get; set; }
        public string? PatientAge { get; set; }

        public List<string> Files { get; set; } = new List<string>();

        public static StudyInfo Parse(DicomDataset dataset)
        {
            var studyInfo = new StudyInfo();

            dataset.TryGetString(DicomTag.PatientID, out string? patientid);
            dataset.TryGetString(DicomTag.PatientName, out string? patientname);
            dataset.TryGetString(DicomTag.PatientSex, out string? patientsex);
            dataset.TryGetString(DicomTag.PatientBirthDate, out string? patientBirthday);
            dataset.TryGetString(DicomTag.AccessionNumber, out string? accessionNumber);
            dataset.TryGetString(DicomTag.StudyID, out string? studyid);
            dataset.TryGetString(DicomTag.StudyInstanceUID, out string? studyiuid);
            dataset.TryGetString(DicomTag.StudyDescription, out string? studydesc);
            dataset.TryGetString(DicomTag.PatientAge, out string? patientage);

            studyInfo.PatientID = patientid;
            studyInfo.PatientName = patientname;
            studyInfo.PatientSex = patientsex;
            studyInfo.AccessionNumber = accessionNumber;
            studyInfo.StudyID = studyid;
            studyInfo.StudyInstanceUID = studyiuid;
            studyInfo.StudyDescription = studydesc;
            studyInfo.PatientAge = patientage;
            return studyInfo;
        }
    }

    public class DicomFileInfo
    {
        public bool Modified { get; set; }
        public string Filename { get; set; } = string.Empty;
    }
}
