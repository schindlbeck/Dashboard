using Dash.Data;
using Dash.Data.Models;
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
            InitializeTags();
        }

        private void InitializeTags()
        {
            checkBoxMorning.Tag = Shifts.morning;
            checkBoxeEvening.Tag = Shifts.evening;
            checkBoxNight.Tag = Shifts.night;

            numericUpDownEquipMorning.Tag = Shifts.morning;
            numericUpDownEquipEvening.Tag = Shifts.evening;
            numericUpDownEquipNight.Tag = Shifts.night;
        }

        private void WorkDaysOverview_Load(object sender, EventArgs e)
        {
            numericUpDownYearStart.Value = DateTime.Now.Year;
            HideFurtherOptions();
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
            foreach (WorkWeek workWeek in workSchedule.WorkWeeks)
            {
                listBoxWorkSchedule.Items.Add(workWeek.ToString());
            }
        }

        private void ListBoxWorkSchedule_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = sender as ListBox;
            selectedWorkWeek = workSchedule.WorkWeeks.Where(w => w.ToString().Equals(item.Text)).First();

            SetUpListBoxDayInfos();
        }

        private void SetUpListBoxDayInfos()
        {
            listBoxDayInfos.Items.Clear();
            listBoxDayInfos.Show();

            foreach (WorkDay workDay in selectedWorkWeek.WorkDays)
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
            groupBoxEquipments.Hide();
            SelectedShifts();
            groupBoxShifts.Show();
        }

        private void SelectedShifts()
        {
            var shifts = selectedWorkDay.Shifts;

            if (shifts.Exists(s => s.Type == Shifts.morning)) checkBoxMorning.Checked = true; else checkBoxMorning.Checked = false;

            if (shifts.Exists(s => s.Type == Shifts.evening)) checkBoxeEvening.Checked = true; else checkBoxeEvening.Checked = false;

            if (shifts.Exists(s => s.Type == Shifts.night)) checkBoxNight.Checked = true; else checkBoxNight.Checked = false;
        }

        private void ButtonEquipments_Click(object sender, EventArgs e)
        {
            groupBoxShifts.Hide(); 
            NumberEquipments();
            groupBoxEquipments.Show();
        }

        private void NumberEquipments()
        {
            var shifts = selectedWorkDay.Shifts;
            ResetEquipmentNumbers();

            if (shifts.Exists(s => s.Type == Shifts.morning)) numericUpDownEquipMorning.Value = shifts.Where(s => s.Type == Shifts.morning).First().NumberEquipments; else numericUpDownEquipMorning.Hide();
            if (shifts.Exists(s => s.Type == Shifts.evening)) numericUpDownEquipEvening.Value = shifts.Where(s => s.Type == Shifts.evening).First().NumberEquipments; else numericUpDownEquipEvening.Hide();
            if (shifts.Exists(s => s.Type == Shifts.night)) numericUpDownEquipNight.Value = shifts.Where(s => s.Type == Shifts.night).First().NumberEquipments; else numericUpDownEquipNight.Hide();

        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (groupBoxShifts.Visible)
            {
                var shift = sender as CheckBox;
                var eShift = Enum.Parse<Shifts>(shift.Tag.ToString());

                if (shift.Checked) workSchedule.AddShift(eShift, selectedWorkDay, selectedWorkWeek);
                else workSchedule.DeleteShift(eShift, selectedWorkDay, selectedWorkWeek);
            }

            groupBoxShifts.Hide();
            SetUpListBoxDayInfos();
        }

        private void NumericUpDownEquip_ValueChanged(object sender, EventArgs e)
        {
            if (groupBoxEquipments.Visible)
            {
                var equipment = sender as NumericUpDown;
                var eEquipment = Enum.Parse<Shifts>(equipment.Tag.ToString());

                workSchedule.ChangeNumberShifts(Convert.ToInt32(equipment.Value), eEquipment, selectedWorkWeek, selectedWorkDay);
            }

            groupBoxEquipments.Hide();
        }

        private void HideFurtherOptions()
        {
            listBoxDayInfos.Hide();
            groupBoxDayOptions.Hide();
            groupBoxShifts.Hide();
            groupBoxEquipments.Hide();
        }

        private void ResetEquipmentNumbers()
        {
            numericUpDownEquipMorning.Value = 0;
            numericUpDownEquipEvening.Value = 0;
            numericUpDownEquipNight.Value = 0;

            numericUpDownEquipMorning.Show();
            numericUpDownEquipEvening.Show();
            numericUpDownEquipNight.Show();
        }

        private void ListBoxWorkSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideFurtherOptions();
        }

        private void ListBoxDayInfos_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBoxShifts.Hide();
            groupBoxEquipments.Hide();
        }
    }
}
