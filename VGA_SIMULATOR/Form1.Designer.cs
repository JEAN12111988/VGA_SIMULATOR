namespace VGA_SIMULATOR
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.picTELA = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pBarFrame = new System.Windows.Forms.ProgressBar();
			this.rdMultiF = new System.Windows.Forms.RadioButton();
			this.rdUnicoF = new System.Windows.Forms.RadioButton();
			this.btnCarregar = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.btnCarregaOUT = new System.Windows.Forms.Button();
			this.txtSIM = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCarregaPPM = new System.Windows.Forms.Button();
			this.txtPPM = new System.Windows.Forms.TextBox();
			this.txtLOG = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.btnLimparLOG = new System.Windows.Forms.Button();
			this.btnExportLOG = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.picTELA)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// picTELA
			// 
			this.picTELA.Location = new System.Drawing.Point(16, 43);
			this.picTELA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.picTELA.Name = "picTELA";
			this.picTELA.Size = new System.Drawing.Size(853, 591);
			this.picTELA.TabIndex = 0;
			this.picTELA.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.pBarFrame);
			this.groupBox1.Controls.Add(this.rdMultiF);
			this.groupBox1.Controls.Add(this.rdUnicoF);
			this.groupBox1.Controls.Add(this.btnCarregar);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.btnCarregaOUT);
			this.groupBox1.Controls.Add(this.txtSIM);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.btnCarregaPPM);
			this.groupBox1.Controls.Add(this.txtPPM);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(903, 43);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox1.Size = new System.Drawing.Size(451, 293);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "ARQUIVOS";
			// 
			// pBarFrame
			// 
			this.pBarFrame.Location = new System.Drawing.Point(8, 240);
			this.pBarFrame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pBarFrame.Name = "pBarFrame";
			this.pBarFrame.Size = new System.Drawing.Size(276, 28);
			this.pBarFrame.TabIndex = 9;
			// 
			// rdMultiF
			// 
			this.rdMultiF.AutoSize = true;
			this.rdMultiF.Location = new System.Drawing.Point(159, 41);
			this.rdMultiF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.rdMultiF.Name = "rdMultiF";
			this.rdMultiF.Size = new System.Drawing.Size(119, 24);
			this.rdMultiF.TabIndex = 8;
			this.rdMultiF.TabStop = true;
			this.rdMultiF.Text = "Multi Frame";
			this.rdMultiF.UseVisualStyleBackColor = true;
			// 
			// rdUnicoF
			// 
			this.rdUnicoF.AutoSize = true;
			this.rdUnicoF.Location = new System.Drawing.Point(8, 41);
			this.rdUnicoF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.rdUnicoF.Name = "rdUnicoF";
			this.rdUnicoF.Size = new System.Drawing.Size(126, 24);
			this.rdUnicoF.TabIndex = 7;
			this.rdUnicoF.TabStop = true;
			this.rdUnicoF.Text = "Unico Frame";
			this.rdUnicoF.UseVisualStyleBackColor = true;
			// 
			// btnCarregar
			// 
			this.btnCarregar.Location = new System.Drawing.Point(292, 226);
			this.btnCarregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnCarregar.Name = "btnCarregar";
			this.btnCarregar.Size = new System.Drawing.Size(151, 58);
			this.btnCarregar.TabIndex = 6;
			this.btnCarregar.Text = "CARREGAR";
			this.btnCarregar.UseVisualStyleBackColor = true;
			this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 150);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(132, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "Caminho do SIM";
			// 
			// btnCarregaOUT
			// 
			this.btnCarregaOUT.Location = new System.Drawing.Point(395, 175);
			this.btnCarregaOUT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnCarregaOUT.Name = "btnCarregaOUT";
			this.btnCarregaOUT.Size = new System.Drawing.Size(48, 28);
			this.btnCarregaOUT.TabIndex = 4;
			this.btnCarregaOUT.Text = "...";
			this.btnCarregaOUT.UseVisualStyleBackColor = true;
			this.btnCarregaOUT.Click += new System.EventHandler(this.btnCarregaOUT_Click);
			// 
			// txtSIM
			// 
			this.txtSIM.Location = new System.Drawing.Point(8, 175);
			this.txtSIM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtSIM.Name = "txtSIM";
			this.txtSIM.Size = new System.Drawing.Size(377, 26);
			this.txtSIM.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 82);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(146, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Caminho do frame";
			// 
			// btnCarregaPPM
			// 
			this.btnCarregaPPM.Location = new System.Drawing.Point(395, 107);
			this.btnCarregaPPM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnCarregaPPM.Name = "btnCarregaPPM";
			this.btnCarregaPPM.Size = new System.Drawing.Size(48, 28);
			this.btnCarregaPPM.TabIndex = 1;
			this.btnCarregaPPM.Text = "...";
			this.btnCarregaPPM.UseVisualStyleBackColor = true;
			this.btnCarregaPPM.Click += new System.EventHandler(this.btnCarregaPPM_Click);
			// 
			// txtPPM
			// 
			this.txtPPM.Location = new System.Drawing.Point(8, 107);
			this.txtPPM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtPPM.Name = "txtPPM";
			this.txtPPM.Size = new System.Drawing.Size(377, 26);
			this.txtPPM.TabIndex = 0;
			// 
			// txtLOG
			// 
			this.txtLOG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtLOG.Location = new System.Drawing.Point(903, 375);
			this.txtLOG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtLOG.Multiline = true;
			this.txtLOG.Name = "txtLOG";
			this.txtLOG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLOG.Size = new System.Drawing.Size(449, 219);
			this.txtLOG.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(907, 351);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 20);
			this.label3.TabIndex = 7;
			this.label3.Text = "LOG";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// btnLimparLOG
			// 
			this.btnLimparLOG.Location = new System.Drawing.Point(903, 603);
			this.btnLimparLOG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnLimparLOG.Name = "btnLimparLOG";
			this.btnLimparLOG.Size = new System.Drawing.Size(151, 34);
			this.btnLimparLOG.TabIndex = 10;
			this.btnLimparLOG.Text = "LIMPAR LOG";
			this.btnLimparLOG.UseVisualStyleBackColor = true;
			this.btnLimparLOG.Click += new System.EventHandler(this.btnLimparLOG_Click);
			// 
			// btnExportLOG
			// 
			this.btnExportLOG.Location = new System.Drawing.Point(1061, 604);
			this.btnExportLOG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnExportLOG.Name = "btnExportLOG";
			this.btnExportLOG.Size = new System.Drawing.Size(151, 34);
			this.btnExportLOG.TabIndex = 11;
			this.btnExportLOG.Text = "EXPORTAR LOG";
			this.btnExportLOG.UseVisualStyleBackColor = true;
			this.btnExportLOG.Click += new System.EventHandler(this.btnExportLOG_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1369, 654);
			this.Controls.Add(this.btnExportLOG);
			this.Controls.Add(this.btnLimparLOG);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtLOG);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.picTELA);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "Form1";
			this.Text = "VGA SIMULATOR";
			((System.ComponentModel.ISupportInitialize)(this.picTELA)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picTELA;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCarregaPPM;
		private System.Windows.Forms.TextBox txtPPM;
		private System.Windows.Forms.Button btnCarregar;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnCarregaOUT;
		private System.Windows.Forms.TextBox txtSIM;
		private System.Windows.Forms.TextBox txtLOG;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.RadioButton rdMultiF;
		private System.Windows.Forms.RadioButton rdUnicoF;
		private System.Windows.Forms.ProgressBar pBarFrame;
		private System.Windows.Forms.Button btnLimparLOG;
		private System.Windows.Forms.Button btnExportLOG;
	}
}

