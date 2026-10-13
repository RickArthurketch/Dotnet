namespace Web_Services
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lb2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tB2 = new System.Windows.Forms.TextBox();
            this.mail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lb = new System.Windows.Forms.Label();
            this.tb = new System.Windows.Forms.TextBox();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(37, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1230, 771);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lb2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tB2);
            this.tabPage1.Controls.Add(this.mail);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1222, 742);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Signature numérique YouSign";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.Location = new System.Drawing.Point(397, 31);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(0, 16);
            this.lb2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mail :";
            // 
            // tB2
            // 
            this.tB2.Location = new System.Drawing.Point(347, 146);
            this.tB2.Multiline = true;
            this.tB2.Name = "tB2";
            this.tB2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tB2.Size = new System.Drawing.Size(761, 590);
            this.tB2.TabIndex = 4;
            // 
            // mail
            // 
            this.mail.Location = new System.Drawing.Point(394, 65);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(461, 22);
            this.mail.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fichier :";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(32, 146);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(185, 46);
            this.button4.TabIndex = 1;
            this.button4.Text = "Demander Signature";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button_Signature_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(32, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 44);
            this.button3.TabIndex = 0;
            this.button3.Text = "Charger Fichier";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_Charger_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lb);
            this.tabPage2.Controls.Add(this.tb);
            this.tabPage2.Controls.Add(this.pBox);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1222, 742);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Analyse d\'images par IA";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Location = new System.Drawing.Point(235, 14);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(47, 16);
            this.lb.TabIndex = 4;
            this.lb.Text = "Fichier";
            // 
            // tb
            // 
            this.tb.Location = new System.Drawing.Point(238, 594);
            this.tb.Multiline = true;
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(879, 119);
            this.tb.TabIndex = 3;
            // 
            // pBox
            // 
            this.pBox.Location = new System.Drawing.Point(238, 33);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(879, 555);
            this.pBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox.TabIndex = 2;
            this.pBox.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 153);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 41);
            this.button2.TabIndex = 1;
            this.button2.Text = "Analyse Image IA";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btAnalyse_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Charger Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btCharger_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1323, 834);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.TextBox tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tB2;
        private System.Windows.Forms.TextBox mail;
        private System.Windows.Forms.Label lb2;
    }
}

