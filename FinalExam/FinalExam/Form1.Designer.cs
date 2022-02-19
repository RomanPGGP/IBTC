namespace FinalExam
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
            this.DBShow = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TeamNameLb = new System.Windows.Forms.Label();
            this.CoachNameLb = new System.Windows.Forms.Label();
            this.DirectorNameLb = new System.Windows.Forms.Label();
            this.AddresLine1Lb = new System.Windows.Forms.Label();
            this.AddressLine2Lb = new System.Windows.Forms.Label();
            this.PostCodeLb = new System.Windows.Forms.Label();
            this.CityLb = new System.Windows.Forms.Label();
            this.ContactNumberLb = new System.Windows.Forms.Label();
            this.EmailLb = new System.Windows.Forms.Label();
            this.InsertButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.inTeamName = new System.Windows.Forms.TextBox();
            this.inCoachName = new System.Windows.Forms.TextBox();
            this.inDirectorName = new System.Windows.Forms.TextBox();
            this.inAddressLine1 = new System.Windows.Forms.TextBox();
            this.inAddressLine2 = new System.Windows.Forms.TextBox();
            this.inPostCode = new System.Windows.Forms.TextBox();
            this.inCity = new System.Windows.Forms.TextBox();
            this.inContactNumber = new System.Windows.Forms.TextBox();
            this.inEmail = new System.Windows.Forms.TextBox();
            this.teamNameCB = new System.Windows.Forms.CheckBox();
            this.coachNameCB = new System.Windows.Forms.CheckBox();
            this.directorNameCB = new System.Windows.Forms.CheckBox();
            this.emailCB = new System.Windows.Forms.CheckBox();
            this.warningLb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DBShow
            // 
            this.DBShow.FormattingEnabled = true;
            this.DBShow.Location = new System.Drawing.Point(12, 12);
            this.DBShow.Name = "DBShow";
            this.DBShow.Size = new System.Drawing.Size(625, 459);
            this.DBShow.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Salmon;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(643, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(479, 91);
            this.button1.TabIndex = 1;
            this.button1.Text = "Please fill out all the information needed when adding a new entry. if data needs" +
    " to be modified or deleted, please select the checkbox to the field to be used a" +
    "s a reference.";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // TeamNameLb
            // 
            this.TeamNameLb.AutoSize = true;
            this.TeamNameLb.Location = new System.Drawing.Point(643, 132);
            this.TeamNameLb.Name = "TeamNameLb";
            this.TeamNameLb.Size = new System.Drawing.Size(68, 13);
            this.TeamNameLb.TabIndex = 2;
            this.TeamNameLb.Text = "Team Name:";
            // 
            // CoachNameLb
            // 
            this.CoachNameLb.AutoSize = true;
            this.CoachNameLb.Location = new System.Drawing.Point(643, 186);
            this.CoachNameLb.Name = "CoachNameLb";
            this.CoachNameLb.Size = new System.Drawing.Size(72, 13);
            this.CoachNameLb.TabIndex = 3;
            this.CoachNameLb.Text = "Coach Name:";
            // 
            // DirectorNameLb
            // 
            this.DirectorNameLb.AutoSize = true;
            this.DirectorNameLb.Location = new System.Drawing.Point(643, 240);
            this.DirectorNameLb.Name = "DirectorNameLb";
            this.DirectorNameLb.Size = new System.Drawing.Size(78, 13);
            this.DirectorNameLb.TabIndex = 4;
            this.DirectorNameLb.Text = "Director Name:";
            // 
            // AddresLine1Lb
            // 
            this.AddresLine1Lb.AutoSize = true;
            this.AddresLine1Lb.Location = new System.Drawing.Point(643, 288);
            this.AddresLine1Lb.Name = "AddresLine1Lb";
            this.AddresLine1Lb.Size = new System.Drawing.Size(80, 13);
            this.AddresLine1Lb.TabIndex = 5;
            this.AddresLine1Lb.Text = "Address Line 1:";
            // 
            // AddressLine2Lb
            // 
            this.AddressLine2Lb.AutoSize = true;
            this.AddressLine2Lb.Location = new System.Drawing.Point(643, 340);
            this.AddressLine2Lb.Name = "AddressLine2Lb";
            this.AddressLine2Lb.Size = new System.Drawing.Size(80, 13);
            this.AddressLine2Lb.TabIndex = 6;
            this.AddressLine2Lb.Text = "Address Line 2:";
            // 
            // PostCodeLb
            // 
            this.PostCodeLb.AutoSize = true;
            this.PostCodeLb.Location = new System.Drawing.Point(877, 132);
            this.PostCodeLb.Name = "PostCodeLb";
            this.PostCodeLb.Size = new System.Drawing.Size(59, 13);
            this.PostCodeLb.TabIndex = 7;
            this.PostCodeLb.Text = "Post Code:";
            // 
            // CityLb
            // 
            this.CityLb.AutoSize = true;
            this.CityLb.Location = new System.Drawing.Point(877, 186);
            this.CityLb.Name = "CityLb";
            this.CityLb.Size = new System.Drawing.Size(27, 13);
            this.CityLb.TabIndex = 8;
            this.CityLb.Text = "City:";
            // 
            // ContactNumberLb
            // 
            this.ContactNumberLb.AutoSize = true;
            this.ContactNumberLb.Location = new System.Drawing.Point(877, 240);
            this.ContactNumberLb.Name = "ContactNumberLb";
            this.ContactNumberLb.Size = new System.Drawing.Size(87, 13);
            this.ContactNumberLb.TabIndex = 9;
            this.ContactNumberLb.Text = "Contact Number:";
            // 
            // EmailLb
            // 
            this.EmailLb.AutoSize = true;
            this.EmailLb.Location = new System.Drawing.Point(877, 288);
            this.EmailLb.Name = "EmailLb";
            this.EmailLb.Size = new System.Drawing.Size(35, 13);
            this.EmailLb.TabIndex = 10;
            this.EmailLb.Text = "Email:";
            // 
            // InsertButton
            // 
            this.InsertButton.BackColor = System.Drawing.Color.Green;
            this.InsertButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.InsertButton.Location = new System.Drawing.Point(657, 403);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(110, 31);
            this.InsertButton.TabIndex = 11;
            this.InsertButton.Text = "Insert";
            this.InsertButton.UseVisualStyleBackColor = false;
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.Orange;
            this.UpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.Location = new System.Drawing.Point(817, 403);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(110, 31);
            this.UpdateButton.TabIndex = 12;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.Maroon;
            this.DeleteButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DeleteButton.Location = new System.Drawing.Point(963, 403);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(123, 31);
            this.DeleteButton.TabIndex = 13;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // inTeamName
            // 
            this.inTeamName.Location = new System.Drawing.Point(643, 148);
            this.inTeamName.Name = "inTeamName";
            this.inTeamName.Size = new System.Drawing.Size(180, 20);
            this.inTeamName.TabIndex = 14;
            // 
            // inCoachName
            // 
            this.inCoachName.Location = new System.Drawing.Point(643, 202);
            this.inCoachName.Name = "inCoachName";
            this.inCoachName.Size = new System.Drawing.Size(180, 20);
            this.inCoachName.TabIndex = 15;
            // 
            // inDirectorName
            // 
            this.inDirectorName.Location = new System.Drawing.Point(643, 256);
            this.inDirectorName.Name = "inDirectorName";
            this.inDirectorName.Size = new System.Drawing.Size(180, 20);
            this.inDirectorName.TabIndex = 16;
            // 
            // inAddressLine1
            // 
            this.inAddressLine1.Location = new System.Drawing.Point(643, 304);
            this.inAddressLine1.Name = "inAddressLine1";
            this.inAddressLine1.Size = new System.Drawing.Size(180, 20);
            this.inAddressLine1.TabIndex = 17;
            // 
            // inAddressLine2
            // 
            this.inAddressLine2.Location = new System.Drawing.Point(643, 356);
            this.inAddressLine2.Name = "inAddressLine2";
            this.inAddressLine2.Size = new System.Drawing.Size(180, 20);
            this.inAddressLine2.TabIndex = 18;
            // 
            // inPostCode
            // 
            this.inPostCode.Location = new System.Drawing.Point(880, 148);
            this.inPostCode.Name = "inPostCode";
            this.inPostCode.Size = new System.Drawing.Size(180, 20);
            this.inPostCode.TabIndex = 19;
            // 
            // inCity
            // 
            this.inCity.Location = new System.Drawing.Point(880, 202);
            this.inCity.Name = "inCity";
            this.inCity.Size = new System.Drawing.Size(180, 20);
            this.inCity.TabIndex = 20;
            // 
            // inContactNumber
            // 
            this.inContactNumber.Location = new System.Drawing.Point(880, 256);
            this.inContactNumber.Name = "inContactNumber";
            this.inContactNumber.Size = new System.Drawing.Size(180, 20);
            this.inContactNumber.TabIndex = 21;
            // 
            // inEmail
            // 
            this.inEmail.Location = new System.Drawing.Point(880, 304);
            this.inEmail.Name = "inEmail";
            this.inEmail.Size = new System.Drawing.Size(180, 20);
            this.inEmail.TabIndex = 22;
            // 
            // teamNameCB
            // 
            this.teamNameCB.AutoSize = true;
            this.teamNameCB.Location = new System.Drawing.Point(829, 151);
            this.teamNameCB.Name = "teamNameCB";
            this.teamNameCB.Size = new System.Drawing.Size(15, 14);
            this.teamNameCB.TabIndex = 23;
            this.teamNameCB.UseVisualStyleBackColor = true;
            // 
            // coachNameCB
            // 
            this.coachNameCB.AutoSize = true;
            this.coachNameCB.Location = new System.Drawing.Point(829, 205);
            this.coachNameCB.Name = "coachNameCB";
            this.coachNameCB.Size = new System.Drawing.Size(15, 14);
            this.coachNameCB.TabIndex = 24;
            this.coachNameCB.UseVisualStyleBackColor = true;
            // 
            // directorNameCB
            // 
            this.directorNameCB.AutoSize = true;
            this.directorNameCB.Location = new System.Drawing.Point(829, 259);
            this.directorNameCB.Name = "directorNameCB";
            this.directorNameCB.Size = new System.Drawing.Size(15, 14);
            this.directorNameCB.TabIndex = 25;
            this.directorNameCB.UseVisualStyleBackColor = true;
            // 
            // emailCB
            // 
            this.emailCB.AutoSize = true;
            this.emailCB.Location = new System.Drawing.Point(1066, 307);
            this.emailCB.Name = "emailCB";
            this.emailCB.Size = new System.Drawing.Size(15, 14);
            this.emailCB.TabIndex = 31;
            this.emailCB.UseVisualStyleBackColor = true;
            // 
            // warningLb
            // 
            this.warningLb.AutoSize = true;
            this.warningLb.Location = new System.Drawing.Point(654, 448);
            this.warningLb.Name = "warningLb";
            this.warningLb.Size = new System.Drawing.Size(0, 13);
            this.warningLb.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 480);
            this.Controls.Add(this.warningLb);
            this.Controls.Add(this.emailCB);
            this.Controls.Add(this.directorNameCB);
            this.Controls.Add(this.coachNameCB);
            this.Controls.Add(this.teamNameCB);
            this.Controls.Add(this.inEmail);
            this.Controls.Add(this.inContactNumber);
            this.Controls.Add(this.inCity);
            this.Controls.Add(this.inPostCode);
            this.Controls.Add(this.inAddressLine2);
            this.Controls.Add(this.inAddressLine1);
            this.Controls.Add(this.inDirectorName);
            this.Controls.Add(this.inCoachName);
            this.Controls.Add(this.inTeamName);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.EmailLb);
            this.Controls.Add(this.ContactNumberLb);
            this.Controls.Add(this.CityLb);
            this.Controls.Add(this.PostCodeLb);
            this.Controls.Add(this.AddressLine2Lb);
            this.Controls.Add(this.AddresLine1Lb);
            this.Controls.Add(this.DirectorNameLb);
            this.Controls.Add(this.CoachNameLb);
            this.Controls.Add(this.TeamNameLb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DBShow);
            this.Name = "Form1";
            this.Text = "Team Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox DBShow;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label TeamNameLb;
        private System.Windows.Forms.Label CoachNameLb;
        private System.Windows.Forms.Label DirectorNameLb;
        private System.Windows.Forms.Label AddresLine1Lb;
        private System.Windows.Forms.Label AddressLine2Lb;
        private System.Windows.Forms.Label PostCodeLb;
        private System.Windows.Forms.Label CityLb;
        private System.Windows.Forms.Label ContactNumberLb;
        private System.Windows.Forms.Label EmailLb;
        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TextBox inTeamName;
        private System.Windows.Forms.TextBox inCoachName;
        private System.Windows.Forms.TextBox inDirectorName;
        private System.Windows.Forms.TextBox inAddressLine1;
        private System.Windows.Forms.TextBox inAddressLine2;
        private System.Windows.Forms.TextBox inPostCode;
        private System.Windows.Forms.TextBox inCity;
        private System.Windows.Forms.TextBox inContactNumber;
        private System.Windows.Forms.TextBox inEmail;
        private System.Windows.Forms.CheckBox teamNameCB;
        private System.Windows.Forms.CheckBox coachNameCB;
        private System.Windows.Forms.CheckBox directorNameCB;
        private System.Windows.Forms.CheckBox emailCB;
        private System.Windows.Forms.Label warningLb;
    }
}

