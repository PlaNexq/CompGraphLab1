namespace compGraphLab1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBarX = new System.Windows.Forms.TrackBar();
            this.trackBarY = new System.Windows.Forms.TrackBar();
            this.trackBarZ = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZ)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(338, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 298);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // trackBarX
            // 
            this.trackBarX.Location = new System.Drawing.Point(34, 41);
            this.trackBarX.Maximum = 180;
            this.trackBarX.Minimum = -180;
            this.trackBarX.Name = "trackBarX";
            this.trackBarX.Size = new System.Drawing.Size(104, 45);
            this.trackBarX.TabIndex = 1;
            this.trackBarX.ValueChanged += new System.EventHandler(this.trackBarX_ValueChanged);
            // 
            // trackBarY
            // 
            this.trackBarY.Location = new System.Drawing.Point(34, 92);
            this.trackBarY.Maximum = 180;
            this.trackBarY.Minimum = -180;
            this.trackBarY.Name = "trackBarY";
            this.trackBarY.Size = new System.Drawing.Size(104, 45);
            this.trackBarY.TabIndex = 2;
            this.trackBarY.ValueChanged += new System.EventHandler(this.trackBarY_ValueChanged);
            // 
            // trackBarZ
            // 
            this.trackBarZ.Location = new System.Drawing.Point(34, 158);
            this.trackBarZ.Maximum = 180;
            this.trackBarZ.Minimum = -180;
            this.trackBarZ.Name = "trackBarZ";
            this.trackBarZ.Size = new System.Drawing.Size(104, 45);
            this.trackBarZ.TabIndex = 3;
            this.trackBarZ.ValueChanged += new System.EventHandler(this.trackBarZ_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.trackBarZ);
            this.Controls.Add(this.trackBarY);
            this.Controls.Add(this.trackBarX);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBarX;
        private System.Windows.Forms.TrackBar trackBarY;
        private System.Windows.Forms.TrackBar trackBarZ;
    }
}

