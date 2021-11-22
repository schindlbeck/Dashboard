using Dash.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dash.DemoApp.Forms
{
    public partial class DragDrop : Form
    {
        public DashDbContext DbContext { get; set; }

        public DragDrop(DashDbContext dbContext)
        {
            DbContext = dbContext;
            InitializeComponent();
        }

        private void DragDrop_Load(object sender, EventArgs e)
        {
            AddWeeks();
        }

        private void AddWeeks()
        {
           var weeks = DbContext.WorkDays.Select(w => w.CalendarWeek).Distinct().ToList();
            foreach (var week in weeks)
            {
                flowLayoutPanelMain.Controls.Add(GetFlowPanel(week));
            }
        }

        private FlowLayoutPanel GetFlowPanel(int week)
        {
            FlowLayoutPanel flowPanel = new();  
            flowPanel.Dock = DockStyle.Top;
            flowPanel.Name = "flowLayoutPanelFirst";
            flowPanel.Size = new Size(217, 1155);
            flowPanel.TabIndex = 0;
            flowPanel.Tag = week;
            flowPanel.Controls.Add(new Label() { Text = "Week" + week.ToString() });

            return flowPanel;
        }
    }
}
