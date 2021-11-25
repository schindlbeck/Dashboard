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
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dash.DemoApp.Forms
{
    public partial class DragDrop : Form
    {
        public DashDbContext DbContext { get; set; }
        public IConfigurationRoot Configuration { get; set; }


        private readonly List<WeekControl> weekcontrols = new();
        public static OrderControl DraggedOrder;
        private List<PrioListElement> prioList;
        private OrderScheduler scheduler;

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
            prioList = ManageOrders.GetPrioList(Configuration);
            //var weeksOrders = prioList.Select(w => w.CWPlanned).Distinct();
            scheduler = new OrderScheduler(prioList);

            var weeks = await DbContext.WorkWeeks.ToListAsync();
            foreach (var week in weeks)
            {
                flowLayoutPanelMain.Controls.Add(GetFlowPanel(week));
            }
        }

        private void AddOrders()
        {
            var orders = ManageOrders.GetOrders(Configuration, prioList);

            foreach (var order in orders)
            {
                order.MouseDown += new MouseEventHandler(Order_MouseDown);

                weekcontrols.Where(w => w.WeekContainer.Week.CalendarWeek == order.OrderContainer.ListElement.CWPlanned).First().AddOrder(order);
            }
        }

        private void Order_MouseDown(object sender, MouseEventArgs e)
        {
            var order = sender as OrderControl;

            DraggedOrder = order;
            DoDragDrop(order.Text, DragDropEffects.Move);
        }

        private WeekControl GetFlowPanel(DbWorkWeek week)
        {
            WeekControl weekControl = new(week);

            weekcontrols.Add(weekControl);
            return weekControl;
        }

        private async void BtnAddWeek_Click(object sender, EventArgs e)
        {
            var lastWeek = weekcontrols.Last().WeekContainer.Week;
            var cw = lastWeek.CalendarWeek;

            WorkSchedule w = new(DbContext);
            DbWorkWeek newWeek = new();

            if ((cw == 52 && ISOWeek.GetWeeksInYear(lastWeek.Year) == 52)
                ||cw == 53)
            {
                newWeek = await w.SetUpDefaultWeekScheduleAsync(1, lastWeek.Year + 1);
            }
            else
            {
                newWeek = await w.SetUpDefaultWeekScheduleAsync(lastWeek.CalendarWeek + 1, lastWeek.Year);
            }

            flowLayoutPanelMain.Controls.Add(GetFlowPanel(newWeek));
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {

        }
    }
}
