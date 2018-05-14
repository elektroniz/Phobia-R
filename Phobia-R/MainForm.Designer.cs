namespace Phobia_R
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.inputBox = new System.Windows.Forms.TextBox();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.MovablePanel = new System.Windows.Forms.Panel();
            this.UnderBox = new System.Windows.Forms.PictureBox();
            this.CloseBox = new System.Windows.Forms.PictureBox();
            this.labelManualMode = new System.Windows.Forms.Label();
            this.urlBox = new System.Windows.Forms.TextBox();
            this.UnderWindowPanel = new System.Windows.Forms.Panel();
            this.PhobiarBox = new System.Windows.Forms.PictureBox();
            this.RightArrowBox = new System.Windows.Forms.PictureBox();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.MovablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnderBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhobiarBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightArrowBox)).BeginInit();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.inputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.inputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputBox.Font = new System.Drawing.Font("Anonymice Powerline", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.inputBox.Location = new System.Drawing.Point(41, 190);
            this.inputBox.Multiline = true;
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(454, 346);
            this.inputBox.TabIndex = 1;
            // 
            // outputBox
            // 
            this.outputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.outputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputBox.Font = new System.Drawing.Font("Anonymice Powerline", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(91)))), ((int)(((byte)(102)))));
            this.outputBox.Location = new System.Drawing.Point(658, 190);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(454, 346);
            this.outputBox.TabIndex = 2;
            // 
            // MovablePanel
            // 
            this.MovablePanel.Controls.Add(this.UnderBox);
            this.MovablePanel.Controls.Add(this.CloseBox);
            this.MovablePanel.Location = new System.Drawing.Point(-5, -4);
            this.MovablePanel.Name = "MovablePanel";
            this.MovablePanel.Size = new System.Drawing.Size(1158, 43);
            this.MovablePanel.TabIndex = 3;
            this.MovablePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MovablePanel_MouseDown);
            // 
            // UnderBox
            // 
            this.UnderBox.Image = global::Phobia_R.Properties.Resources.horizontal_line_remove_buttonwhite;
            this.UnderBox.Location = new System.Drawing.Point(1068, 16);
            this.UnderBox.Name = "UnderBox";
            this.UnderBox.Size = new System.Drawing.Size(33, 17);
            this.UnderBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UnderBox.TabIndex = 6;
            this.UnderBox.TabStop = false;
            this.UnderBox.Click += new System.EventHandler(this.UnderBox_Click);
            // 
            // CloseBox
            // 
            this.CloseBox.Image = global::Phobia_R.Properties.Resources.close_buttonwhite;
            this.CloseBox.Location = new System.Drawing.Point(1107, 16);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(33, 17);
            this.CloseBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseBox.TabIndex = 5;
            this.CloseBox.TabStop = false;
            this.CloseBox.Click += new System.EventHandler(this.CloseBox_Click);
            // 
            // labelManualMode
            // 
            this.labelManualMode.AutoSize = true;
            this.labelManualMode.Font = new System.Drawing.Font("Anonymice Powerline", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelManualMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(130)))), ((int)(((byte)(118)))));
            this.labelManualMode.Location = new System.Drawing.Point(35, 144);
            this.labelManualMode.Name = "labelManualMode";
            this.labelManualMode.Size = new System.Drawing.Size(203, 32);
            this.labelManualMode.TabIndex = 6;
            this.labelManualMode.Text = "Manual Mode";
            // 
            // urlBox
            // 
            this.urlBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.urlBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.urlBox.Font = new System.Drawing.Font("Anonymice Powerline", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.urlBox.Location = new System.Drawing.Point(41, 557);
            this.urlBox.Multiline = true;
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(454, 21);
            this.urlBox.TabIndex = 7;
            // 
            // UnderWindowPanel
            // 
            this.UnderWindowPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.UnderWindowPanel.ForeColor = System.Drawing.Color.Coral;
            this.UnderWindowPanel.Location = new System.Drawing.Point(-5, 634);
            this.UnderWindowPanel.Name = "UnderWindowPanel";
            this.UnderWindowPanel.Size = new System.Drawing.Size(1158, 35);
            this.UnderWindowPanel.TabIndex = 8;
            // 
            // PhobiarBox
            // 
            this.PhobiarBox.Image = global::Phobia_R.Properties.Resources.logo;
            this.PhobiarBox.Location = new System.Drawing.Point(38, 12);
            this.PhobiarBox.Name = "PhobiarBox";
            this.PhobiarBox.Size = new System.Drawing.Size(230, 43);
            this.PhobiarBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PhobiarBox.TabIndex = 5;
            this.PhobiarBox.TabStop = false;
            this.PhobiarBox.Click += new System.EventHandler(this.PhobiarBox_Click);
            // 
            // RightArrowBox
            // 
            this.RightArrowBox.Image = global::Phobia_R.Properties.Resources.keyboard_right_arrow_button;
            this.RightArrowBox.Location = new System.Drawing.Point(501, 329);
            this.RightArrowBox.Name = "RightArrowBox";
            this.RightArrowBox.Size = new System.Drawing.Size(151, 76);
            this.RightArrowBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RightArrowBox.TabIndex = 4;
            this.RightArrowBox.TabStop = false;
            this.RightArrowBox.Click += new System.EventHandler(this.RightArrowBox_Click);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnSaveFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSaveFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveFile.Font = new System.Drawing.Font("Anonymice Powerline", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(130)))), ((int)(((byte)(118)))));
            this.btnSaveFile.Location = new System.Drawing.Point(1037, 555);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFile.TabIndex = 9;
            this.btnSaveFile.Text = "Save";
            this.btnSaveFile.UseVisualStyleBackColor = false;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1147, 668);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.UnderWindowPanel);
            this.Controls.Add(this.urlBox);
            this.Controls.Add(this.labelManualMode);
            this.Controls.Add(this.PhobiarBox);
            this.Controls.Add(this.RightArrowBox);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.MovablePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MovablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UnderBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhobiarBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightArrowBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Panel MovablePanel;
        private System.Windows.Forms.PictureBox RightArrowBox;
        private System.Windows.Forms.PictureBox UnderBox;
        private System.Windows.Forms.PictureBox CloseBox;
        private System.Windows.Forms.PictureBox PhobiarBox;
        private System.Windows.Forms.Label labelManualMode;
        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.Panel UnderWindowPanel;
        private System.Windows.Forms.Button btnSaveFile;
    }
}

