﻿namespace WindowsFormsApp4
{
    partial class MainAdmin
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
            this.masiniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pieseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugaMasinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugaPiesaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchPiesaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masiniToolStripMenuItem,
            this.pieseToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.adaugaMasinaToolStripMenuItem,
            this.adaugaPiesaToolStripMenuItem,
            this.searchPiesaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(760, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // masiniToolStripMenuItem
            // 
            this.masiniToolStripMenuItem.Name = "masiniToolStripMenuItem";
            this.masiniToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.masiniToolStripMenuItem.Text = "Masini";
            this.masiniToolStripMenuItem.Click += new System.EventHandler(this.masiniToolStripMenuItem_Click_1);
            // 
            // pieseToolStripMenuItem
            // 
            this.pieseToolStripMenuItem.Name = "pieseToolStripMenuItem";
            this.pieseToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.pieseToolStripMenuItem.Text = "Piese";
            this.pieseToolStripMenuItem.Click += new System.EventHandler(this.pieseToolStripMenuItem_Click_1);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // adaugaMasinaToolStripMenuItem
            // 
            this.adaugaMasinaToolStripMenuItem.Name = "adaugaMasinaToolStripMenuItem";
            this.adaugaMasinaToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.adaugaMasinaToolStripMenuItem.Text = "Adauga Masina";
            this.adaugaMasinaToolStripMenuItem.Click += new System.EventHandler(this.adaugaMasinaToolStripMenuItem_Click);
            // 
            // adaugaPiesaToolStripMenuItem
            // 
            this.adaugaPiesaToolStripMenuItem.Name = "adaugaPiesaToolStripMenuItem";
            this.adaugaPiesaToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.adaugaPiesaToolStripMenuItem.Text = "Adauga Piesa";
            this.adaugaPiesaToolStripMenuItem.Click += new System.EventHandler(this.adaugaPiesaToolStripMenuItem_Click);
            // 
            // searchPiesaToolStripMenuItem
            // 
            this.searchPiesaToolStripMenuItem.Name = "searchPiesaToolStripMenuItem";
            this.searchPiesaToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.searchPiesaToolStripMenuItem.Text = "SearchPiesa";
            this.searchPiesaToolStripMenuItem.Click += new System.EventHandler(this.searchPiesaToolStripMenuItem_Click);
            // 
            // MainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainAdmin";
            this.Text = "MainAdmin";
            this.Load += new System.EventHandler(this.MainAdmin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem masiniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pieseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugaMasinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugaPiesaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchPiesaToolStripMenuItem;
    }
}