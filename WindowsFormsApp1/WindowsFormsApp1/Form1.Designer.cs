namespace WindowsFormsApp1
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
            this.Tbnum1 = new System.Windows.Forms.TextBox();
            this.BtSum = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Tbnum1
            // 
            this.Tbnum1.Location = new System.Drawing.Point(52, 23);
            this.Tbnum1.Name = "Tbnum1";
            this.Tbnum1.Size = new System.Drawing.Size(170, 20);
            this.Tbnum1.TabIndex = 0;
            this.Tbnum1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tbnum1_KeyPress);
            // 
            // BtSum
            // 
            this.BtSum.Location = new System.Drawing.Point(52, 49);
            this.BtSum.Name = "BtSum";
            this.BtSum.Size = new System.Drawing.Size(170, 24);
            this.BtSum.TabIndex = 3;
            this.BtSum.Text = "=";
            this.BtSum.UseVisualStyleBackColor = true;
            this.BtSum.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 100);
            this.Controls.Add(this.BtSum);
            this.Controls.Add(this.Tbnum1);
            this.Name = "Form1";
            this.Text = "Calculater";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Tbnum1;
        private System.Windows.Forms.Button BtSum;
    }
}

