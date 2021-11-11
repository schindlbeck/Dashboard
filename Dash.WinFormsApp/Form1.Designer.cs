
namespace Dash.WinFormsApp
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtBoxCwStart = new System.Windows.Forms.TextBox();
            this.txtBoxCwEnd = new System.Windows.Forms.TextBox();
            this.monthCalendarSaturdays = new System.Windows.Forms.MonthCalendar();
            this.monthCalendarHolidays = new System.Windows.Forms.MonthCalendar();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddSaturday = new System.Windows.Forms.Button();
            this.btnAddHolidays = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(37, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(332, 19);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Enter Calendarweeks:                     till\r\n";
            // 
            // txtBoxCwStart
            // 
            this.txtBoxCwStart.Location = new System.Drawing.Point(219, 28);
            this.txtBoxCwStart.Name = "txtBoxCwStart";
            this.txtBoxCwStart.Size = new System.Drawing.Size(39, 26);
            this.txtBoxCwStart.TabIndex = 1;
            // 
            // txtBoxCwEnd
            // 
            this.txtBoxCwEnd.Location = new System.Drawing.Point(307, 28);
            this.txtBoxCwEnd.Name = "txtBoxCwEnd";
            this.txtBoxCwEnd.Size = new System.Drawing.Size(39, 26);
            this.txtBoxCwEnd.TabIndex = 2;
            // 
            // monthCalendarSaturdays
            // 
            this.monthCalendarSaturdays.Location = new System.Drawing.Point(37, 134);
            this.monthCalendarSaturdays.MaxSelectionCount = 1;
            this.monthCalendarSaturdays.Name = "monthCalendarSaturdays";
            this.monthCalendarSaturdays.TabIndex = 3;
            // 
            // monthCalendarHolidays
            // 
            this.monthCalendarHolidays.Location = new System.Drawing.Point(397, 134);
            this.monthCalendarHolidays.MaxSelectionCount = 14;
            this.monthCalendarHolidays.Name = "monthCalendarHolidays";
            this.monthCalendarHolidays.TabIndex = 4;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(473, 28);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(236, 63);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Saturdays";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Holidays";
            // 
            // btnAddSaturday
            // 
            this.btnAddSaturday.Location = new System.Drawing.Point(37, 399);
            this.btnAddSaturday.Name = "btnAddSaturday";
            this.btnAddSaturday.Size = new System.Drawing.Size(312, 40);
            this.btnAddSaturday.TabIndex = 8;
            this.btnAddSaturday.Text = "Add";
            this.btnAddSaturday.UseVisualStyleBackColor = true;
            this.btnAddSaturday.Click += new System.EventHandler(this.BtnAddSaturday_Click);
            // 
            // btnAddHolidays
            // 
            this.btnAddHolidays.Location = new System.Drawing.Point(397, 399);
            this.btnAddHolidays.Name = "btnAddHolidays";
            this.btnAddHolidays.Size = new System.Drawing.Size(312, 40);
            this.btnAddHolidays.TabIndex = 9;
            this.btnAddHolidays.Text = "Add";
            this.btnAddHolidays.UseVisualStyleBackColor = true;
            this.btnAddHolidays.Click += new System.EventHandler(this.BtnAddHolidays_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 489);
            this.Controls.Add(this.btnAddHolidays);
            this.Controls.Add(this.btnAddSaturday);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.monthCalendarHolidays);
            this.Controls.Add(this.monthCalendarSaturdays);
            this.Controls.Add(this.txtBoxCwEnd);
            this.Controls.Add(this.txtBoxCwStart);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtBoxCwStart;
        private System.Windows.Forms.TextBox txtBoxCwEnd;
        private System.Windows.Forms.MonthCalendar monthCalendarSaturdays;
        private System.Windows.Forms.MonthCalendar monthCalendarHolidays;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddSaturday;
        private System.Windows.Forms.Button btnAddHolidays;
    }
}

