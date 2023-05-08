namespace sqloefening
{
    partial class WorkshopAanmelden
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
            this.LeerlingKiesMenu = new System.Windows.Forms.ComboBox();
            this.PlanningDataGrid = new System.Windows.Forms.DataGridView();
            this.InschrijvenButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PlanningDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // LeerlingKiesMenu
            // 
            this.LeerlingKiesMenu.FormattingEnabled = true;
            this.LeerlingKiesMenu.Location = new System.Drawing.Point(12, 24);
            this.LeerlingKiesMenu.Name = "LeerlingKiesMenu";
            this.LeerlingKiesMenu.Size = new System.Drawing.Size(376, 28);
            this.LeerlingKiesMenu.TabIndex = 0;
            // 
            // PlanningDataGrid
            // 
            this.PlanningDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlanningDataGrid.Location = new System.Drawing.Point(422, 24);
            this.PlanningDataGrid.Name = "PlanningDataGrid";
            this.PlanningDataGrid.RowHeadersWidth = 51;
            this.PlanningDataGrid.RowTemplate.Height = 29;
            this.PlanningDataGrid.Size = new System.Drawing.Size(353, 308);
            this.PlanningDataGrid.TabIndex = 1;
            // 
            // InschrijvenButton
            // 
            this.InschrijvenButton.Location = new System.Drawing.Point(333, 409);
            this.InschrijvenButton.Name = "InschrijvenButton";
            this.InschrijvenButton.Size = new System.Drawing.Size(94, 29);
            this.InschrijvenButton.TabIndex = 2;
            this.InschrijvenButton.Text = "Inschrijven";
            this.InschrijvenButton.UseVisualStyleBackColor = true;
            this.InschrijvenButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // WorkshopAanmelden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InschrijvenButton);
            this.Controls.Add(this.PlanningDataGrid);
            this.Controls.Add(this.LeerlingKiesMenu);
            this.Name = "WorkshopAanmelden";
            this.Text = "WorkshopAanmelden";
            ((System.ComponentModel.ISupportInitialize)(this.PlanningDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox LeerlingKiesMenu;
        private DataGridView PlanningDataGrid;
        private Button InschrijvenButton;
    }
}