namespace CRS_PRE
{
    partial class ads016_02b
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
            this.label2 = new System.Windows.Forms.Label();
            this.cb_ges_per = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_ges_tio = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cb_ges_per);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_ges_tio);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Primera Gestión";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gestion";
            // 
            // cb_ges_per
            // 
            this.cb_ges_per.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ges_per.FormattingEnabled = true;
            this.cb_ges_per.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cb_ges_per.Location = new System.Drawing.Point(135, 92);
            this.cb_ges_per.Name = "cb_ges_per";
            this.cb_ges_per.Size = new System.Drawing.Size(103, 21);
            this.cb_ges_per.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Esta opción nos permite crear la primera\r\nGestión de la Empresa. Tomando en cuent" +
    "a\r\nel Periodo Inicial según corresponda.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_ges_tio
            // 
            this.tb_ges_tio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ges_tio.Location = new System.Drawing.Point(80, 93);
            this.tb_ges_tio.MaxLength = 4;
            this.tb_ges_tio.Multiline = true;
            this.tb_ges_tio.Name = "tb_ges_tio";
            this.tb_ges_tio.Size = new System.Drawing.Size(50, 18);
            this.tb_ges_tio.TabIndex = 3;
            this.tb_ges_tio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ges_tio_KeyPress);
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 125);
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
            // ads016_02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 167);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads016_02";
            this.Tag = "Crea Gestión Inicial";
            this.Text = "Crea Gestión Inicial";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ges_tio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_ges_per;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Label label3;
    }
}