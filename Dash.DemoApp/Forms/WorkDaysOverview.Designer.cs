namespace Dash.DemoApp.Forms
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
            this.listBoxDayInfos = new System.Windows.Forms.ListBox();
            this.buttonDeleteDay = new System.Windows.Forms.Button();
            this.groupBoxDayOptions = new System.Windows.Forms.GroupBox();
            this.buttonDeleteShift = new System.Windows.Forms.Button();
            this.buttonChangeShifts = new System.Windows.Forms.Button();
            this.groupBoxShifts = new System.Windows.Forms.GroupBox();
            this.checkBoxNight = new System.Windows.Forms.CheckBox();
            this.checkBoxeEvening = new System.Windows.Forms.CheckBox();
            this.checkBoxMorning = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCwStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCwEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYearStart)).BeginInit();
            this.groupBoxDayOptions.SuspendLayout();
            this.groupBoxShifts.SuspendLayout();
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
            this.listBoxWorkSchedule.Size = new System.Drawing.Size(371, 504);
            this.listBoxWorkSchedule.TabIndex = 6;
            this.listBoxWorkSchedule.SelectedIndexChanged += new System.EventHandler(this.ListBoxWorkSchedule_SelectedIndexChanged);
            this.listBoxWorkSchedule.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxWorkSchedule_MouseDoubleClick);
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
            // listBoxDayInfos
            // 
            this.listBoxDayInfos.FormattingEnabled = true;
            this.listBoxDayInfos.ItemHeight = 25;
            this.listBoxDayInfos.Location = new System.Drawing.Point(409, 150);
            this.listBoxDayInfos.Name = "listBoxDayInfos";
            this.listBoxDayInfos.Size = new System.Drawing.Size(214, 254);
            this.listBoxDayInfos.TabIndex = 11;
            this.listBoxDayInfos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxDayInfos_MouseClick);
            this.listBoxDayInfos.SelectedIndexChanged += new System.EventHandler(this.ListBoxDayInfos_SelectedIndexChanged);
            // 
            // buttonDeleteDay
            // 
            this.buttonDeleteDay.Location = new System.Drawing.Point(6, 45);
            this.buttonDeleteDay.Name = "buttonDeleteDay";
            this.buttonDeleteDay.Size = new System.Drawing.Size(145, 52);
            this.buttonDeleteDay.TabIndex = 12;
            this.buttonDeleteDay.Text = "Delete Day";
            this.buttonDeleteDay.UseVisualStyleBackColor = true;
            this.buttonDeleteDay.Click += new System.EventHandler(this.ButtonDeleteDay_Click);
            // 
            // groupBoxDayOptions
            // 
            this.groupBoxDayOptions.Controls.Add(this.buttonDeleteShift);
            this.groupBoxDayOptions.Controls.Add(this.buttonChangeShifts);
            this.groupBoxDayOptions.Controls.Add(this.buttonDeleteDay);
            this.groupBoxDayOptions.Location = new System.Drawing.Point(409, 410);
            this.groupBoxDayOptions.Name = "groupBoxDayOptions";
            this.groupBoxDayOptions.Size = new System.Drawing.Size(155, 239);
            this.groupBoxDayOptions.TabIndex = 13;
            this.groupBoxDayOptions.TabStop = false;
            this.groupBoxDayOptions.Text = "Options";
            // 
            // buttonDeleteShift
            // 
            this.buttonDeleteShift.Location = new System.Drawing.Point(6, 177);
            this.buttonDeleteShift.Name = "buttonDeleteShift";
            this.buttonDeleteShift.Size = new System.Drawing.Size(145, 52);
            this.buttonDeleteShift.TabIndex = 14;
            this.buttonDeleteShift.Text = "Delete Shift";
            this.buttonDeleteShift.UseVisualStyleBackColor = true;
            this.buttonDeleteShift.Click += new System.EventHandler(this.ButtonDeleteShift_Click);
            // 
            // buttonChangeShifts
            // 
            this.buttonChangeShifts.Location = new System.Drawing.Point(6, 119);
            this.buttonChangeShifts.Name = "buttonChangeShifts";
            this.buttonChangeShifts.Size = new System.Drawing.Size(145, 52);
            this.buttonChangeShifts.TabIndex = 13;
            this.buttonChangeShifts.Text = "Change Shifts";
            this.buttonChangeShifts.UseVisualStyleBackColor = true;
            this.buttonChangeShifts.Click += new System.EventHandler(this.ButtonChangeShifts_Click);
            // 
            // groupBoxShifts
            // 
            this.groupBoxShifts.Controls.Add(this.checkBoxNight);
            this.groupBoxShifts.Controls.Add(this.checkBoxeEvening);
            this.groupBoxShifts.Controls.Add(this.checkBoxMorning);
            this.groupBoxShifts.Location = new System.Drawing.Point(629, 150);
            this.groupBoxShifts.Name = "groupBoxShifts";
            this.groupBoxShifts.Size = new System.Drawing.Size(196, 155);
            this.groupBoxShifts.TabIndex = 14;
            this.groupBoxShifts.TabStop = false;
            this.groupBoxShifts.Text = "Shifts";
            // 
            // checkBoxNight
            // 
            this.checkBoxNight.AutoSize = true;
            this.checkBoxNight.Location = new System.Drawing.Point(17, 110);
            this.checkBoxNight.Name = "checkBoxNight";
            this.checkBoxNight.Size = new System.Drawing.Size(123, 29);
            this.checkBoxNight.TabIndex = 2;
            this.checkBoxNight.Text = "Night Shift";
            this.checkBoxNight.UseVisualStyleBackColor = true;
            this.checkBoxNight.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBoxeEvening
            // 
            this.checkBoxeEvening.AutoSize = true;
            this.checkBoxeEvening.Checked = true;
            this.checkBoxeEvening.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxeEvening.Location = new System.Drawing.Point(17, 75);
            this.checkBoxeEvening.Name = "checkBoxeEvening";
            this.checkBoxeEvening.Size = new System.Drawing.Size(141, 29);
            this.checkBoxeEvening.TabIndex = 1;
            this.checkBoxeEvening.Text = "Evening Shift\r\n";
            this.checkBoxeEvening.UseVisualStyleBackColor = true;
            this.checkBoxeEvening.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBoxMorning
            // 
            this.checkBoxMorning.AutoSize = true;
            this.checkBoxMorning.Checked = true;
            this.checkBoxMorning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMorning.Location = new System.Drawing.Point(17, 40);
            this.checkBoxMorning.Name = "checkBoxMorning";
            this.checkBoxMorning.Size = new System.Drawing.Size(147, 29);
            this.checkBoxMorning.TabIndex = 0;
            this.checkBoxMorning.Text = "Morning Shift";
            this.checkBoxMorning.UseVisualStyleBackColor = true;
            this.checkBoxMorning.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // WorkDaysOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1350, 674);
            this.Controls.Add(this.groupBoxShifts);
            this.Controls.Add(this.groupBoxDayOptions);
            this.Controls.Add(this.listBoxDayInfos);
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
            this.groupBoxDayOptions.ResumeLayout(false);
            this.groupBoxShifts.ResumeLayout(false);
            this.groupBoxShifts.PerformLayout();
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
        private System.Windows.Forms.ListBox listBoxDayInfos;
        private System.Windows.Forms.Button buttonDeleteDay;
        private System.Windows.Forms.GroupBox groupBoxDayOptions;
        private System.Windows.Forms.Button buttonDeleteShift;
        private System.Windows.Forms.Button buttonChangeShifts;
        private System.Windows.Forms.GroupBox groupBoxShifts;
        private System.Windows.Forms.CheckBox checkBoxNight;
        private System.Windows.Forms.CheckBox checkBoxeEvening;
        private System.Windows.Forms.CheckBox checkBoxMorning;
    }
}