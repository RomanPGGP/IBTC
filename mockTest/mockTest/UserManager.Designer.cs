namespace mockTest
{
    partial class UserManager
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
            this.usersList = new System.Windows.Forms.ListBox();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.lUsername = new System.Windows.Forms.Label();
            this.nameLb = new System.Windows.Forms.Label();
            this.inName = new System.Windows.Forms.TextBox();
            this.LastNameLb = new System.Windows.Forms.Label();
            this.EmailLb = new System.Windows.Forms.Label();
            this.inLastName = new System.Windows.Forms.TextBox();
            this.inEmail = new System.Windows.Forms.TextBox();
            this.InsertButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.uNameChecked = new System.Windows.Forms.CheckBox();
            this.uLastNameChecked = new System.Windows.Forms.CheckBox();
            this.uEmailChecked = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // usersList
            // 
            this.usersList.FormattingEnabled = true;
            this.usersList.Location = new System.Drawing.Point(25, 21);
            this.usersList.Name = "usersList";
            this.usersList.Size = new System.Drawing.Size(459, 394);
            this.usersList.TabIndex = 0;
            // 
            // LogoutButton
            // 
            this.LogoutButton.Location = new System.Drawing.Point(700, 392);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(75, 23);
            this.LogoutButton.TabIndex = 1;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // lUsername
            // 
            this.lUsername.AutoSize = true;
            this.lUsername.Location = new System.Drawing.Point(504, 38);
            this.lUsername.Name = "lUsername";
            this.lUsername.Size = new System.Drawing.Size(10, 13);
            this.lUsername.TabIndex = 2;
            this.lUsername.Text = "-";
            // 
            // nameLb
            // 
            this.nameLb.AutoSize = true;
            this.nameLb.Location = new System.Drawing.Point(490, 107);
            this.nameLb.Name = "nameLb";
            this.nameLb.Size = new System.Drawing.Size(38, 13);
            this.nameLb.TabIndex = 3;
            this.nameLb.Text = "Name:";
            // 
            // inName
            // 
            this.inName.Location = new System.Drawing.Point(507, 123);
            this.inName.Name = "inName";
            this.inName.Size = new System.Drawing.Size(166, 20);
            this.inName.TabIndex = 4;
            // 
            // LastNameLb
            // 
            this.LastNameLb.AutoSize = true;
            this.LastNameLb.Location = new System.Drawing.Point(490, 155);
            this.LastNameLb.Name = "LastNameLb";
            this.LastNameLb.Size = new System.Drawing.Size(61, 13);
            this.LastNameLb.TabIndex = 5;
            this.LastNameLb.Text = "Last Name:";
            // 
            // EmailLb
            // 
            this.EmailLb.AutoSize = true;
            this.EmailLb.Location = new System.Drawing.Point(490, 204);
            this.EmailLb.Name = "EmailLb";
            this.EmailLb.Size = new System.Drawing.Size(33, 13);
            this.EmailLb.TabIndex = 6;
            this.EmailLb.Text = "Emai:";
            // 
            // inLastName
            // 
            this.inLastName.Location = new System.Drawing.Point(507, 171);
            this.inLastName.Name = "inLastName";
            this.inLastName.Size = new System.Drawing.Size(166, 20);
            this.inLastName.TabIndex = 7;
            // 
            // inEmail
            // 
            this.inEmail.Location = new System.Drawing.Point(507, 220);
            this.inEmail.Name = "inEmail";
            this.inEmail.Size = new System.Drawing.Size(166, 20);
            this.inEmail.TabIndex = 8;
            // 
            // InsertButton
            // 
            this.InsertButton.Location = new System.Drawing.Point(507, 332);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(75, 23);
            this.InsertButton.TabIndex = 9;
            this.InsertButton.Text = "Insert";
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(605, 332);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 10;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(700, 332);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 11;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // uNameChecked
            // 
            this.uNameChecked.AutoSize = true;
            this.uNameChecked.Location = new System.Drawing.Point(708, 126);
            this.uNameChecked.Name = "uNameChecked";
            this.uNameChecked.Size = new System.Drawing.Size(91, 17);
            this.uNameChecked.TabIndex = 12;
            this.uNameChecked.Text = "Select to Find";
            this.uNameChecked.UseVisualStyleBackColor = true;
            // 
            // uLastNameChecked
            // 
            this.uLastNameChecked.AutoSize = true;
            this.uLastNameChecked.Location = new System.Drawing.Point(708, 173);
            this.uLastNameChecked.Name = "uLastNameChecked";
            this.uLastNameChecked.Size = new System.Drawing.Size(91, 17);
            this.uLastNameChecked.TabIndex = 13;
            this.uLastNameChecked.Text = "Select to Find";
            this.uLastNameChecked.UseVisualStyleBackColor = true;
            // 
            // uEmailChecked
            // 
            this.uEmailChecked.AutoSize = true;
            this.uEmailChecked.Location = new System.Drawing.Point(708, 222);
            this.uEmailChecked.Name = "uEmailChecked";
            this.uEmailChecked.Size = new System.Drawing.Size(91, 17);
            this.uEmailChecked.TabIndex = 14;
            this.uEmailChecked.Text = "Select to Find";
            this.uEmailChecked.UseVisualStyleBackColor = true;
            // 
            // UserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uEmailChecked);
            this.Controls.Add(this.uLastNameChecked);
            this.Controls.Add(this.uNameChecked);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.inEmail);
            this.Controls.Add(this.inLastName);
            this.Controls.Add(this.EmailLb);
            this.Controls.Add(this.LastNameLb);
            this.Controls.Add(this.inName);
            this.Controls.Add(this.nameLb);
            this.Controls.Add(this.lUsername);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.usersList);
            this.Name = "UserManager";
            this.Text = "UserManager";
            this.Load += new System.EventHandler(this.UserManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox usersList;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Label lUsername;
        private System.Windows.Forms.Label nameLb;
        private System.Windows.Forms.TextBox inName;
        private System.Windows.Forms.Label LastNameLb;
        private System.Windows.Forms.Label EmailLb;
        private System.Windows.Forms.TextBox inLastName;
        private System.Windows.Forms.TextBox inEmail;
        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.CheckBox uNameChecked;
        private System.Windows.Forms.CheckBox uLastNameChecked;
        private System.Windows.Forms.CheckBox uEmailChecked;
    }
}