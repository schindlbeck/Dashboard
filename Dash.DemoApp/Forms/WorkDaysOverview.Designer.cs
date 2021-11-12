﻿namespace Dash.DemoApp.Forms
{
    partial class WorkDaysOverview
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxWorkSchedule = new System.Windows.Forms.ListBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.numericUpDownCwStart = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCwEnd = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownYearStart = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCwStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCwEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYearStart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Set start (cw/year):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Set end (cw):";
            // 
            // listBoxWorkSchedule
            // 
            this.listBoxWorkSchedule.FormattingEnabled = true;
            this.listBoxWorkSchedule.ItemHeight = 25;
            this.listBoxWorkSchedule.Location = new System.Drawing.Point(32, 150);
            this.listBoxWorkSchedule.Name = "listBoxWorkSchedule";
            this.listBoxWorkSchedule.Size = new System.Drawing.Size(371, 479);
            this.listBoxWorkSchedule.TabIndex = 6;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(417, 40);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(94, 73);
            this.btnGo.TabIndex = 7;
            this.btnGo.Text = "go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // numericUpDownCwStart
            // 
            this.numericUpDownCwStart.Location = new System.Drawing.Point(227, 43);
            this.numericUpDownCwStart.Maximum = new decimal(new int[] {
            53,
            0,
            0,
            0});
            this.numericUpDownCwStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCwStart.Name = "numericUpDownCwStart";
            this.numericUpDownCwStart.Size = new System.Drawing.Size(70, 31);
            this.numericUpDownCwStart.TabIndex = 8;
            this.numericUpDownCwStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownCwEnd
            // 
            this.numericUpDownCwEnd.Location = new System.Drawing.Point(227, 82);
            this.numericUpDownCwEnd.Maximum = new decimal(new int[] {
            53,
            0,
            0,
            0});
            this.numericUpDownCwEnd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCwEnd.Name = "numericUpDownCwEnd";
            this.numericUpDownCwEnd.ReadOnly = true;
            this.numericUpDownCwEnd.Size = new System.Drawing.Size(70, 31);
            this.numericUpDownCwEnd.TabIndex = 9;
            this.numericUpDownCwEnd.Value = new decimal(new int[] {
            52,
            0,
            0,
            0});
            // 
            // numericUpDownYearStart
            // 
            this.numericUpDownYearStart.Location = new System.Drawing.Point(303, 43);
            this.numericUpDownYearStart.Maximum = new decimal(new int[] {
            2999,
            0,
            0,
            0});
            this.numericUpDownYearStart.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDownYearStart.Name = "numericUpDownYearStart";
            this.numericUpDownYearStart.Size = new System.Drawing.Size(80, 31);
            this.numericUpDownYearStart.TabIndex = 10;
            this.numericUpDownYearStart.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // WorkDaysOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1350, 674);
            this.Controls.Add(this.numericUpDownYearStart);
            this.Controls.Add(this.numericUpDownCwEnd);
            this.Controls.Add(this.numericUpDownCwStart);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.listBoxWorkSchedule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "WorkDaysOverview";
            this.Text = "WorkDaysOverview";
            this.Load += new System.EventHandler(this.WorkDaysOverview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCwStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCwEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYearStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxWorkSchedule;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.NumericUpDown numericUpDownCwStart;
        private System.Windows.Forms.NumericUpDown numericUpDownCwEnd;
        private System.Windows.Forms.NumericUpDown numericUpDownYearStart;
    }
}