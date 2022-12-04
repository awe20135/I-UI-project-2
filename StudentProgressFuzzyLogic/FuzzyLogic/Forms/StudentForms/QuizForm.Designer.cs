
namespace StudentProgressFuzzyLogic.FuzzyLogic.Forms
{
    partial class QuizForm
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
            this.components = new System.ComponentModel.Container();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.questionTitleLabel = new System.Windows.Forms.Label();
            this.answerRadioButton1 = new System.Windows.Forms.RadioButton();
            this.answerRadioButton2 = new System.Windows.Forms.RadioButton();
            this.answerRadioButton3 = new System.Windows.Forms.RadioButton();
            this.answerRadioButton4 = new System.Windows.Forms.RadioButton();
            this.nextQuestionButton = new System.Windows.Forms.Button();
            this.endQuizButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeLabel.Location = new System.Drawing.Point(0, 0);
            this.timeLabel.MaximumSize = new System.Drawing.Size(0, 50);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(108, 24);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "Time: 00:00";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // questionTitleLabel
            // 
            this.questionTitleLabel.AutoSize = true;
            this.questionTitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.questionTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.questionTitleLabel.Location = new System.Drawing.Point(0, 24);
            this.questionTitleLabel.Margin = new System.Windows.Forms.Padding(3);
            this.questionTitleLabel.MaximumSize = new System.Drawing.Size(600, 150);
            this.questionTitleLabel.Name = "questionTitleLabel";
            this.questionTitleLabel.Size = new System.Drawing.Size(118, 24);
            this.questionTitleLabel.TabIndex = 1;
            this.questionTitleLabel.Text = "Question title";
            // 
            // answerRadioButton1
            // 
            this.answerRadioButton1.AutoSize = true;
            this.answerRadioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.answerRadioButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.answerRadioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.answerRadioButton1.Location = new System.Drawing.Point(0, 48);
            this.answerRadioButton1.MaximumSize = new System.Drawing.Size(600, 50);
            this.answerRadioButton1.Name = "answerRadioButton1";
            this.answerRadioButton1.Size = new System.Drawing.Size(600, 28);
            this.answerRadioButton1.TabIndex = 2;
            this.answerRadioButton1.Text = "Answer";
            this.answerRadioButton1.UseVisualStyleBackColor = true;
            // 
            // answerRadioButton2
            // 
            this.answerRadioButton2.AutoSize = true;
            this.answerRadioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.answerRadioButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.answerRadioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.answerRadioButton2.Location = new System.Drawing.Point(0, 76);
            this.answerRadioButton2.MaximumSize = new System.Drawing.Size(600, 50);
            this.answerRadioButton2.Name = "answerRadioButton2";
            this.answerRadioButton2.Size = new System.Drawing.Size(600, 28);
            this.answerRadioButton2.TabIndex = 3;
            this.answerRadioButton2.Text = "Answer";
            this.answerRadioButton2.UseVisualStyleBackColor = true;
            // 
            // answerRadioButton3
            // 
            this.answerRadioButton3.AutoSize = true;
            this.answerRadioButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.answerRadioButton3.Dock = System.Windows.Forms.DockStyle.Top;
            this.answerRadioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.answerRadioButton3.Location = new System.Drawing.Point(0, 104);
            this.answerRadioButton3.MaximumSize = new System.Drawing.Size(600, 50);
            this.answerRadioButton3.Name = "answerRadioButton3";
            this.answerRadioButton3.Size = new System.Drawing.Size(600, 28);
            this.answerRadioButton3.TabIndex = 4;
            this.answerRadioButton3.Text = "Answer";
            this.answerRadioButton3.UseVisualStyleBackColor = true;
            // 
            // answerRadioButton4
            // 
            this.answerRadioButton4.AutoSize = true;
            this.answerRadioButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.answerRadioButton4.Dock = System.Windows.Forms.DockStyle.Top;
            this.answerRadioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.answerRadioButton4.Location = new System.Drawing.Point(0, 132);
            this.answerRadioButton4.MaximumSize = new System.Drawing.Size(600, 50);
            this.answerRadioButton4.Name = "answerRadioButton4";
            this.answerRadioButton4.Size = new System.Drawing.Size(600, 28);
            this.answerRadioButton4.TabIndex = 5;
            this.answerRadioButton4.Text = "Answer";
            this.answerRadioButton4.UseVisualStyleBackColor = true;
            // 
            // nextQuestionButton
            // 
            this.nextQuestionButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nextQuestionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextQuestionButton.Location = new System.Drawing.Point(0, 361);
            this.nextQuestionButton.Name = "nextQuestionButton";
            this.nextQuestionButton.Size = new System.Drawing.Size(612, 100);
            this.nextQuestionButton.TabIndex = 6;
            this.nextQuestionButton.Text = "Next question";
            this.nextQuestionButton.UseVisualStyleBackColor = true;
            this.nextQuestionButton.Click += new System.EventHandler(this.nextQuestionButton_Click);
            // 
            // endQuizButton
            // 
            this.endQuizButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.endQuizButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.endQuizButton.Location = new System.Drawing.Point(0, 261);
            this.endQuizButton.Name = "endQuizButton";
            this.endQuizButton.Size = new System.Drawing.Size(612, 100);
            this.endQuizButton.TabIndex = 7;
            this.endQuizButton.Text = "End quiz";
            this.endQuizButton.UseVisualStyleBackColor = true;
            this.endQuizButton.Visible = false;
            this.endQuizButton.Click += new System.EventHandler(this.endQuizButton_Click);
            // 
            // QuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 461);
            this.ControlBox = false;
            this.Controls.Add(this.endQuizButton);
            this.Controls.Add(this.nextQuestionButton);
            this.Controls.Add(this.answerRadioButton4);
            this.Controls.Add(this.answerRadioButton3);
            this.Controls.Add(this.answerRadioButton2);
            this.Controls.Add(this.answerRadioButton1);
            this.Controls.Add(this.questionTitleLabel);
            this.Controls.Add(this.timeLabel);
            this.Name = "QuizForm";
            this.Text = "QuizForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label questionTitleLabel;
        private System.Windows.Forms.RadioButton answerRadioButton1;
        private System.Windows.Forms.RadioButton answerRadioButton2;
        private System.Windows.Forms.RadioButton answerRadioButton3;
        private System.Windows.Forms.RadioButton answerRadioButton4;
        private System.Windows.Forms.Button nextQuestionButton;
        private System.Windows.Forms.Button endQuizButton;
    }
}