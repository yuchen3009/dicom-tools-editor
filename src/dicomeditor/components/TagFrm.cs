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
    public partial class TagFrm : Form
    {
        private DicomDataset _dataset;
        private TagListCtl _tagListCtl;
        public TagFrm(DicomDataset dataset)
        {
            InitializeComponent();
            _dataset = dataset;

            _tagListCtl = new TagListCtl(_dataset);
            _tagListCtl.Dock = DockStyle.Fill;
            panel_tags.Controls.Add(_tagListCtl);
        }
    }
}
