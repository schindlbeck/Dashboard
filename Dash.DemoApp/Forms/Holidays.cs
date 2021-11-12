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
        public Holidays()
        {
            InitializeComponent();
        }

        private void Holidays_Load(object sender, EventArgs e)
        {
            btnGo.Hide();
        }

        private void TxtBoxMonthFrom_TextChanged(object sender, EventArgs e)
        {

            CheckNumbers(out int numberFrom, out int numberTo);

            if (numberFrom <= 0 
                || numberFrom > 12
                || numberFrom > numberTo)
            {
                btnGo.Hide();
                txtBoxMonthFrom.BackColor = Color.DarkRed;
            }
            else
            {
                txtBoxMonthFrom.BackColor = Color.White;
            }

            BtnGoState();

        }

        
        private void TxtBoxMonthTo_TextChanged(object sender, EventArgs e)
        {
            int numberFrom, numberTo;

            CheckNumbers(out numberFrom, out numberTo);

            if (numberTo <= 0 
                || numberTo > 12
                || numberFrom > numberTo)
            {
                btnGo.Hide();
                txtBoxMonthTo.BackColor = Color.DarkRed;
            }
            else
            {
                txtBoxMonthTo.BackColor = Color.White;
            }

            BtnGoState();
        }
        private void CheckNumbers(out int numberFrom, out int numberTo)
        {
            try
            {
                numberFrom = Convert.ToInt32(txtBoxMonthFrom.Text);
            }
            catch
            {
                numberFrom = 0;
            }

            try
            {
                numberTo = Convert.ToInt32(txtBoxMonthTo.Text);
            }
            catch
            {
                numberTo = 0;
            }
        }

        private void BtnGoState()
        {
            if (txtBoxMonthFrom.BackColor == Color.White
                && txtBoxMonthTo.BackColor == Color.White)
            {
                btnGo.Show();
            }
        }
    }
}
