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
        private List<FlowLayoutPanel> flowLayoutPanels = new();
        private Label draggedLabel;
        private int i = 1;

        public DragDrop(DashDbContext dbContext)
        {
            DbContext = dbContext;
            InitializeComponent();
        }

        private void DragDrop_Load(object sender, EventArgs e)
        {
            AddWeeks();

            AddOrders();
        }

        private void AddOrders()
        {
            flowLayoutPanels[2].Controls.Add(GetLabel());
            flowLayoutPanels[2].Controls.Add(GetLabel());
            flowLayoutPanels[2].Controls.Add(GetLabel());
            flowLayoutPanels[2].Controls.Add(GetLabel());
            flowLayoutPanels[2].Controls.Add(GetLabel());
            flowLayoutPanels[2].Controls.Add(GetLabel());
            flowLayoutPanels[2].Controls.Add(GetLabel());
        }

        private void AddWeeks()
        {
            var weeks = DbContext.WorkDays.Select(w => w.CalendarWeek).Distinct().ToList();

            foreach (var week in weeks)
            {
                flowLayoutPanelMain.Controls.Add(GetFlowPanel(week));
            }
        }

        private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            var label = sender as Label;

            draggedLabel = label;
            DoDragDrop(label.Text, DragDropEffects.Move);
        }

        private void FlowPanel_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FlowPanel_DragDrop(object sender, DragEventArgs e)
        {
           //Label newLabel = new();

           // newLabel.Tag = e.Data.GetData("Tag", true);
           // newLabel.Text = "Dragged";

            FlowLayoutPanel panel = sender as FlowLayoutPanel;
            panel.Controls.Add(draggedLabel);
        }

        private Label GetLabel()
        {
            Label label = new();

            label.Text = "Test" + i.ToString();
            label.MouseDown += new MouseEventHandler(Label_MouseDown);
            label.Tag = DateTime.Now;
            //TODO: Label Tag
            i++;
            return label;
        }

        private FlowLayoutPanel GetFlowPanel(int week)
        {
            FlowLayoutPanel flowPanel = new();

            flowPanel.AllowDrop = true;
            flowPanel.AutoSize = true;
            flowPanel.BorderStyle = BorderStyle.FixedSingle;
            flowPanel.Dock = DockStyle.Top;
            flowPanel.DragDrop += new DragEventHandler(FlowPanel_DragDrop);
            flowPanel.DragEnter += new DragEventHandler(FlowPanel_DragEnter);
            flowPanel.FlowDirection = FlowDirection.TopDown;
            flowPanel.Name = "flowLayoutPanelFirst";
            flowPanel.Size = new Size(250, 300);
            flowPanel.TabIndex = 0;
            flowPanel.Tag = week;
            flowPanel.Controls.Add(new Label() { Text = "Week" + week.ToString(), BackColor = Color.Aquamarine });

            flowLayoutPanels.Add(flowPanel);
            return flowPanel;
        }
    }
}
