namespace StudentRegistration
{
    partial class Form2
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
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            dep = new ComboBox();
            ll = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // reportViewer1
            // 
            reportViewer1.Anchor = AnchorStyles.None;
            reportViewer1.Location = new Point(228, 150);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(1000, 700);
            reportViewer1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(513, 106);
            button1.Name = "button1";
            button1.Size = new Size(107, 34);
            button1.TabIndex = 9;
            button1.Text = "Exit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(128, 255, 128);
            button2.Location = new Point(513, 38);
            button2.Name = "button2";
            button2.Size = new Size(107, 34);
            button2.TabIndex = 6;
            button2.Text = "Search";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.Highlight;
            button3.Location = new Point(513, 70);
            button3.Name = "button3";
            button3.Size = new Size(107, 34);
            button3.TabIndex = 7;
            button3.Text = "Clear";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // dep
            // 
            dep.DisplayMember = "select";
            dep.FormattingEnabled = true;
            dep.Items.AddRange(new object[] { "CSE", "BBA", "EEE" });
            dep.Location = new Point(364, 110);
            dep.Name = "dep";
            dep.Size = new Size(105, 28);
            dep.TabIndex = 10;
            dep.SelectedIndexChanged += dep_SelectedIndexChanged;
            dep.KeyPress += dep_KeyPress;
            // 
            // ll
            // 
            ll.AutoSize = true;
            ll.BackColor = Color.White;
            ll.ForeColor = SystemColors.ControlDarkDark;
            ll.Location = new Point(375, 113);
            ll.Name = "ll";
            ll.Size = new Size(49, 20);
            ll.TabIndex = 11;
            ll.Text = "Select";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "select" });
            comboBox1.Location = new Point(364, 42);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(105, 28);
            comboBox1.TabIndex = 12;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.KeyPress += comboBox1_KeyPress;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "select" });
            comboBox2.Location = new Point(364, 76);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(105, 28);
            comboBox2.TabIndex = 13;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            comboBox2.KeyPress += comboBox2_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(274, 50);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 14;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(269, 113);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 15;
            label2.Text = "Department";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(274, 79);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 16;
            label3.Text = "Course";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(375, 79);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 17;
            label4.Text = "Select";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(375, 45);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 18;
            label5.Text = "Select";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1372, 939);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(ll);
            Controls.Add(dep);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(reportViewer1);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Exit";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Button button1;
        private Button button2;
        private Button button3;
        private ComboBox dep;
        private Label ll;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}