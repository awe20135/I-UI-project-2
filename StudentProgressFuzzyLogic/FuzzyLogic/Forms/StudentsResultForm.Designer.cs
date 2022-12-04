
namespace StudentProgressFuzzyLogic.FuzzyLogic.Forms
{
    partial class StudentsResultForm
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
            this.termPanel = new System.Windows.Forms.Panel();
            this.studentsResultDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.studentsResultDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // termPanel
            // 
            this.termPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.termPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.termPanel.Location = new System.Drawing.Point(547, 0);
            this.termPanel.Name = "termPanel";
            this.termPanel.Size = new System.Drawing.Size(253, 450);
            this.termPanel.TabIndex = 0;
            // 
            // studentsResultDataGridView
            // 
            this.studentsResultDataGridView.AllowUserToAddRows = false;
            this.studentsResultDataGridView.AllowUserToDeleteRows = false;
            this.studentsResultDataGridView.AllowUserToResizeColumns = false;
            this.studentsResultDataGridView.AllowUserToResizeRows = false;
            this.studentsResultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentsResultDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentsResultDataGridView.Location = new System.Drawing.Point(0, 0);
            this.studentsResultDataGridView.Name = "studentsResultDataGridView";
            this.studentsResultDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.studentsResultDataGridView.Size = new System.Drawing.Size(547, 450);
            this.studentsResultDataGridView.TabIndex = 1;
            // 
            // StudentsResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.studentsResultDataGridView);
            this.Controls.Add(this.termPanel);
            this.Name = "StudentsResultForm";
            this.Text = "StudentsResultForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentsResultForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.studentsResultDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel termPanel;
        private System.Windows.Forms.DataGridView studentsResultDataGridView;
    }
}