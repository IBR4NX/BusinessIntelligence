using System;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Main : Form
    {
        private readonly MetadataService _metadataService;

        public Main(MetadataService metadataService)
        {
            InitializeComponent();

            _metadataService = metadataService;

            LoadTables();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
