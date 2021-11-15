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
        private WorkDay selectedWorkDay;

        public WorkDaysOverview()
        {
            InitializeComponent();
        }

        private void WorkDaysOverview_Load(object sender, EventArgs e)
        {
            numericUpDownYearStart.Value = DateTime.Now.Year;
            HideFurtherOptions();
        }

        private void HideFurtherOptions()
        {
            listBoxDayInfos.Hide();
            groupBoxDayOptions.Hide();
            groupBoxShifts.Hide();
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
            selectedWorkDay = selectedWorkWeek.WorkDays.Where(w => w.ToString().Equals(listBoxDayInfos.Text)).First();
        }

        private void ButtonDeleteDay_Click(object sender, EventArgs e)
        {
            workSchedule.DeleteWorkday(selectedWorkDay, selectedWorkWeek);

            listBoxDayInfos.Hide();
            groupBoxDayOptions.Hide();
            FillListBoxSchedule();
        }

        private void ButtonChangeShifts_Click(object sender, EventArgs e)
        {
            groupBoxShifts.Show();

            SelectedShifts();
        }

        private void SelectedShifts()
        {
            var shifts = selectedWorkDay.Shifts;

            if(shifts.Exists(s => s.Type == Shifts.morning))
            {
                checkBoxMorning.Checked = true;
            }

            if (shifts.Exists(s => s.Type == Shifts.evening))
            {
                checkBoxeEvening.Checked = true;
            }

            if (shifts.Exists(s => s.Type == Shifts.night))
            {
                checkBoxNight.Checked = true;
            }
        }

        private void ButtonDeleteShift_Click(object sender, EventArgs e)
        {

        }

        private void ListBoxWorkSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideFurtherOptions();
        }

        private void ListBoxDayInfos_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBoxShifts.Hide();
        }
    }
}
