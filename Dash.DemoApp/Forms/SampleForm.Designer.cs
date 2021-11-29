namespace Dash.DemoApp.Forms
{
    partial class SampleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanelLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel45 = new System.Windows.Forms.FlowLayoutPanel();
            this.label45 = new System.Windows.Forms.Label();
            this.flowLayoutPanel46 = new System.Windows.Forms.FlowLayoutPanel();
            this.label46 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanelLeft.SuspendLayout();
            this.flowLayoutPanel45.SuspendLayout();
            this.flowLayoutPanel46.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelLeft
            // 
            this.flowLayoutPanelLeft.AllowDrop = true;
            this.flowLayoutPanelLeft.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelLeft.Controls.Add(this.label2);
            this.flowLayoutPanelLeft.Location = new System.Drawing.Point(65, 58);
            this.flowLayoutPanelLeft.Name = "flowLayoutPanelLeft";
            this.flowLayoutPanelLeft.Size = new System.Drawing.Size(200, 403);
            this.flowLayoutPanelLeft.TabIndex = 1;
            this.flowLayoutPanelLeft.DragDrop += new System.Windows.Forms.DragEventHandler(this.On_DragDrop);
            this.flowLayoutPanelLeft.DragEnter += new System.Windows.Forms.DragEventHandler(this.On_DragEnter);
            // 
            // flowLayoutPanel45
            // 
            this.flowLayoutPanel45.AllowDrop = true;
            this.flowLayoutPanel45.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel45.Controls.Add(this.label45);
            this.flowLayoutPanel45.Location = new System.Drawing.Point(348, 58);
            this.flowLayoutPanel45.Name = "flowLayoutPanel45";
            this.flowLayoutPanel45.Size = new System.Drawing.Size(189, 347);
            this.flowLayoutPanel45.TabIndex = 2;
            this.flowLayoutPanel45.DragDrop += new System.Windows.Forms.DragEventHandler(this.On_DragDrop);
            this.flowLayoutPanel45.DragEnter += new System.Windows.Forms.DragEventHandler(this.On_DragEnter);
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label45.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label45.Location = new System.Drawing.Point(3, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(185, 47);
            this.label45.TabIndex = 0;
            this.label45.Text = "KW 45";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel46
            // 
            this.flowLayoutPanel46.AllowDrop = true;
            this.flowLayoutPanel46.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel46.Controls.Add(this.label46);
            this.flowLayoutPanel46.Location = new System.Drawing.Point(556, 58);
            this.flowLayoutPanel46.Name = "flowLayoutPanel46";
            this.flowLayoutPanel46.Size = new System.Drawing.Size(189, 347);
            this.flowLayoutPanel46.TabIndex = 3;
            this.flowLayoutPanel46.DragDrop += new System.Windows.Forms.DragEventHandler(this.On_DragDrop);
            this.flowLayoutPanel46.DragEnter += new System.Windows.Forms.DragEventHandler(this.On_DragEnter);
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label46.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label46.Location = new System.Drawing.Point(3, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(185, 47);
            this.label46.TabIndex = 0;
            this.label46.Text = "KW 46";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 511);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 47);
            this.label2.TabIndex = 1;
            this.label2.Text = "New";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Dash.DemoApp.Properties.Resources.bee;
            this.ClientSize = new System.Drawing.Size(800, 535);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel46);
            this.Controls.Add(this.flowLayoutPanel45);
            this.Controls.Add(this.flowLayoutPanelLeft);
            this.Name = "SampleForm";
            this.Text = "SampleForm";
            this.Load += new System.EventHandler(this.SampleForm_Load);
            this.flowLayoutPanelLeft.ResumeLayout(false);
            this.flowLayoutPanel45.ResumeLayout(false);
            this.flowLayoutPanel46.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelLeft;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel45;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel46;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}