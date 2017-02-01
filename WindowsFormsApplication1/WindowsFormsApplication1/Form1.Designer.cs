namespace WindowsFormsApplication1
{
    partial class FYP
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FYP));
            this.listView1 = new System.Windows.Forms.ListView();
            this.Symbol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Table_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Exits = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.StockName = new System.Windows.Forms.TextBox();
            this.Update = new System.Windows.Forms.Button();
            this.StockNameTxtBox = new System.Windows.Forms.TextBox();
            this.StatusOfConnection = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ClockTimer = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ConnectionLable = new System.Windows.Forms.Label();
            this.DLHistoricalDataB = new System.Windows.Forms.Button();
            this.StockTableName = new System.Windows.Forms.TextBox();
            this.HistLabel = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.HistoricalSymbol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HistoricalTableName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HistoricalLastUpdateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.connectionStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historicalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ADD = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Symbol,
            this.Table_Name,
            this.Status,
            this.Date});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(16, 52);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(303, 172);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // Symbol
            // 
            this.Symbol.Text = "Symbol";
            this.Symbol.Width = 71;
            // 
            // Table_Name
            // 
            this.Table_Name.Text = "Table Name";
            this.Table_Name.Width = 106;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 45;
            // 
            // Date
            // 
            this.Date.Text = "Last Update";
            this.Date.Width = 77;
            // 
            // Exits
            // 
            this.Exits.Location = new System.Drawing.Point(645, 300);
            this.Exits.Name = "Exits";
            this.Exits.Size = new System.Drawing.Size(75, 23);
            this.Exits.TabIndex = 2;
            this.Exits.Text = "Close";
            this.Exits.UseVisualStyleBackColor = true;
            this.Exits.Click += new System.EventHandler(this.Exits_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Stock Information Table (Real Time)";
            // 
            // StockName
            // 
            this.StockName.Location = new System.Drawing.Point(110, 244);
            this.StockName.Name = "StockName";
            this.StockName.Size = new System.Drawing.Size(120, 20);
            this.StockName.TabIndex = 6;
            this.StockName.Text = "Stock name";
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(15, 227);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(89, 50);
            this.Update.TabIndex = 7;
            this.Update.Text = "Update Database Manually";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // StockNameTxtBox
            // 
            this.StockNameTxtBox.Location = new System.Drawing.Point(518, 242);
            this.StockNameTxtBox.Name = "StockNameTxtBox";
            this.StockNameTxtBox.Size = new System.Drawing.Size(91, 20);
            this.StockNameTxtBox.TabIndex = 9;
            this.StockNameTxtBox.Text = "Stock Symbol";
            // 
            // StatusOfConnection
            // 
            this.StatusOfConnection.AutoSize = true;
            this.StatusOfConnection.Location = new System.Drawing.Point(12, 296);
            this.StatusOfConnection.Name = "StatusOfConnection";
            this.StatusOfConnection.Size = new System.Drawing.Size(24, 13);
            this.StatusOfConnection.TabIndex = 10;
            this.StatusOfConnection.Text = "Idle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Next update in :";
            // 
            // ClockTimer
            // 
            this.ClockTimer.AutoSize = true;
            this.ClockTimer.Location = new System.Drawing.Point(110, 280);
            this.ClockTimer.Name = "ClockTimer";
            this.ClockTimer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ClockTimer.Size = new System.Drawing.Size(34, 13);
            this.ClockTimer.TabIndex = 12;
            this.ClockTimer.Text = "00:00";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ConnectionLable
            // 
            this.ConnectionLable.AutoSize = true;
            this.ConnectionLable.Location = new System.Drawing.Point(642, 326);
            this.ConnectionLable.Name = "ConnectionLable";
            this.ConnectionLable.Size = new System.Drawing.Size(61, 13);
            this.ConnectionLable.TabIndex = 13;
            this.ConnectionLable.Text = "Cennecting";
            // 
            // DLHistoricalDataB
            // 
            this.DLHistoricalDataB.Location = new System.Drawing.Point(436, 227);
            this.DLHistoricalDataB.Name = "DLHistoricalDataB";
            this.DLHistoricalDataB.Size = new System.Drawing.Size(76, 50);
            this.DLHistoricalDataB.TabIndex = 14;
            this.DLHistoricalDataB.Text = "Download Historical Data";
            this.DLHistoricalDataB.UseVisualStyleBackColor = true;
            this.DLHistoricalDataB.Click += new System.EventHandler(this.DLHistoricalDataB_Click);
            // 
            // StockTableName
            // 
            this.StockTableName.Location = new System.Drawing.Point(615, 242);
            this.StockTableName.Name = "StockTableName";
            this.StockTableName.Size = new System.Drawing.Size(105, 20);
            this.StockTableName.TabIndex = 15;
            this.StockTableName.Text = "Stock Table Name";
            // 
            // HistLabel
            // 
            this.HistLabel.AutoSize = true;
            this.HistLabel.Location = new System.Drawing.Point(433, 280);
            this.HistLabel.Name = "HistLabel";
            this.HistLabel.Size = new System.Drawing.Size(88, 13);
            this.HistLabel.TabIndex = 16;
            this.HistLabel.Text = "No Action Taken";
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HistoricalSymbol,
            this.HistoricalTableName,
            this.HistoricalLastUpdateDate});
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(436, 52);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(284, 172);
            this.listView2.TabIndex = 17;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // HistoricalSymbol
            // 
            this.HistoricalSymbol.Text = "Symbol";
            // 
            // HistoricalTableName
            // 
            this.HistoricalTableName.Text = "Table Name";
            this.HistoricalTableName.Width = 79;
            // 
            // HistoricalLastUpdateDate
            // 
            this.HistoricalLastUpdateDate.Text = "Last Update Date";
            this.HistoricalLastUpdateDate.Width = 140;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(436, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Historical Tables Informations\r\n";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton3,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(732, 25);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionStringToolStripMenuItem,
            this.addTableToolStripMenuItem});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(40, 22);
            this.toolStripDropDownButton3.Text = "Edit";
            // 
            // connectionStringToolStripMenuItem
            // 
            this.connectionStringToolStripMenuItem.Name = "connectionStringToolStripMenuItem";
            this.connectionStringToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.connectionStringToolStripMenuItem.Text = "Connection String";
            // 
            // addTableToolStripMenuItem
            // 
            this.addTableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historicalToolStripMenuItem,
            this.realTimeToolStripMenuItem});
            this.addTableToolStripMenuItem.Name = "addTableToolStripMenuItem";
            this.addTableToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.addTableToolStripMenuItem.Text = "Add Table";
            // 
            // historicalToolStripMenuItem
            // 
            this.historicalToolStripMenuItem.Name = "historicalToolStripMenuItem";
            this.historicalToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.historicalToolStripMenuItem.Text = "Historical Table";
            // 
            // realTimeToolStripMenuItem
            // 
            this.realTimeToolStripMenuItem.Name = "realTimeToolStripMenuItem";
            this.realTimeToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.realTimeToolStripMenuItem.Text = "Stock Information Real Time Table";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tutorialToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton2.Text = "Help";
            // 
            // tutorialToolStripMenuItem
            // 
            this.tutorialToolStripMenuItem.Name = "tutorialToolStripMenuItem";
            this.tutorialToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.tutorialToolStripMenuItem.Text = "Tutorial";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // ADD
            // 
            this.ADD.Location = new System.Drawing.Point(236, 242);
            this.ADD.Name = "ADD";
            this.ADD.Size = new System.Drawing.Size(75, 23);
            this.ADD.TabIndex = 5;
            this.ADD.Text = "ADD";
            this.ADD.UseVisualStyleBackColor = true;
            this.ADD.Click += new System.EventHandler(this.ADD_Click);
            // 
            // FYP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 348);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.HistLabel);
            this.Controls.Add(this.StockTableName);
            this.Controls.Add(this.DLHistoricalDataB);
            this.Controls.Add(this.ConnectionLable);
            this.Controls.Add(this.ClockTimer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StatusOfConnection);
            this.Controls.Add(this.StockNameTxtBox);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.StockName);
            this.Controls.Add(this.ADD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Exits);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FYP";
            this.Text = "Salamander V1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Symbol;
        private System.Windows.Forms.ColumnHeader Table_Name;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Button Exits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StockName;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.TextBox StockNameTxtBox;
        private System.Windows.Forms.Label StatusOfConnection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ClockTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label ConnectionLable;
        private System.Windows.Forms.Button DLHistoricalDataB;
        private System.Windows.Forms.TextBox StockTableName;
        private System.Windows.Forms.Label HistLabel;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader HistoricalSymbol;
        private System.Windows.Forms.ColumnHeader HistoricalTableName;
        private System.Windows.Forms.ColumnHeader HistoricalLastUpdateDate;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem connectionStringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tutorialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historicalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button ADD;
    }
}

