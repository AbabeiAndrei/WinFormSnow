﻿namespace WinFormTest
{
    partial class MainForm
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
            if (disposing)
            {
                if(components != null)
                    components.Dispose();
                DisposeComponents();
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
            this.tmrGfx = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrGfx
            // 
            this.tmrGfx.Interval = 10;
            this.tmrGfx.Tick += new System.EventHandler(this.tmrGfx_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(837, 473);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Snow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrGfx;
    }
}

