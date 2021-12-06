using Dash.Shared;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Dash.DemoApp.UserControls
{
    public partial class OrderControl : UserControl
    {
        public OrderContainer OrderContainer { get; init; }

        public OrderControl(OrderContainer container)
        {
            OrderContainer = container;

            InitializeComponent();

            this.OrderContainer.OrderProductionCWChanged += OrderContainer_OrderCwChanged;
        }

        private void OrderContainer_OrderCwChanged(object sender, EventArgs e)
        {
            InitializeText();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            groupBoxOrder.Text = OrderContainer.ListElement.Project + "/" + OrderContainer.ListElement.OrderNr;

            InitializeText();
        }

        private void InitializeText()
        {
            richTextBoxInfo.Text = $"CW planned: {OrderContainer.ListElement.DeliveryCW}" + Environment.NewLine +
                $"CW current: {OrderContainer.ProductionCW}" + Environment.NewLine + $"Total time: {OrderContainer.ListElement.TimeTotal}";

            if (OrderContainer.ProductionCW >= OrderContainer.ListElement.DeliveryCW)
            {
                if (OrderContainer.ProductionCW == OrderContainer.ListElement.DeliveryCW)
                    richTextBoxInfo.BackColor = Color.LightYellow;
                else
                    richTextBoxInfo.BackColor = Color.IndianRed;
            }
            else
            {
                if (OrderContainer.CurrentYear > OrderContainer.ListElement.DeliveryDate.Year)
                    richTextBoxInfo.BackColor = Color.IndianRed;
                else
                    richTextBoxInfo.BackColor = Color.DarkSeaGreen;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text { get; set; }
    }
}
