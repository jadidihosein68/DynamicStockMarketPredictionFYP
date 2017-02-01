namespace WindowsFormsApplication1
{
    partial class Analyse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Analyse));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.Notic = new System.Windows.Forms.Label();
            this.StartDateLable = new System.Windows.Forms.Label();
            this.EndDatelabel = new System.Windows.Forms.Label();
            this.Historicallabel = new System.Windows.Forms.Label();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.Tablelabel = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HistoTextBox = new System.Windows.Forms.TextBox();
            this.DataSetName = new System.Windows.Forms.TextBox();
            this.Createbutton = new System.Windows.Forms.Button();
            this.DropTable = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(585, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "No action were taken";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(830, 278);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Main Menu";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dateStart
            // 
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateStart.Location = new System.Drawing.Point(132, 108);
            this.dateStart.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(116, 20);
            this.dateStart.TabIndex = 4;
            this.dateStart.Value = new System.DateTime(2014, 1, 2, 0, 0, 0, 0);
            // 
            // Notic
            // 
            this.Notic.AutoSize = true;
            this.Notic.Location = new System.Drawing.Point(12, 23);
            this.Notic.Name = "Notic";
            this.Notic.Size = new System.Drawing.Size(258, 52);
            this.Notic.TabIndex = 5;
            this.Notic.Text = "Notic\r\nbefore creating new data set for analysis make sure : \r\n- 60 records befor" +
    "e the start date are exists \r\n- Start date and end date are exist ";
            // 
            // StartDateLable
            // 
            this.StartDateLable.AutoSize = true;
            this.StartDateLable.Location = new System.Drawing.Point(16, 108);
            this.StartDateLable.Name = "StartDateLable";
            this.StartDateLable.Size = new System.Drawing.Size(69, 13);
            this.StartDateLable.TabIndex = 6;
            this.StartDateLable.Text = "Starting Date";
            // 
            // EndDatelabel
            // 
            this.EndDatelabel.AutoSize = true;
            this.EndDatelabel.Location = new System.Drawing.Point(16, 135);
            this.EndDatelabel.Name = "EndDatelabel";
            this.EndDatelabel.Size = new System.Drawing.Size(66, 13);
            this.EndDatelabel.TabIndex = 7;
            this.EndDatelabel.Text = "Ending Date";
            // 
            // Historicallabel
            // 
            this.Historicallabel.AutoSize = true;
            this.Historicallabel.Location = new System.Drawing.Point(16, 166);
            this.Historicallabel.Name = "Historicallabel";
            this.Historicallabel.Size = new System.Drawing.Size(111, 13);
            this.Historicallabel.TabIndex = 8;
            this.Historicallabel.Text = "Historical Table Name";
            // 
            // dateEnd
            // 
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEnd.Location = new System.Drawing.Point(132, 134);
            this.dateEnd.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(116, 20);
            this.dateEnd.TabIndex = 9;
            this.dateEnd.Value = new System.DateTime(2014, 4, 11, 12, 43, 0, 0);
            // 
            // Tablelabel
            // 
            this.Tablelabel.AutoSize = true;
            this.Tablelabel.Location = new System.Drawing.Point(16, 189);
            this.Tablelabel.Name = "Tablelabel";
            this.Tablelabel.Size = new System.Drawing.Size(79, 13);
            this.Tablelabel.TabIndex = 10;
            this.Tablelabel.Text = "Data set name ";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(276, 23);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(259, 229);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Symbol";
            this.columnHeader1.Width = 79;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Table name";
            this.columnHeader2.Width = 96;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last update";
            this.columnHeader3.Width = 173;
            // 
            // HistoTextBox
            // 
            this.HistoTextBox.Location = new System.Drawing.Point(132, 163);
            this.HistoTextBox.Name = "HistoTextBox";
            this.HistoTextBox.Size = new System.Drawing.Size(116, 20);
            this.HistoTextBox.TabIndex = 12;
            this.HistoTextBox.Text = "SUPERMXHISTORICAL";
            // 
            // DataSetName
            // 
            this.DataSetName.Location = new System.Drawing.Point(132, 189);
            this.DataSetName.Name = "DataSetName";
            this.DataSetName.Size = new System.Drawing.Size(116, 20);
            this.DataSetName.TabIndex = 13;
            this.DataSetName.Text = "Please input name";
            // 
            // Createbutton
            // 
            this.Createbutton.Location = new System.Drawing.Point(7, 260);
            this.Createbutton.Name = "Createbutton";
            this.Createbutton.Size = new System.Drawing.Size(75, 23);
            this.Createbutton.TabIndex = 14;
            this.Createbutton.Text = "Create";
            this.Createbutton.UseVisualStyleBackColor = true;
            this.Createbutton.Click += new System.EventHandler(this.Createbutton_Click);
            // 
            // DropTable
            // 
            this.DropTable.Location = new System.Drawing.Point(685, 261);
            this.DropTable.Name = "DropTable";
            this.DropTable.Size = new System.Drawing.Size(75, 23);
            this.DropTable.TabIndex = 15;
            this.DropTable.Text = "Drop Table";
            this.DropTable.UseVisualStyleBackColor = true;
            this.DropTable.Click += new System.EventHandler(this.DropTable_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(584, 23);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(320, 229);
            this.listView2.TabIndex = 16;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Table name";
            this.columnHeader4.Width = 79;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Symbol";
            this.columnHeader5.Width = 96;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Starting date";
            this.columnHeader6.Width = 81;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Ending Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Historical data tables";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(581, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Analyzing data tables";
            // 
            // Analyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 310);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.DropTable);
            this.Controls.Add(this.Createbutton);
            this.Controls.Add(this.DataSetName);
            this.Controls.Add(this.HistoTextBox);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Tablelabel);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.Historicallabel);
            this.Controls.Add(this.EndDatelabel);
            this.Controls.Add(this.StartDateLable);
            this.Controls.Add(this.Notic);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Analyse";
            this.Text = "Sal V1.0 - Analysis";
            this.Load += new System.EventHandler(this.Analyse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Label Notic;
        private System.Windows.Forms.Label StartDateLable;
        private System.Windows.Forms.Label EndDatelabel;
        private System.Windows.Forms.Label Historicallabel;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Label Tablelabel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox HistoTextBox;
        private System.Windows.Forms.TextBox DataSetName;
        private System.Windows.Forms.Button Createbutton;
        private System.Windows.Forms.Button DropTable;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}