
using Dash.Data;
using Dash.DemoApp.Forms;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Windows.Forms;

namespace Erp.Prototype
{
    public partial class PrototypeForm : Form
    {
        Form activeForm;
        public IConfigurationRoot Configuration { get; }
        public DashDbContext DbContext { get; set; }
        
        public PrototypeForm(IConfigurationRoot configuration)
        {
            Configuration = configuration;
            InitializeComponent();
            SetDbContext();
        }

        private void SetDbContext()
        {
            var factory = new DashDbContextFactory();
            DbContext = factory.CreateDbContext(Array.Empty<string>());
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            activeForm?.Close();
        }

        private void BtnHolidays_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Holidays(DbContext), sender);

        }

        private void BtnExcelToJson_Click(object sender, EventArgs e)
        {
            OpenChildForm(new WorkDaysOverview(DbContext), sender);

        }

        private void BtnDataOverview_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DragDrop(DbContext, Configuration), sender);
        }

        private void OpenChildForm(Form childForm, object sender)
        {
            panelDesk.Controls.Clear();
            Log.Information("Child Form load: {0}", childForm);
            activeForm?.Close();
            if (childForm != null)
            {
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelDesk.Controls.Add(childForm);
                panelDesk.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
        }
    }
}
