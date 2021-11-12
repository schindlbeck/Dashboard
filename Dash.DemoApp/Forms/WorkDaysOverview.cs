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
        public WorkDaysOverview()
        {
            InitializeComponent();
        }

        private void WorkDaysOverview_Load(object sender, EventArgs e)
        {
            numericUpDownYearStart.Value = DateTime.Now.Year;
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            workSchedule = new(Convert.ToInt32(numericUpDownYearStart.Value), Convert.ToInt32(numericUpDownCwStart.Value), Convert.ToInt32(numericUpDownCwEnd.Value));

            listBoxWorkSchedule.Items.Clear();
            FillListBox();
        }

        private void FillListBox()
        {
            foreach(WorkWeek workWeek in workSchedule.WorkWeeks)
            {
                listBoxWorkSchedule.Items.Add(workWeek.ToString());
            }
        }
    }
}
