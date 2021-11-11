using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dash.WinFormsApp
{
    public partial class Form1 : Form
    {
        private List<DateTime> saturdays;
        private List<DateTime> holidays;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            saturdays = new List<DateTime>();
            holidays = new List<DateTime>();
        }

        private void BtnAddSaturday_Click(object sender, EventArgs e)
        {
            var day = monthCalendarSaturdays.SelectionStart;
            saturdays.Add(day);
        }

        private void BtnAddHolidays_Click(object sender, EventArgs e)
        {
            var startDay = monthCalendarHolidays.SelectionStart;
            var endDay = monthCalendarHolidays.SelectionEnd;

            for (DateTime day = startDay; day <= endDay; day.AddDays(1))
            {
                holidays.Add(day);
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            WorkSchedule workSchedule = new();
        }
    }
}
