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
using Dash.Shared;

namespace Dash.DemoApp.UserControls
{
    public partial class OrderControl : UserControl
    {
        public OrderContainer OrderContainer { get; init; }

        public OrderControl(PrioListElement element)
        {
            OrderContainer = new(element);

            InitializeComponent();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            groupBoxOrder.Text = OrderContainer.ListElement.Project + "/" + OrderContainer.ListElement.OrderNr;

            InitializeText();
        }

        private void InitializeText()
        {
            //TODO: colors right if cwplan>cwcurrent, but in next year
            richTextBoxInfo.Text = $"CW planned: {OrderContainer.ListElement.CWPlanned}" + Environment.NewLine +
                $"CW current: {OrderContainer.CurrentCW}" + Environment.NewLine + $"Total time: {OrderContainer.ListElement.TimeTotal}";

            if (OrderContainer.CurrentCW >= OrderContainer.ListElement.CWPlanned)
            {
                if (OrderContainer.CurrentCW == OrderContainer.ListElement.CWPlanned)
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
            OrderContainer.CurrentCW = cw;
            InitializeText();
        }
    }
}
