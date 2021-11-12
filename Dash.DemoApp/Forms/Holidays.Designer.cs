namespace Dash.DemoApp.Forms
{
    partial class Holidays
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
            this.txtBoxYear = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.listBoxHolidays = new System.Windows.Forms.ListBox();
            this.txtBoxMonthFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxMonthTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxYear
            // 
            this.txtBoxYear.BackColor = System.Drawing.Color.White;
            this.txtBoxYear.Location = new System.Drawing.Point(205, 53);
            this.txtBoxYear.Name = "txtBoxYear";
            this.txtBoxYear.Size = new System.Drawing.Size(103, 31);
            this.txtBoxYear.TabIndex = 0;
            this.txtBoxYear.TextChanged += new System.EventHandler(this.TxtBoxYear_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Year:";
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.PaleGreen;
            this.btnGo.Location = new System.Drawing.Point(485, 45);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(219, 47);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "New";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.Location = new System.Drawing.Point(485, 158);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(219, 47);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // listBoxHolidays
            // 
            this.listBoxHolidays.FormattingEnabled = true;
            this.listBoxHolidays.ItemHeight = 25;
            this.listBoxHolidays.Location = new System.Drawing.Point(35, 135);
            this.listBoxHolidays.Name = "listBoxHolidays";
            this.listBoxHolidays.Size = new System.Drawing.Size(417, 529);
            this.listBoxHolidays.TabIndex = 5;
            // 
            // txtBoxMonthFrom
            // 
            this.txtBoxMonthFrom.BackColor = System.Drawing.Color.White;
            this.txtBoxMonthFrom.Location = new System.Drawing.Point(35, 53);
            this.txtBoxMonthFrom.Name = "txtBoxMonthFrom";
            this.txtBoxMonthFrom.Size = new System.Drawing.Size(65, 31);
            this.txtBoxMonthFrom.TabIndex = 6;
            this.txtBoxMonthFrom.Text = "1";
            this.txtBoxMonthFrom.TextChanged += new System.EventHandler(this.TxtBoxMonthFrom_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "From";
            // 
            // txtBoxMonthTo
            // 
            this.txtBoxMonthTo.BackColor = System.Drawing.Color.White;
            this.txtBoxMonthTo.Location = new System.Drawing.Point(106, 53);
            this.txtBoxMonthTo.Name = "txtBoxMonthTo";
            this.txtBoxMonthTo.Size = new System.Drawing.Size(65, 31);
            this.txtBoxMonthTo.TabIndex = 9;
            this.txtBoxMonthTo.Text = "12";
            this.txtBoxMonthTo.TextChanged += new System.EventHandler(this.TxtBoxMonthTo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "To";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAdd.Location = new System.Drawing.Point(485, 105);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(219, 47);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Holidays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(981, 676);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxMonthTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxMonthFrom);
            this.Controls.Add(this.listBoxHolidays);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxYear);
            this.Name = "Holidays";
            this.Text = "Holidays";
            this.Load += new System.EventHandler(this.Holidays_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox listBoxHolidays;
        private System.Windows.Forms.TextBox txtBoxMonthFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxMonthTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
    }
}