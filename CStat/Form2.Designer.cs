﻿namespace CStat
{
    /// <summary>
    /// CStat Calculator Help
    /// </summary>
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            pictureBox1 = new PictureBox();
            lbIntro = new Label();
            rtbHelp = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.cstat_70;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(13, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(815, 509);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lbIntro
            // 
            lbIntro.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbIntro.Location = new Point(12, 9);
            lbIntro.Name = "lbIntro";
            lbIntro.Size = new Size(815, 28);
            lbIntro.TabIndex = 1;
            lbIntro.Text = "The numbered items 1-7 in the image are explained below.";
            lbIntro.UseMnemonic = false;
            // 
            // rtbHelp
            // 
            rtbHelp.BorderStyle = BorderStyle.None;
            rtbHelp.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rtbHelp.Location = new Point(12, 552);
            rtbHelp.Name = "rtbHelp";
            rtbHelp.ScrollBars = RichTextBoxScrollBars.None;
            rtbHelp.Size = new Size(815, 182);
            rtbHelp.TabIndex = 2;
            rtbHelp.Text = resources.GetString("rtbHelp.Text");
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 751);
            Controls.Add(rtbHelp);
            Controls.Add(lbIntro);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form2";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "CStat Calculator Help";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lbIntro;
        private RichTextBox rtbHelp;
    }
}