using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1.database
{
    public class Connection_database
    {
        public MySqlConnection Server_information()
        {
            MySqlConnection mysqlserverconnection = new MySqlConnection("server=127.0.0.1;port=3306;user id=root; password=; database=college_mis");
            return mysqlserverconnection;
        }

        public int Server_Query_checkLogin(string checkuser, string checkpassword, string checkoccup, int verify_number, int choose)
        {
            MySqlConnection mysqlserverconnection = Server_information();

            mysqlserverconnection.Open();

            MySqlCommand command = mysqlserverconnection.CreateCommand();
            command.Parameters.Add(new MySqlParameter("@checkuser", checkuser));
            command.Parameters.Add(new MySqlParameter("@checkpassword", checkpassword));
            command.Parameters.Add(new MySqlParameter("@checkoccup", checkoccup));
            command.Parameters.Add(new MySqlParameter("@verfiy_number", verify_number));
            command.Parameters.Add(new MySqlParameter("@verfiy_end_number", 0));

            if (choose == 1)
            {
                command.CommandText = "select * from login_id where username=@checkuser and password=@checkpassword and access_type=@checkoccup";
                command.ExecuteNonQuery();
                DataTable dataifpresent = new DataTable();
                //it helps in adapting the server database to software data.
                MySqlDataAdapter mysqlquerydata = new MySqlDataAdapter(command);
                mysqlquerydata.Fill(dataifpresent);
                //return 1 if there is value present in datatable else 0.
                int i = Convert.ToInt32(dataifpresent.Rows.Count.ToString());
                mysqlserverconnection.Close();
                //clearning such that it doesn't conflict if the user press wrong login id info.
                // dataifpresent.Rows.Clear();
                dataifpresent.Clear();

                return i;
            }
            else if (choose == 2)
            {
                command.CommandText = "insert INTO login_id (username,password,access_type,verify_no) VALUES('" + checkuser + "','" + checkuser + "','" + checkoccup + "','" + verify_number + "'); ";
                command.ExecuteNonQuery();
                return 0;
            }
            else if (choose == 3)
            {
                command.CommandText = "delete from login_id where username=@checkuser and password=@checkpassword and access_type=@checkoccup";
                command.ExecuteNonQuery();
                return 0;
            }
            else if (choose == 4)
            {
                command.CommandText = "delete from head_info where username=@checkuser";
                command.ExecuteNonQuery();
                return 0;
            }
            else if (choose == 5)
            {
                command.CommandText = "select username from login_id where username=@checkuser";
                command.ExecuteNonQuery();

                DataTable dataifpresent = new DataTable();
                //it helps in adapting the server database to software data.
                MySqlDataAdapter mysqlquerydata = new MySqlDataAdapter(command);
                mysqlquerydata.Fill(dataifpresent);
                //return 1 if there is value present in datatable else 0.
                int i = Convert.ToInt32(dataifpresent.Rows.Count.ToString());
                mysqlserverconnection.Close();
                //clearning such that it doesn't conflict if the user press wrong login id info.
                // dataifpresent.Rows.Clear();
                dataifpresent.Clear();

                return i;

            }
            else if (choose == 6)
            {
                command.CommandText = "update login_id set password=@checkpassword , verify_no=@verfiy_end_number where username=@checkuser";
                command.ExecuteNonQuery();
                return 0;

            }
            else if (choose == 7)
            {
                command.CommandText = "select username,verify_no from login_id where verify_no=@verfiy_number and username=@checkuser";
                command.ExecuteNonQuery();

                DataTable dataifpresent = new DataTable();
                //it helps in adapting the server database to software data.
                MySqlDataAdapter mysqlquerydata = new MySqlDataAdapter(command);
                mysqlquerydata.Fill(dataifpresent);
                //return 1 if there is value present in datatable else 0.
                int i = Convert.ToInt32(dataifpresent.Rows.Count.ToString());
                mysqlserverconnection.Close();
                //clearning such that it doesn't conflict if the user press wrong login id info.
                // dataifpresent.Rows.Clear();
                dataifpresent.Clear();

                return i;

            }
            else if (choose == 8)
            {
                command.CommandText = "select username,password from login_id where password=@checkuser and username=@checkuser";
                command.ExecuteNonQuery();

                DataTable dataifpresent = new DataTable();
                //it helps in adapting the server database to software data.
                MySqlDataAdapter mysqlquerydata = new MySqlDataAdapter(command);
                mysqlquerydata.Fill(dataifpresent);
                //return 1 if there is value present in datatable else 0.
                int i = Convert.ToInt32(dataifpresent.Rows.Count.ToString());
                mysqlserverconnection.Close();
                //clearning such that it doesn't conflict if the user press wrong login id info.
                // dataifpresent.Rows.Clear();
                dataifpresent.Clear();

                return i;

            }
            else if (choose == 9)
            {
                command.CommandText = "update login_id set verify_no=@verfiy_number where username=@checkuser";
                command.ExecuteNonQuery();


            }
            else if (choose == 10)
            {
                command.CommandText = "select username,verify_no  from login_id where username=@checkuser and verify_no IS NOT NULL";
                command.ExecuteNonQuery();
                DataTable dataifpresent = new DataTable();
                //it helps in adapting the server database to software data.
                MySqlDataAdapter mysqlquerydata = new MySqlDataAdapter(command);
                mysqlquerydata.Fill(dataifpresent);
                //return 1 if there is value present in datatable else 0.
                int i = Convert.ToInt32(dataifpresent.Rows.Count.ToString());
                mysqlserverconnection.Close();
                //clearning such that it doesn't conflict if the user press wrong login id info.
                // dataifpresent.Rows.Clear();
                dataifpresent.Clear();

                return i;
            }

            return 0;



        }
        public int count_teacherid()
        {
            MySqlConnection mysqlserverconnection = Server_information();

            mysqlserverconnection.Open();

            MySqlCommand command = mysqlserverconnection.CreateCommand();
            command.CommandText = "Select * from counter_id where teacherid =(Select Max(teacherid) from counter_id)";
            command.ExecuteNonQuery();

            DataTable dataidcount = new DataTable();
            //it helps in adapting the server database to software data.
            MySqlDataAdapter mysqlquerydata = new MySqlDataAdapter(command);
            mysqlquerydata.Fill(dataidcount);

            try
            {
                int maxValue = dataidcount.AsEnumerable().Select(row => Convert.ToInt32(row["teacherid"])).Max();
                mysqlserverconnection.Close();
                return maxValue;
            }
            catch
            {
                int maxValue = 999;
                mysqlserverconnection.Close();
                return maxValue;
            }

        }
        public void max_teacherid(decimal teacherid)
        {
            MySqlConnection mysqlserverconnection = Server_information();

            mysqlserverconnection.Open();

            MySqlCommand command = mysqlserverconnection.CreateCommand();
            command.CommandText = "insert INTO counter_id(teacherid) VALUE('" + Convert.ToInt16(teacherid) + "');";
            command.ExecuteNonQuery();
            mysqlserverconnection.Close();
        }
        public void display_head_info(DataGridView dataGridView_delete, int choose, string searchteacherid)
        {
            MySqlConnection mysqlserverconnection = Server_information();

            mysqlserverconnection.Open();

            MySqlCommand command = mysqlserverconnection.CreateCommand();
            command.Parameters.Add(new MySqlParameter("@checkteacherid", searchteacherid));

            if (choose == 1)
            {
                command.CommandText = "Select * from head_info ";
            }
            else if (choose == 2)
            {
                command.CommandText = "Select * from head_info where teacherid = @checkteacherid";
            }
            else if (choose == 3)
            {
                command.CommandText = "Select * from head_info where username = @checkteacherid";
            }

            command.ExecuteNonQuery();
            MySqlDataAdapter head_info_data = new MySqlDataAdapter(command);
            DataTable head_info_datatab = new DataTable();
            DataTable head_info_value = new DataTable();
            head_info_data.Fill(head_info_datatab);
            head_info_value = head_info_datatab.DefaultView.ToTable(true, "teacherid", "department", "username", "name");


            dataGridView_delete.AutoGenerateColumns = false;
            dataGridView_delete.AutoGenerateColumns = false;
            dataGridView_delete.Columns[0].DataPropertyName = "teacherid";
            dataGridView_delete.Columns[1].DataPropertyName = "department";
            dataGridView_delete.Columns[2].DataPropertyName = "username";
            dataGridView_delete.Columns[3].DataPropertyName = "name";
            dataGridView_delete.DataSource = head_info_value;


        }
        public void delete_head(string delete_user)
        {
            MySqlConnection mysqlserverconnection = Server_information();

            mysqlserverconnection.Open();

            MySqlCommand command = mysqlserverconnection.CreateCommand();
            command.Parameters.Add(new MySqlParameter("@checkuser", delete_user));

            command.CommandText = "delete from head_info where username=@checkuser";
            command.ExecuteNonQuery();
            command.CommandText = "delete from login_id where username=@checkuser";
            command.ExecuteNonQuery();

        }
        public void approve_head(DataGridView dataGridView_approve, int choose, string approveuser, string approvename, string approveaddress, string approvecontact_no, string approveemail, string approvedept)
        {
            MySqlConnection mysqlserverconnection = Server_information();

            mysqlserverconnection.Open();

            MySqlCommand command = mysqlserverconnection.CreateCommand();
            command.Parameters.Add(new MySqlParameter("@approveuser", approveuser));
            command.Parameters.Add(new MySqlParameter("@approvename", approvename));
            command.Parameters.Add(new MySqlParameter("@approveaddress", approveaddress));
            command.Parameters.Add(new MySqlParameter("@approvecontact", approvecontact_no));
            command.Parameters.Add(new MySqlParameter("@approveemail", approveemail));
            command.Parameters.Add(new MySqlParameter("@approvedept", approvedept));

            if (choose == 1)
            {
                command.CommandText = "Select * from temp_data ";
                command.ExecuteNonQuery();
                MySqlDataAdapter head_info_data = new MySqlDataAdapter(command);
                DataTable head_info_datatab = new DataTable();
                DataTable head_info_value = new DataTable();
                head_info_data.Fill(head_info_datatab);
                head_info_value = head_info_datatab.DefaultView.ToTable(true, "name", "address", "contact_number", "email", "department", "username");


                dataGridView_approve.AutoGenerateColumns = false;

                dataGridView_approve.Columns[0].DataPropertyName = "username";
                dataGridView_approve.Columns[1].DataPropertyName = "name";
                dataGridView_approve.Columns[2].DataPropertyName = "address";
                dataGridView_approve.Columns[3].DataPropertyName = "contact_number";
                dataGridView_approve.Columns[4].DataPropertyName = "email";
                dataGridView_approve.Columns[5].DataPropertyName = "department";
                dataGridView_approve.DataSource = head_info_value;
            }
            else if (choose == 2)
            {
                command.CommandText = "delete from temp_data where username=@approveuser";
                command.ExecuteNonQuery();
            }
            else if (choose == 3)
            {

                command.CommandText = "update head_info set name= IFNULL(NULLIF(@approvename, ''),name) ," +
                    "address= IFNULL(NULLIF(@approveaddress, ''),address) ," +
                    "contact_number= IFNULL(NULLIF(@approvecontact,''),contact_number) ," +
                    "email= IFNULL(NULLIF(@approveemail,''),email) ," +
                    "department= IFNULL(NULLIF(@approvedept,''),department) " +
                    "where username=@approveuser";
                command.ExecuteNonQuery();

            }
        }
        public string get_head(int choose, string getuser)
        {

            MySqlConnection mysqlserverconnection = Server_information();

            mysqlserverconnection.Open();

            MySqlCommand command = mysqlserverconnection.CreateCommand();
            command.Parameters.Add(new MySqlParameter("@get_user", getuser));
            if (choose == 1)
            {
                command.CommandText = "Select name from head_info where username=@get_user ";
                command.ExecuteNonQuery();
            }
            else if (choose == 2)
            {
                command.CommandText = "Select email from head_info where username=@get_user ";
                command.ExecuteNonQuery();
            }
            MySqlDataAdapter head_info_data = new MySqlDataAdapter(command);
            DataTable head_info_datatab = new DataTable();

            head_info_data.Fill(head_info_datatab);

            if (choose == 1)
            {
                string head_name = (head_info_datatab.Rows[0][0]).ToString();
                return head_name;
            }
            else if (choose == 2)
            {
                string head_email = (head_info_datatab.Rows[0][0]).ToString();
                return head_email;
            }
            return "1";

        }

        public int count_active_users(int choose)
        {
            MySqlConnection mysqlserverconnection = Server_information();

            mysqlserverconnection.Open();

            MySqlCommand command = mysqlserverconnection.CreateCommand();


            if (choose == 1)
            {
                command.CommandText = "select * from head_info";
            }
            else if (choose == 2)
            {
                command.CommandText = "select * from teacher_info";
            }
            else if (choose == 3)
            {
                command.CommandText = "select * from student_info";
            }
            else if (choose == 4)
            {
                command.CommandText = "select * from assistant_info";
            }
            command.ExecuteNonQuery();
            DataTable dataifpresent = new DataTable();
            //it helps in adapting the server database to software data.
            MySqlDataAdapter mysqlquerydata = new MySqlDataAdapter(command);
            mysqlquerydata.Fill(dataifpresent);
            //return 1 if there is value present in datatable else 0.
            int i = Convert.ToInt32(dataifpresent.Rows.Count.ToString());
            mysqlserverconnection.Close();
            //clearning such that it doesn't conflict if the user press wrong login id info.
            // dataifpresent.Rows.Clear();
            dataifpresent.Clear();

            return i;
        }
        public void Close_server()
        {
            MySqlConnection mysqlserverconnection = Server_information();
            mysqlserverconnection.Close();

        }
        //kirti from here
        public DataTable Search_student(int choice, string studentid)
        {   
            MySqlConnection mysqlserverconnection = Server_information();
            MySqlCommand command = mysqlserverconnection.CreateCommand();
            command.Parameters.Add(new MySqlParameter("@checkstudent", studentid));
            if (choice == 1 )
            {
                command.CommandText = "select * from info_student where student_id = @checkstudent";
            }
            else if(choice ==2)
            {
                command.CommandText = "select * from info_teacher where teacher_id = @checkstudent";
            }
            mysqlserverconnection.Open();
            command.ExecuteNonQuery();
            DataTable dataifpresent = new DataTable();
            MySqlDataAdapter mysqlquerydata = new MySqlDataAdapter(command);
            mysqlquerydata.Fill(dataifpresent);
            mysqlserverconnection.Close();
            return dataifpresent;
            
        }
        //kirti to here
    }
}




           
                   
          