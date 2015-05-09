namespace DemoUserControl
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
            this.buttonFlat1 = new QuanLyHocSinh.ButtonFlat();
            this.SuspendLayout();
            // 
            // buttonFlat1
            // 
            this.buttonFlat1.AlphaGlow = 40;
            this.buttonFlat1.AlphaGlowValue = 0;
            this.buttonFlat1.BackColor = System.Drawing.Color.Transparent;
            this.buttonFlat1.DeltaAlphaGlow = 8;
            this.buttonFlat1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFlat1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonFlat1.Location = new System.Drawing.Point(12, 12);
            this.buttonFlat1.Name = "buttonFlat1";
            this.buttonFlat1.RealBackColor = System.Drawing.Color.DarkCyan;
            this.buttonFlat1.Size = new System.Drawing.Size(350, 350);
            this.buttonFlat1.TabIndex = 0;
            this.buttonFlat1.Text = "UIT";
            this.buttonFlat1.TextAlignment = QuanLyHocSinh.ButtonFlat.BTTextAlignment.Bot;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 397);
            this.Controls.Add(this.buttonFlat1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private QuanLyHocSinh.ButtonFlat buttonFlat1;









    }
}

