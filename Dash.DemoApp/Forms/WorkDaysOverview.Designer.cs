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
            this.buttonEquipment = new System.Windows.Forms.Button();
            this.buttonChangeShifts = new System.Windows.Forms.Button();
            this.groupBoxShifts = new System.Windows.Forms.GroupBox();
            this.checkBoxNight = new System.Windows.Forms.CheckBox();
            this.checkBoxeEvening = new System.Windows.Forms.CheckBox();
            this.checkBoxMorning = new System.Windows.Forms.CheckBox();
            this.numericUpDownEquipMorning = new System.Windows.Forms.NumericUpDown();
            this.groupBoxEquipments = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownEquipNight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEquipEvening = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCwStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCwEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYearStart)).BeginInit();
            this.groupBoxDayOptions.SuspendLayout();
            this.groupBoxShifts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEquipMorning)).BeginInit();
            this.groupBoxEquipments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEquipNight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEquipEvening)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Set start (cw/year):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Set end (cw):";
            // 
            // listBoxWorkSchedule
            // 
            this.listBoxWorkSchedule.FormattingEnabled = true;
            this.listBoxWorkSchedule.ItemHeight = 15;
            this.listBoxWorkSchedule.Location = new System.Drawing.Point(22, 90);
            this.listBoxWorkSchedule.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxWorkSchedule.Name = "listBoxWorkSchedule";
            this.listBoxWorkSchedule.Size = new System.Drawing.Size(261, 304);
            this.listBoxWorkSchedule.TabIndex = 6;
            this.listBoxWorkSchedule.SelectedIndexChanged += new System.EventHandler(this.ListBoxWorkSchedule_SelectedIndexChanged);
            this.listBoxWorkSchedule.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxWorkSchedule_MouseDoubleClick);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(292, 24);
            this.btnGo.Margin = new System.Windows.Forms.Padding(2);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(66, 44);
            this.btnGo.TabIndex = 7;
            this.btnGo.Text = "go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // numericUpDownCwStart
            // 
            this.numericUpDownCwStart.Location = new System.Drawing.Point(159, 26);
            this.numericUpDownCwStart.Margin = new System.Windows.Forms.Padding(2);
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
            this.numericUpDownCwStart.Size = new System.Drawing.Size(49, 23);
            this.numericUpDownCwStart.TabIndex = 8;
            this.numericUpDownCwStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownCwEnd
            // 
            this.numericUpDownCwEnd.Location = new System.Drawing.Point(159, 49);
            this.numericUpDownCwEnd.Margin = new System.Windows.Forms.Padding(2);
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
            this.numericUpDownCwEnd.Size = new System.Drawing.Size(49, 23);
            this.numericUpDownCwEnd.TabIndex = 9;
            this.numericUpDownCwEnd.Value = new decimal(new int[] {
            52,
            0,
            0,
            0});
            // 
            // numericUpDownYearStart
            // 
            this.numericUpDownYearStart.Location = new System.Drawing.Point(212, 26);
            this.numericUpDownYearStart.Margin = new System.Windows.Forms.Padding(2);
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
            this.numericUpDownYearStart.Size = new System.Drawing.Size(56, 23);
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
            this.listBoxDayInfos.ItemHeight = 15;
            this.listBoxDayInfos.Location = new System.Drawing.Point(286, 90);
            this.listBoxDayInfos.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxDayInfos.Name = "listBoxDayInfos";
            this.listBoxDayInfos.Size = new System.Drawing.Size(151, 154);
            this.listBoxDayInfos.TabIndex = 11;
            this.listBoxDayInfos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxDayInfos_MouseClick);
            this.listBoxDayInfos.SelectedIndexChanged += new System.EventHandler(this.ListBoxDayInfos_SelectedIndexChanged);
            // 
            // buttonDeleteDay
            // 
            this.buttonDeleteDay.Location = new System.Drawing.Point(4, 27);
            this.buttonDeleteDay.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeleteDay.Name = "buttonDeleteDay";
            this.buttonDeleteDay.Size = new System.Drawing.Size(102, 31);
            this.buttonDeleteDay.TabIndex = 12;
            this.buttonDeleteDay.Text = "Delete Day";
            this.buttonDeleteDay.UseVisualStyleBackColor = true;
            this.buttonDeleteDay.Click += new System.EventHandler(this.ButtonDeleteDay_Click);
            // 
            // groupBoxDayOptions
            // 
            this.groupBoxDayOptions.Controls.Add(this.buttonEquipment);
            this.groupBoxDayOptions.Controls.Add(this.buttonChangeShifts);
            this.groupBoxDayOptions.Controls.Add(this.buttonDeleteDay);
            this.groupBoxDayOptions.Location = new System.Drawing.Point(286, 246);
            this.groupBoxDayOptions.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxDayOptions.Name = "groupBoxDayOptions";
            this.groupBoxDayOptions.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxDayOptions.Size = new System.Drawing.Size(108, 143);
            this.groupBoxDayOptions.TabIndex = 13;
            this.groupBoxDayOptions.TabStop = false;
            this.groupBoxDayOptions.Text = "Options";
            // 
            // buttonEquipment
            // 
            this.buttonEquipment.Location = new System.Drawing.Point(4, 106);
            this.buttonEquipment.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEquipment.Name = "buttonEquipment";
            this.buttonEquipment.Size = new System.Drawing.Size(102, 31);
            this.buttonEquipment.TabIndex = 14;
            this.buttonEquipment.Text = "Equipments";
            this.buttonEquipment.UseVisualStyleBackColor = true;
            this.buttonEquipment.Click += new System.EventHandler(this.ButtonEquipments_Click);
            // 
            // buttonChangeShifts
            // 
            this.buttonChangeShifts.Location = new System.Drawing.Point(4, 71);
            this.buttonChangeShifts.Margin = new System.Windows.Forms.Padding(2);
            this.buttonChangeShifts.Name = "buttonChangeShifts";
            this.buttonChangeShifts.Size = new System.Drawing.Size(102, 31);
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
            this.groupBoxShifts.Location = new System.Drawing.Point(440, 90);
            this.groupBoxShifts.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxShifts.Name = "groupBoxShifts";
            this.groupBoxShifts.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxShifts.Size = new System.Drawing.Size(137, 93);
            this.groupBoxShifts.TabIndex = 14;
            this.groupBoxShifts.TabStop = false;
            this.groupBoxShifts.Text = "Shifts";
            // 
            // checkBoxNight
            // 
            this.checkBoxNight.AutoSize = true;
            this.checkBoxNight.Location = new System.Drawing.Point(12, 66);
            this.checkBoxNight.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxNight.Name = "checkBoxNight";
            this.checkBoxNight.Size = new System.Drawing.Size(83, 19);
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
            this.checkBoxeEvening.Location = new System.Drawing.Point(12, 45);
            this.checkBoxeEvening.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxeEvening.Name = "checkBoxeEvening";
            this.checkBoxeEvening.Size = new System.Drawing.Size(95, 19);
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
            this.checkBoxMorning.Location = new System.Drawing.Point(12, 24);
            this.checkBoxMorning.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxMorning.Name = "checkBoxMorning";
            this.checkBoxMorning.Size = new System.Drawing.Size(99, 19);
            this.checkBoxMorning.TabIndex = 0;
            this.checkBoxMorning.Text = "Morning Shift";
            this.checkBoxMorning.UseVisualStyleBackColor = true;
            this.checkBoxMorning.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // numericUpDownEquipMorning
            // 
            this.numericUpDownEquipMorning.Location = new System.Drawing.Point(75, 24);
            this.numericUpDownEquipMorning.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownEquipMorning.Name = "numericUpDownEquipMorning";
            this.numericUpDownEquipMorning.Size = new System.Drawing.Size(51, 23);
            this.numericUpDownEquipMorning.TabIndex = 15;
            this.numericUpDownEquipMorning.ValueChanged += new System.EventHandler(this.NumericUpDownEquip_ValueChanged);
            // 
            // groupBoxEquipments
            // 
            this.groupBoxEquipments.Controls.Add(this.label5);
            this.groupBoxEquipments.Controls.Add(this.label4);
            this.groupBoxEquipments.Controls.Add(this.label3);
            this.groupBoxEquipments.Controls.Add(this.numericUpDownEquipNight);
            this.groupBoxEquipments.Controls.Add(this.numericUpDownEquipEvening);
            this.groupBoxEquipments.Controls.Add(this.numericUpDownEquipMorning);
            this.groupBoxEquipments.Location = new System.Drawing.Point(440, 188);
            this.groupBoxEquipments.Name = "groupBoxEquipments";
            this.groupBoxEquipments.Size = new System.Drawing.Size(157, 116);
            this.groupBoxEquipments.TabIndex = 16;
            this.groupBoxEquipments.TabStop = false;
            this.groupBoxEquipments.Text = "Equipments";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "Evening";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "Night";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Morning";
            // 
            // numericUpDownEquipNight
            // 
            this.numericUpDownEquipNight.Location = new System.Drawing.Point(75, 82);
            this.numericUpDownEquipNight.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownEquipNight.Name = "numericUpDownEquipNight";
            this.numericUpDownEquipNight.Size = new System.Drawing.Size(51, 23);
            this.numericUpDownEquipNight.TabIndex = 17;
            this.numericUpDownEquipNight.ValueChanged += new System.EventHandler(this.NumericUpDownEquip_ValueChanged);
            // 
            // numericUpDownEquipEvening
            // 
            this.numericUpDownEquipEvening.Location = new System.Drawing.Point(75, 53);
            this.numericUpDownEquipEvening.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownEquipEvening.Name = "numericUpDownEquipEvening";
            this.numericUpDownEquipEvening.Size = new System.Drawing.Size(51, 23);
            this.numericUpDownEquipEvening.TabIndex = 16;
            this.numericUpDownEquipEvening.ValueChanged += new System.EventHandler(this.NumericUpDownEquip_ValueChanged);
            // 
            // WorkDaysOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(945, 404);
            this.Controls.Add(this.groupBoxEquipments);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WorkDaysOverview";
            this.Text = "WorkDaysOverview";
            this.Load += new System.EventHandler(this.WorkDaysOverview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCwStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCwEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYearStart)).EndInit();
            this.groupBoxDayOptions.ResumeLayout(false);
            this.groupBoxShifts.ResumeLayout(false);
            this.groupBoxShifts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEquipMorning)).EndInit();
            this.groupBoxEquipments.ResumeLayout(false);
            this.groupBoxEquipments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEquipNight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEquipEvening)).EndInit();
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
        private System.Windows.Forms.Button buttonEquipment;
        private System.Windows.Forms.Button buttonChangeShifts;
        private System.Windows.Forms.GroupBox groupBoxShifts;
        private System.Windows.Forms.CheckBox checkBoxNight;
        private System.Windows.Forms.CheckBox checkBoxeEvening;
        private System.Windows.Forms.CheckBox checkBoxMorning;
        private System.Windows.Forms.NumericUpDown numericUpDownEquipMorning;
        private System.Windows.Forms.GroupBox groupBoxEquipments;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownEquipNight;
        private System.Windows.Forms.NumericUpDown numericUpDownEquipEvening;
    }
}