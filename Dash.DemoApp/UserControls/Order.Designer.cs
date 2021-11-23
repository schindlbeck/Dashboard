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
            this.labelMinutes = new System.Windows.Forms.Label();
            this.labelCwPlan = new System.Windows.Forms.Label();
            this.labelCwNow = new System.Windows.Forms.Label();
            this.groupBoxOrder = new System.Windows.Forms.GroupBox();
            this.groupBoxOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelMinutes
            // 
            this.labelMinutes.AutoSize = true;
            this.labelMinutes.Location = new System.Drawing.Point(35, 44);
            this.labelMinutes.Name = "labelMinutes";
            this.labelMinutes.Size = new System.Drawing.Size(38, 15);
            this.labelMinutes.TabIndex = 2;
            this.labelMinutes.Text = "label3";
            // 
            // labelCwPlan
            // 
            this.labelCwPlan.AutoSize = true;
            this.labelCwPlan.Location = new System.Drawing.Point(6, 19);
            this.labelCwPlan.Name = "labelCwPlan";
            this.labelCwPlan.Size = new System.Drawing.Size(38, 15);
            this.labelCwPlan.TabIndex = 3;
            this.labelCwPlan.Text = "label3";
            // 
            // labelCwNow
            // 
            this.labelCwNow.AutoSize = true;
            this.labelCwNow.Location = new System.Drawing.Point(61, 19);
            this.labelCwNow.Name = "labelCwNow";
            this.labelCwNow.Size = new System.Drawing.Size(38, 15);
            this.labelCwNow.TabIndex = 4;
            this.labelCwNow.Text = "label3";
            // 
            // groupBoxOrder
            // 
            this.groupBoxOrder.BackColor = System.Drawing.SystemColors.Window;
            this.groupBoxOrder.Controls.Add(this.labelCwNow);
            this.groupBoxOrder.Controls.Add(this.labelCwPlan);
            this.groupBoxOrder.Controls.Add(this.labelMinutes);
            this.groupBoxOrder.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxOrder.Location = new System.Drawing.Point(0, 0);
            this.groupBoxOrder.Name = "groupBoxOrder";
            this.groupBoxOrder.Size = new System.Drawing.Size(106, 67);
            this.groupBoxOrder.TabIndex = 5;
            this.groupBoxOrder.TabStop = false;
            this.groupBoxOrder.Text = "groupBox1";
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.Controls.Add(this.groupBoxOrder);
            this.Name = "Order";
            this.Size = new System.Drawing.Size(135, 67);
            this.Load += new System.EventHandler(this.Order_Load);
            this.groupBoxOrder.ResumeLayout(false);
            this.groupBoxOrder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelMinutes;
        private System.Windows.Forms.Label labelCwPlan;
        private System.Windows.Forms.Label labelCwNow;
        private System.Windows.Forms.GroupBox groupBoxOrder;
    }
}
