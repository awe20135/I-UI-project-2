
namespace StudentProgressFuzzyLogic.FuzzyLogic.Forms
{
    partial class MajorityTweakForm
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
            this.LvPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.abortButton = new System.Windows.Forms.Button();
            this.LvPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LvPanel
            // 
            this.LvPanel.Controls.Add(this.panel1);
            this.LvPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LvPanel.Location = new System.Drawing.Point(0, 0);
            this.LvPanel.Name = "LvPanel";
            this.LvPanel.Size = new System.Drawing.Size(478, 450);
            this.LvPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.abortButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 390);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 60);
            this.panel1.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.saveButton.Location = new System.Drawing.Point(0, 0);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(237, 60);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // abortButton
            // 
            this.abortButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.abortButton.Location = new System.Drawing.Point(243, 0);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(235, 60);
            this.abortButton.TabIndex = 1;
            this.abortButton.Text = "Abort";
            this.abortButton.UseVisualStyleBackColor = true;
            this.abortButton.Click += new System.EventHandler(this.abortButton_Click);
            // 
            // MajorityTweakForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 450);
            this.Controls.Add(this.LvPanel);
            this.Name = "MajorityTweakForm";
            this.Text = "MajorityTweakForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MajorityTweakForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MajorityTweakForm_FormClosed);
            this.LvPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LvPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button abortButton;
        private System.Windows.Forms.Button saveButton;
    }
}