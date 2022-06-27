using dicomeditor.Models;
using FellowOakDicom;
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
    public partial class TagListCtl : UserControl
    {
        private DicomDataset _dataset;
        private BindingList<TagInfo> _datasource = new BindingList<TagInfo>();
        public bool _modified { get; private set; }
        public TagListCtl(DicomDataset dataset)
        {
            InitializeComponent();
            dataGridView1.DataSource = _datasource;

            _dataset = dataset;

            Load();
        }

        private void Load()
        {
            if (_dataset == null)
                return;

            foreach (var item in _dataset.AsEnumerable())
            {
                if (item is DicomSequence)
                    continue;

                var tag = new TagInfo();
                tag.Group = item.Tag.Group.ToString("X4");
                tag.Element = item.Tag.Element.ToString("X4"); 
                tag.Keyword = item.Tag.DictionaryEntry.Keyword;
                tag.Name = item.Tag.DictionaryEntry.Name;
                tag.VR = item.Tag.DictionaryEntry.ValueRepresentations[0].Code;
                tag.Value = (item is FellowOakDicom.Imaging.DicomPixelData) ? "large pixel data" : _dataset.GetString(item.Tag);
                _datasource.Add(tag);
            }

        }
    }
}
