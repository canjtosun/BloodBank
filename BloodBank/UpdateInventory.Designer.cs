namespace BloodBank
{
    partial class UpdateInventory
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
            this.UpdateInventoryLabel = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SelectNumberOfUnitsLabel = new System.Windows.Forms.Label();
            this.SelectBloodTypeInventoryLabel = new System.Windows.Forms.Label();
            this.SelectDonationTypeInventoryLabel = new System.Windows.Forms.Label();
            this.InputUnitsUsedTextBox = new System.Windows.Forms.TextBox();
            this.InventorySelectBloodTypeBox = new System.Windows.Forms.ComboBox();
            this.InventorySelectDonationTypeBox = new System.Windows.Forms.ComboBox();
            this.UpdateInventoryFormFinalButton = new System.Windows.Forms.Button();
            this.UpdateInventoryLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdateInventoryLabel
            // 
            this.UpdateInventoryLabel.Controls.Add(this.UpdateInventoryFormFinalButton);
            this.UpdateInventoryLabel.Controls.Add(this.InventorySelectDonationTypeBox);
            this.UpdateInventoryLabel.Controls.Add(this.InventorySelectBloodTypeBox);
            this.UpdateInventoryLabel.Controls.Add(this.InputUnitsUsedTextBox);
            this.UpdateInventoryLabel.Controls.Add(this.SelectDonationTypeInventoryLabel);
            this.UpdateInventoryLabel.Controls.Add(this.SelectBloodTypeInventoryLabel);
            this.UpdateInventoryLabel.Controls.Add(this.SelectNumberOfUnitsLabel);
            this.UpdateInventoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateInventoryLabel.ForeColor = System.Drawing.Color.Indigo;
            this.UpdateInventoryLabel.Location = new System.Drawing.Point(0, 0);
            this.UpdateInventoryLabel.Name = "UpdateInventoryLabel";
            this.UpdateInventoryLabel.Size = new System.Drawing.Size(604, 292);
            this.UpdateInventoryLabel.TabIndex = 0;
            this.UpdateInventoryLabel.TabStop = false;
            this.UpdateInventoryLabel.Text = "Update Inventory for this facility";
            // 
            // SelectNumberOfUnitsLabel
            // 
            this.SelectNumberOfUnitsLabel.AutoSize = true;
            this.SelectNumberOfUnitsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectNumberOfUnitsLabel.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.SelectNumberOfUnitsLabel.Location = new System.Drawing.Point(28, 59);
            this.SelectNumberOfUnitsLabel.Name = "SelectNumberOfUnitsLabel";
            this.SelectNumberOfUnitsLabel.Size = new System.Drawing.Size(198, 25);
            this.SelectNumberOfUnitsLabel.TabIndex = 0;
            this.SelectNumberOfUnitsLabel.Text = "Select # of units used";
            this.SelectNumberOfUnitsLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // SelectBloodTypeInventoryLabel
            // 
            this.SelectBloodTypeInventoryLabel.AutoSize = true;
            this.SelectBloodTypeInventoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectBloodTypeInventoryLabel.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.SelectBloodTypeInventoryLabel.Location = new System.Drawing.Point(28, 116);
            this.SelectBloodTypeInventoryLabel.Name = "SelectBloodTypeInventoryLabel";
            this.SelectBloodTypeInventoryLabel.Size = new System.Drawing.Size(210, 25);
            this.SelectBloodTypeInventoryLabel.TabIndex = 1;
            this.SelectBloodTypeInventoryLabel.Text = "Select blood type used";
            // 
            // SelectDonationTypeInventoryLabel
            // 
            this.SelectDonationTypeInventoryLabel.AutoSize = true;
            this.SelectDonationTypeInventoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectDonationTypeInventoryLabel.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.SelectDonationTypeInventoryLabel.Location = new System.Drawing.Point(28, 174);
            this.SelectDonationTypeInventoryLabel.Name = "SelectDonationTypeInventoryLabel";
            this.SelectDonationTypeInventoryLabel.Size = new System.Drawing.Size(237, 25);
            this.SelectDonationTypeInventoryLabel.TabIndex = 2;
            this.SelectDonationTypeInventoryLabel.Text = "Select donation type used";
            // 
            // InputUnitsUsedTextBox
            // 
            this.InputUnitsUsedTextBox.BackColor = System.Drawing.Color.Gainsboro;
            this.InputUnitsUsedTextBox.Location = new System.Drawing.Point(322, 53);
            this.InputUnitsUsedTextBox.Name = "InputUnitsUsedTextBox";
            this.InputUnitsUsedTextBox.Size = new System.Drawing.Size(100, 35);
            this.InputUnitsUsedTextBox.TabIndex = 1;
            // 
            // InventorySelectBloodTypeBox
            // 
            this.InventorySelectBloodTypeBox.BackColor = System.Drawing.Color.Gainsboro;
            this.InventorySelectBloodTypeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventorySelectBloodTypeBox.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.InventorySelectBloodTypeBox.FormattingEnabled = true;
            this.InventorySelectBloodTypeBox.Items.AddRange(new object[] {
            "Select Blood Type",
            "A-",
            "A+",
            "B-",
            "B+",
            "AB-",
            "AB+",
            "O-",
            "O+",
            "Unknown"});
            this.InventorySelectBloodTypeBox.Location = new System.Drawing.Point(322, 110);
            this.InventorySelectBloodTypeBox.Name = "InventorySelectBloodTypeBox";
            this.InventorySelectBloodTypeBox.Size = new System.Drawing.Size(241, 30);
            this.InventorySelectBloodTypeBox.TabIndex = 3;
            // 
            // InventorySelectDonationTypeBox
            // 
            this.InventorySelectDonationTypeBox.BackColor = System.Drawing.Color.Gainsboro;
            this.InventorySelectDonationTypeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventorySelectDonationTypeBox.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.InventorySelectDonationTypeBox.FormattingEnabled = true;
            this.InventorySelectDonationTypeBox.Items.AddRange(new object[] {
            "Select Donation Type",
            "Plasma",
            "Platelet",
            "Power Red",
            "Whole Blood"});
            this.InventorySelectDonationTypeBox.Location = new System.Drawing.Point(322, 168);
            this.InventorySelectDonationTypeBox.Name = "InventorySelectDonationTypeBox";
            this.InventorySelectDonationTypeBox.Size = new System.Drawing.Size(241, 30);
            this.InventorySelectDonationTypeBox.TabIndex = 4;
            // 
            // UpdateInventoryFormFinalButton
            // 
            this.UpdateInventoryFormFinalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateInventoryFormFinalButton.Location = new System.Drawing.Point(416, 230);
            this.UpdateInventoryFormFinalButton.Name = "UpdateInventoryFormFinalButton";
            this.UpdateInventoryFormFinalButton.Size = new System.Drawing.Size(147, 41);
            this.UpdateInventoryFormFinalButton.TabIndex = 5;
            this.UpdateInventoryFormFinalButton.Text = "Update";
            this.UpdateInventoryFormFinalButton.UseVisualStyleBackColor = true;
            this.UpdateInventoryFormFinalButton.Click += new System.EventHandler(UpdateInventoryFormFinalButton_Click);
            // 
            // UpdateInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(621, 324);
            this.Controls.Add(this.UpdateInventoryLabel);
            this.Name = "UpdateInventory";
            this.Text = "UpdateInventory";
            this.UpdateInventoryLabel.ResumeLayout(false);
            this.UpdateInventoryLabel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox UpdateInventoryLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label SelectBloodTypeInventoryLabel;
        private System.Windows.Forms.Label SelectNumberOfUnitsLabel;
        private System.Windows.Forms.Label SelectDonationTypeInventoryLabel;
        private System.Windows.Forms.ComboBox InventorySelectBloodTypeBox;
        private System.Windows.Forms.TextBox InputUnitsUsedTextBox;
        private System.Windows.Forms.ComboBox InventorySelectDonationTypeBox;
        private System.Windows.Forms.Button UpdateInventoryFormFinalButton;
    }
}