namespace BloodBank
{
    partial class Form1
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
            this.DonorInfoBox = new System.Windows.Forms.GroupBox();
            this.DonorPhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.DonorLastNameTextBox = new System.Windows.Forms.TextBox();
            this.DonorMiddleNameTextBox = new System.Windows.Forms.TextBox();
            this.DonorFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.DonorPhoneNumber = new System.Windows.Forms.Label();
            this.DonorLastName = new System.Windows.Forms.Label();
            this.DonorMiddleName = new System.Windows.Forms.Label();
            this.DonorFirstName = new System.Windows.Forms.Label();
            this.NurseInfoBox = new System.Windows.Forms.GroupBox();
            this.NurseFirstName = new System.Windows.Forms.Label();
            this.NurseMiddleName = new System.Windows.Forms.Label();
            this.NurseLastName = new System.Windows.Forms.Label();
            this.NursePhoneNumber = new System.Windows.Forms.Label();
            this.NurseFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.NurseMiddleNameTextBox = new System.Windows.Forms.TextBox();
            this.NurseLastNameTextBox = new System.Windows.Forms.TextBox();
            this.NursePhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.DonationInfoBox = new System.Windows.Forms.GroupBox();
            this.DonationDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.DonorValidationTextBox = new System.Windows.Forms.TextBox();
            this.DonationBloodTypeTextBox = new System.Windows.Forms.TextBox();
            this.DonationDescription = new System.Windows.Forms.Label();
            this.DonationValidation = new System.Windows.Forms.Label();
            this.DonationBloodType = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.DonorInfoBox.SuspendLayout();
            this.NurseInfoBox.SuspendLayout();
            this.DonationInfoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DonorInfoBox
            // 
            this.DonorInfoBox.Controls.Add(this.DonorPhoneNumberTextBox);
            this.DonorInfoBox.Controls.Add(this.DonorLastNameTextBox);
            this.DonorInfoBox.Controls.Add(this.DonorMiddleNameTextBox);
            this.DonorInfoBox.Controls.Add(this.DonorFirstNameTextBox);
            this.DonorInfoBox.Controls.Add(this.DonorPhoneNumber);
            this.DonorInfoBox.Controls.Add(this.DonorLastName);
            this.DonorInfoBox.Controls.Add(this.DonorMiddleName);
            this.DonorInfoBox.Controls.Add(this.DonorFirstName);
            this.DonorInfoBox.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DonorInfoBox.Location = new System.Drawing.Point(41, 286);
            this.DonorInfoBox.Name = "DonorInfoBox";
            this.DonorInfoBox.Size = new System.Drawing.Size(440, 262);
            this.DonorInfoBox.TabIndex = 0;
            this.DonorInfoBox.TabStop = false;
            this.DonorInfoBox.Text = "Donor Information";
            // 
            // DonorPhoneNumberTextBox
            // 
            this.DonorPhoneNumberTextBox.Location = new System.Drawing.Point(277, 193);
            this.DonorPhoneNumberTextBox.Name = "DonorPhoneNumberTextBox";
            this.DonorPhoneNumberTextBox.Size = new System.Drawing.Size(157, 32);
            this.DonorPhoneNumberTextBox.TabIndex = 7;
            // 
            // DonorLastNameTextBox
            // 
            this.DonorLastNameTextBox.Location = new System.Drawing.Point(277, 145);
            this.DonorLastNameTextBox.Name = "DonorLastNameTextBox";
            this.DonorLastNameTextBox.Size = new System.Drawing.Size(157, 32);
            this.DonorLastNameTextBox.TabIndex = 6;
            // 
            // DonorMiddleNameTextBox
            // 
            this.DonorMiddleNameTextBox.Location = new System.Drawing.Point(277, 99);
            this.DonorMiddleNameTextBox.Name = "DonorMiddleNameTextBox";
            this.DonorMiddleNameTextBox.Size = new System.Drawing.Size(157, 32);
            this.DonorMiddleNameTextBox.TabIndex = 5;
            // 
            // DonorFirstNameTextBox
            // 
            this.DonorFirstNameTextBox.Location = new System.Drawing.Point(277, 51);
            this.DonorFirstNameTextBox.Name = "DonorFirstNameTextBox";
            this.DonorFirstNameTextBox.Size = new System.Drawing.Size(157, 32);
            this.DonorFirstNameTextBox.TabIndex = 4;
            // 
            // DonorPhoneNumber
            // 
            this.DonorPhoneNumber.AutoSize = true;
            this.DonorPhoneNumber.Location = new System.Drawing.Point(6, 195);
            this.DonorPhoneNumber.Name = "DonorPhoneNumber";
            this.DonorPhoneNumber.Size = new System.Drawing.Size(161, 25);
            this.DonorPhoneNumber.TabIndex = 3;
            this.DonorPhoneNumber.Text = "Phone Number";
            // 
            // DonorLastName
            // 
            this.DonorLastName.AutoSize = true;
            this.DonorLastName.Location = new System.Drawing.Point(6, 147);
            this.DonorLastName.Name = "DonorLastName";
            this.DonorLastName.Size = new System.Drawing.Size(118, 25);
            this.DonorLastName.TabIndex = 2;
            this.DonorLastName.Text = "Last Name";
            // 
            // DonorMiddleName
            // 
            this.DonorMiddleName.AutoSize = true;
            this.DonorMiddleName.Location = new System.Drawing.Point(6, 101);
            this.DonorMiddleName.Name = "DonorMiddleName";
            this.DonorMiddleName.Size = new System.Drawing.Size(142, 25);
            this.DonorMiddleName.TabIndex = 1;
            this.DonorMiddleName.Text = "Middle Name";
            this.DonorMiddleName.Click += new System.EventHandler(this.label2_Click);
            // 
            // DonorFirstName
            // 
            this.DonorFirstName.AutoSize = true;
            this.DonorFirstName.Location = new System.Drawing.Point(6, 53);
            this.DonorFirstName.Name = "DonorFirstName";
            this.DonorFirstName.Size = new System.Drawing.Size(122, 25);
            this.DonorFirstName.TabIndex = 0;
            this.DonorFirstName.Text = "First Name";
            this.DonorFirstName.Click += new System.EventHandler(this.label1_Click);
            // 
            // NurseInfoBox
            // 
            this.NurseInfoBox.Controls.Add(this.NursePhoneNumberTextBox);
            this.NurseInfoBox.Controls.Add(this.NurseLastNameTextBox);
            this.NurseInfoBox.Controls.Add(this.NurseMiddleNameTextBox);
            this.NurseInfoBox.Controls.Add(this.NurseFirstNameTextBox);
            this.NurseInfoBox.Controls.Add(this.NursePhoneNumber);
            this.NurseInfoBox.Controls.Add(this.NurseLastName);
            this.NurseInfoBox.Controls.Add(this.NurseMiddleName);
            this.NurseInfoBox.Controls.Add(this.NurseFirstName);
            this.NurseInfoBox.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NurseInfoBox.Location = new System.Drawing.Point(550, 286);
            this.NurseInfoBox.Name = "NurseInfoBox";
            this.NurseInfoBox.Size = new System.Drawing.Size(440, 262);
            this.NurseInfoBox.TabIndex = 1;
            this.NurseInfoBox.TabStop = false;
            this.NurseInfoBox.Text = "Nurse Information";
            // 
            // NurseFirstName
            // 
            this.NurseFirstName.AutoSize = true;
            this.NurseFirstName.Location = new System.Drawing.Point(6, 55);
            this.NurseFirstName.Name = "NurseFirstName";
            this.NurseFirstName.Size = new System.Drawing.Size(122, 25);
            this.NurseFirstName.TabIndex = 0;
            this.NurseFirstName.Text = "First Name";
            this.NurseFirstName.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // NurseMiddleName
            // 
            this.NurseMiddleName.AutoSize = true;
            this.NurseMiddleName.Location = new System.Drawing.Point(6, 103);
            this.NurseMiddleName.Name = "NurseMiddleName";
            this.NurseMiddleName.Size = new System.Drawing.Size(142, 25);
            this.NurseMiddleName.TabIndex = 1;
            this.NurseMiddleName.Text = "Middle Name";
            // 
            // NurseLastName
            // 
            this.NurseLastName.AutoSize = true;
            this.NurseLastName.Location = new System.Drawing.Point(6, 149);
            this.NurseLastName.Name = "NurseLastName";
            this.NurseLastName.Size = new System.Drawing.Size(118, 25);
            this.NurseLastName.TabIndex = 2;
            this.NurseLastName.Text = "Last Name";
            // 
            // NursePhoneNumber
            // 
            this.NursePhoneNumber.AutoSize = true;
            this.NursePhoneNumber.Location = new System.Drawing.Point(6, 196);
            this.NursePhoneNumber.Name = "NursePhoneNumber";
            this.NursePhoneNumber.Size = new System.Drawing.Size(161, 25);
            this.NursePhoneNumber.TabIndex = 3;
            this.NursePhoneNumber.Text = "Phone Number";
            // 
            // NurseFirstNameTextBox
            // 
            this.NurseFirstNameTextBox.Location = new System.Drawing.Point(266, 53);
            this.NurseFirstNameTextBox.Name = "NurseFirstNameTextBox";
            this.NurseFirstNameTextBox.Size = new System.Drawing.Size(168, 32);
            this.NurseFirstNameTextBox.TabIndex = 4;
            // 
            // NurseMiddleNameTextBox
            // 
            this.NurseMiddleNameTextBox.Location = new System.Drawing.Point(266, 101);
            this.NurseMiddleNameTextBox.Name = "NurseMiddleNameTextBox";
            this.NurseMiddleNameTextBox.Size = new System.Drawing.Size(168, 32);
            this.NurseMiddleNameTextBox.TabIndex = 5;
            // 
            // NurseLastNameTextBox
            // 
            this.NurseLastNameTextBox.Location = new System.Drawing.Point(266, 147);
            this.NurseLastNameTextBox.Name = "NurseLastNameTextBox";
            this.NurseLastNameTextBox.Size = new System.Drawing.Size(168, 32);
            this.NurseLastNameTextBox.TabIndex = 6;
            // 
            // NursePhoneNumberTextBox
            // 
            this.NursePhoneNumberTextBox.Location = new System.Drawing.Point(266, 188);
            this.NursePhoneNumberTextBox.Name = "NursePhoneNumberTextBox";
            this.NursePhoneNumberTextBox.Size = new System.Drawing.Size(168, 32);
            this.NursePhoneNumberTextBox.TabIndex = 7;
            // 
            // DonationInfoBox
            // 
            this.DonationInfoBox.Controls.Add(this.DonationDescriptionTextBox);
            this.DonationInfoBox.Controls.Add(this.DonorValidationTextBox);
            this.DonationInfoBox.Controls.Add(this.DonationBloodTypeTextBox);
            this.DonationInfoBox.Controls.Add(this.DonationDescription);
            this.DonationInfoBox.Controls.Add(this.DonationValidation);
            this.DonationInfoBox.Controls.Add(this.DonationBloodType);
            this.DonationInfoBox.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DonationInfoBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DonationInfoBox.Location = new System.Drawing.Point(1057, 286);
            this.DonationInfoBox.Name = "DonationInfoBox";
            this.DonationInfoBox.Size = new System.Drawing.Size(440, 262);
            this.DonationInfoBox.TabIndex = 2;
            this.DonationInfoBox.TabStop = false;
            this.DonationInfoBox.Text = "Donation Information";
            // 
            // DonationDescriptionTextBox
            // 
            this.DonationDescriptionTextBox.Location = new System.Drawing.Point(266, 135);
            this.DonationDescriptionTextBox.Name = "DonationDescriptionTextBox";
            this.DonationDescriptionTextBox.Size = new System.Drawing.Size(168, 32);
            this.DonationDescriptionTextBox.TabIndex = 6;
            // 
            // DonorValidationTextBox
            // 
            this.DonorValidationTextBox.Location = new System.Drawing.Point(266, 92);
            this.DonorValidationTextBox.Name = "DonorValidationTextBox";
            this.DonorValidationTextBox.Size = new System.Drawing.Size(168, 32);
            this.DonorValidationTextBox.TabIndex = 5;
            // 
            // DonationBloodTypeTextBox
            // 
            this.DonationBloodTypeTextBox.Location = new System.Drawing.Point(266, 44);
            this.DonationBloodTypeTextBox.Name = "DonationBloodTypeTextBox";
            this.DonationBloodTypeTextBox.Size = new System.Drawing.Size(168, 32);
            this.DonationBloodTypeTextBox.TabIndex = 4;
            // 
            // DonationDescription
            // 
            this.DonationDescription.AutoSize = true;
            this.DonationDescription.Location = new System.Drawing.Point(6, 145);
            this.DonationDescription.Name = "DonationDescription";
            this.DonationDescription.Size = new System.Drawing.Size(223, 25);
            this.DonationDescription.TabIndex = 2;
            this.DonationDescription.Text = "Donation Description";
            // 
            // DonationValidation
            // 
            this.DonationValidation.AutoSize = true;
            this.DonationValidation.Location = new System.Drawing.Point(6, 99);
            this.DonationValidation.Name = "DonationValidation";
            this.DonationValidation.Size = new System.Drawing.Size(112, 25);
            this.DonationValidation.TabIndex = 1;
            this.DonationValidation.Text = "Validation";
            // 
            // DonationBloodType
            // 
            this.DonationBloodType.AutoSize = true;
            this.DonationBloodType.Location = new System.Drawing.Point(6, 51);
            this.DonationBloodType.Name = "DonationBloodType";
            this.DonationBloodType.Size = new System.Drawing.Size(121, 25);
            this.DonationBloodType.TabIndex = 0;
            this.DonationBloodType.Text = "Blood Type";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(1385, 586);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(112, 57);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "ADD";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1537, 793);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DonationInfoBox);
            this.Controls.Add(this.NurseInfoBox);
            this.Controls.Add(this.DonorInfoBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.DonorInfoBox.ResumeLayout(false);
            this.DonorInfoBox.PerformLayout();
            this.NurseInfoBox.ResumeLayout(false);
            this.NurseInfoBox.PerformLayout();
            this.DonationInfoBox.ResumeLayout(false);
            this.DonationInfoBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DonorInfoBox;
        private System.Windows.Forms.Label DonorFirstName;
        private System.Windows.Forms.Label DonorMiddleName;
        private System.Windows.Forms.Label DonorLastName;
        private System.Windows.Forms.TextBox DonorPhoneNumberTextBox;
        private System.Windows.Forms.TextBox DonorLastNameTextBox;
        private System.Windows.Forms.TextBox DonorMiddleNameTextBox;
        private System.Windows.Forms.TextBox DonorFirstNameTextBox;
        private System.Windows.Forms.Label DonorPhoneNumber;
        private System.Windows.Forms.GroupBox NurseInfoBox;
        private System.Windows.Forms.Label NurseFirstName;
        private System.Windows.Forms.Label NursePhoneNumber;
        private System.Windows.Forms.Label NurseLastName;
        private System.Windows.Forms.Label NurseMiddleName;
        private System.Windows.Forms.TextBox NursePhoneNumberTextBox;
        private System.Windows.Forms.TextBox NurseLastNameTextBox;
        private System.Windows.Forms.TextBox NurseMiddleNameTextBox;
        private System.Windows.Forms.TextBox NurseFirstNameTextBox;
        private System.Windows.Forms.GroupBox DonationInfoBox;
        private System.Windows.Forms.TextBox DonationDescriptionTextBox;
        private System.Windows.Forms.TextBox DonorValidationTextBox;
        private System.Windows.Forms.TextBox DonationBloodTypeTextBox;
        private System.Windows.Forms.Label DonationDescription;
        private System.Windows.Forms.Label DonationValidation;
        private System.Windows.Forms.Label DonationBloodType;
        private System.Windows.Forms.Button AddButton;
    }
}

