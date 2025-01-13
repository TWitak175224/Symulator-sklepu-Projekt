namespace Symulator_sklepu
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
            button1 = new Button();
            button2 = new Button();
            nazwa1 = new Label();
            nazwa2 = new Label();
            nazwa3 = new Label();
            nazwa4 = new Label();
            nazwa5 = new Label();
            cena1 = new Label();
            cena2 = new Label();
            cena3 = new Label();
            cena4 = new Label();
            cena5 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(317, 95);
            button1.Name = "button1";
            button1.Size = new Size(65, 23);
            button1.TabIndex = 0;
            button1.Text = "A-Z";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(482, 95);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "1-10";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // nazwa1
            // 
            nazwa1.AutoSize = true;
            nazwa1.Location = new Point(155, 152);
            nazwa1.Name = "nazwa1";
            nazwa1.Size = new Size(0, 15);
            nazwa1.TabIndex = 2;
            // 
            // nazwa2
            // 
            nazwa2.AutoSize = true;
            nazwa2.Location = new Point(155, 167);
            nazwa2.Name = "nazwa2";
            nazwa2.Size = new Size(0, 15);
            nazwa2.TabIndex = 3;
            // 
            // nazwa3
            // 
            nazwa3.AutoSize = true;
            nazwa3.Location = new Point(155, 182);
            nazwa3.Name = "nazwa3";
            nazwa3.Size = new Size(0, 15);
            nazwa3.TabIndex = 4;
            // 
            // nazwa4
            // 
            nazwa4.AutoSize = true;
            nazwa4.Location = new Point(155, 197);
            nazwa4.Name = "nazwa4";
            nazwa4.Size = new Size(0, 15);
            nazwa4.TabIndex = 5;
            // 
            // nazwa5
            // 
            nazwa5.AutoSize = true;
            nazwa5.Location = new Point(155, 212);
            nazwa5.Name = "nazwa5";
            nazwa5.Size = new Size(38, 15);
            nazwa5.TabIndex = 6;
            nazwa5.Text = "cena1";
            // 
            // cena1
            // 
            cena1.AutoSize = true;
            cena1.Location = new Point(220, 152);
            cena1.Name = "cena1";
            cena1.Size = new Size(38, 15);
            cena1.TabIndex = 7;
            cena1.Text = "cena1";
            // 
            // cena2
            // 
            cena2.AutoSize = true;
            cena2.Location = new Point(220, 167);
            cena2.Name = "cena2";
            cena2.Size = new Size(38, 15);
            cena2.TabIndex = 8;
            cena2.Text = "cena2";
            // 
            // cena3
            // 
            cena3.AutoSize = true;
            cena3.Location = new Point(220, 182);
            cena3.Name = "cena3";
            cena3.Size = new Size(38, 15);
            cena3.TabIndex = 9;
            cena3.Text = "cena3";
            // 
            // cena4
            // 
            cena4.AutoSize = true;
            cena4.Location = new Point(220, 197);
            cena4.Name = "cena4";
            cena4.Size = new Size(38, 15);
            cena4.TabIndex = 10;
            cena4.Text = "cena4";
            // 
            // cena5
            // 
            cena5.AutoSize = true;
            cena5.Location = new Point(220, 212);
            cena5.Name = "cena5";
            cena5.Size = new Size(38, 15);
            cena5.TabIndex = 11;
            cena5.Text = "cena5";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cena5);
            Controls.Add(cena4);
            Controls.Add(cena3);
            Controls.Add(cena2);
            Controls.Add(cena1);
            Controls.Add(nazwa5);
            Controls.Add(nazwa4);
            Controls.Add(nazwa3);
            Controls.Add(nazwa2);
            Controls.Add(nazwa1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label nazwa1;
        private Label nazwa2;
        private Label nazwa3;
        private Label nazwa4;
        private Label nazwa5;
        private Label cena1;
        private Label cena2;
        private Label cena3;
        private Label cena4;
        private Label cena5;
    }
}
