using Dash.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dash.DemoApp.UserControls
{
    public partial class Order : UserControl
    {
        public PrioListElement ListElement { get; set; }  

        public Order(PrioListElement element)
        {
            ListElement = element;
            InitializeComponent();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            InitializeLabels();
        }

        private void InitializeLabels()
        {
            groupBoxOrder.Text = ListElement.Project + "/" +ListElement.OrderNr;
            labelCwNow.Text = ListElement.CWPlanned.ToString();
            labelCwPlan.Text = ListElement.CWPlanned.ToString();
            labelMinutes.Text = ListElement.TimeTotal.ToString();
        }
    }
}
