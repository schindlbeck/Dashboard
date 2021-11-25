﻿using Dash.Data.Models;
using Dash.Shared;
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
        public WeekContainer WeekContainer { get; init; }
 
        public WeekControl(DbWorkWeek workWeek)
        {
            WeekContainer = new(workWeek);
            InitializeComponent();
        }

        private void WeekControl_Load(object sender, EventArgs e)
        {
            label1.Text = WeekContainer.Week.CalendarWeek.ToString();
            label1.BackColor = Color.Aquamarine;

            flowPanel.ControlAdded += FlowPanel_ControlAdded;
            flowPanel.DragDrop += FlowPanel_DragDrop;
            flowPanel.DragEnter += FlowPanel_DragEnter;
            flowPanel.ControlRemoved += FlowPanel_ControlRemoved;
        }

        private void FlowPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            WeekContainer.Orders.Remove(Forms.DragDrop.DraggedOrder.OrderContainer.ListElement);
            CalculateMinutes();
        }

        public void AddOrder(OrderControl order)
        {
            flowPanel.Controls.Add(order);
            WeekContainer.Orders.Add(order.OrderContainer.ListElement);
            CalculateMinutes();
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
            OrderControl o = Forms.DragDrop.DraggedOrder;
            o.SetCWCurrent(WeekContainer.Week.CalendarWeek);
            WeekContainer.Orders.Add(o.OrderContainer.ListElement);
            flowPanel.Controls.Add(o);
        }

        private void CalculateMinutes()
        {
            var minutesBooked = WeekContainer.Orders.Sum(s => s.TimeTotal);
            var productionMinutes = WeekContainer.Week.ProductionMinutes;
            textBoxInfo.Text = $"Production Minutes: {minutesBooked}/{productionMinutes}";

            if(minutesBooked > productionMinutes * 0.9)
            {
                if(minutesBooked > productionMinutes) textBoxInfo.BackColor = Color.Red;
                else textBoxInfo.BackColor = Color.PaleVioletRed;
            }
            else
            {
                textBoxInfo.BackColor = Color.LightGreen;
            }
        }

        private void FlowPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            CalculateMinutes();
        }
    }
}
