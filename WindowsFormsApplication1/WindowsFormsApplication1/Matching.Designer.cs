namespace WindowsFormsApplication1
{
    partial class Matching
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Matching));
            this.Execute_button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Close_key = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ScreenName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tweets = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // Execute_button
            // 
            this.Execute_button.Location = new System.Drawing.Point(12, 343);
            this.Execute_button.Name = "Execute_button";
            this.Execute_button.Size = new System.Drawing.Size(75, 23);
            this.Execute_button.TabIndex = 1;
            this.Execute_button.Text = "Execute";
            this.Execute_button.UseVisualStyleBackColor = true;
            this.Execute_button.Click += new System.EventHandler(this.Execute_button_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 63);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(289, 250);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Query";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(409, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // Close_key
            // 
            this.Close_key.Location = new System.Drawing.Point(937, 334);
            this.Close_key.Name = "Close_key";
            this.Close_key.Size = new System.Drawing.Size(75, 23);
            this.Close_key.TabIndex = 5;
            this.Close_key.Text = "Close";
            this.Close_key.UseVisualStyleBackColor = true;
            this.Close_key.Click += new System.EventHandler(this.Close_key_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ScreenName,
            this.Tweets,
            this.Date});
            this.listView1.Location = new System.Drawing.Point(319, 63);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(813, 250);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ScreenName
            // 
            this.ScreenName.Text = "Screen Name";
            this.ScreenName.Width = 95;
            // 
            // Tweets
            // 
            this.Tweets.Text = "Tweets";
            this.Tweets.Width = 646;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            // 
            // Matching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 369);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Close_key);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Execute_button);
            this.Name = "Matching";
            this.Text = "Matching";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Execute_button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Close_key;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ScreenName;
        private System.Windows.Forms.ColumnHeader Tweets;
        private System.Windows.Forms.ColumnHeader Date;
    }
}