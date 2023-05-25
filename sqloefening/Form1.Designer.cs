namespace sqloefening
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            this.inschrijvingenDataGridView = new System.Windows.Forms.DataGridView();
            this.workshopToevoegenButton = new System.Windows.Forms.Button();
            this.workshopAanmeldenButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inschrijvingenDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // inschrijvingenDataGridView
            // 
            this.inschrijvingenDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inschrijvingenDataGridView.Location = new System.Drawing.Point(12, 12);
            this.inschrijvingenDataGridView.Name = "inschrijvingenDataGridView";
            this.inschrijvingenDataGridView.RowHeadersWidth = 51;
            this.inschrijvingenDataGridView.RowTemplate.Height = 29;
            this.inschrijvingenDataGridView.Size = new System.Drawing.Size(776, 339);
            this.inschrijvingenDataGridView.TabIndex = 0;
            // 
            // workshopToevoegenButton
            // 
            this.workshopToevoegenButton.Location = new System.Drawing.Point(12, 369);
            this.workshopToevoegenButton.Name = "workshopToevoegenButton";
            this.workshopToevoegenButton.Size = new System.Drawing.Size(167, 53);
            this.workshopToevoegenButton.TabIndex = 1;
            this.workshopToevoegenButton.Text = "Voeg Workshop Toe";
            this.workshopToevoegenButton.UseVisualStyleBackColor = true;
            this.workshopToevoegenButton.Click += new System.EventHandler(this.workshopToevoegenButton_Click);
            // 
            // workshopAanmeldenButton
            // 
            this.workshopAanmeldenButton.Location = new System.Drawing.Point(185, 369);
            this.workshopAanmeldenButton.Name = "workshopAanmeldenButton";
            this.workshopAanmeldenButton.Size = new System.Drawing.Size(198, 53);
            this.workshopAanmeldenButton.TabIndex = 2;
            this.workshopAanmeldenButton.Text = "Schrijf Student In Voor Workshop";
            this.workshopAanmeldenButton.UseVisualStyleBackColor = true;
            this.workshopAanmeldenButton.Click += new System.EventHandler(this.workshopAanmeldenButton_Click);
            // 

            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);

            this.Controls.Add(this.workshopAanmeldenButton);
            this.Controls.Add(this.workshopToevoegenButton);
            this.Controls.Add(this.inschrijvingenDataGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.inschrijvingenDataGridView)).EndInit();

            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView inschrijvingenDataGridView;
        private Button workshopToevoegenButton;
        private Button workshopAanmeldenButton;
    }
}