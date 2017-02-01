namespace WindowsFormsApplication1
{
    partial class TwitterManagement
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
            this.User = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ScreenNameradioButton = new System.Windows.Forms.RadioButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Screen_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Smallest_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Largest_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Last_Update = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NumberOfTweets = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Update = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // User
            // 
            this.User.Location = new System.Drawing.Point(12, 199);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(88, 24);
            this.User.TabIndex = 0;
            this.User.Text = "Extract Tweets";
            this.User.UseVisualStyleBackColor = true;
            this.User.Click += new System.EventHandler(this.User_Click);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Status.Location = new System.Drawing.Point(0, 248);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(227, 13);
            this.Status.TabIndex = 3;
            this.Status.Text = "Mouse hover over the buttons to see the detail";
            // 
            // Menu
            // 
            this.Menu.Location = new System.Drawing.Point(570, 198);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(75, 25);
            this.Menu.TabIndex = 4;
            this.Menu.Text = "Menu";
            this.Menu.UseVisualStyleBackColor = true;
            this.Menu.Click += new System.EventHandler(this.Menu_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // ScreenNameradioButton
            // 
            this.ScreenNameradioButton.AutoSize = true;
            this.ScreenNameradioButton.Checked = true;
            this.ScreenNameradioButton.Location = new System.Drawing.Point(12, 24);
            this.ScreenNameradioButton.Name = "ScreenNameradioButton";
            this.ScreenNameradioButton.Size = new System.Drawing.Size(90, 17);
            this.ScreenNameradioButton.TabIndex = 7;
            this.ScreenNameradioButton.TabStop = true;
            this.ScreenNameradioButton.Text = "Screen Name";
            this.ScreenNameradioButton.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Screen_Name,
            this.Smallest_ID,
            this.Largest_ID,
            this.Last_Update,
            this.NumberOfTweets});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(225, 24);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(420, 168);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Screen_Name
            // 
            this.Screen_Name.Text = "Screen Name";
            this.Screen_Name.Width = 79;
            // 
            // Smallest_ID
            // 
            this.Smallest_ID.Text = "Smallest ID";
            this.Smallest_ID.Width = 73;
            // 
            // Largest_ID
            // 
            this.Largest_ID.Text = "Largest ID";
            this.Largest_ID.Width = 70;
            // 
            // Last_Update
            // 
            this.Last_Update.Text = "Latest Date";
            this.Last_Update.Width = 84;
            // 
            // NumberOfTweets
            // 
            this.NumberOfTweets.Text = "Number Of Tweets";
            this.NumberOfTweets.Width = 108;
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(489, 198);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(75, 25);
            this.Update.TabIndex = 12;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 17;
            // 
            // TwitterManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 261);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ScreenNameradioButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.User);
            this.Name = "TwitterManagement";
            this.Text = "Twitter Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button User;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Button Menu;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton ScreenNameradioButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Screen_Name;
        private System.Windows.Forms.ColumnHeader Smallest_ID;
        private System.Windows.Forms.ColumnHeader Largest_ID;
        private System.Windows.Forms.ColumnHeader Last_Update;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.ColumnHeader NumberOfTweets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}