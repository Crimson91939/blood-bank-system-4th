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
    
    public partial class donor : Form
    {
        private mysql_database _servermysql = new mysql_database();
        DataTable data;
        string em;
        public donor(string user)
        {
            InitializeComponent();
            em = user;
            DataTable data = _servermysql.display_eventdata();
            dataGridView_donor_showevents.DataSource = data;
            makepaneldisplay(1);
        }

        private void button_admin_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn openloginpage = new LogIn();
            openloginpage.ShowDialog();
        }

        public void makepaneldisplay(int choice)
        {
            panel_donor_dashboard.Visible = false;
            panel_donor_profile.Visible = false;
            panel_donor_donate.Visible = false;
            panel_donor_donate_form.Visible = false;
            panel_donor_history.Visible = false;

            if (choice == 1)
            {
                panel_donor_dashboard.Visible = true;

            }
            else if (choice == 2)
            {
                panel_donor_profile.Visible = true;
            }
            else if (choice == 3)
            {
                panel_donor_donate.Visible = true;
            }
            else if (choice == 4)
            {
                panel_donor_donate_form.Visible = true;
            }
            else if (choice == 5)
            {
                panel_donor_history.Visible = true;
            }
        }


        private void button_donor_menu_dashboard_Click(object sender, EventArgs e)
        {
            DataTable data = _servermysql.display_eventdata();
            dataGridView_donor_showevents.DataSource = data;
            makepaneldisplay(1);
        }

        private void button_donor_menu_profile_Click(object sender, EventArgs e)
        {

            try
            {
                _servermysql.start_connection();
                try
                {
                    //MessageBox.Show(em.ToString());
                    data = _servermysql.find_donor(em);
                    
                    int id = data.Rows.Count;
                    for (int i = 0; i < id; i++)
                    {
                        label_donor_id.Text = data.Rows[i]["id"].ToString();
                        label_donor_fullname.Text = data.Rows[i]["fullname"].ToString();
                        label_donor_address.Text = data.Rows[i]["address"].ToString();
                        label_donor_bloodtype.Text = data.Rows[i]["bloodtype"].ToString();
                        label_donor_date.Text = data.Rows[i]["date"].ToString();
                        label_donor_gender.Text = data.Rows[i]["gender"].ToString();
                        label_donor_regular.Text = data.Rows[i]["regular"].ToString();
                        label_donor_height.Text = data.Rows[i]["height"].ToString();
                        label_donor_weight.Text = data.Rows[i]["weight"].ToString();
                        label_donor_email.Text = data.Rows[i]["email"].ToString();
                        label_donor_donatetimes.Text = data.Rows[i]["Amount"].ToString();
                    }
                    
                }
                catch
                {
                    MessageBox.Show("Data crashed", "Warning");
                }

            }
            catch
            {
                _servermysql.end_connection();
            }
            
            makepaneldisplay(2);
        }

        private void button_donor_menu_donate_Click(object sender, EventArgs e)
        {
            makepaneldisplay(3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            makepaneldisplay(4);
        }

        private void button_donor_menu_history_Click(object sender, EventArgs e)
        {
            makepaneldisplay(5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label_donate_elisible.Visible = false;
            makepaneldisplay(3);
        }

        public static string elisible;
        public static string gender;

        private void button_donor_donate_check_Click(object sender, EventArgs e)
        {
           


            int age = Convert.ToInt32(textBox_donate_age.Text);
            int weight = Convert.ToInt32(textBox_donate_weight.Text);
            double donateheight = Convert.ToDouble(textBox_donate_height.Text);
            
            if (string.IsNullOrEmpty(Convert.ToString(age)) || string.IsNullOrWhiteSpace(Convert.ToString(age)) && string.IsNullOrEmpty(Convert.ToString(weight)) || string.IsNullOrWhiteSpace(Convert.ToString(weight)) && string.IsNullOrEmpty(Convert.ToString(donateheight)) || string.IsNullOrWhiteSpace(Convert.ToString(donateheight)))
            {
                label_donor_empty.Text = "Enter all data";
                this.ActiveControl = textBox_donate_age;
            }

            else
            {
                if (gender == "male")
                {
                    if (age >= 17)
                    {
                        if (donateheight >= 5)
                        {
                            if (weight >= 50)
                            {
                                elisible = "yes";
                            }
                            else
                            {
                                elisible = "no";
                            }
                        }
                        else if (donateheight < 5)
                        {
                            if (weight >= 53)
                            {
                                elisible = "yes";
                            }
                            else
                            {
                                elisible = "no";
                            }
                        }
                        else
                        {
                            elisible = "no";
                        }
                    }
                    else if (age < 17)
                    {
                        elisible = "no";
                    }

                }
                else if (gender == "female")
                {

                    if (age >= 17)
                    {
                        if (donateheight >= 5)
                        {
                            if (weight >= 66)
                            {
                                elisible = "yes";
                            }
                            else
                            {
                                elisible = "no";
                            }
                        }
                        else if (donateheight > 5.6)
                        {
                            if (weight >= 50)
                            {
                                elisible = "yes";
                            }
                            else
                            {
                                elisible = "no";
                            }
                        }
                        else if (donateheight < 4.8)
                        {
                            elisible = "no";
                        }
                    }
                    else if (age < 17)
                    {
                        elisible = "no";
                    }
                    else if (age > 60)
                    {
                        elisible = "no";
                    }
                }
                if (elisible == "no")
                {
                    label_donate_elisible.Visible = true;
                    label_donate_elisible.Text = "Sorry! You cannot donate your blood";
                }
                else if (elisible == "yes")
                {
                    label_donate_elisible.Visible = true;
                    label_donate_elisible.Text = "You can donate your blood";
                }
            }

            

            textBox_donate_age.Clear();
            textBox_donate_weight.Clear();
            textBox_donate_height.Clear();
            makepaneldisplay(4);

        }
        
        private void radioButton_donate_male_CheckedChanged(object sender, EventArgs e)
        {
            gender = "male";
        }

        private void radioButton_donate_female_CheckedChanged(object sender, EventArgs e)
        {
            gender = "female";
        }
    }
}
