namespace DesktopApp
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
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button1 = new Button();
            textBox4 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.Location = new Point(43, 94);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(43, 134);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(43, 188);
            button1.Name = "button1";
            button1.Size = new Size(100, 40);
            button1.TabIndex = 3;
            button1.Text = "Calculate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(202, 205);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 4;
            textBox4.TextChanged += textBox4_TextChanged;
            textBox4.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(151, 209);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 5;
            label1.Text = "Result :";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(151, 96);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 6;
            label2.Text = "FirstNum";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(151, 137);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 7;
            label3.Text = "SecondNum";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveCaption;
            label4.Location = new Point(50, 41);
            label4.Name = "label4";
            label4.Padding = new Padding(5);
            label4.Size = new Size(184, 25);
            label4.TabIndex = 8;
            label4.Text = "Welcome to my calculator App!";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Red;
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(149, 111);
            label5.Name = "label5";
            label5.Size = new Size(87, 15);
            label5.TabIndex = 9;
            label5.Text = "WRONG INPUT";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Red;
            label6.ForeColor = Color.Snow;
            label6.Location = new Point(149, 152);
            label6.Name = "label6";
            label6.Size = new Size(87, 15);
            label6.TabIndex = 10;
            label6.Text = "WRONG INPUT";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 265);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button1;
        private TextBox textBox4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
