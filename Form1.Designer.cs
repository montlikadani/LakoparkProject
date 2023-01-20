namespace Lakopark {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            panelPictureBox = new System.Windows.Forms.Panel();
            iconBox = new System.Windows.Forms.PictureBox();
            leftButton = new System.Windows.Forms.Button();
            rightButton = new System.Windows.Forms.Button();
            SaveButton = new System.Windows.Forms.Button();
            ButtonStatistics = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) iconBox).BeginInit();
            SuspendLayout();
            // 
            // panelPictureBox
            // 
            panelPictureBox.AutoSize = true;
            panelPictureBox.BackColor = System.Drawing.SystemColors.Window;
            panelPictureBox.Location = new System.Drawing.Point(173, 46);
            panelPictureBox.Name = "panelPictureBox";
            panelPictureBox.Size = new System.Drawing.Size(251, 132);
            panelPictureBox.TabIndex = 0;
            // 
            // iconBox
            // 
            iconBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            iconBox.Location = new System.Drawing.Point(26, 46);
            iconBox.Name = "iconBox";
            iconBox.Size = new System.Drawing.Size(92, 132);
            iconBox.TabIndex = 1;
            iconBox.TabStop = false;
            // 
            // leftButton
            // 
            leftButton.BackgroundImage = Properties.Resources.balnyil;
            leftButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            leftButton.Location = new System.Drawing.Point(381, 457);
            leftButton.Name = "leftButton";
            leftButton.Size = new System.Drawing.Size(87, 48);
            leftButton.TabIndex = 2;
            leftButton.UseVisualStyleBackColor = true;
            leftButton.Click += leftButton_Click;
            // 
            // rightButton
            // 
            rightButton.BackgroundImage = Properties.Resources.jobbnyil;
            rightButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            rightButton.Location = new System.Drawing.Point(495, 457);
            rightButton.Name = "rightButton";
            rightButton.Size = new System.Drawing.Size(87, 48);
            rightButton.TabIndex = 3;
            rightButton.UseVisualStyleBackColor = true;
            rightButton.Click += rightButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new System.Drawing.Point(264, 463);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new System.Drawing.Size(87, 37);
            SaveButton.TabIndex = 4;
            SaveButton.Text = "Mentés";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // ButtonStatistics
            // 
            ButtonStatistics.Location = new System.Drawing.Point(605, 463);
            ButtonStatistics.Name = "ButtonStatistics";
            ButtonStatistics.Size = new System.Drawing.Size(87, 37);
            ButtonStatistics.TabIndex = 5;
            ButtonStatistics.Text = "Statisztikák";
            ButtonStatistics.UseVisualStyleBackColor = true;
            ButtonStatistics.Click += ButtonStatistics_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(933, 519);
            Controls.Add(ButtonStatistics);
            Controls.Add(SaveButton);
            Controls.Add(rightButton);
            Controls.Add(leftButton);
            Controls.Add(iconBox);
            Controls.Add(panelPictureBox);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,  0);
            Name = "Form1";
            Text = "lakópark";
            ((System.ComponentModel.ISupportInitialize) iconBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelPictureBox;
        private System.Windows.Forms.PictureBox iconBox;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ButtonStatistics;
    }
}

