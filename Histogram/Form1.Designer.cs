namespace Histogram
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzObrazToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyjścieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obrazToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skalaSzarościToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalnyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korekcjaGammaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ObrazWejscie = new System.Windows.Forms.PictureBox();
            this.ObrazWyjscie = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lGamma = new System.Windows.Forms.Label();
            this.nUDGamma = new System.Windows.Forms.NumericUpDown();
            this.BGamma = new System.Windows.Forms.Button();
            this.zapisz = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ObrazWejscie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObrazWyjscie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDGamma)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.obrazToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(629, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzObrazToolStripMenuItem,
            this.wyjścieToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // otwórzObrazToolStripMenuItem
            // 
            this.otwórzObrazToolStripMenuItem.Name = "otwórzObrazToolStripMenuItem";
            this.otwórzObrazToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.otwórzObrazToolStripMenuItem.Text = "Otwórz obraz";
            this.otwórzObrazToolStripMenuItem.Click += new System.EventHandler(this.otwórzObrazToolStripMenuItem_Click);
            // 
            // wyjścieToolStripMenuItem
            // 
            this.wyjścieToolStripMenuItem.Name = "wyjścieToolStripMenuItem";
            this.wyjścieToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.wyjścieToolStripMenuItem.Text = "Wyjście";
            this.wyjścieToolStripMenuItem.Click += new System.EventHandler(this.wyjścieToolStripMenuItem_Click);
            // 
            // obrazToolStripMenuItem
            // 
            this.obrazToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skalaSzarościToolStripMenuItem,
            this.histogramToolStripMenuItem,
            this.korekcjaGammaToolStripMenuItem});
            this.obrazToolStripMenuItem.Enabled = false;
            this.obrazToolStripMenuItem.Name = "obrazToolStripMenuItem";
            this.obrazToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.obrazToolStripMenuItem.Text = "Obraz";
            // 
            // skalaSzarościToolStripMenuItem
            // 
            this.skalaSzarościToolStripMenuItem.Name = "skalaSzarościToolStripMenuItem";
            this.skalaSzarościToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.skalaSzarościToolStripMenuItem.Text = "Skala szarości";
            this.skalaSzarościToolStripMenuItem.Click += new System.EventHandler(this.skalaSzarościToolStripMenuItem_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.globalnyToolStripMenuItem,
            this.x16ToolStripMenuItem,
            this.x32ToolStripMenuItem});
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.histogramToolStripMenuItem.Text = "Histogram";
            // 
            // globalnyToolStripMenuItem
            // 
            this.globalnyToolStripMenuItem.Name = "globalnyToolStripMenuItem";
            this.globalnyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.globalnyToolStripMenuItem.Text = "Globalny";
            this.globalnyToolStripMenuItem.Click += new System.EventHandler(this.globalnyToolStripMenuItem_Click);
            // 
            // x16ToolStripMenuItem
            // 
            this.x16ToolStripMenuItem.Name = "x16ToolStripMenuItem";
            this.x16ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.x16ToolStripMenuItem.Text = "16x16";
            this.x16ToolStripMenuItem.Click += new System.EventHandler(this.x16ToolStripMenuItem_Click);
            // 
            // x32ToolStripMenuItem
            // 
            this.x32ToolStripMenuItem.Name = "x32ToolStripMenuItem";
            this.x32ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.x32ToolStripMenuItem.Text = "32x32";
            this.x32ToolStripMenuItem.Click += new System.EventHandler(this.x32ToolStripMenuItem_Click);
            // 
            // korekcjaGammaToolStripMenuItem
            // 
            this.korekcjaGammaToolStripMenuItem.Name = "korekcjaGammaToolStripMenuItem";
            this.korekcjaGammaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.korekcjaGammaToolStripMenuItem.Text = "Korekcja Gamma";
            this.korekcjaGammaToolStripMenuItem.Click += new System.EventHandler(this.korekcjaGammaToolStripMenuItem_Click);
            // 
            // ObrazWejscie
            // 
            this.ObrazWejscie.Location = new System.Drawing.Point(26, 57);
            this.ObrazWejscie.Name = "ObrazWejscie";
            this.ObrazWejscie.Size = new System.Drawing.Size(256, 256);
            this.ObrazWejscie.TabIndex = 1;
            this.ObrazWejscie.TabStop = false;
            // 
            // ObrazWyjscie
            // 
            this.ObrazWyjscie.Location = new System.Drawing.Point(342, 57);
            this.ObrazWyjscie.Name = "ObrazWyjscie";
            this.ObrazWyjscie.Size = new System.Drawing.Size(256, 256);
            this.ObrazWyjscie.TabIndex = 2;
            this.ObrazWyjscie.TabStop = false;
            // 
            // lGamma
            // 
            this.lGamma.AutoSize = true;
            this.lGamma.Location = new System.Drawing.Point(61, 336);
            this.lGamma.Name = "lGamma";
            this.lGamma.Size = new System.Drawing.Size(88, 13);
            this.lGamma.TabIndex = 3;
            this.lGamma.Text = "Korekcja Gamma";
            this.lGamma.Visible = false;
            // 
            // nUDGamma
            // 
            this.nUDGamma.DecimalPlaces = 1;
            this.nUDGamma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUDGamma.Location = new System.Drawing.Point(156, 336);
            this.nUDGamma.Maximum = new decimal(new int[] {
            19,
            0,
            0,
            65536});
            this.nUDGamma.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUDGamma.Name = "nUDGamma";
            this.nUDGamma.Size = new System.Drawing.Size(79, 20);
            this.nUDGamma.TabIndex = 4;
            this.nUDGamma.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDGamma.Visible = false;
            // 
            // BGamma
            // 
            this.BGamma.Location = new System.Drawing.Point(64, 362);
            this.BGamma.Name = "BGamma";
            this.BGamma.Size = new System.Drawing.Size(75, 23);
            this.BGamma.TabIndex = 5;
            this.BGamma.Text = "Koryguj";
            this.BGamma.UseVisualStyleBackColor = true;
            this.BGamma.Visible = false;
            this.BGamma.Click += new System.EventHandler(this.BGamma_Click);
            // 
            // zapisz
            // 
            this.zapisz.Location = new System.Drawing.Point(342, 336);
            this.zapisz.Name = "zapisz";
            this.zapisz.Size = new System.Drawing.Size(75, 23);
            this.zapisz.TabIndex = 6;
            this.zapisz.Text = "Zapisz obraz";
            this.zapisz.UseVisualStyleBackColor = true;
            this.zapisz.Visible = false;
            this.zapisz.Click += new System.EventHandler(this.zapisz_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 418);
            this.Controls.Add(this.zapisz);
            this.Controls.Add(this.BGamma);
            this.Controls.Add(this.nUDGamma);
            this.Controls.Add(this.lGamma);
            this.Controls.Add(this.ObrazWyjscie);
            this.Controls.Add(this.ObrazWejscie);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ObrazWejscie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObrazWyjscie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDGamma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otwórzObrazToolStripMenuItem;
        private System.Windows.Forms.PictureBox ObrazWejscie;
        private System.Windows.Forms.PictureBox ObrazWyjscie;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem obrazToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skalaSzarościToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyjścieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem globalnyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x16ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x32ToolStripMenuItem;
        private System.Windows.Forms.Label lGamma;
        private System.Windows.Forms.NumericUpDown nUDGamma;
        private System.Windows.Forms.Button BGamma;
        private System.Windows.Forms.ToolStripMenuItem korekcjaGammaToolStripMenuItem;
        private System.Windows.Forms.Button zapisz;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

    }
}

