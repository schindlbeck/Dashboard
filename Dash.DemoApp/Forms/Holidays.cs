using Dash.Data;
using Dash.Data.Models;
using System;
using System.Windows.Forms;

namespace Dash.DemoApp.Forms
{
    public partial class Holidays : Form
    {
        private Shared.Holidays holidays;
        public DashDbContext DbContext { get; set; } 

        public Holidays(DashDbContext dbContext)
        {
            DbContext = dbContext;
            InitializeComponent();
        }

        private void Holidays_Load(object sender, EventArgs e)
        {
            HideButtons();
            btnDelete.Hide();
            numericUpDownYear.Value = DateTime.Now.Year;

            holidays = new(DbContext);
            SetUpListBoxHolidays();
        }

        private void ShowButtons()
        {
            btnNew.Show();
            btnAdd.Show();
        }

        private void HideButtons()
        {
            btnAdd.Hide();
            btnNew.Hide();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            holidays.ChangeHolidays(Convert.ToInt32(numericUpDownYear.Value), Convert.ToInt32(numericUpDownFrom.Value), Convert.ToInt32(numericUpDownTo.Value));
           
            listBoxHolidays.Items.Clear();
            SetUpListBoxHolidays();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            holidays.ChangeHolidays(Convert.ToInt32(numericUpDownYear.Value), Convert.ToInt32(numericUpDownFrom.Value), Convert.ToInt32(numericUpDownTo.Value));

            SetUpListBoxHolidays();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void SetUpListBoxHolidays()
        {
            foreach (Holiday holiday in holidays.HolidayList)
            {
                listBoxHolidays.Items.Add(holiday.ToString());
            }
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownTo.Value < numericUpDownFrom.Value)
            {
                HideButtons();
            }
            else
            {
                ShowButtons();
            }
        }
    }
}
