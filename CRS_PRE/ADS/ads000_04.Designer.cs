namespace CRS_PRE.ADS
{
    partial class ads000_04
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ads000_04));
            this.pb_ima_cpu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ima_cpu)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_ima_cpu
            // 
            this.pb_ima_cpu.Image = ((System.Drawing.Image)(resources.GetObject("pb_ima_cpu.Image")));
            this.pb_ima_cpu.Location = new System.Drawing.Point(12, 21);
            this.pb_ima_cpu.Name = "pb_ima_cpu";
            this.pb_ima_cpu.Size = new System.Drawing.Size(80, 70);
            this.pb_ima_cpu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_ima_cpu.TabIndex = 34;
            this.pb_ima_cpu.TabStop = false;
            // 
            // ads000_04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 196);
            this.ControlBox = false;
            this.Controls.Add(this.pb_ima_cpu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads000_04";
            this.Tag = "Clave Licencia";
            this.Text = "Clave Licencia";
            this.Load += new System.EventHandler(this.ads000_04_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_ima_cpu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_ima_cpu;
    }
}