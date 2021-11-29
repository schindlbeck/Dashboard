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
        private List<PrioListElement> prioList;
        private readonly OrderScheduler scheduler;

        public DragDrop(DashDbContext dbContext, IConfigurationRoot configuration)
        {
            Configuration = configuration;
            DbContext = dbContext;
            scheduler = new OrderScheduler();
            prioList = ManageOrders.GetPrioList(Configuration);

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

            //TODO : cw later dateNow
            var cw = 41;
            var d = prioList.Select(w => w.CWPlanned).ToList();

            var weeksDisplayed1 = weeks.Where(w => w.CalendarWeek >= cw || d.Contains(w.CalendarWeek)).ToList();
           
            foreach (var week in weeksDisplayed1)
            {
                flowLayoutPanelMain.Controls.Add(GetFlowPanel(week));
            }
        }

        private void AddOrders()
        {
            var orders = ManageOrders.GetOrders(prioList);

            foreach (var order in orders)
            {
                order.MouseDown += new MouseEventHandler(Order_MouseDown);
                scheduler.Orders.Add(order);
                weekcontrols.First(w => w.WeekContainer.Week.CalendarWeek == order.OrderContainer.ListElement.CWPlanned).AddOrder(order);
            }
        }

        private void Order_MouseDown(object sender, MouseEventArgs e)
        {
            var order = sender as OrderControl;

            order.Text = order.OrderContainer.ListElement.KeyToString();
            DoDragDrop(order.Text, DragDropEffects.Move);
        }

        private WeekControl GetFlowPanel(DbWorkWeek week)
        {
            WeekControl weekControl = new(week, scheduler);

            weekcontrols.Add(weekControl);
            return weekControl;
        }

        private async void BtnAddWeek_Click(object sender, EventArgs e)
        {
            var lastWeek = weekcontrols.Last().WeekContainer.Week;
            var cw = lastWeek.CalendarWeek;

            WorkSchedule w = new(DbContext);
            DbWorkWeek newWeek;

            if ((cw == 52 && ISOWeek.GetWeeksInYear(lastWeek.Year) == 52)
                || cw == 53)
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
            var lastChanged = scheduler.GetLastChangedItem();

            if (lastChanged is not null)
            {
                weekcontrols.First(w => w.WeekContainer.Week.CalendarWeek == lastChanged.CwLast).AddOrder(lastChanged.Key, true);
                weekcontrols.First(w => w.WeekContainer.Week.CalendarWeek == lastChanged.CwNow).RemoveOrder();

                scheduler.LastChangedUndid();
            }
        }
    }
}
