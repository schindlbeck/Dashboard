using Dash.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dash.FormsApp
{
    public partial class Form1 : Form
    {
        private List<DateTime> saturdays = new();
        private List<DateTime> holidays = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void BtnAddSaturday_Click(object sender, EventArgs e)
        {
            var date = monthCalendarSaturdays.SelectionStart;
            saturdays.Add(date);
        }

        private void BtnAddHolidays_Click(object sender, EventArgs e)
        {
            var startDay = monthCalendarHolidays.SelectionStart;
            var endDay = monthCalendarHolidays.SelectionEnd;

            for (DateTime day = startDay; day <= endDay; day = day.AddDays(1))
            {
                holidays.Add(day);
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            WorkSchedule workSchedule = new(Convert.ToInt32(txtBoxYear.Text), Convert.ToInt32(txtBoxCwStart.Text), Convert.ToInt32(txtBoxCwEnd.Text));
            SetSaturdays(workSchedule);
            

            workSchedule.SetHolidays(holidays);
        }

        private void SetSaturdays(WorkSchedule workSchedule)
        {
            foreach (DateTime date in saturdays)
            {
                var cw = ISOWeek.GetWeekOfYear(date);
                workSchedule.AddSaturday(cw);
            }
        }
    }
}
