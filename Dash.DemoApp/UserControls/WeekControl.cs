using Dash.Data;
using Dash.Data.Models;
using Dash.DemoApp.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dash.DemoApp.UserControls
{
    public partial class WeekControl : UserControl
    {
        private readonly DragDrop dragDrop;

        public WeekContainer WeekContainer { get; init; }

        public WeekControl(DbWorkWeek workWeek, OrderScheduler scheduler, PriorityDbContext dbContext, DragDrop dragDrop)
        {

            WeekContainer = new(workWeek, scheduler, dbContext);
            InitializeComponent();
            this.dragDrop = dragDrop;
        }

        private void WeekControl_Load(object sender, EventArgs e)
        {
            label1.Text = WeekContainer.Week.CalendarWeek.ToString();
            label1.BackColor = Color.Aquamarine;

            flowPanel.ControlAdded += FlowPanel_ControlAdded;
            flowPanel.ControlRemoved += FlowPanel_ControlRemoved;

            //TODO : datetime.now later
            var cw = 41;
            var year = 2021;

            if (WeekContainer.Week.CalendarWeek >= cw || WeekContainer.Week.Year > year)
            {
                flowPanel.DragDrop += FlowPanel_DragDrop;
                flowPanel.DragEnter += FlowPanel_DragEnter;
            }

            DisplayMinutes();
        }

        public async Task AddOrderInitialized(OrderControl order)
        {
            flowPanel.Controls.Add(order);
            await WeekContainer.AddOrderInitialized(order.OrderContainer);
            DisplayMinutes();
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
            var orderKey = e.Data.GetData(DataFormats.Text) as string;

            AddOrder(orderKey, false);
        }

        public async void AddOrder(string orderKey, bool isUndo)
        {
            var order = await WeekContainer.AddOrderAfterDragDrop(orderKey, isUndo);


            if (order is not null)
            {
                var a = WeekContainer.Orders.First(o => o.ListElement.KeyToString().Equals(order.ListElement.KeyToString()));

                flowPanel.Controls.Add(dragDrop.OrderControls[a.ListElement.KeyToString()]);
            }
        }

        private void FlowPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            DisplayMinutes();
        }

        private async void FlowPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            await RemoveOrder();
        }

        public async Task RemoveOrder()
        {
            await WeekContainer.RemoveOrder();
            DisplayMinutes();
        }

        private void DisplayMinutes()
        {

            textBoxInfo.Text = $"Production Minutes: {WeekContainer.MinutesBooked}/{WeekContainer.ProductionMinutes}";

            if (WeekContainer.MinutesBooked > WeekContainer.ProductionMinutes * 0.9)
            {
                if (WeekContainer.MinutesBooked > WeekContainer.ProductionMinutes) textBoxInfo.BackColor = Color.Red;
                else textBoxInfo.BackColor = Color.PaleVioletRed;
            }
            else
            {
                textBoxInfo.BackColor = Color.LightGreen;
            }
        }
    }
}
