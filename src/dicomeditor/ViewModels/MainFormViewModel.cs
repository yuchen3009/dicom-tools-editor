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
        public StudyInfo? CurrentStudy { get; set; }
        public DicomReference? CurrentDicomReference{ get; set; }

        public List<StudyInfo> Studies { get; set; } = new List<StudyInfo>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>检查</returns>
        public StudyInfo AddOrAppend(string filename)
        {
            DicomReference dicomReference = new DicomReference(filename);
            var ds = dicomReference.Dataset;

            string studyiuid = string.Empty;
            ds.TryGetString(DicomTag.StudyInstanceUID, out studyiuid);

            StudyInfo selectedStudyInfo;
            if (Studies.Any(p => p.StudyInstanceUID == studyiuid))
            {
                selectedStudyInfo = Studies.Where(p => p.StudyInstanceUID == studyiuid).First();
                selectedStudyInfo.Files.Add(dicomReference);
            }
            else
            {
                selectedStudyInfo = StudyInfo.Parse(ds);
                selectedStudyInfo.Files.Add(dicomReference);
                Studies.Add(selectedStudyInfo);
            }

            CurrentStudy = selectedStudyInfo;
            CurrentDicomReference = dicomReference;
            return selectedStudyInfo;
        }
        public void Clear()
        {
            Studies.Clear();
            CurrentDicomReference = null;
            CurrentStudy = null;
        }
    }
}
