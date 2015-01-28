namespace RPG_Adventure
{
    partial class SkillPanel
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.skillpoints = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.statBox = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 110);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Health";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(148, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 110);
            this.button2.TabIndex = 1;
            this.button2.Text = "Add Strength";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 151);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 98);
            this.button3.TabIndex = 2;
            this.button3.Text = "Add Resistance";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // skillpoints
            // 
            this.skillpoints.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skillpoints.Location = new System.Drawing.Point(12, 9);
            this.skillpoints.Name = "skillpoints";
            this.skillpoints.ReadOnly = true;
            this.skillpoints.Size = new System.Drawing.Size(266, 22);
            this.skillpoints.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(148, 151);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 98);
            this.button4.TabIndex = 4;
            this.button4.Text = "Add Archery";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // statBox
            // 
            this.statBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statBox.Location = new System.Drawing.Point(284, 9);
            this.statBox.Multiline = true;
            this.statBox.Name = "statBox";
            this.statBox.ReadOnly = true;
            this.statBox.Size = new System.Drawing.Size(257, 418);
            this.statBox.TabIndex = 5;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 255);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(130, 98);
            this.button5.TabIndex = 6;
            this.button5.Text = "Add Theivery";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // SkillPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 439);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.statBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.skillpoints);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "SkillPanel";
            this.Text = "Skills";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox skillpoints;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox statBox;
        private System.Windows.Forms.Button button5;
    }
}