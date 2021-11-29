using Dash.DemoApp.UserControls;
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
    public partial class SampleForm : Form
    {
        DragDropManager Manager = new();
        public Dictionary<string, Control> ItemRelations = new Dictionary<string, Control>();
        public Dictionary<string, Control> ContainerRelations = new Dictionary<string, Control>();

        public SampleForm()
        {
            InitializeComponent();
        }

        private void On_MouseDown(object sender, MouseEventArgs e)
        {
            var dragControl = sender as ItemControl;
            dragControl.DoDragDrop(dragControl.ItemId, DragDropEffects.Move);
        }

        private void On_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void On_DragDrop(object sender, DragEventArgs e)
        {
            // get the item
            var itemId = e.Data.GetData(DataFormats.Text) as String;
            var item = Manager.GetItemById(itemId);

            // get the containers
            var containerPanel = sender as FlowLayoutPanel;
            var container = containerPanel.Tag as DragDropItemContainer;

            // get the related control
            var control = ItemRelations[itemId];
            Manager.Drop(item, container);
            containerPanel.Controls.Add(control);

            item.Container = container;
            label1.Text = $"Action {itemId} -> [{container.Id}]";
        }

        private void SampleForm_Load(object sender, EventArgs e)
        {
            // build relation to containers
            DragDropItemContainer containerLeft = new();
            ContainerRelations.Add(containerLeft.Id, flowLayoutPanelLeft);
            flowLayoutPanelLeft.Tag = containerLeft;

            DragDropItemContainer container45 = new();
            ContainerRelations.Add(container45.Id, flowLayoutPanel45);
            flowLayoutPanel45.Tag = container45;

            DragDropItemContainer container46 = new();
            ContainerRelations.Add(container46.Id, flowLayoutPanel46);
            flowLayoutPanel46.Tag = container46;

            // create demo data
            for (int i = 1; i < 5; i++)
            {
                var item = CreateItemControl(containerLeft);
            }
        }

        private ItemControl CreateItemControl(DragDropItemContainer container)
        {
            ItemControl itemControl = new ItemControl();

            itemControl.BackColor = System.Drawing.Color.MidnightBlue;
            itemControl.Dock = System.Windows.Forms.DockStyle.Top;
            itemControl.Location = new System.Drawing.Point(3, 3);
            itemControl.Size = new System.Drawing.Size(175, 78);
            itemControl.TabIndex = 4;
            itemControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.On_MouseDown);

            var dragDropItem = new DragDropItem();
            dragDropItem.Container = container;
            itemControl.ItemId = dragDropItem.Id;
            itemControl.Text = dragDropItem.Id;

            ItemRelations.Add(dragDropItem.Id, itemControl);
            Manager.Items.Add(dragDropItem);

            flowLayoutPanelLeft.Controls.Add(itemControl);

            return itemControl;
        }

    }

    internal class FromToDragDropAction
    {
        public string FromContainerID { get; init; } = string.Empty;
        public string ToContainerID { get; init; } = string.Empty;
        public string ItemId { get; init; } = string.Empty;
    }

    internal class DragDropManager
    {
        public List<DragDropItemContainer> Containers = new();
        public Stack<FromToDragDropAction> Actions = new();
        public List<DragDropItem> Items = new();

        public event EventHandler ItemDroped;

        internal DragDropItem GetItemById(string itemId)
        {
            return Items.Where(i => i.Id == itemId).FirstOrDefault();
        }

        public bool Drop(DragDropItem item, DragDropItemContainer container)
        {
            if (container.CanDrop(item))
            {
                var oldContainer = item.Container;
                oldContainer?.Items.Remove(item);

                FromToDragDropAction action = new()
                {
                    FromContainerID = oldContainer?.Id,
                    ToContainerID = container.Id,
                    ItemId = item.Id,
                };
                Actions.Push(action);

                container.Drop(item);
                OnDroped(new EventArgs());

                return true;
            }
            return false;
        }

        protected virtual void OnDroped(EventArgs e)
        {
            EventHandler handler = ItemDroped;
            handler?.Invoke(this, e);
        }

    }

    internal class DragDropItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(24);
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

        public DragDropItemContainer Container { get; set; }
    }

    internal class DragDropItemContainer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(24);
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

        public List<DragDropItem> Items { get; set; } = new List<DragDropItem>();

        public bool CanDrop(DragDropItem item)
        {
            return !Items.Contains(item);
        }

        public bool Drop(DragDropItem item)
        {
            if (CanDrop(item))
            {
                item.Container = this;
                Items.Add(item);
                return true;
            }
            return false;
        }
    }


}
