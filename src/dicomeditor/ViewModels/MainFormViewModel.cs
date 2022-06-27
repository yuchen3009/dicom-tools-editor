using dicomeditor.Models;
using FellowOakDicom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicomeditor.ViewModels
{
    public class MainFormViewModel
    {
        public StudyInfo CurrentStudy { get; set; }
        public DicomFileInfo CurrentDicomFileInfo { get; set; }

        public List<StudyInfo> Studies { get; set; } = new List<StudyInfo>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>检查</returns>
        public StudyInfo AddOrAppend(string filename)
        {
            DicomFile dicomFile = DicomFile.Open(filename);
            var ds = dicomFile.Dataset;

            string studyiuid = string.Empty;
            ds.TryGetString(DicomTag.StudyInstanceUID, out studyiuid);

            StudyInfo selectedStudyInfo;

            if (Studies.Any(p => p.StudyInstanceUID == studyiuid))
            {
                selectedStudyInfo = Studies.Where(p => p.StudyInstanceUID == studyiuid).First();
                selectedStudyInfo.Files.Add(filename);
            }
            else
            {
                selectedStudyInfo = StudyInfo.Parse(ds);
                selectedStudyInfo.Files.Add(filename);
                Studies.Add(selectedStudyInfo);
            }

            CurrentStudy = selectedStudyInfo;
            CurrentDicomFileInfo = new DicomFileInfo { Filename = filename };
            return selectedStudyInfo;
        }
    }
}
