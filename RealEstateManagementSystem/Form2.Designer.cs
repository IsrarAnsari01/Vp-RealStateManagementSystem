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
            System.Windows.Forms.Button button4;
            System.Windows.Forms.Button button5;
            label1 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
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
            label1.Location = new System.Drawing.Point(234, 43);
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
            button1.Location = new System.Drawing.Point(71, 136);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(113, 84);
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
            button2.Location = new System.Drawing.Point(292, 136);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(117, 84);
            button2.TabIndex = 2;
            button2.Text = "Clients";
            button2.UseVisualStyleBackColor = false;
            button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            button3.BackColor = System.Drawing.Color.Tomato;
            button3.Cursor = System.Windows.Forms.Cursors.Hand;
            button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            button3.Location = new System.Drawing.Point(502, 136);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(120, 84);
            button3.TabIndex = 3;
            button3.Text = "Property Types";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = System.Drawing.Color.DimGray;
            button4.Cursor = System.Windows.Forms.Cursors.Hand;
            button4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            button4.Location = new System.Drawing.Point(151, 272);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(133, 76);
            button4.TabIndex = 4;
            button4.Text = "Properties";
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = System.Drawing.Color.Chocolate;
            button5.Cursor = System.Windows.Forms.Cursors.Hand;
            button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            button5.Location = new System.Drawing.Point(418, 272);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(136, 76);
            button5.TabIndex = 5;
            button5.Text = "View Properties";
            button5.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(719, 450);
            this.Controls.Add(button5);
            this.Controls.Add(button4);
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
        private Button button4;
        private Button button5;
    }
}