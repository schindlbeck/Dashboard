using Dash.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dash.DemoApp.UserControls
{
    public partial class WeekControl : UserControl
    {
        public DbWorkWeek Week { get; set; }

        public WeekControl(DbWorkWeek workWeek)
        {
            Week = workWeek;
            InitializeComponent();
        }

        private void WeekControl_Load(object sender, EventArgs e)
        {
            label1.Text = Week.CalendarWeek.ToString();
            label1.BackColor = Color.Aquamarine;

            flowPanel.ControlAdded += FlowPanel_ControlAdded;
            flowPanel.DragDrop += FlowPanel_DragDrop;
            flowPanel.DragEnter += FlowPanel_DragEnter;
        }

        public void AddOrder(Order order)
        {
            flowPanel.Controls.Add(order);
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
            Order o = Forms.DragDrop.DraggedOrder;
            flowPanel.Controls.Add(o);
        }

        private void FlowPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            
        }

    }
}
