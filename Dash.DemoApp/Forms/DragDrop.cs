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
        private readonly List<FlowLayoutPanel> flowLayoutPanels = new();
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
        
        private void AddWeeks()
        {
            var weeks = DbContext.WorkWeeks.Select(w => w.CalendarWeek).Distinct();

            foreach (var week in weeks)
            {
                flowLayoutPanelMain.Controls.Add(GetFlowPanel(week));
            }
        }

        private void AddOrders()
        {
            //TODO: get orders
            flowLayoutPanels[2].Controls.Add(GetLabel());
            flowLayoutPanels[2].Controls.Add(GetLabel());
            flowLayoutPanels[2].Controls.Add(GetLabel());
            flowLayoutPanels[2].Controls.Add(GetLabel());
            flowLayoutPanels[2].Controls.Add(GetLabel());
            flowLayoutPanels[2].Controls.Add(GetLabel());
            flowLayoutPanels[2].Controls.Add(GetLabel());
        }

        private void FlowPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            var panel = sender as FlowLayoutPanel;


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
            FlowLayoutPanel panel = sender as FlowLayoutPanel;
            panel.Controls.Add(draggedLabel);
        }

        private Label GetLabel()
        {
            Label label = new();

            label.Text = "Test" + i.ToString();
            label.MouseDown += new MouseEventHandler(Label_MouseDown);
            //TODO: Tag should be order
            label.Tag = RandomNumber();
            
            i++;
            return label;
        }

        private static int RandomNumber()
        {
            Random r = new();
            return r.Next(50, 150);
        }

        private FlowLayoutPanel GetFlowPanel(int week)
        {
            FlowLayoutPanel flowPanel = new();
            flowPanel.AllowDrop = true;
            flowPanel.AutoSize = true;
            flowPanel.BorderStyle = BorderStyle.FixedSingle;
            flowPanel.ControlAdded += new ControlEventHandler(FlowPanel_ControlAdded);
            flowPanel.Dock = DockStyle.Top;
            flowPanel.DragDrop += new DragEventHandler(FlowPanel_DragDrop);
            flowPanel.DragEnter += new DragEventHandler(FlowPanel_DragEnter);
            flowPanel.FlowDirection = FlowDirection.TopDown;
            flowPanel.TabIndex = 0;
            flowPanel.Tag = DbContext.WorkWeeks.First(w => w.CalendarWeek == week);
            flowPanel.Controls.Add(new Label() { Text = "Week" + week.ToString(), BackColor = Color.Aquamarine });

            flowLayoutPanels.Add(flowPanel);
            return flowPanel;
        }

    }
}
