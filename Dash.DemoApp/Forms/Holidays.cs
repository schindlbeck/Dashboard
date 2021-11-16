using Dash.Data;
using Dash.Data.Models;
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
            holidays = new(Convert.ToInt32(numericUpDownYear.Value), Convert.ToInt32(numericUpDownFrom.Value), Convert.ToInt32(numericUpDownTo.Value), DbContext);

            listBoxHolidays.Items.Clear();
            SetUpListBoxHolidays();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            holidays = new(Convert.ToInt32(numericUpDownYear.Value), Convert.ToInt32(numericUpDownFrom.Value), Convert.ToInt32(numericUpDownTo.Value), DbContext);

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
