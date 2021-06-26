using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blood_bank.mysql;


namespace Blood_bank
{
    public partial class LogIn : Form
    {
        private mysql_database _servermysql = new mysql_database();
        public LogIn()
        {
            InitializeComponent();
        }
        public static string readpwd;//= textBox_login_password.Text;
        public static string reademail;// = textBox_login_user.Text;
        private void button1_Click(object sender, EventArgs e)
        {
            
              readpwd = textBox_login_password.Text;
             reademail = textBox_login_user.Text;

            
            
            try
            {
                _servermysql.start_connection();
                try
                {
                    
                    if (string.Compare(readpwd, "admin") == 0 && string.Compare(reademail, "admin") == 0)
                    {

                        this.Hide();
                        admin openadminpage = new admin();
                        openadminpage.ShowDialog();
                        this.Close();
                        
                    }
                    else if (string.Compare(reademail, "_") == 0 && string.Compare(readpwd, "_") == 0)
                    {
                        label_login_error_message.Text = "No Donor with this Email and Password found";
                       // MessageBox.Show("No Donor with this Email and Password found", "Warning");
                        clear();
                        
                    }
                    else if (string.IsNullOrEmpty(reademail) || string.IsNullOrWhiteSpace(reademail))
                    {
                        label_login_error_message.Text = "Email and Password is empty";
                        clear();
                    }
                    else if (string.IsNullOrEmpty(readpwd) || string.IsNullOrWhiteSpace(readpwd))
                    {
                        label_login_error_message.Text = "Email and Password is empty";
                        clear();
                    }
                    else
                    {
                      
                        if (value == 2)
                        {
                            string ema = _servermysql.login_hospital(reademail, readpwd);
                           
                            if (ema == "0")
                            {
                                label_login_error_message.Text = "No Hospital with this Email and Password found";
                              //  MessageBox.Show("No Hospital with this Email and Password found", "Warning");
                                clear();
                                value = 0;
                            }
                            else 
                            {
                                value = 0;
                                this.Hide();
                                hospital openhospitalpage = new hospital(reademail);
                                openhospitalpage.ShowDialog();
                                this.Close();
                            }
                        }
                        else if (value == 1)
                        {
                            
                            string ema = _servermysql.login_donor(reademail, readpwd);
                            
                            if (ema == "0")
                            {
                                label_login_error_message.Text = "No Donor with this Email and Password found";
                               // MessageBox.Show("No Donor with this Email and Password found", "Warning");
                                clear();
                                value = 0;
                            }

                            else
                            {
                                value = 0;
                                this.Hide();
                                donor opendonorpage = new donor(reademail);
                                opendonorpage.ShowDialog();
                                this.Close();
                               
                            }
                            
                        }
                        else
                        {
                            label_login_error_message.Text = "Email and Password is empty";
                            //MessageBox.Show("Email and Password is empty", "Warning");
                            clear();
                        }



                    }
                }
                catch
                {
                    
                    MessageBox.Show("Database not found", "Warning");

                }
            }
            catch
            {
                _servermysql.end_connection();
            }

            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox_login_pwd_TextChanged(object sender, EventArgs e)
        {

        }
        public static int value;
        private void radioButton_login_donor_CheckedChanged(object sender, EventArgs e)
        {
            value = 1;
        }

        private void radioButton_login_hospital_CheckedChanged(object sender, EventArgs e)
        {
            value = 2;
        }

       
        public void clear()
        {
            textBox_login_password.Clear();
            textBox_login_user.Clear();
            radioButton_login_donor.Checked = false;
            radioButton_login_hospital.Checked = false;
        }
    }
}
