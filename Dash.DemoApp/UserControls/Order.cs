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
        private int orderCWCurrent;

        public Order(PrioListElement element)
        {
            ListElement = element;
            orderCWCurrent = ListElement.CWPlanned;
            InitializeComponent();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            groupBoxOrder.Text = ListElement.Project + "/" + ListElement.OrderNr;

            InitializeText();
        }

        private void InitializeText()
        {
            richTextBoxInfo.Text = $"CW planned: {ListElement.CWPlanned}" + Environment.NewLine +
                $"CW current: {orderCWCurrent}" + Environment.NewLine + $"Total time: {ListElement.TimeTotal}";

            if (orderCWCurrent >= ListElement.CWPlanned)
            {
                if (orderCWCurrent == ListElement.CWPlanned)
                    richTextBoxInfo.BackColor = Color.LightYellow;
                else
                    richTextBoxInfo.BackColor = Color.IndianRed;
            }
            else
            {
                richTextBoxInfo.BackColor = Color.DarkSeaGreen;
            }
        }

        public void SetCWCurrent(int cw)
        {
            orderCWCurrent = cw;
            InitializeText();
        }
    }
}
