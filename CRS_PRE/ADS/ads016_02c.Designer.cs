namespace CRS_PRE
{
    partial class ads016_02c
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_nue_ges = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_nue_ges = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.lb_ult_ges = new System.Windows.Forms.Label();
            this.tb_ult_ges = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_ult_ges);
            this.groupBox1.Controls.Add(this.tb_ult_ges);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lb_nue_ges);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_nue_ges);
            this.groupBox1.Location = new System.Drawing.Point(3, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 148);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Prepara Siguiente Gestión";
            // 
            // lb_nue_ges
            // 
            this.lb_nue_ges.AutoSize = true;
            this.lb_nue_ges.Location = new System.Drawing.Point(34, 111);
            this.lb_nue_ges.Name = "lb_nue_ges";
            this.lb_nue_ges.Size = new System.Drawing.Size(90, 13);
            this.lb_nue_ges.TabIndex = 4;
            this.lb_nue_ges.Text = "Siguiente Gestión";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Esta opción nos permite preparar la siguiente\r\nGestión de la Empresa. Tomando en " +
    "cuenta\r\nla última Gestión creada.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_nue_ges
            // 
            this.tb_nue_ges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nue_ges.Location = new System.Drawing.Point(126, 109);
            this.tb_nue_ges.MaxLength = 4;
            this.tb_nue_ges.Multiline = true;
            this.tb_nue_ges.Name = "tb_nue_ges";
            this.tb_nue_ges.Size = new System.Drawing.Size(50, 18);
            this.tb_nue_ges.TabIndex = 5;
            this.tb_nue_ges.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nue_ges_KeyPress);
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 139);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(286, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(124, 9);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 25);
            this.bt_ace_pta.TabIndex = 0;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            this.bt_ace_pta.Click += new System.EventHandler(this.bt_ace_pta_Click);
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(202, 9);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // lb_ult_ges
            // 
            this.lb_ult_ges.AutoSize = true;
            this.lb_ult_ges.Location = new System.Drawing.Point(49, 87);
            this.lb_ult_ges.Name = "lb_ult_ges";
            this.lb_ult_ges.Size = new System.Drawing.Size(75, 13);
            this.lb_ult_ges.TabIndex = 2;
            this.lb_ult_ges.Text = "Última Gestión";
            // 
            // tb_ult_ges
            // 
            this.tb_ult_ges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ult_ges.Location = new System.Drawing.Point(126, 85);
            this.tb_ult_ges.MaxLength = 4;
            this.tb_ult_ges.Multiline = true;
            this.tb_ult_ges.Name = "tb_ult_ges";
            this.tb_ult_ges.ReadOnly = true;
            this.tb_ult_ges.Size = new System.Drawing.Size(50, 18);
            this.tb_ult_ges.TabIndex = 3;
            // 
            // ads016_02c
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 181);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads016_02c";
            this.Tag = "Crea Siguiente Gestión";
            this.Text = "Crea Siguiente Gestión";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_nue_ges;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_nue_ges;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Label lb_ult_ges;
        private System.Windows.Forms.TextBox tb_ult_ges;
    }
}