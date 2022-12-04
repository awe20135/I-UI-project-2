
namespace StudentProgressFuzzyLogic.FuzzyLogic.Forms
{
    partial class TweakLVMajorityForm
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
            this.lvNameLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.majorityTextBox = new System.Windows.Forms.TextBox();
            this.termsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.setButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvNameLabel
            // 
            this.lvNameLabel.AutoSize = true;
            this.lvNameLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvNameLabel.Location = new System.Drawing.Point(0, 0);
            this.lvNameLabel.Name = "lvNameLabel";
            this.lvNameLabel.Size = new System.Drawing.Size(89, 24);
            this.lvNameLabel.TabIndex = 0;
            this.lvNameLabel.Text = "LV Name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lvNameLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 32);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.majorityTextBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(277, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 32);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Majority";
            // 
            // majorityTextBox
            // 
            this.majorityTextBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.majorityTextBox.Location = new System.Drawing.Point(75, 0);
            this.majorityTextBox.Name = "majorityTextBox";
            this.majorityTextBox.Size = new System.Drawing.Size(75, 29);
            this.majorityTextBox.TabIndex = 2;
            // 
            // termsRichTextBox
            // 
            this.termsRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.termsRichTextBox.Location = new System.Drawing.Point(0, 32);
            this.termsRichTextBox.Name = "termsRichTextBox";
            this.termsRichTextBox.Size = new System.Drawing.Size(427, 371);
            this.termsRichTextBox.TabIndex = 2;
            this.termsRichTextBox.Text = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cancelButton);
            this.panel3.Controls.Add(this.setButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 336);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(427, 67);
            this.panel3.TabIndex = 3;
            // 
            // setButton
            // 
            this.setButton.AutoSize = true;
            this.setButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.setButton.Location = new System.Drawing.Point(0, 0);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(212, 67);
            this.setButton.TabIndex = 0;
            this.setButton.Text = "Set";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.AutoSize = true;
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.cancelButton.Location = new System.Drawing.Point(218, 0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(209, 67);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // TweakLVMajorityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 403);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.termsRichTextBox);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "TweakLVMajorityForm";
            this.Text = "TweakLVMajorityForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lvNameLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox majorityTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox termsRichTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button setButton;
    }
}