using Dash.Data;
using Dash.Data.Models;
using Dash.DemoApp.UserControls;
using Dash.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dash.DemoApp.Forms
{
    public partial class DragDrop : Form
    {
        public DashDbContext DashContext { get; set; }
        //public PriorityDbContext PriorityContext { get; set; }
        public IConfigurationRoot Configuration { get; set; }

        public Dictionary<string, OrderControl> OrderControls { get; } = new();

        private readonly List<WeekControl> weekcontrols = new();
        private readonly List<PrioListElement> prioList;
        private readonly OrderScheduler scheduler;

        public DragDrop(DashDbContext dbDashContext, IConfigurationRoot configuration)
        {
            Configuration = configuration;

            DashContext = dbDashContext;

            //DashDbContextFactorySqLite factory = new();
            //PriorityContext = factory.CreateDbContext(null);
            //PriorityContext.Database.EnsureCreated();

            scheduler = new OrderScheduler();
            prioList = ManageOrders.GetPrioList(Configuration);

            InitializeComponent();
        }

        private async void DragDrop_LoadAsync(object sender, EventArgs e)
        {
            await AddWeeks();
            await AddOrders();
        }

        private async Task AddWeeks()
        {
            var workScheduleWeeks = await DashContext.WorkWeeks.ToListAsync();

            //TODO : cw later dateNow
            var currentCw = 41;
            var currentYear = 2021;

            //later other source
            var prioListWeeks = prioList.Select(w => Convert.ToInt32(w.DeliveryDate.Year.ToString() + w.DeliveryCW.ToString())).ToList();

            var weeksDisplayed1 = workScheduleWeeks.Where(w => (w.CalendarWeek >= currentCw && w.Year == currentYear)
                                                                || w.Year > currentYear
                                                                || prioListWeeks.Contains(Convert.ToInt32(w.Year.ToString() + w.CalendarWeek.ToString())))
                                                                .ToList();

            foreach (var week in weeksDisplayed1)
            {
                flowLayoutPanelMain.Controls.Add(GetFlowPanel(week));
            }
        }

        private async Task AddOrders()
        {
            var prioritizedOrders = await DashContext.PriotizedOrders.ToListAsync();

            //later other source
            var orderContainer = ManageOrders.GetOrders(prioList);

            orderContainer = ManageOrders.CheckOrdersAgainstPrioritization(orderContainer, prioritizedOrders);

            foreach (var container in orderContainer)
            {
                OrderControl control = new(container);
                
                control.MouseDown += new MouseEventHandler(Order_MouseDown);
                OrderControls.Add(control.OrderContainer.ListElement.KeyToString(), control);
                await weekcontrols.First(w => w.WeekContainer.Week.CalendarWeek == control.OrderContainer.ProductionCW).AddOrderInitialized(control);
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
            WeekControl weekControl = new(week, scheduler, DashContext, this);

            weekcontrols.Add(weekControl);
            return weekControl;
        }

        private async void BtnAddWeek_Click(object sender, EventArgs e)
        {
            var lastWeek = weekcontrols.Last().WeekContainer.Week;
            var cw = lastWeek.CalendarWeek;

            WorkSchedule w = new(DashContext);
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

        private async void BtnUndo_Click(object sender, EventArgs e)
        {
            var lastChanged = scheduler.GetLastChangedItem();

            if (lastChanged is not null)
            {
                weekcontrols.First(w => w.WeekContainer.Week.CalendarWeek == lastChanged.OldProdutionCW).AddOrder(lastChanged.Key, true);
                await weekcontrols.First(w => w.WeekContainer.Week.CalendarWeek == lastChanged.NewProductionCW).RemoveOrder();

                scheduler.LastChangedUndid();
            }
        }
    }
}
