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
    public partial class admin : Form
    {
        private mysql_database _servermysql = new mysql_database();
        public admin()
        {
            InitializeComponent();
            makepaneldis(5);
            dataGridView_admin_displaydonordata.Visible = false;

            DataTable data = _servermysql.display_request();
            dataGridView_admin_requestlogs.DataSource = data;


        }
        public void makepaneldis(int choice)
        {
            panel_admin_adddonor.Visible = false;
            panel_admin_stock.Visible = false;
            panel_admin_update.Visible = false;
            panel_admin_history.Visible = false;
            panel_admin_dashboard.Visible = false;
            panel_admin_addhospital.Visible = false;
            panel_admin_donor.Visible = false;
            panel_admin_event.Visible = false;
            panel_admin_addevent.Visible = false;
            panel_admin_hosptal.Visible = false;
            panel_admin_addstock.Visible = false;
            panel_admin_updatedonorprofile.Visible = false;
            panel_admin_updatehospitalprofile.Visible = false;
            panel_admin_updateevent.Visible = false;

            if (choice == 1)
            {

                id = 1 + _servermysql.count_donor_id();
                textBox_admin_donorid.Text = Convert.ToString(id);
                panel_admin_adddonor.Visible = true;
                comboBox_admin_adddonor_bloodtype.Text = "A+";

            }
            else if (choice == 2)
            {
                panel_admin_stock.Visible = true;
            }
            else if (choice == 3)
            {
                panel_admin_update.Visible = true;
            }
            else if (choice == 4)
            {
                panel_admin_history.Visible = true;
            }
            else if (choice == 5)
            {
                panel_admin_dashboard.Visible = true;
            }
            else if (choice == 6)
            {
                panel_admin_addhospital.Visible = true;
            }
            else if (choice == 7)
            {
                panel_admin_donor.Visible = true;
            }
            else if (choice == 8)
            {
                panel_admin_event.Visible = true;
            }
            else if (choice == 9)
            {
                panel_admin_addevent.Visible = true;
            }
            else if (choice == 10)
            {
                panel_admin_hosptal.Visible = true;
            }
            else if (choice == 11)
            {
                panel_admin_addstock.Visible = true;
            }
            else if (choice == 12)
            {
                panel_admin_updatedonorprofile.Visible = true;
            }
            else if (choice == 13)
            {
                panel_admin_updatehospitalprofile.Visible = true;
            }
            else if (choice == 14)
            {
                panel_admin_updateevent.Visible = true;
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            makepaneldis(4);
            DataTable data = _servermysql.display_historydata();

            dataGridView_admin_historyview.DataSource = data;
            

        }

        private void button_admin_adddonor_Click(object sender, EventArgs e)
        {
            radioButton_admin_yes.Checked = false;
            radioButton_admin_no.Checked = false;
            panel_visible_onlyyes_regular.Visible = false;

            makepaneldis(1);
        }
        
        private void button_admin_stock_Click(object sender, EventArgs e)
        {
            try
            {
                _servermysql.start_connection();
                try
                {
                    int aplus = 0;
                    int aminus = 0;
                    int bplus = 0;
                    int bminus = 0;
                    int abplus = 0;
                    int abminus = 0;
                    int oplus = 0;
                    int ominus = 0;
                    DataTable data = _servermysql.stock_view();
                    int rownum = data.Rows.Count;
                    
                    for (int i = 0; i < rownum; i++)
                    {
                        string blood = data.Rows[i]["bloodtype"].ToString();
                       // MessageBox.Show(data.Rows[i]["Amount"].ToString());
                        int amount =Convert.ToInt32(data.Rows[i]["Amount"].ToString());
                        
                        if (string.Compare(blood, "A+") == 0)
                        {

                            aplus = aplus + amount;

                        }
                        else if (string.Compare(blood, "A-") == 0)
                        {

                            aminus = aminus + 1;
                        }
                        else if (string.Compare(blood, "B+") == 0)
                        {

                            bplus = bplus + 1;

                        }
                        else if (string.Compare(blood, "B-") == 0)
                        {


                            bminus = bminus + 1;
                        }
                        else if (string.Compare(blood, "AB+") == 0)
                        {

                            abplus = abplus + 1;
                        }
                        else if (string.Compare(blood, "AB-") == 0)
                        {

                            abminus = abminus + 1;
                        }
                        else if (string.Compare(blood, "O+") == 0)
                        {

                            oplus = oplus + 1;
                        }
                        else if (string.Compare(blood, "O-") == 0)
                        {

                            ominus = ominus + 1;
                        }
                    }
                    label_admin_stockap.Text = Convert.ToString(aplus);
                    label_admin_stockam.Text = Convert.ToString(aminus);
                    label_admin_stockbp.Text = Convert.ToString(bplus);
                    label_admin_stockbm.Text = Convert.ToString(bminus);
                    label_admin_stockabp.Text = Convert.ToString(abplus);
                    label_admin_stockabm.Text = Convert.ToString(abminus);
                    label_admin_stockop.Text = Convert.ToString(oplus);
                    label_admin_stockom.Text = Convert.ToString(ominus);
                }
                catch
                {
                    MessageBox.Show("Error in data");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }

            makepaneldis(2);
        }



        private void button_admin_update_Click(object sender, EventArgs e)
        {
            makepaneldis(3);

            try
            {
                _servermysql.start_connection();

                try
                {

                    DataTable dataTable = _servermysql.display_update();
                    dataGridView_admin_update.DataSource = dataTable;
                    makepaneldis(3);

                }
                catch
                {

                    MessageBox.Show("Database not available");

                }

            }
            catch
            {

                _servermysql.end_connection();

            }

        }

        private void button_admin_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn openloginpage = new LogIn();
            openloginpage.ShowDialog();
        }
        public static int id;
        private void button1_Click(object sender, EventArgs e)
        {

            string fullname = textBox_admin_donorfullname.Text;
            string weight = textBox_admin_weight.Text;
            string height = textBox_admin_height.Text;
            string bloodtype = comboBox_admin_adddonor_bloodtype.Text;
            string mobileno = textBox_admin_donornumber.Text;
            string address = textBox_admin_donoraddress.Text;
            DateTime datetemp = dateTimePicker_admin_adddoner_date.Value.Date;
            string date1 = datetemp.ToString("yyyy/MM/dd");
            
            string email = textBox_admin_donoruseremail.Text;
            string password = textBox_admin_donoruserpassword.Text;

            if (string.IsNullOrEmpty(email)||string.IsNullOrWhiteSpace(email) && string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                label_admin_adddonor_error_email.Text = "Enter email";
                label_admin_adddonor_error_password.Text = "Enter password";
                this.ActiveControl = textBox_admin_donoruseremail;
            }

            else
            {
                try
                {
                    _servermysql.start_connection();

                    try
                    {

                        _servermysql.insert_mysql_donor_info(id, fullname, bloodtype, mobileno, address, date1, email, password, gender, regular, height, weight);
                        makepaneldis(1);

                    }
                    catch
                    {
                        MessageBox.Show("Data alredy exists!");
                    }
                }
                catch
                {
                    _servermysql.end_connection();
                }
                clear();

            }
            
        }

        private void button_admin_dashboard_Click(object sender, EventArgs e)
        {

            makepaneldis(5);
            DataTable data = _servermysql.display_request();
            dataGridView_admin_requestlogs.DataSource = data;
            
        }

        private void button1_admin_addhospital_Click(object sender, EventArgs e)
        {
            DataTable data = _servermysql.display_hospitaldata();
            dataGridView_admin_hosptal_view.DataSource = data;
            makepaneldis(10);
        }
        public void clear()
        {
            textBox_admin_donorfullname.Clear();
            textBox_admin_donornumber.Clear();
            textBox_admin_donoraddress.Clear();
            textBox_admin_weight.Clear();
            textBox_admin_height.Clear();
            comboBox_admin_adddonor_bloodtype.Text = "A+";
            textBox_admin_donoruseremail.Clear();
            textBox_admin_donoruserpassword.Clear();
            radioButton_admin_male.Checked = false;
            radioButton_admin_female.Checked = false;
            radioButton_admin_yes.Checked = false;
            radioButton_admin_no.Checked = false;
            label_admin_adddonor_error_email.Text = null;
            label_admin_adddonor_error_password.Text = null;
        }

        private static string gender;

        private void radioButton_admin_male_CheckedChanged(object sender, EventArgs e)
        {
            gender = "male";
        }

        private void radioButton_admin_female_CheckedChanged(object sender, EventArgs e)
        {
            gender = "female";
        }

        private void textBox_admin_donorid_TextChanged(object sender, EventArgs e)
        {
            this.ActiveControl = dateTimePicker_admin_adddoner_date;
        }

        private static string regular;

        private void radioButton_admin_yes_CheckedChanged(object sender, EventArgs e)
        {
            regular = "yes";
            panel_visible_onlyyes_regular.Visible = true;
        }

        private void radioButton_admin_no_CheckedChanged(object sender, EventArgs e)
        {
            regular = "no";
            panel_visible_onlyyes_regular.Visible = false;
        }

        private void button_admin_hospitalsubmit_Click(object sender, EventArgs e)
        {

            DateTime datetemp1 = dateTimePicker_admin_hospitaldate.Value.Date;
            string date2 = datetemp1.ToString("yyyy/MM/dd");
            string hospitalname = textBox_admin_hospitalname.Text;
            string phonenumber = textBox_admin_hospitalphonenumber.Text;
            string address = textBox_admin_hospitaladdress.Text;
            string email = textBox_admin_hospitalemail.Text;
            string password = textBox_admin_hospitalpassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email) && string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                label_admin_hospital_email_error.Text = "Enter email";
                label_admin_hospital_password_error.Text = "Enter password";
                this.ActiveControl = textBox_admin_hospitalemail;
            }
            else
            {
                try
                {

                    _servermysql.start_connection();

                    try
                    {

                        _servermysql.insert_mysql_hospital_info(date2, hospitalname, phonenumber, address, email, password);
                        makepaneldis(6);

                    }
                    catch
                    {

                        MessageBox.Show("Data Already exist");

                    }
                }
                catch
                {

                    _servermysql.end_connection();

                }

                clear_hospital();
            }

            

        }

        public void clear_hospital()
        {

            textBox_admin_hospitalname.Clear();
            textBox_admin_hospitalphonenumber.Clear();
            textBox_admin_hospitaladdress.Clear();
            textBox_admin_hospitalemail.Clear();
            textBox_admin_hospitalpassword.Clear();
            label_admin_hospital_email_error.Text = null;
            label_admin_hospital_password_error.Text = null;

        }

        private void button_admin_donor_Click(object sender, EventArgs e)
        {
            try
            {
                _servermysql.start_connection();
                try
                {
                    DataTable dataTable = _servermysql.display_data();
                    dataGridView_admin_donorsearch.DataSource = dataTable;
                }
                catch
                {
                    MessageBox.Show("Data not found");
                }
            }

            catch
            {
                _servermysql.end_connection();
            }
            makepaneldis(7);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                _servermysql.start_connection();
                try
                {

                    string name = textBox_admin_donorsearchname.Text + '%';
                    string number = textBox_admin_donorsearchmobile.Text + '%';
                    if (string.IsNullOrWhiteSpace(number) || string.IsNullOrEmpty(number))
                    {

                        DataTable data = _servermysql.search_data(name, number, 1);
                        dataGridView_admin_donorsearch.DataSource = data;

                    }
                    else
                    {
                        DataTable data = _servermysql.search_data(name, number, 0);
                        dataGridView_admin_donorsearch.DataSource = data;
                    }

                }
                catch
                {
                    MessageBox.Show("No match");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }
            textBox_admin_donorsearchname.Clear();
            textBox_admin_donorsearchmobile.Clear();
        }

        private void button_admin_event_Click(object sender, EventArgs e)
        {

            DataTable data = _servermysql.display_eventdata();
            dataGridView_admin_eventgrid.DataSource = data;
            makepaneldis(8);
        }

        private void button_admin_addevent_Click(object sender, EventArgs e)
        {
            makepaneldis(9);
        }

        private void button_admin_eventsubmit_Click(object sender, EventArgs e)
        {
            string name = textBox_admin_eventname.Text;
            string address = textBox_admin_eventaddress.Text;
            string organizer = textBox_admin_eventorganizer.Text;
            string time = textBox_admin_eventtime.Text;
            DateTime datetemp3 = dateTimePicker_admin_eventdate.Value.Date;
            string date3 = datetemp3.ToString("yyyy/MM/dd");

            try
            {
                _servermysql.start_connection();
                try
                {
                    _servermysql.insert_mysql_event_info(name, address, time, date3, organizer);
                    makepaneldis(9);

                }
                catch
                {
                    MessageBox.Show("Data Already exists");
                }
            }

            catch
            {
                _servermysql.end_connection();
            }
            event_clear();
        }
        public void event_clear()
        {
            textBox_admin_eventname.Clear();
            textBox_admin_eventaddress.Clear();
            textBox_admin_eventorganizer.Clear();
            textBox_admin_eventtime.Clear();
        }
        public static DataTable data1;
        private void button_admin_searchdonorstock_Click(object sender, EventArgs e)
        {

            string id = textBox_admin_stockdonorID.Text;
            string name = textBox_admin_stockdonorname.Text + '%';

            try
            {
                _servermysql.start_connection();
                try
                {

                    if (string.IsNullOrWhiteSpace(id) || string.IsNullOrEmpty(id))
                    {

                        data1 = _servermysql.display_datadonor(id, 0, name);
                        int maxvalue = data1.Rows.Count;
                        displayDonor(maxvalue, data1);

                    }
                    else
                    {

                        DataTable data2 = _servermysql.display_datadonor(id, 1, name);
                        int maxvalue = data2.Rows.Count;
                        displayDonor(maxvalue, data2);

                    }

                }
                catch
                {

                    MessageBox.Show("No Match found");

                }
            }
            catch
            {
                _servermysql.end_connection();
            }

            textBox_admin_stockdonorID.Clear();
            textBox_admin_stockdonorname.Clear();

        }

        private void displayDonor(int maxvalue, DataTable datatable)
        {

            if (maxvalue > 1)
            {

                dataGridView_admin_displaydonordata.Visible = true;
                dataGridView_admin_displaydonordata.DataSource = datatable;

            }
            else
            {
                for (int i = 0; i < maxvalue; i++)
                {

                    label_admin_donorstockid.Text = datatable.Rows[i]["id"].ToString();
                    label_admin_stocknumberdonor.Text = datatable.Rows[i]["mobilenumber"].ToString();
                    label_admin_donornamestock.Text = datatable.Rows[i]["fullname"].ToString();

                }
            }

        }
        private void panel_admin_addstock_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView_admin_displaydonordata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowvalue = dataGridView_admin_displaydonordata.CurrentCell.RowIndex;

            display_datagridvalue(rowvalue);

        }
        private void display_datagridvalue(int rowvalue)
        {

            label_admin_donorstockid.Text = data1.Rows[rowvalue]["id"].ToString();
            label_admin_stocknumberdonor.Text = data1.Rows[rowvalue]["mobilenumber"].ToString();
            label_admin_donornamestock.Text = data1.Rows[rowvalue]["fullname"].ToString();
            dataGridView_admin_displaydonordata.Visible = false;

        }

        private void button_admin_addtostock_Click(object sender, EventArgs e)
        {
            try
            {
                _servermysql.start_connection();
                try
                {
                        int give_id = Convert.ToInt16(label_admin_donorstockid.Text);
                        try
                        {
                        
                            _servermysql.add_amount(give_id);
                            
                        }
                        catch
                        {
                            MessageBox.Show("Error: no data addded");
                        }
                        finally
                        {
                            label_admin_donorstockid.Text = null;
                            label_admin_stocknumberdonor.Text = null;
                            label_admin_donornamestock.Text = null;
                        }
                    
                }
                catch
                {
                    MessageBox.Show("No id found", "Warning");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }
            
            

        }

        private void button_admin_addhospital_Click(object sender, EventArgs e)
        {
            makepaneldis(6);
        }

        private void button_admin_addstock_Click(object sender, EventArgs e)
        {
            makepaneldis(11);
        }

        private void button_admin_searchhistory_Click(object sender, EventArgs e)
        {
            try
            {
                _servermysql.start_connection();
                try
                {
                    string name = textBox_admin_searchhistory.Text + '%';
                    DataTable data = _servermysql.search_historydata(name);
                    dataGridView_admin_historyview.DataSource = data;
                }
                catch
                {
                    MessageBox.Show("Data not found");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }
        }
        private static DataTable data2;

        private void button_admin_hosptal_search_Click(object sender, EventArgs e)
        {
            string number = textBox_admin_hosptal_search_number.Text + '%';
            string name = textBox_admin_hosptal_search_name.Text + '%';

            try
            {
                _servermysql.start_connection();
                try
                {

                    if (string.IsNullOrWhiteSpace(number) || string.IsNullOrEmpty(number))
                    {


                        data2 = _servermysql.search_hospital_data(name, number, 1);
                        dataGridView_admin_hosptal_view.DataSource = data2;


                    }
                    else
                    {

                        data2 = _servermysql.search_hospital_data(name, number, 0);
                        dataGridView_admin_hosptal_view.DataSource = data2;
                    }

                }
                catch
                {
                    MessageBox.Show("No Match found");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }
            textBox_admin_hosptal_search_number.Clear();
            textBox_admin_hosptal_search_name.Clear();
        }
        private static DataTable data;
        private void button_admin_updatesearch_Click(object sender, EventArgs e)
        {

            string id = textBox_admin_updatesearch_id.Text;
            string name = textBox_admin_updatesearch_fullname.Text + '%';

            try
            {
                _servermysql.start_connection();
                try
                {
                    if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
                    {

                        data = _servermysql.select_donordata(id, name, 1);
                        int rownum = data.Rows.Count;
                        display_donorupdate(rownum, data);

                    }
                    else
                    {

                        data = _servermysql.select_donordata(id, name, 0);
                        int rownum = data.Rows.Count;
                        display_donorupdate(rownum, data);

                    }
                }
                catch
                {
                    MessageBox.Show("Data not found");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }

        }
        private static int updateid;
        public void display_donorupdate(int row, DataTable datatable)
        {
            try
            {
                _servermysql.start_connection();
                try
                {
                    if (row > 1)
                    {

                        dataGridView_admin_searchprofile.Visible = true;
                        dataGridView_admin_searchprofile.DataSource = datatable;


                    }
                    else
                    {
                        for (int i = 0; i < row; i++)
                        {

                            textBox_admin_updateid.Text = data.Rows[i]["id"].ToString();
                            updateid = Convert.ToInt16(data.Rows[i]["id"].ToString());
                            textBox_admin_updatefullname.Text = data.Rows[i]["fullname"].ToString();
                            textBox_admin_updateweight.Text = data.Rows[i]["weight"].ToString();
                            textBox_admin_updateaddress.Text = data.Rows[i]["address"].ToString();
                            textBox_admin_updateheight.Text = data.Rows[i]["height"].ToString();
                            textBox_admin_updatenumber.Text = data.Rows[i]["mobilenumber"].ToString();
                            textBox_admin_updateemail.Text = data.Rows[i]["email"].ToString();
                            textBox_admin_updatepassword.Text = data.Rows[i]["password"].ToString();
                            comboBox_admin_updatebloodtype.Text = data.Rows[i]["bloodtype"].ToString();
                            if (string.Compare(data.Rows[i]["gender"].ToString(), "male") == 0)
                            {
                                radioButton_admin_updatemale.Select();
                            }
                            else
                            {
                                radioButton_admin_updatefemale.Select();
                            }
                            if (string.Compare(data.Rows[i]["regular"].ToString(), "yes") == 0)
                            {
                                radioButton_admin_updateyes.Select();
                            }
                            else
                            {
                                radioButton_admin_updateno.Select();
                            }
                            dataGridView_admin_searchprofile.Visible = false;
                            update_enter_new_data(id, 0);



                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error found");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }
            textBox_admin_updatesearch_id.Clear();
            textBox_admin_updatesearch_fullname.Clear();
        }

        private void button_admin_updatedonorinfo_Click(object sender, EventArgs e)
        {

            clearupdate();
            dataGridView_admin_searchprofile.Visible = false;
            makepaneldis(12);

        }



        private void dataGridView_admin_searchprofile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int rownumber = dataGridView_admin_searchprofile.CurrentCell.RowIndex;
            display_searchdonor(rownumber);

        }

        private void display_searchdonor(int row)
        {
            try
            {
                _servermysql.start_connection();
                try
                {

                    textBox_admin_updateid.Text = data.Rows[row]["id"].ToString();
                    updateid = Convert.ToInt16(data.Rows[row]["id"].ToString());
                    textBox_admin_updatefullname.Text = data.Rows[row]["fullname"].ToString();
                    textBox_admin_updateweight.Text = data.Rows[row]["weight"].ToString();
                    textBox_admin_updateaddress.Text = data.Rows[row]["address"].ToString();
                    textBox_admin_updateheight.Text = data.Rows[row]["height"].ToString();
                    textBox_admin_updatenumber.Text = data.Rows[row]["mobilenumber"].ToString();
                    textBox_admin_updateemail.Text = data.Rows[row]["email"].ToString();
                    textBox_admin_updatepassword.Text = data.Rows[row]["password"].ToString();
                    if (string.Compare(data.Rows[row]["gender"].ToString(), "male") == 0)
                    {
                        radioButton_admin_updatemale.Select();
                    }
                    else
                    {
                        radioButton_admin_updatefemale.Select();
                    }
                    if (string.Compare(data.Rows[row]["regular"].ToString(), "yes") == 0)
                    {
                        radioButton_admin_updateyes.Select();
                    }
                    else
                    {
                        radioButton_admin_updateno.Select();
                    }

                }
                catch
                {
                    MessageBox.Show("Error on Database");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }


        }

        public void update_enter_new_data(int id, int which)
        {

            try
            {
                _servermysql.start_connection();
                try
                {

                    string name = textBox_admin_updatefullname.Text;
                    string bloodtype = comboBox_admin_updatebloodtype.Text;
                    string mobileno = textBox_admin_updatenumber.Text;
                    string address = textBox_admin_updateaddress.Text;
                    string email = textBox_admin_updateemail.Text;
                    string password = textBox_admin_updatepassword.Text;
                    string height = textBox_admin_updateheight.Text;
                    string weight = textBox_admin_updateweight.Text;

                    _servermysql.update_donorinfo(id, name, bloodtype, mobileno, address, email, password, gender, regular, height, weight);
                    if (which == 1)
                    {
                        _servermysql.update_ok(1, name);
                    }
                    else
                    {
                        _servermysql.update_ok(0, name);
                    }

                }
                catch
                {
                    MessageBox.Show("Data didn't update");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }

        }

        private void radioButton_admin_updatemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "male";
        }

        private void radioButton_admin_updatefemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "female";
        }

        private void radioButton_admin_updateyes_CheckedChanged(object sender, EventArgs e)
        {
            regular = "yes";
            panel_make_visible_onlyyes_update.Visible = true;
        }

        private void radioButton_admin_updateno_CheckedChanged(object sender, EventArgs e)
        {
            regular = "no";
            panel_make_visible_onlyyes_update.Visible = false;

        }

        public void clearupdate()
        {
            textBox_admin_updatefullname.Clear();
            textBox_admin_updateaddress.Clear();
            textBox_admin_updateheight.Clear();
            textBox_admin_updateid.Clear();
            textBox_admin_updatenumber.Clear();
            textBox_admin_updatepassword.Clear();
            textBox_admin_updateweight.Clear();
            comboBox_admin_updatebloodtype.Text = "A+";
            radioButton_admin_updatemale.Checked = false;
            radioButton_admin_updatefemale.Checked = false;
            radioButton_admin_updateyes.Checked = false;
            radioButton_admin_updateno.Checked = false;
            textBox_admin_updateemail.Clear();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                _servermysql.start_connection();
                try
                {
                    DataTable dataTable = _servermysql.display_data();
                    dataGridView_admin_donorsearch.DataSource = dataTable;
                }
                catch
                {
                    MessageBox.Show("Data not found");
                }
            }

            catch
            {
                _servermysql.end_connection();
            }

            makepaneldis(7);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                _servermysql.start_connection();
                try
                {
                    DataTable dataTable = _servermysql.display_data();
                    dataGridView_admin_donorsearch.DataSource = dataTable;
                }
                catch
                {
                    MessageBox.Show("Data not found");
                }
            }

            catch
            {
                _servermysql.end_connection();
            }
            makepaneldis(7);
           // makepaneldis(7);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            DataTable data = _servermysql.display_hospitaldata();
            dataGridView_admin_hosptal_view.DataSource = data;

            makepaneldis(10);
        }

        private void button_admin_updatehospital_Click(object sender, EventArgs e)
        {
            string number = textBox_admin_updatehospitalsearchnumber.Text + '%';
            string name = textBox_admin_searchname.Text + '%';

            try
            {
                _servermysql.start_connection();
                try
                {
                    if (string.IsNullOrEmpty(number) || string.IsNullOrWhiteSpace(number))
                    {

                        data = _servermysql.search_hospital_data(name, number, 1);
                        int rownum = data.Rows.Count;
                        display_hospitalupdate(rownum, data);

                    }
                    else
                    {

                        data = _servermysql.search_hospital_data(name, number, 0);
                        int rownum = data.Rows.Count;
                        display_hospitalupdate(rownum, data);

                    }
                }
                catch
                {
                    MessageBox.Show("Data not found");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }
            textBox_admin_updatehospitalname.Clear();
            textBox_admin_updatehospitalnumber.Clear();
            textBox_admin_updatehospitaladdress.Clear();
            textBox_admin_updatehospitalemail.Clear();
            textBox_admin_updatehospitalpassword.Clear();

        }
        public static string namehospital;
        public void display_hospitalupdate(int row, DataTable data)
        {
            try
            {
                _servermysql.start_connection();
                try
                {
                    
                    if (row > 1)
                    {
                        dataGridView_admin_updatehospitalgrid.Visible = true;
                        dataGridView_admin_updatehospitalgrid.DataSource = data;

                    }
                    else
                    {
                        for (int i = 0; i < row; i++)
                        {

                            textBox_admin_updatehospitalname.Text = data.Rows[i]["hospitalname"].ToString();
                            namehospital = data.Rows[i]["hospitalname"].ToString();
                            textBox_admin_updatehospitaladdress.Text = data.Rows[i]["address"].ToString();
                            textBox_admin_updatehospitalnumber.Text = data.Rows[i]["phonenumber"].ToString();
                            textBox_admin_updatehospitalemail.Text = data.Rows[i]["email"].ToString();
                            textBox_admin_updatehospitalpassword.Text = data.Rows[i]["password"].ToString();
                            dataGridView_admin_updatehospitalgrid.Visible = false;

                            update_enter_new_data_hospital(namehospital, 0);


                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error found");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }
            textBox_admin_updatehospitalsearchnumber.Clear();
            textBox_admin_searchname.Clear();
        }

        public void update_enter_new_data_hospital(string hospital, int which)
        {
            try
            {
                _servermysql.start_connection();
                try
                {

                    string name = textBox_admin_updatehospitalname.Text;
                    string mobileno = textBox_admin_updatehospitalnumber.Text;
                    string address = textBox_admin_updatehospitaladdress.Text;
                    string email = textBox_admin_updatehospitalemail.Text;
                    string password = textBox_admin_updatehospitalpassword.Text;


                    _servermysql.update_hospitalinfo(name, mobileno, address, email, password);
                    if (which == 1)
                    {
                        _servermysql.updatehospital_ok(1, name);
                    }
                    else
                    {
                        _servermysql.updatehospital_ok(0, name);
                    }
                }
                catch
                {
                    MessageBox.Show("Data didn't update");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }

        }
        private void display_searchhospital(int row)
        {
            try
            {
                _servermysql.start_connection();
                try
                {

                    textBox_admin_updatehospitalname.Text = data.Rows[row]["hospitalname"].ToString();
                    namehospital = data.Rows[row]["hospitalname"].ToString();
                    textBox_admin_updatehospitaladdress.Text = data.Rows[row]["address"].ToString();
                    textBox_admin_updatehospitalnumber.Text = data.Rows[row]["phonenumber"].ToString();
                    textBox_admin_updatehospitalemail.Text = data.Rows[row]["email"].ToString();
                    textBox_admin_updatehospitalpassword.Text = data.Rows[row]["password"].ToString();
                    update_enter_new_data_hospital(namehospital, 1);

                }
                catch
                {
                    MessageBox.Show("Error on Database");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }

        }

        private void dataGridView_admin_updatehospitalgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rownumber = dataGridView_admin_updatehospitalgrid.CurrentCell.RowIndex;
            display_searchhospital(rownumber);
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            textBox_admin_updatehospitalname.Clear();
            textBox_admin_updatehospitalnumber.Clear();
            textBox_admin_updatehospitaladdress.Clear();
            textBox_admin_updatehospitalemail.Clear();
            textBox_admin_updatehospitalpassword.Clear();
            dataGridView_admin_updatehospitalgrid.Visible = false;
            makepaneldis(13);

        }

        private void button_admin_updatehospitalback_Click(object sender, EventArgs e)
        {
            try
            {
                _servermysql.start_connection();
                try
                {
                    DataTable data = _servermysql.display_hospitaldata();
                    dataGridView_admin_hosptal_view.DataSource = data;
                }
                catch
                {
                    MessageBox.Show("Database not found");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }

            
            makepaneldis(10);
        }

        private void button_admin_updatehospitalinfo_Click(object sender, EventArgs e)
        {
            update_enter_new_data_hospital(namehospital, 0);
            textBox_admin_updatehospitalname.Clear();
            textBox_admin_updatehospitalnumber.Clear();
            textBox_admin_updatehospitaladdress.Clear();
            textBox_admin_updatehospitalemail.Clear();
            textBox_admin_updatehospitalpassword.Clear();

        }

        private void textBox_admin_updatehospitalpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_admin_donorsubmit1_Click(object sender, EventArgs e)
        {

            string fullname = textBox_admin_donorfullname.Text;
            string weight = textBox_admin_weight.Text;
            string height = textBox_admin_height.Text;
            string bloodtype = comboBox_admin_adddonor_bloodtype.Text;
            string mobileno = textBox_admin_donornumber.Text;
            string address = textBox_admin_donoraddress.Text;

            DateTime datetemp = dateTimePicker_admin_adddoner_date.Value.Date;
            string date1 = datetemp.ToString("yyyy/MM/dd");
            string email = textBox_admin_donoruseremail.Text;
            string password = textBox_admin_donoruserpassword.Text;

            try
            {
                _servermysql.start_connection();

                try
                {

                    _servermysql.insert_mysql_donor_info(id, fullname, bloodtype, mobileno, address, date1, email, password, gender, regular, height, weight);
                    makepaneldis(1);

                }
                catch
                {
                    MessageBox.Show("Data alredy exists!");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }
            clear();
        }

        private void button_admin_updatedonorprofile_Click(object sender, EventArgs e)
        {
            update_enter_new_data(updateid, 1);
            clearupdate();
        }

        private void button_admin_updatedonorprofile1_Click(object sender, EventArgs e)
        {

            textBox_admin_updateemail.Text = "_";
            textBox_admin_updatepassword.Text = "_";
            update_enter_new_data(updateid, 1);
            clearupdate();
        }

        private void button_admin_updateevent_search_Click(object sender, EventArgs e)
        {

            string name = textBox_admin_updateevent_searchname.Text + '%';
            string organizer = textBox_admin_updateevent_searchorganizer.Text + '%';
            
            try
            {
                _servermysql.start_connection();
                
                try
                {
                    
                    if (string.IsNullOrEmpty(this.textBox_admin_updateevent_searchorganizer.Text) || string.IsNullOrWhiteSpace(this.textBox_admin_updateevent_searchorganizer.Text))
                    {
                        
                        data = _servermysql.select_eventdata(organizer, name, 0);
                        int rownum = data.Rows.Count;
                       // MessageBox.Show(name);
                        display_eventupdate(rownum, data);

                    }
                    else
                    {
                        
                        data = _servermysql.select_eventdata(organizer, name, 1);  
                        int rownum = data.Rows.Count;
                        display_eventupdate(rownum, data);

                    }
                }
                catch
                {
                    MessageBox.Show("Event not found");
                }
                
            }
            catch
            {
                _servermysql.end_connection();
            }

        }

        private static int updatename;
        public void display_eventupdate(int row, DataTable datatable)
        {
            try
            {
                _servermysql.start_connection();
                try
                {
                    if (row > 1)
                    {

                        dataGridView_admin_updateevent.Visible = true;
                        dataGridView_admin_updateevent.DataSource = datatable;
                        
                    }
                    else
                    {
                        for (int i = 0; i < row; i++)
                        {

                            textBox_admin_updateevent_name.Text = data.Rows[i]["e_name"].ToString();
                            updatename = Convert.ToInt32( data.Rows[i]["event_id"].ToString());
                            textBox_admin_updateevent_organizer.Text = data.Rows[i]["e_organizer"].ToString();
                            textBox_admin_updateevent_address.Text = data.Rows[i]["e_address"].ToString();
                            textBox_admin_updateevent_time.Text = data.Rows[i]["e_time"].ToString();
                            textBox_admin_updateevent_date.Text = data.Rows[i]["e_date"].ToString();
                            dataGridView_admin_updateevent.Visible = false;
                            update_enter_new_data_event(updatename, 0);
                            
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error found");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }
            textBox_admin_updateevent_searchname.Clear();
            textBox_admin_updateevent_searchorganizer.Clear();
        }

        public void update_enter_new_data_event(int id, int which)
        {
            try
            {
                _servermysql.start_connection();
                try
                {

                    string name = textBox_admin_updateevent_name.Text;
                    string organizer = textBox_admin_updateevent_organizer.Text;
                    string address = textBox_admin_updateevent_address.Text;
                    string time = textBox_admin_updateevent_time.Text;
                    string date = textBox_admin_updateevent_date.Text;


                    _servermysql.update_eventinfo(id,name, organizer, address, time, date);
                    if (which == 1)
                    {
                        _servermysql.updateevent_ok(1, name);
                    }
                    else
                    {
                        _servermysql.updateevent_ok(0, name);
                    }
                }
                catch
                {
                    MessageBox.Show("Data didn't update");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }
            textBox_admin_updateevent_searchname.Clear();
            textBox_admin_updateevent_searchorganizer.Clear();
        }

        private void button_admin_updateevent_back_Click(object sender, EventArgs e)
        {

            try
            {
                _servermysql.start_connection();
                try
                {
                    DataTable data = _servermysql.display_eventdata();
                    dataGridView_admin_eventgrid.DataSource = data;
                }
                catch
                {
                    MessageBox.Show("Database Not open");
                }
                    
            }
            catch
            {
                _servermysql.end_connection();
            }

            makepaneldis(8);
        }

        private void button_admin_updateevent_Click(object sender, EventArgs e)
        {

            textBox_admin_updateevent_name.Clear();
            textBox_admin_updateevent_organizer.Clear();
            textBox_admin_updateevent_address.Clear();
            textBox_admin_updateevent_time.Clear();
            textBox_admin_updateevent_date.Clear();
            dataGridView_admin_updateevent.Visible = false;
            makepaneldis(14);
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            try
            {
                _servermysql.start_connection();
                try
                {
                    int aplus = 0;
                    int aminus = 0;
                    int bplus = 0;
                    int bminus = 0;
                    int abplus = 0;
                    int abminus = 0;
                    int oplus = 0;
                    int ominus = 0;
                    DataTable data = _servermysql.stock_view();
                    int rownum = data.Rows.Count;
                    for (int i = 0; i < rownum; i++)
                    {
                        string blood = data.Rows[i]["bloodtype"].ToString();
                        if (string.Compare(blood, "A+") == 0)
                        {

                            aplus = aplus + 1;

                        }
                        else if (string.Compare(blood, "A-") == 0)
                        {

                            aminus = aminus + 1;
                        }
                        else if (string.Compare(blood, "B+") == 0)
                        {

                            bplus = bplus + 1;

                        }
                        else if (string.Compare(blood, "B-") == 0)
                        {


                            bminus = bminus + 1;
                        }
                        else if (string.Compare(blood, "AB+") == 0)
                        {

                            abplus = abplus + 1;
                        }
                        else if (string.Compare(blood, "AB-") == 0)
                        {

                            abminus = abminus + 1;
                        }
                        else if (string.Compare(blood, "O+") == 0)
                        {

                            oplus = oplus + 1;
                        }
                        else if (string.Compare(blood, "O-") == 0)
                        {

                            ominus = ominus + 1;
                        }
                    }
                    label_admin_stockap.Text = Convert.ToString(aplus);
                    label_admin_stockam.Text = Convert.ToString(aminus);
                    label_admin_stockbp.Text = Convert.ToString(bplus);
                    label_admin_stockbm.Text = Convert.ToString(bminus);
                    label_admin_stockabp.Text = Convert.ToString(abplus);
                    label_admin_stockabm.Text = Convert.ToString(abminus);
                    label_admin_stockop.Text = Convert.ToString(oplus);
                    label_admin_stockom.Text = Convert.ToString(ominus);
                }
                catch
                {
                    MessageBox.Show("Error in data");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }

            makepaneldis(2);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                _servermysql.start_connection();
                try
                {
                    DataTable data = _servermysql.display_eventdata();
                    dataGridView_admin_eventgrid.DataSource = data;
                }
                catch
                {
                    MessageBox.Show("Database Not open");
                }

            }
            catch
            {
                _servermysql.end_connection();
            }

            makepaneldis(8);
        }

        private void dataGridView_admin_updateevent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           int row = dataGridView_admin_updateevent.CurrentCell.RowIndex;
            /*textBox_admin_updateevent_name.Clear();
            textBox_admin_updateevent_organizer.Clear();
            textBox_admin_updateevent_address.Clear();
            textBox_admin_updateevent_time.Clear();
            textBox_admin_updateevent_date.Clear();*/
            display_eventdata(row);
        }

        public void display_eventdata(int i)
        {

            try
            {
                _servermysql.start_connection();
                try
                {
                    
                    textBox_admin_updateevent_name.Text = data.Rows[i]["e_name"].ToString();
                   // MessageBox.Show("God");
                    updatename =Convert.ToInt16( data.Rows[i]["event_id"].ToString());
                   // MessageBox.Show("God");
                    textBox_admin_updateevent_organizer.Text = data.Rows[i]["e_organizer"].ToString();
                    textBox_admin_updateevent_address.Text = data.Rows[i]["e_address"].ToString();
                    textBox_admin_updateevent_time.Text = data.Rows[i]["e_time"].ToString();
                    textBox_admin_updateevent_date.Text = data.Rows[i]["e_date"].ToString();
                    
                    update_enter_new_data_event(updatename, 0);
                }
                catch
                {
                    MessageBox.Show("No database found");
                }
            }
            catch
            {
                _servermysql.end_connection();
            }
            
        }

        private void button_admin_updateevent_submit_Click(object sender, EventArgs e)
        {
            update_enter_new_data_event(updatename, 1);
            textBox_admin_updateevent_name.Clear();
            textBox_admin_updateevent_organizer.Clear();
            textBox_admin_updateevent_address.Clear();
            textBox_admin_updateevent_time.Clear();
            textBox_admin_updateevent_date.Clear();
        }
    }
    
} 
