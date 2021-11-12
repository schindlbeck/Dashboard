using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erp.Prototype.Forms
{
    public partial class DataOverview : Form
    {
        public IConfigurationRoot Configuration { get; }

        public DataOverview(IConfigurationRoot configuration)
        {
            InitializeComponent();
            Configuration = configuration;
        }

        private void DataOverview_Load(object sender, EventArgs e)
        {
        }
        
    }
}
