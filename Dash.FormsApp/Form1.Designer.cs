
namespace Dash.FormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.monthCalendarHolidays = new System.Windows.Forms.MonthCalendar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtBoxCwStart = new System.Windows.Forms.TextBox();
            this.txtBoxCwEnd = new System.Windows.Forms.TextBox();
            this.txtBoxYear = new System.Windows.Forms.TextBox();
            this.btnAddSaturday = new System.Windows.Forms.Button();
            this.btnAddHolidays = new System.Windows.Forms.Button();
            this.monthCalendarSaturdays = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(762, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(169, 71);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Saturdays";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(403, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Holidays";
            // 
            // monthCalendarHolidays
            // 
            this.monthCalendarHolidays.Location = new System.Drawing.Point(403, 141);
            this.monthCalendarHolidays.Name = "monthCalendarHolidays";
            this.monthCalendarHolidays.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(8, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(609, 24);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Please set the start and end:                     till                        (st" +
    "art)year";
            // 
            // txtBoxCwStart
            // 
            this.txtBoxCwStart.Location = new System.Drawing.Point(255, 17);
            this.txtBoxCwStart.Name = "txtBoxCwStart";
            this.txtBoxCwStart.Size = new System.Drawing.Size(60, 31);
            this.txtBoxCwStart.TabIndex = 6;
            // 
            // txtBoxCwEnd
            // 
            this.txtBoxCwEnd.Location = new System.Drawing.Point(374, 17);
            this.txtBoxCwEnd.Name = "txtBoxCwEnd";
            this.txtBoxCwEnd.Size = new System.Drawing.Size(60, 31);
            this.txtBoxCwEnd.TabIndex = 7;
            // 
            // txtBoxYear
            // 
            this.txtBoxYear.Location = new System.Drawing.Point(566, 17);
            this.txtBoxYear.Name = "txtBoxYear";
            this.txtBoxYear.Size = new System.Drawing.Size(91, 31);
            this.txtBoxYear.TabIndex = 8;
            // 
            // btnAddSaturday
            // 
            this.btnAddSaturday.Location = new System.Drawing.Point(18, 420);
            this.btnAddSaturday.Name = "btnAddSaturday";
            this.btnAddSaturday.Size = new System.Drawing.Size(312, 37);
            this.btnAddSaturday.TabIndex = 9;
            this.btnAddSaturday.Text = "Add";
            this.btnAddSaturday.UseVisualStyleBackColor = true;
            this.btnAddSaturday.Click += new System.EventHandler(this.BtnAddSaturday_Click);
            // 
            // btnAddHolidays
            // 
            this.btnAddHolidays.Location = new System.Drawing.Point(403, 420);
            this.btnAddHolidays.Name = "btnAddHolidays";
            this.btnAddHolidays.Size = new System.Drawing.Size(312, 37);
            this.btnAddHolidays.TabIndex = 10;
            this.btnAddHolidays.Text = "Add";
            this.btnAddHolidays.UseVisualStyleBackColor = true;
            this.btnAddHolidays.Click += new System.EventHandler(this.BtnAddHolidays_Click);
            // 
            // monthCalendarSaturdays
            // 
            this.monthCalendarSaturdays.Location = new System.Drawing.Point(18, 141);
            this.monthCalendarSaturdays.Name = "monthCalendarSaturdays";
            this.monthCalendarSaturdays.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1083, 630);
            this.Controls.Add(this.btnAddHolidays);
            this.Controls.Add(this.btnAddSaturday);
            this.Controls.Add(this.txtBoxYear);
            this.Controls.Add(this.txtBoxCwEnd);
            this.Controls.Add(this.txtBoxCwStart);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.monthCalendarHolidays);
            this.Controls.Add(this.monthCalendarSaturdays);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar monthCalendarHolidays;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtBoxCwStart;
        private System.Windows.Forms.TextBox txtBoxCwEnd;
        private System.Windows.Forms.TextBox txtBoxYear;
        private System.Windows.Forms.Button btnAddSaturday;
        private System.Windows.Forms.Button btnAddHolidays;
        private System.Windows.Forms.MonthCalendar monthCalendarSaturdays;
    }
}

