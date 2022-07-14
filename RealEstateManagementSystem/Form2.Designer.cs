namespace RealEstateManagementSystem
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Button button1;
            System.Windows.Forms.Button button2;
            System.Windows.Forms.Button button3;
            System.Windows.Forms.Button button5;
            label1 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label1.Cursor = System.Windows.Forms.Cursors.Hand;
            label1.Font = new System.Drawing.Font("Segoe UI", 22.2F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(106, 37);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(247, 52);
            label1.TabIndex = 0;
            label1.Text = "Select Action";
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.SteelBlue;
            button1.Cursor = System.Windows.Forms.Cursors.Hand;
            button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            button1.Location = new System.Drawing.Point(25, 136);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(132, 84);
            button1.TabIndex = 1;
            button1.Text = "Owners";
            button1.UseVisualStyleBackColor = false;
            button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.DodgerBlue;
            button2.Cursor = System.Windows.Forms.Cursors.Hand;
            button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            button2.Location = new System.Drawing.Point(305, 136);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(136, 84);
            button2.TabIndex = 2;
            button2.Text = "Clients";
            button2.UseVisualStyleBackColor = false;
            button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            button3.BackColor = System.Drawing.Color.DarkSlateGray;
            button3.Cursor = System.Windows.Forms.Cursors.Hand;
            button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            button3.Location = new System.Drawing.Point(25, 283);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(132, 84);
            button3.TabIndex = 3;
            button3.Text = "Properties";
            button3.UseVisualStyleBackColor = false;
            button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            button5.BackColor = System.Drawing.Color.Chocolate;
            button5.Cursor = System.Windows.Forms.Cursors.Hand;
            button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            button5.Location = new System.Drawing.Point(305, 283);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(136, 84);
            button5.TabIndex = 5;
            button5.Text = "View Properties";
            button5.UseVisualStyleBackColor = false;
            button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(532, 393);
            this.Controls.Add(button5);
            this.Controls.Add(button3);
            this.Controls.Add(button2);
            this.Controls.Add(button1);
            this.Controls.Add(label1);
            this.Name = "Form2";
            this.Text = "Action Box";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button5;
    }
}