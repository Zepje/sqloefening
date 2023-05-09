namespace sqloefening
{
    partial class WorkshopToevoegen
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
            this.docentComboBox = new System.Windows.Forms.ComboBox();
            this.lokaalComboBox = new System.Windows.Forms.ComboBox();
            this.cursussenComboBox = new System.Windows.Forms.ComboBox();
            this.cursusLabel = new System.Windows.Forms.Label();
            this.docentLabel = new System.Windows.Forms.Label();
            this.lokaalLabel = new System.Windows.Forms.Label();
            this.selectGroupBox = new System.Windows.Forms.GroupBox();
            this.maxDeelnemersInput = new System.Windows.Forms.NumericUpDown();
            this.maxDeelnemersLabel = new System.Windows.Forms.Label();
            this.momentLabel = new System.Windows.Forms.Label();
            this.momentPicker = new System.Windows.Forms.DateTimePicker();
            this.toevoegenButton = new System.Windows.Forms.Button();
            this.annuleerButton = new System.Windows.Forms.Button();
            this.selectGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxDeelnemersInput)).BeginInit();
            this.SuspendLayout();
            // 
            // docentComboBox
            // 
            this.docentComboBox.FormattingEnabled = true;
            this.docentComboBox.Location = new System.Drawing.Point(6, 40);
            this.docentComboBox.Name = "docentComboBox";
            this.docentComboBox.Size = new System.Drawing.Size(670, 28);
            this.docentComboBox.TabIndex = 0;
            // 
            // lokaalComboBox
            // 
            this.lokaalComboBox.FormattingEnabled = true;
            this.lokaalComboBox.Location = new System.Drawing.Point(6, 175);
            this.lokaalComboBox.Name = "lokaalComboBox";
            this.lokaalComboBox.Size = new System.Drawing.Size(670, 28);
            this.lokaalComboBox.TabIndex = 1;
            // 
            // cursussenComboBox
            // 
            this.cursussenComboBox.FormattingEnabled = true;
            this.cursussenComboBox.Location = new System.Drawing.Point(6, 107);
            this.cursussenComboBox.Name = "cursussenComboBox";
            this.cursussenComboBox.Size = new System.Drawing.Size(670, 28);
            this.cursussenComboBox.TabIndex = 2;
            // 
            // cursusLabel
            // 
            this.cursusLabel.AutoSize = true;
            this.cursusLabel.Location = new System.Drawing.Point(6, 84);
            this.cursusLabel.Name = "cursusLabel";
            this.cursusLabel.Size = new System.Drawing.Size(51, 20);
            this.cursusLabel.TabIndex = 3;
            this.cursusLabel.Text = "Cursus";
            // 
            // docentLabel
            // 
            this.docentLabel.AutoSize = true;
            this.docentLabel.Location = new System.Drawing.Point(6, 17);
            this.docentLabel.Name = "docentLabel";
            this.docentLabel.Size = new System.Drawing.Size(57, 20);
            this.docentLabel.TabIndex = 4;
            this.docentLabel.Text = "Docent";
            // 
            // lokaalLabel
            // 
            this.lokaalLabel.AutoSize = true;
            this.lokaalLabel.Location = new System.Drawing.Point(6, 152);
            this.lokaalLabel.Name = "lokaalLabel";
            this.lokaalLabel.Size = new System.Drawing.Size(52, 20);
            this.lokaalLabel.TabIndex = 5;
            this.lokaalLabel.Text = "Lokaal";
            // 
            // selectGroupBox
            // 
            this.selectGroupBox.Controls.Add(this.maxDeelnemersInput);
            this.selectGroupBox.Controls.Add(this.maxDeelnemersLabel);
            this.selectGroupBox.Controls.Add(this.momentLabel);
            this.selectGroupBox.Controls.Add(this.momentPicker);
            this.selectGroupBox.Controls.Add(this.cursusLabel);
            this.selectGroupBox.Controls.Add(this.lokaalLabel);
            this.selectGroupBox.Controls.Add(this.docentComboBox);
            this.selectGroupBox.Controls.Add(this.docentLabel);
            this.selectGroupBox.Controls.Add(this.lokaalComboBox);
            this.selectGroupBox.Controls.Add(this.cursussenComboBox);
            this.selectGroupBox.Location = new System.Drawing.Point(12, 24);
            this.selectGroupBox.Name = "selectGroupBox";
            this.selectGroupBox.Size = new System.Drawing.Size(692, 332);
            this.selectGroupBox.TabIndex = 6;
            this.selectGroupBox.TabStop = false;
            // 
            // maxDeelnemersInput
            // 
            this.maxDeelnemersInput.Location = new System.Drawing.Point(175, 286);
            this.maxDeelnemersInput.Name = "maxDeelnemersInput";
            this.maxDeelnemersInput.Size = new System.Drawing.Size(157, 27);
            this.maxDeelnemersInput.TabIndex = 7;
            // 
            // maxDeelnemersLabel
            // 
            this.maxDeelnemersLabel.AutoSize = true;
            this.maxDeelnemersLabel.Location = new System.Drawing.Point(6, 288);
            this.maxDeelnemersLabel.Name = "maxDeelnemersLabel";
            this.maxDeelnemersLabel.Size = new System.Drawing.Size(163, 20);
            this.maxDeelnemersLabel.TabIndex = 8;
            this.maxDeelnemersLabel.Text = "Max aantal deelnemers";
            // 
            // momentLabel
            // 
            this.momentLabel.AutoSize = true;
            this.momentLabel.Location = new System.Drawing.Point(6, 217);
            this.momentLabel.Name = "momentLabel";
            this.momentLabel.Size = new System.Drawing.Size(65, 20);
            this.momentLabel.TabIndex = 7;
            this.momentLabel.Text = "Moment";
            // 
            // momentPicker
            // 
            this.momentPicker.Location = new System.Drawing.Point(6, 240);
            this.momentPicker.Name = "momentPicker";
            this.momentPicker.Size = new System.Drawing.Size(326, 27);
            this.momentPicker.TabIndex = 7;
            // 
            // toevoegenButton
            // 
            this.toevoegenButton.Location = new System.Drawing.Point(189, 362);
            this.toevoegenButton.Name = "toevoegenButton";
            this.toevoegenButton.Size = new System.Drawing.Size(171, 62);
            this.toevoegenButton.TabIndex = 7;
            this.toevoegenButton.Text = "Toevoegen";
            this.toevoegenButton.UseVisualStyleBackColor = true;
            this.toevoegenButton.Click += new System.EventHandler(this.toevoegenButton_Click);
            // 
            // annuleerButton
            // 
            this.annuleerButton.Location = new System.Drawing.Point(12, 362);
            this.annuleerButton.Name = "annuleerButton";
            this.annuleerButton.Size = new System.Drawing.Size(171, 62);
            this.annuleerButton.TabIndex = 8;
            this.annuleerButton.Text = "Annuleer";
            this.annuleerButton.UseVisualStyleBackColor = true;
            // 
            // WorkshopToevoegen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 437);
            this.Controls.Add(this.annuleerButton);
            this.Controls.Add(this.toevoegenButton);
            this.Controls.Add(this.selectGroupBox);
            this.Name = "WorkshopToevoegen";
            this.Text = "WorkshopToevoegen";
            this.selectGroupBox.ResumeLayout(false);
            this.selectGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxDeelnemersInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox docentComboBox;
        private ComboBox lokaalComboBox;
        private ComboBox cursussenComboBox;
        private Label cursusLabel;
        private Label docentLabel;
        private Label lokaalLabel;
        private GroupBox selectGroupBox;
        private DateTimePicker momentPicker;
        private Label momentLabel;
        private NumericUpDown maxDeelnemersInput;
        private Label maxDeelnemersLabel;
        private Button toevoegenButton;
        private Button annuleerButton;
    }
}