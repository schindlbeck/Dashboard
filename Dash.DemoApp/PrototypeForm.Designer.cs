
namespace Erp.Prototype
{
    partial class PrototypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrototypeForm));
            this.panelLeft = new System.Windows.Forms.Panel();
            this.buttonPopup = new System.Windows.Forms.Button();
            this.buttonToast = new System.Windows.Forms.Button();
            this.BtnDataOverview = new System.Windows.Forms.Button();
            this.BtnExcelToJson = new System.Windows.Forms.Button();
            this.BtnHolidays = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelDesk = new System.Windows.Forms.Panel();
            this.pictureBoxDesk = new System.Windows.Forms.PictureBox();
            this.panelLeft.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelDesk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDesk)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.AllowDrop = true;
            this.panelLeft.Controls.Add(this.buttonPopup);
            this.panelLeft.Controls.Add(this.buttonToast);
            this.panelLeft.Controls.Add(this.BtnDataOverview);
            this.panelLeft.Controls.Add(this.BtnExcelToJson);
            this.panelLeft.Controls.Add(this.BtnHolidays);
            this.panelLeft.Controls.Add(this.buttonHome);
            this.panelLeft.Controls.Add(this.panelLogo);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(443, 1050);
            this.panelLeft.TabIndex = 1;
            this.panelLeft.DragDrop += new System.Windows.Forms.DragEventHandler(this.PanelLeft_DragDrop);
            this.panelLeft.DragEnter += new System.Windows.Forms.DragEventHandler(this.PanelLeft_DragEnter);
            // 
            // buttonPopup
            // 
            this.buttonPopup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPopup.FlatAppearance.BorderSize = 0;
            this.buttonPopup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.buttonPopup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPopup.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonPopup.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonPopup.Location = new System.Drawing.Point(0, 856);
            this.buttonPopup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPopup.Name = "buttonPopup";
            this.buttonPopup.Padding = new System.Windows.Forms.Padding(29, 0, 0, 0);
            this.buttonPopup.Size = new System.Drawing.Size(443, 97);
            this.buttonPopup.TabIndex = 8;
            this.buttonPopup.Text = "Popup";
            this.buttonPopup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPopup.UseVisualStyleBackColor = true;
            // 
            // buttonToast
            // 
            this.buttonToast.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonToast.FlatAppearance.BorderSize = 0;
            this.buttonToast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.buttonToast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToast.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonToast.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonToast.Location = new System.Drawing.Point(0, 953);
            this.buttonToast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonToast.Name = "buttonToast";
            this.buttonToast.Padding = new System.Windows.Forms.Padding(29, 0, 0, 0);
            this.buttonToast.Size = new System.Drawing.Size(443, 97);
            this.buttonToast.TabIndex = 7;
            this.buttonToast.Text = "Toast";
            this.buttonToast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonToast.UseVisualStyleBackColor = true;
            // 
            // BtnDataOverview
            // 
            this.BtnDataOverview.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnDataOverview.FlatAppearance.BorderSize = 0;
            this.BtnDataOverview.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.BtnDataOverview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDataOverview.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnDataOverview.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnDataOverview.Location = new System.Drawing.Point(0, 474);
            this.BtnDataOverview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnDataOverview.Name = "BtnDataOverview";
            this.BtnDataOverview.Padding = new System.Windows.Forms.Padding(29, 0, 0, 0);
            this.BtnDataOverview.Size = new System.Drawing.Size(443, 97);
            this.BtnDataOverview.TabIndex = 6;
            this.BtnDataOverview.Text = "Data Overview";
            this.BtnDataOverview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDataOverview.UseVisualStyleBackColor = true;
            this.BtnDataOverview.Click += new System.EventHandler(this.BtnDataOverview_Click);
            // 
            // BtnExcelToJson
            // 
            this.BtnExcelToJson.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnExcelToJson.FlatAppearance.BorderSize = 0;
            this.BtnExcelToJson.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.BtnExcelToJson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExcelToJson.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnExcelToJson.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnExcelToJson.Location = new System.Drawing.Point(0, 377);
            this.BtnExcelToJson.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnExcelToJson.Name = "BtnExcelToJson";
            this.BtnExcelToJson.Padding = new System.Windows.Forms.Padding(29, 0, 0, 0);
            this.BtnExcelToJson.Size = new System.Drawing.Size(443, 97);
            this.BtnExcelToJson.TabIndex = 5;
            this.BtnExcelToJson.Text = "Compare Excel to Json";
            this.BtnExcelToJson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExcelToJson.UseVisualStyleBackColor = true;
            this.BtnExcelToJson.Click += new System.EventHandler(this.BtnExcelToJson_Click);
            // 
            // BtnHolidays
            // 
            this.BtnHolidays.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnHolidays.FlatAppearance.BorderSize = 0;
            this.BtnHolidays.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.BtnHolidays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnHolidays.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnHolidays.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnHolidays.Location = new System.Drawing.Point(0, 280);
            this.BtnHolidays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnHolidays.Name = "BtnHolidays";
            this.BtnHolidays.Padding = new System.Windows.Forms.Padding(29, 0, 0, 0);
            this.BtnHolidays.Size = new System.Drawing.Size(443, 97);
            this.BtnHolidays.TabIndex = 4;
            this.BtnHolidays.Text = "Holidays";
            this.BtnHolidays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHolidays.UseVisualStyleBackColor = true;
            this.BtnHolidays.Click += new System.EventHandler(this.BtnHolidays_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonHome.FlatAppearance.BorderSize = 0;
            this.buttonHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonHome.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonHome.Location = new System.Drawing.Point(0, 180);
            this.buttonHome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Padding = new System.Windows.Forms.Padding(29, 0, 0, 0);
            this.buttonHome.Size = new System.Drawing.Size(443, 100);
            this.buttonHome.TabIndex = 1;
            this.buttonHome.Text = "Home";
            this.buttonHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBoxLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(443, 180);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(443, 180);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(443, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1481, 180);
            this.panelTop.TabIndex = 2;
            // 
            // panelDesk
            // 
            this.panelDesk.Controls.Add(this.pictureBoxDesk);
            this.panelDesk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesk.Location = new System.Drawing.Point(443, 180);
            this.panelDesk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelDesk.Name = "panelDesk";
            this.panelDesk.Size = new System.Drawing.Size(1481, 870);
            this.panelDesk.TabIndex = 3;
            // 
            // pictureBoxDesk
            // 
            this.pictureBoxDesk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxDesk.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDesk.Image")));
            this.pictureBoxDesk.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxDesk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxDesk.Name = "pictureBoxDesk";
            this.pictureBoxDesk.Size = new System.Drawing.Size(1481, 870);
            this.pictureBoxDesk.TabIndex = 0;
            this.pictureBoxDesk.TabStop = false;
            // 
            // PrototypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.panelDesk);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PrototypeForm";
            this.Text = "PrototypeMainForm";
            this.panelLeft.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelDesk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDesk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button buttonPopup;
        private System.Windows.Forms.Button buttonToast;
        private System.Windows.Forms.Button BtnDataOverview;
        private System.Windows.Forms.Button BtnExcelToJson;
        private System.Windows.Forms.Button BtnHolidays;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelDesk;
        private System.Windows.Forms.PictureBox pictureBoxDesk;
    }
}

