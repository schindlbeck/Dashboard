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

namespace Dash.DemoApp.Forms
{
    public partial class WorkDaysOverview : Form
    {
        private WorkSchedule workSchedule;
        private WorkWeek selectedWorkWeek;

        public WorkDaysOverview()
        {
            InitializeComponent();
        }

        private void WorkDaysOverview_Load(object sender, EventArgs e)
        {
            numericUpDownYearStart.Value = DateTime.Now.Year;
            listBoxDayInfos.Hide();
            groupBoxDayOptions.Hide();
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            workSchedule = new(Convert.ToInt32(numericUpDownYearStart.Value), Convert.ToInt32(numericUpDownCwStart.Value), Convert.ToInt32(numericUpDownCwEnd.Value));

            listBoxWorkSchedule.Items.Clear();
            FillListBoxSchedule();
        }

        private void FillListBoxSchedule()
        {
            listBoxWorkSchedule.Items.Clear();
            foreach(WorkWeek workWeek in workSchedule.WorkWeeks)
            {
                listBoxWorkSchedule.Items.Add(workWeek.ToString());
            }
        }

        private void ListBoxWorkSchedule_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = sender as ListBox;

            listBoxDayInfos.Items.Clear();
            listBoxDayInfos.Show();

            selectedWorkWeek = workSchedule.WorkWeeks.Where(w => w.ToString().Equals(item.Text)).First();

            foreach(WorkDay workDay in selectedWorkWeek.WorkDays)
            {
                listBoxDayInfos.Items.Add(workDay.ToString());
            }

        }

        private void ListBoxDayInfos_MouseClick(object sender, MouseEventArgs e)
        {
            groupBoxDayOptions.Show();
        }

        private void ButtonDeleteDay_Click(object sender, EventArgs e)
        {
            var day = selectedWorkWeek.WorkDays.Where(w => w.ToString().Equals(listBoxDayInfos.Text)).First();

            workSchedule.DeleteWorkday(day, selectedWorkWeek);

            listBoxDayInfos.Hide();
            groupBoxDayOptions.Hide();
            FillListBoxSchedule();
        }

        private void ButtonAddShift_Click(object sender, EventArgs e)
        {

        }

        private void ButtonDeleteShift_Click(object sender, EventArgs e)
        {

        }
    }
}
