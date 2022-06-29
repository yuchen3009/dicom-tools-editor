using FellowOakDicom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicomeditor.Models
{
    public class DicomReference
    {
        public bool Updated { get; set; }
        private FileInfo _fileinfo;
        public DicomReference(string filename)
        {
            Filename = filename;
            _fileinfo = new FileInfo(Filename);
        }
        public string Filename { get; set; }

        public long Size { get { return _fileinfo.Length; } }

        private DicomFileMetaInfo? _metaInfo;
        public DicomFileMetaInfo? MetaInfo
        {
            get
            {
                if (_metaInfo != null)
                    return _metaInfo;
                _metaInfo = GetFileMetaInfo();
                return _metaInfo;
            }
        }

        private DicomDataset _dataset = null;
        public DicomDataset Dataset
        {
            get
            {
                if (_dataset != null) return _dataset;

                DicomFile dicomFile = DicomFile.Open(_fileinfo.FullName);
                _dataset = dicomFile.Dataset;
                return _dataset;
            }
        }

        public DicomFileMetaInfo GetFileMetaInfo()
        {
            return DicomFileMetaInfo.LoadFromFile(Filename);
        }
    }
}
