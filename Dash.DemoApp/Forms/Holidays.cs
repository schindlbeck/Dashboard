using Dash.Shared.Models;
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

        public Holidays()
        {
            InitializeComponent();
        }

        private void Holidays_Load(object sender, EventArgs e)
        {
            HideButtons();
            btnDelete.Hide();
            txtBoxYear.Text = DateTime.Now.Year.ToString(); 
        }

        private void TxtBoxMonthFrom_TextChanged(object sender, EventArgs e)
        {
            CheckNumbers(out int numberFrom, out int numberTo);

            if (numberFrom <= 0 
                || numberFrom > 12
                || numberFrom > numberTo)
            {
                HideButtons();
                txtBoxMonthFrom.BackColor = Color.DarkRed;
            }
            else
            {
                txtBoxMonthFrom.BackColor = Color.White;
                BtnState();
            }
        }

        private void TxtBoxMonthTo_TextChanged(object sender, EventArgs e)
        {
            int numberFrom, numberTo;

            CheckNumbers(out numberFrom, out numberTo);

            if (numberTo <= 0 
                || numberTo > 12
                || numberFrom > numberTo)
            {
                HideButtons();
                txtBoxMonthTo.BackColor = Color.DarkRed;
            }
            else
            {
                txtBoxMonthTo.BackColor = Color.White;
                BtnState();
            }
        }

        private void TxtBoxYear_TextChanged(object sender, EventArgs e)
        {
            int year;
            try { year = Convert.ToInt32(txtBoxYear.Text); }
            catch { year = 0; }

            if (year < 2000
                || year > 2999)
            {
                txtBoxYear.BackColor = Color.DarkRed;
                HideButtons();
            }
            else
            {
                txtBoxYear.BackColor = Color.White;
                BtnState();
            }
        }

        private void CheckNumbers(out int numberFrom, out int numberTo)
        {
            try { numberFrom = Convert.ToInt32(txtBoxMonthFrom.Text); }
            catch { numberFrom = 0; }

            try { numberTo = Convert.ToInt32(txtBoxMonthTo.Text); }
            catch { numberTo = 0; }
        }

        private void BtnState()
        {
            if (txtBoxMonthFrom.BackColor == Color.White
                && txtBoxMonthTo.BackColor == Color.White
                && txtBoxYear.BackColor == Color.White)
            {
                btnNew.Show();
                btnAdd.Show();
            }
        }

        private void HideButtons()
        {
            btnAdd.Hide();
            btnNew.Hide();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(txtBoxYear.Text);
            int monthFrom = Convert.ToInt32(txtBoxMonthFrom.Text);
            int monthTo = Convert.ToInt32(txtBoxMonthTo.Text);

            holidays = new(year, monthFrom, monthTo);

            listBoxHolidays.Items.Clear();
            SetUpListBoxHolidays();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(txtBoxYear.Text);
            int monthFrom = Convert.ToInt32(txtBoxMonthFrom.Text);
            int monthTo = Convert.ToInt32(txtBoxMonthTo.Text);

            holidays = new(year, monthFrom, monthTo);

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
    }
}
