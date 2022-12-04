
namespace GameRates
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
            this.gameNameLabel = new System.Windows.Forms.Label();
            this.questionPanel = new System.Windows.Forms.Panel();
            this.setButton = new System.Windows.Forms.Button();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.loadButton = new System.Windows.Forms.Button();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameNameLabel
            // 
            this.gameNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.gameNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gameNameLabel.Location = new System.Drawing.Point(0, 0);
            this.gameNameLabel.Margin = new System.Windows.Forms.Padding(10);
            this.gameNameLabel.Name = "gameNameLabel";
            this.gameNameLabel.Size = new System.Drawing.Size(784, 105);
            this.gameNameLabel.TabIndex = 0;
            this.gameNameLabel.Text = "label1";
            this.gameNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // questionPanel
            // 
            this.questionPanel.AutoSize = true;
            this.questionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.questionPanel.Location = new System.Drawing.Point(0, 105);
            this.questionPanel.Name = "questionPanel";
            this.questionPanel.Size = new System.Drawing.Size(784, 0);
            this.questionPanel.TabIndex = 1;
            // 
            // setButton
            // 
            this.setButton.AutoSize = true;
            this.setButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.setButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.setButton.Location = new System.Drawing.Point(392, 0);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(392, 49);
            this.setButton.TabIndex = 2;
            this.setButton.Text = "Set";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.loadButton);
            this.buttonPanel.Controls.Add(this.setButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 512);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(784, 49);
            this.buttonPanel.TabIndex = 3;
            // 
            // loadButton
            // 
            this.loadButton.AutoSize = true;
            this.loadButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadButton.Location = new System.Drawing.Point(0, 0);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(392, 49);
            this.loadButton.TabIndex = 3;
            this.loadButton.Text = "Load Result";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.questionPanel);
            this.Controls.Add(this.gameNameLabel);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Game rate";
            this.buttonPanel.ResumeLayout(false);
            this.buttonPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gameNameLabel;
        private System.Windows.Forms.Panel questionPanel;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button loadButton;
    }
}

