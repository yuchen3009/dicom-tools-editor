using FellowOakDicom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicomeditor.Extensions
{
    public static class DicomFileExtensions
    {
    }

    public static class DicomDatasetExtensions
    {
        /// <summary>
        /// 获取字符串格式的TAG值
        /// </summary>
        /// <param name="dataset"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static string GetStringOrDefault(this DicomDataset dataset, DicomTag tag)
        {
            if (dataset == null)
                return string.Empty;
            if (!dataset.Contains(tag))
                return string.Empty;

            string tmp = string.Empty;
            dataset.TryGetString(tag, out tmp);

            return tmp;
        }


    }

    public static class DicomTagExtensions
    {
        public static string Tag(this DicomTag dicomTag, bool containsSplinter = true)
        {
            if (containsSplinter)
                return string.Format("{0:x4},{1:x4}", dicomTag.Group, dicomTag.Element);
            else
                return string.Format("{0:x4}{1:x4}", dicomTag.Group, dicomTag.Element);
        }
    }

}
