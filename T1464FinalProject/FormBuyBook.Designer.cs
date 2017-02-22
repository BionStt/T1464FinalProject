namespace T1464FinalProject {
    partial class FormBuyBook {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanelWrapper = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTime = new System.Windows.Forms.Label();
            this.groupBoxBookList = new System.Windows.Forms.GroupBox();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.tableLayoutPanelWrapper.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tableLayoutPanelWrapper
            // 
            this.tableLayoutPanelWrapper.ColumnCount = 1;
            this.tableLayoutPanelWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelWrapper.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanelWrapper.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanelWrapper.Controls.Add(this.groupBoxBookList, 0, 2);
            this.tableLayoutPanelWrapper.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanelWrapper.Name = "tableLayoutPanelWrapper";
            this.tableLayoutPanelWrapper.RowCount = 4;
            this.tableLayoutPanelWrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelWrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanelWrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelWrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelWrapper.Size = new System.Drawing.Size(860, 537);
            this.tableLayoutPanelWrapper.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(349, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(161, 37);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Buy Book";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.lblTime, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblEmployeeID, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 56);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(854, 20);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(686, 3);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(50, 13);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "Time: {0}";
            // 
            // groupBoxBookList
            // 
            this.groupBoxBookList.Location = new System.Drawing.Point(3, 82);
            this.groupBoxBookList.Name = "groupBoxBookList";
            this.groupBoxBookList.Size = new System.Drawing.Size(854, 262);
            this.groupBoxBookList.TabIndex = 4;
            this.groupBoxBookList.TabStop = false;
            this.groupBoxBookList.Text = "Book List";
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Location = new System.Drawing.Point(382, 3);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(87, 13);
            this.lblEmployeeID.TabIndex = 1;
            this.lblEmployeeID.Text = "Employee ID: {0}";
            // 
            // FormBuyBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanelWrapper);
            this.Name = "FormBuyBook";
            this.Text = "FormBuyBook";
            this.Load += new System.EventHandler(this.FormBuyBook_Load);
            this.tableLayoutPanelWrapper.ResumeLayout(false);
            this.tableLayoutPanelWrapper.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelWrapper;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxBookList;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblEmployeeID;
    }
}