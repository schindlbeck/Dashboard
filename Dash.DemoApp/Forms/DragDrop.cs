using Dash.Data;
using Dash.Data.Models;
using Dash.DemoApp.UserControls;
using Dash.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dash.DemoApp.Forms
{
    public partial class DragDrop : Form
    {
        public DashDbContext DbContext { get; set; }
        public IConfigurationRoot Configuration { get; set; }
        private readonly List<FlowLayoutPanel> flowLayoutPanels = new();
        private Order draggedOrder;
        private int i = 1;

        public DragDrop(DashDbContext dbContext, IConfigurationRoot configuration)
        {
            Configuration = configuration;
            DbContext = dbContext;
            InitializeComponent();
        }

        private async void DragDrop_LoadAsync(object sender, EventArgs e)
        {
            await AddWeeks();
            AddOrders();
        }

        private async Task AddWeeks()
        {
            var weeks = await DbContext.WorkWeeks.ToListAsync();
            foreach (var week in weeks)
            {
                flowLayoutPanelMain.Controls.Add(GetFlowPanel(week));
            }
        }

        private void AddOrders()
        {
            List<Order> orders = ManageOrders.GetOrders(Configuration);

            foreach (var order in orders)
            {
                order.MouseDown += new MouseEventHandler(Order_MouseDown);
                flowLayoutPanels[2].Controls.Add(order);
            }

        }

        private void FlowPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            var panel = sender as FlowLayoutPanel;


        }

        private void Order_MouseDown(object sender, MouseEventArgs e)
        {
            var order = sender as Order;

            draggedOrder = order;
            DoDragDrop(order.Text, DragDropEffects.Move);
        }

        private void FlowPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
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
            panel.Controls.Add(draggedOrder);
        }

        private FlowLayoutPanel GetFlowPanel(DbWorkWeek week)
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
            flowPanel.Tag = week;
            flowPanel.Controls.Add(new Label() { Text = "Week" + week.CalendarWeek.ToString(), BackColor = Color.Aquamarine });

            flowLayoutPanels.Add(flowPanel);
            return flowPanel;
        }

    }
}
