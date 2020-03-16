namespace BloodBank
{
    partial class Form2
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
            this.DonorBox = new System.Windows.Forms.GroupBox();
            this.Form2DonorChangeButton = new System.Windows.Forms.Button();
            this.DonorBloodTypeBox = new System.Windows.Forms.ComboBox();
            this.DonorBloodType = new System.Windows.Forms.Label();
            this.DonorPhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.DonorPhoneNumber = new System.Windows.Forms.Label();
            this.DonorLastNameTextBox = new System.Windows.Forms.TextBox();
            this.DonorLastName = new System.Windows.Forms.Label();
            this.DonorMiddleNameTextBox = new System.Windows.Forms.TextBox();
            this.DonorMiddleName = new System.Windows.Forms.Label();
            this.DonorFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.DonorFirstName = new System.Windows.Forms.Label();
            this.DonorBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DonorBox
            // 
            this.DonorBox.Controls.Add(this.Form2DonorChangeButton);
            this.DonorBox.Controls.Add(this.DonorBloodTypeBox);
            this.DonorBox.Controls.Add(this.DonorBloodType);
            this.DonorBox.Controls.Add(this.DonorPhoneNumberTextBox);
            this.DonorBox.Controls.Add(this.DonorPhoneNumber);
            this.DonorBox.Controls.Add(this.DonorLastNameTextBox);
            this.DonorBox.Controls.Add(this.DonorLastName);
            this.DonorBox.Controls.Add(this.DonorMiddleNameTextBox);
            this.DonorBox.Controls.Add(this.DonorMiddleName);
            this.DonorBox.Controls.Add(this.DonorFirstNameTextBox);
            this.DonorBox.Controls.Add(this.DonorFirstName);
            this.DonorBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DonorBox.ForeColor = System.Drawing.Color.Black;
            this.DonorBox.Location = new System.Drawing.Point(12, 12);
            this.DonorBox.Name = "DonorBox";
            this.DonorBox.Size = new System.Drawing.Size(405, 412);
            this.DonorBox.TabIndex = 1;
            this.DonorBox.TabStop = false;
            this.DonorBox.Text = "Donor";
            // 
            // Form2DonorChangeButton
            // 
            this.Form2DonorChangeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Form2DonorChangeButton.Location = new System.Drawing.Point(129, 355);
            this.Form2DonorChangeButton.Name = "Form2DonorChangeButton";
            this.Form2DonorChangeButton.Size = new System.Drawing.Size(117, 38);
            this.Form2DonorChangeButton.TabIndex = 10;
            this.Form2DonorChangeButton.Text = "Change";
            this.Form2DonorChangeButton.UseVisualStyleBackColor = true;
            this.Form2DonorChangeButton.Click += new System.EventHandler(this.Form2DonorChangeButton_Click);
            // 
            // DonorBloodTypeBox
            // 
            this.DonorBloodTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DonorBloodTypeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DonorBloodTypeBox.FormattingEnabled = true;
            this.DonorBloodTypeBox.Items.AddRange(new object[] {
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
            this.DonorBloodTypeBox.Location = new System.Drawing.Point(170, 292);
            this.DonorBloodTypeBox.Name = "DonorBloodTypeBox";
            this.DonorBloodTypeBox.Size = new System.Drawing.Size(222, 33);
            this.DonorBloodTypeBox.TabIndex = 9;
            // 
            // DonorBloodType
            // 
            this.DonorBloodType.AutoSize = true;
            this.DonorBloodType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DonorBloodType.Location = new System.Drawing.Point(6, 292);
            this.DonorBloodType.Name = "DonorBloodType";
            this.DonorBloodType.Size = new System.Drawing.Size(120, 25);
            this.DonorBloodType.TabIndex = 8;
            this.DonorBloodType.Text = "Blood Type*";
            // 
            // DonorPhoneNumberTextBox
            // 
            this.DonorPhoneNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DonorPhoneNumberTextBox.Location = new System.Drawing.Point(170, 235);
            this.DonorPhoneNumberTextBox.Name = "DonorPhoneNumberTextBox";
            this.DonorPhoneNumberTextBox.Size = new System.Drawing.Size(222, 30);
            this.DonorPhoneNumberTextBox.TabIndex = 7;
            // 
            // DonorPhoneNumber
            // 
            this.DonorPhoneNumber.AutoSize = true;
            this.DonorPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DonorPhoneNumber.Location = new System.Drawing.Point(6, 235);
            this.DonorPhoneNumber.Name = "DonorPhoneNumber";
            this.DonorPhoneNumber.Size = new System.Drawing.Size(151, 25);
            this.DonorPhoneNumber.TabIndex = 6;
            this.DonorPhoneNumber.Text = "Phone Number*";
            // 
            // DonorLastNameTextBox
            // 
            this.DonorLastNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DonorLastNameTextBox.Location = new System.Drawing.Point(170, 180);
            this.DonorLastNameTextBox.Name = "DonorLastNameTextBox";
            this.DonorLastNameTextBox.Size = new System.Drawing.Size(222, 30);
            this.DonorLastNameTextBox.TabIndex = 5;
            // 
            // DonorLastName
            // 
            this.DonorLastName.AutoSize = true;
            this.DonorLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DonorLastName.Location = new System.Drawing.Point(6, 180);
            this.DonorLastName.Name = "DonorLastName";
            this.DonorLastName.Size = new System.Drawing.Size(114, 25);
            this.DonorLastName.TabIndex = 4;
            this.DonorLastName.Text = "Last Name*";
            // 
            // DonorMiddleNameTextBox
            // 
            this.DonorMiddleNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DonorMiddleNameTextBox.Location = new System.Drawing.Point(170, 128);
            this.DonorMiddleNameTextBox.Name = "DonorMiddleNameTextBox";
            this.DonorMiddleNameTextBox.Size = new System.Drawing.Size(222, 30);
            this.DonorMiddleNameTextBox.TabIndex = 3;
            // 
            // DonorMiddleName
            // 
            this.DonorMiddleName.AutoSize = true;
            this.DonorMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DonorMiddleName.Location = new System.Drawing.Point(6, 128);
            this.DonorMiddleName.Name = "DonorMiddleName";
            this.DonorMiddleName.Size = new System.Drawing.Size(122, 25);
            this.DonorMiddleName.TabIndex = 2;
            this.DonorMiddleName.Text = "MiddleName";
            // 
            // DonorFirstNameTextBox
            // 
            this.DonorFirstNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DonorFirstNameTextBox.Location = new System.Drawing.Point(170, 72);
            this.DonorFirstNameTextBox.Name = "DonorFirstNameTextBox";
            this.DonorFirstNameTextBox.Size = new System.Drawing.Size(222, 30);
            this.DonorFirstNameTextBox.TabIndex = 1;
            // 
            // DonorFirstName
            // 
            this.DonorFirstName.AutoSize = true;
            this.DonorFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DonorFirstName.Location = new System.Drawing.Point(6, 72);
            this.DonorFirstName.Name = "DonorFirstName";
            this.DonorFirstName.Size = new System.Drawing.Size(114, 25);
            this.DonorFirstName.TabIndex = 0;
            this.DonorFirstName.Text = "First Name*";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(429, 433);
            this.Controls.Add(this.DonorBox);
            this.Name = "Form2";
            this.Text = "Form2";
            this.DonorBox.ResumeLayout(false);
            this.DonorBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DonorBox;
        private System.Windows.Forms.Button Form2DonorChangeButton;
        private System.Windows.Forms.ComboBox DonorBloodTypeBox;
        private System.Windows.Forms.Label DonorBloodType;
        private System.Windows.Forms.TextBox DonorPhoneNumberTextBox;
        private System.Windows.Forms.Label DonorPhoneNumber;
        private System.Windows.Forms.TextBox DonorLastNameTextBox;
        private System.Windows.Forms.Label DonorLastName;
        private System.Windows.Forms.TextBox DonorMiddleNameTextBox;
        private System.Windows.Forms.Label DonorMiddleName;
        private System.Windows.Forms.TextBox DonorFirstNameTextBox;
        private System.Windows.Forms.Label DonorFirstName;
    }
}