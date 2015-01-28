namespace RPG_Adventure
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.statBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(638, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generate Area";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // messageBox
            // 
            this.messageBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBox.Location = new System.Drawing.Point(0, 220);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.ReadOnly = true;
            this.messageBox.Size = new System.Drawing.Size(634, 127);
            this.messageBox.TabIndex = 3;
            this.messageBox.Text = "Welcome to a RPG Adventure!";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(640, 303);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 44);
            this.button3.TabIndex = 4;
            this.button3.Text = "Clear Messages";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // statBox
            // 
            this.statBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statBox.Location = new System.Drawing.Point(638, 57);
            this.statBox.Multiline = true;
            this.statBox.Name = "statBox";
            this.statBox.ReadOnly = true;
            this.statBox.Size = new System.Drawing.Size(142, 140);
            this.statBox.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(640, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 44);
            this.button2.TabIndex = 6;
            this.button2.Text = "Skill Panel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(640, 253);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(144, 44);
            this.button4.TabIndex = 7;
            this.button4.Text = "Inventory";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(640, 353);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(144, 44);
            this.button5.TabIndex = 9;
            this.button5.Text = "Restart";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // outputBox
            // 
            this.outputBox.BackColor = System.Drawing.Color.Black;
            this.outputBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputBox.ForeColor = System.Drawing.Color.White;
            this.outputBox.Location = new System.Drawing.Point(-2, -1);
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(634, 215);
            this.outputBox.TabIndex = 10;
            this.outputBox.Text = "";
            this.outputBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.outputBox_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 401);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.statBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "RPG Adventure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox statBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RichTextBox outputBox;
    }
}

