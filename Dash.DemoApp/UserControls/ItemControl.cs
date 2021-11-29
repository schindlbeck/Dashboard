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
    public partial class ItemControl : UserControl
    {
        public string ItemId { get; set; } = String.Empty;

        public ItemControl()
        {
            InitializeComponent();
        }

        private void ItemControl_MouseDown(object sender, MouseEventArgs e)
        {
            var dragControl = sender as Control;
            dragControl.DoDragDrop(ItemId, DragDropEffects.Move);
        }

        private void ItemControl_Load(object sender, EventArgs e)
        {
            Random rndm = new();
            label1.Text = ItemId?.ToString();
            label2.Text = $"KW{rndm.Next(45,47)}";
        }
    }
}
