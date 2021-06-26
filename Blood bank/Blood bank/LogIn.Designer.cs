namespace Blood_bank
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.textBox_login_user = new System.Windows.Forms.TextBox();
            this.textBox_login_password = new System.Windows.Forms.TextBox();
            this.label_login_username = new System.Windows.Forms.Label();
            this.label_login_password = new System.Windows.Forms.Label();
            this.button_login_login = new System.Windows.Forms.Button();
            this.pictureBox_login_logo = new System.Windows.Forms.PictureBox();
            this.radioButton_login_donor = new System.Windows.Forms.RadioButton();
            this.radioButton_login_hospital = new System.Windows.Forms.RadioButton();
            this.label_login_error_message = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_login_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_login_user
            // 
            this.textBox_login_user.Location = new System.Drawing.Point(327, 87);
            this.textBox_login_user.Name = "textBox_login_user";
            this.textBox_login_user.Size = new System.Drawing.Size(259, 20);
            this.textBox_login_user.TabIndex = 0;
            this.textBox_login_user.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_login_password
            // 
            this.textBox_login_password.Location = new System.Drawing.Point(327, 122);
            this.textBox_login_password.Name = "textBox_login_password";
            this.textBox_login_password.PasswordChar = '*';
            this.textBox_login_password.Size = new System.Drawing.Size(259, 20);
            this.textBox_login_password.TabIndex = 1;
            this.textBox_login_password.TextChanged += new System.EventHandler(this.textBox_login_pwd_TextChanged);
            // 
            // label_login_username
            // 
            this.label_login_username.AutoSize = true;
            this.label_login_username.Font = new System.Drawing.Font("Font Awesome 5 Free Solid", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_login_username.ForeColor = System.Drawing.Color.Red;
            this.label_login_username.Location = new System.Drawing.Point(289, 83);
            this.label_login_username.Name = "label_login_username";
            this.label_login_username.Size = new System.Drawing.Size(33, 25);
            this.label_login_username.TabIndex = 2;
            this.label_login_username.Text = "user";
            // 
            // label_login_password
            // 
            this.label_login_password.AutoSize = true;
            this.label_login_password.Font = new System.Drawing.Font("Font Awesome 5 Free Solid", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_login_password.ForeColor = System.Drawing.Color.Red;
            this.label_login_password.Location = new System.Drawing.Point(288, 116);
            this.label_login_password.Name = "label_login_password";
            this.label_login_password.Size = new System.Drawing.Size(33, 25);
            this.label_login_password.TabIndex = 3;
            this.label_login_password.Text = "lock";
            // 
            // button_login_login
            // 
            this.button_login_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_login_login.ForeColor = System.Drawing.Color.Red;
            this.button_login_login.Location = new System.Drawing.Point(478, 185);
            this.button_login_login.Name = "button_login_login";
            this.button_login_login.Size = new System.Drawing.Size(108, 29);
            this.button_login_login.TabIndex = 4;
            this.button_login_login.Text = "LogIn";
            this.button_login_login.UseVisualStyleBackColor = true;
            this.button_login_login.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox_login_logo
            // 
            this.pictureBox_login_logo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_login_logo.Image")));
            this.pictureBox_login_logo.Location = new System.Drawing.Point(45, 50);
            this.pictureBox_login_logo.Name = "pictureBox_login_logo";
            this.pictureBox_login_logo.Size = new System.Drawing.Size(200, 149);
            this.pictureBox_login_logo.TabIndex = 5;
            this.pictureBox_login_logo.TabStop = false;
            // 
            // radioButton_login_donor
            // 
            this.radioButton_login_donor.AutoSize = true;
            this.radioButton_login_donor.Location = new System.Drawing.Point(327, 157);
            this.radioButton_login_donor.Name = "radioButton_login_donor";
            this.radioButton_login_donor.Size = new System.Drawing.Size(54, 17);
            this.radioButton_login_donor.TabIndex = 2;
            this.radioButton_login_donor.TabStop = true;
            this.radioButton_login_donor.Text = "Donor";
            this.radioButton_login_donor.UseVisualStyleBackColor = true;
            this.radioButton_login_donor.CheckedChanged += new System.EventHandler(this.radioButton_login_donor_CheckedChanged);
            // 
            // radioButton_login_hospital
            // 
            this.radioButton_login_hospital.AutoSize = true;
            this.radioButton_login_hospital.Location = new System.Drawing.Point(478, 157);
            this.radioButton_login_hospital.Name = "radioButton_login_hospital";
            this.radioButton_login_hospital.Size = new System.Drawing.Size(63, 17);
            this.radioButton_login_hospital.TabIndex = 3;
            this.radioButton_login_hospital.TabStop = true;
            this.radioButton_login_hospital.Text = "Hospital";
            this.radioButton_login_hospital.UseVisualStyleBackColor = true;
            this.radioButton_login_hospital.CheckedChanged += new System.EventHandler(this.radioButton_login_hospital_CheckedChanged);
            // 
            // label_login_error_message
            // 
            this.label_login_error_message.AutoSize = true;
            this.label_login_error_message.BackColor = System.Drawing.Color.White;
            this.label_login_error_message.Location = new System.Drawing.Point(328, 61);
            this.label_login_error_message.Name = "label_login_error_message";
            this.label_login_error_message.Size = new System.Drawing.Size(0, 13);
            this.label_login_error_message.TabIndex = 6;
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(614, 269);
            this.Controls.Add(this.label_login_error_message);
            this.Controls.Add(this.radioButton_login_hospital);
            this.Controls.Add(this.radioButton_login_donor);
            this.Controls.Add(this.pictureBox_login_logo);
            this.Controls.Add(this.button_login_login);
            this.Controls.Add(this.label_login_password);
            this.Controls.Add(this.label_login_username);
            this.Controls.Add(this.textBox_login_password);
            this.Controls.Add(this.textBox_login_user);
            this.ForeColor = System.Drawing.Color.Red;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LogIn";
            this.Text = "LogIn";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_login_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_login_user;
        private System.Windows.Forms.TextBox textBox_login_password;
        private System.Windows.Forms.Label label_login_username;
        private System.Windows.Forms.Label label_login_password;
        private System.Windows.Forms.Button button_login_login;
        private System.Windows.Forms.PictureBox pictureBox_login_logo;
        private System.Windows.Forms.RadioButton radioButton_login_donor;
        private System.Windows.Forms.RadioButton radioButton_login_hospital;
        private System.Windows.Forms.Label label_login_error_message;
    }
}

