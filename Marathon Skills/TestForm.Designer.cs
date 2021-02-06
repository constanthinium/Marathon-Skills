
namespace Marathon_Skills
{
    partial class TestForm
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
            this.placeholderTextBox1 = new Marathon_Skills.Controls.PlaceholderTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.roundedButton1 = new Marathon_Skills.Controls.RoundedButton();
            this.SuspendLayout();
            // 
            // placeholderTextBox1
            // 
            this.placeholderTextBox1.ForeColor = System.Drawing.Color.Gray;
            this.placeholderTextBox1.Location = new System.Drawing.Point(371, 73);
            this.placeholderTextBox1.Name = "placeholderTextBox1";
            this.placeholderTextBox1.Placeholder = "ну это пиздец реально";
            this.placeholderTextBox1.Size = new System.Drawing.Size(270, 20);
            this.placeholderTextBox1.TabIndex = 0;
            this.placeholderTextBox1.Text = "ну это пиздец реально";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(371, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // roundedButton1
            // 
            this.roundedButton1.Location = new System.Drawing.Point(130, 125);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(75, 23);
            this.roundedButton1.TabIndex = 2;
            this.roundedButton1.Text = "roundedButton1";
            this.roundedButton1.UseVisualStyleBackColor = true;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.placeholderTextBox1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.PlaceholderTextBox placeholderTextBox1;
        private System.Windows.Forms.Button button1;
        private Controls.RoundedButton roundedButton1;
    }
}