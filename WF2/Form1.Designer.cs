namespace WF2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreateButton = new System.Windows.Forms.Button();
            this.lblCreateLabel = new System.Windows.Forms.Label();
            this.txtCreateTextBox = new System.Windows.Forms.TextBox();
            this.lblButtonCount = new System.Windows.Forms.Label();
            this.lblLabelCount = new System.Windows.Forms.Label();
            this.lblTextBoxCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCreateButton
            // 
            this.btnCreateButton.Location = new System.Drawing.Point(69, 53);
            this.btnCreateButton.Name = "btnCreateButton";
            this.btnCreateButton.Size = new System.Drawing.Size(75, 23);
            this.btnCreateButton.TabIndex = 0;
            this.btnCreateButton.Text = "button1";
            this.btnCreateButton.UseVisualStyleBackColor = true;
            // 
            // lblCreateLabel
            // 
            this.lblCreateLabel.AutoSize = true;
            this.lblCreateLabel.Location = new System.Drawing.Point(202, 58);
            this.lblCreateLabel.Name = "lblCreateLabel";
            this.lblCreateLabel.Size = new System.Drawing.Size(35, 13);
            this.lblCreateLabel.TabIndex = 1;
            this.lblCreateLabel.Text = "label1";
            // 
            // txtCreateTextBox
            // 
            this.txtCreateTextBox.Location = new System.Drawing.Point(359, 58);
            this.txtCreateTextBox.Name = "txtCreateTextBox";
            this.txtCreateTextBox.Size = new System.Drawing.Size(100, 20);
            this.txtCreateTextBox.TabIndex = 2;
            // 
            // lblButtonCount
            // 
            this.lblButtonCount.AutoSize = true;
            this.lblButtonCount.Location = new System.Drawing.Point(485, 118);
            this.lblButtonCount.Name = "lblButtonCount";
            this.lblButtonCount.Size = new System.Drawing.Size(35, 13);
            this.lblButtonCount.TabIndex = 3;
            this.lblButtonCount.Text = "label1";
            // 
            // lblLabelCount
            // 
            this.lblLabelCount.AutoSize = true;
            this.lblLabelCount.Location = new System.Drawing.Point(485, 153);
            this.lblLabelCount.Name = "lblLabelCount";
            this.lblLabelCount.Size = new System.Drawing.Size(35, 13);
            this.lblLabelCount.TabIndex = 4;
            this.lblLabelCount.Text = "label2";
            // 
            // lblTextBoxCount
            // 
            this.lblTextBoxCount.AutoSize = true;
            this.lblTextBoxCount.Location = new System.Drawing.Point(485, 191);
            this.lblTextBoxCount.Name = "lblTextBoxCount";
            this.lblTextBoxCount.Size = new System.Drawing.Size(35, 13);
            this.lblTextBoxCount.TabIndex = 5;
            this.lblTextBoxCount.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 450);
            this.Controls.Add(this.lblTextBoxCount);
            this.Controls.Add(this.lblLabelCount);
            this.Controls.Add(this.lblButtonCount);
            this.Controls.Add(this.txtCreateTextBox);
            this.Controls.Add(this.lblCreateLabel);
            this.Controls.Add(this.btnCreateButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateButton;
        private System.Windows.Forms.Label lblCreateLabel;
        private System.Windows.Forms.TextBox txtCreateTextBox;
        private System.Windows.Forms.Label lblButtonCount;
        private System.Windows.Forms.Label lblLabelCount;
        private System.Windows.Forms.Label lblTextBoxCount;
    }
}

