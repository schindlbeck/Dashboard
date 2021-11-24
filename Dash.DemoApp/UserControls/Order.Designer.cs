namespace Dash.DemoApp.UserControls
{
    partial class Order
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxOrder = new System.Windows.Forms.GroupBox();
            this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.groupBoxOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxOrder
            // 
            this.groupBoxOrder.BackColor = System.Drawing.SystemColors.Window;
            this.groupBoxOrder.Controls.Add(this.richTextBoxInfo);
            this.groupBoxOrder.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxOrder.Location = new System.Drawing.Point(0, 0);
            this.groupBoxOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxOrder.Name = "groupBoxOrder";
            this.groupBoxOrder.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxOrder.Size = new System.Drawing.Size(180, 141);
            this.groupBoxOrder.TabIndex = 5;
            this.groupBoxOrder.TabStop = false;
            this.groupBoxOrder.Text = "groupBox1";
            // 
            // richTextBoxInfo
            // 
            this.richTextBoxInfo.Location = new System.Drawing.Point(7, 32);
            this.richTextBoxInfo.Name = "richTextBoxInfo";
            this.richTextBoxInfo.Size = new System.Drawing.Size(165, 98);
            this.richTextBoxInfo.TabIndex = 0;
            this.richTextBoxInfo.Text = "";
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.Controls.Add(this.groupBoxOrder);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Order";
            this.Size = new System.Drawing.Size(217, 141);
            this.Load += new System.EventHandler(this.Order_Load);
            this.groupBoxOrder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxOrder;
        private System.Windows.Forms.RichTextBox richTextBoxInfo;
    }
}
