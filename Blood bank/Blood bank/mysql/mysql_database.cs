using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blood_bank.mysql
{
    class mysql_database
    {
        public MySqlConnection start_connection()
        {
            MySqlConnection mysqlserverconnection = new MySqlConnection("server=127.0.0.1;port=3306;user id=root; password=; database=bloodbank");
            return mysqlserverconnection;
        }
        public void insert_mysql_donor_info(int id, string fullname, string bloodtype, string mobileno, string address, string date1, string email, string password, string gender, string regular, string height, string weight)
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand command = mysqlserverconnection.CreateCommand();
            command.CommandText = "insert INTO donor_info (id,fullname,bloodtype,mobilenumber,address,date,email,password,gender,regular,height,weight) VALUES('" + id + "','" + fullname + "','" + bloodtype + "','" + mobileno + "','" + address + "','" + date1 + "','" + email + "','" + password + "','" + gender + "','" + regular + "','" + height + "','" + weight + "');";
            command.ExecuteNonQuery();
            string time = timeofday();
            string joined = "Donor added";
            command.CommandText = "insert INTO history_info (Time,Date,Title,Action)VALUES('" + time + "','" + date1 + "','" + fullname + "', '" + joined + "')";
            command.ExecuteNonQuery();
            string joined_D = "Donor";
            command.CommandText = "insert INTO update_info (date,name,action)VALUES('" + date1 + "','" + fullname + "', '" + joined_D + "')";
            command.ExecuteNonQuery();
            mysqlserverconnection.Close();
        }

        public void insert_mysql_hospital_info(string date2, string hospitalname, string phonenumber, string address, string email, string password)
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand command = mysqlserverconnection.CreateCommand();
            command.CommandText = "insert INTO hospital_info (date,hospitalname,phonenumber,address,email,password)VALUES('" + date2 + "','" + hospitalname + "','" + phonenumber + "','" + address + "','" + email + "','" + password + "');";
            command.ExecuteNonQuery();
            string time = timeofday();
            string joined = "Hospital added";
            command.CommandText = "insert INTO history_info (Time,Date,Title,Action)VALUES('" + time + "','" + date2 + "','" + hospitalname + "', '" + joined + "' )";
            command.ExecuteNonQuery();
            string joined_H = "Hospital";
            command.CommandText = "insert INTO update_info (date,name,action)VALUES('" + date2 + "','" + hospitalname + "', '" + joined_H + "')";
            command.ExecuteNonQuery();
            mysqlserverconnection.Close();
        }

        public void insert_mysql_event_info(string name, string address, string time, string date3, string organizer)
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand command = mysqlserverconnection.CreateCommand();
            command.CommandText = "insert INTO event_info (e_name,e_address,e_time,e_date,e_organizer)VALUES('" + name + "','" + address + "','" + time + "','" + date3 + "','" + organizer + "')";
            command.ExecuteNonQuery();
            string time1 = timeofday();
            string event1 = "Event added";
            command.CommandText = "insert INTO history_info (Time,Date,Title,Action)VALUES('" + time1 + "','" + date3 + "','" + name + "', '" + event1 + "' )";
            command.ExecuteNonQuery();
            string joined_E = "Event";
            command.CommandText = "insert INTO update_info (date,name,action)VALUES('" + date3 + "','" + name + "', '" + joined_E + "')";
            command.ExecuteNonQuery();
            mysqlserverconnection.Close();
        }

        public int count_donor_id()
        {
            MySqlConnection mysqlserverconnection = start_connection();

            mysqlserverconnection.Open();

            MySqlCommand command = mysqlserverconnection.CreateCommand();
            command.CommandText = "Select id from donor_info where id =(Select Max(id) from donor_info)";
            command.ExecuteNonQuery();

            DataTable dataidcount = new DataTable();
            //it helps in adapting the server database to software data.
            MySqlDataAdapter mysqlquerydata = new MySqlDataAdapter(command);
            mysqlquerydata.Fill(dataidcount);

            try
            {
                int maxValue = dataidcount.AsEnumerable().Select(row => Convert.ToInt32(row["id"])).Max();
                mysqlserverconnection.Close();
                return maxValue;
            }
            catch
            {
                int maxValue = 0;
                mysqlserverconnection.Close();
                return maxValue;
            }

        }
        public void end_connection()
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Close();
        }

        // constructor of class MySqlConnection

        public DataTable display_data()
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from donor_info";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            MySqlDataAdapter dataadp = new MySqlDataAdapter(cmd);
            dataadp.Fill(dta);
            mysqlserverconnection.Close();
            return dta;

        }

        public DataTable search_data(string name, string number, int choice)
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (choice == 1)
            {
                cmd.CommandText = "select * from donor_info where fullname like '" + name + "'";
            }
            else
            {
                cmd.CommandText = "select * from donor_info where mobilenumber like '" + number + "'";
            }

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            mysqlserverconnection.Close();
            return dt;
        }


        public DataTable display_datadonor(string id, int choice, string name)
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (choice == 1)
            {
                cmd.CommandText = "select * from donor_info where id = '" + id + "' ";
            }
            else
            {
                cmd.CommandText = "select * from donor_info where fullname like '" + name + "' ";
            }
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            MySqlDataAdapter dataadp = new MySqlDataAdapter(cmd);
            dataadp.Fill(dta);
            mysqlserverconnection.Close();
            return dta;
        }

        public void add_amount(int check_id)
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from donor_info where id = '" + check_id + "' ";

            cmd.ExecuteNonQuery();
            mysqlserverconnection.Close();
            DataTable dta = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dta);
            int max = Convert.ToInt16(dta.Rows[0]["Amount"].ToString());
            max = max + 1;
            
            string name = dta.Rows[0]["fullname"].ToString();
            mysqlserverconnection.Open();
            MySqlCommand cmd2 = mysqlserverconnection.CreateCommand();
            cmd2.CommandType = CommandType.Text;

            cmd2.CommandText = "update donor_info set Amount='" + max + "' where id = '" + check_id + "' ";
            cmd2.ExecuteNonQuery();
            mysqlserverconnection.Close();

            mysqlserverconnection.Open();
            MySqlCommand cmd1 = mysqlserverconnection.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            string time = timeofday();
            string amount = "Amount added";
            cmd1.CommandText = "insert INTO history_info (Time,Title,Action)VALUES('" + time + "','" + name + "', '" + amount + "' );";
            cmd1.ExecuteNonQuery();
            mysqlserverconnection.Close();
        }

        public DataTable display_eventdata()
        {

            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from event_info";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            MySqlDataAdapter dataadp = new MySqlDataAdapter(cmd);
            dataadp.Fill(dta);
            mysqlserverconnection.Close();
            return dta;

        }

        

        public DataTable display_historydata()
        {

            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from history_info";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            MySqlDataAdapter dataadp = new MySqlDataAdapter(cmd);
            dataadp.Fill(dta);
            mysqlserverconnection.Close();
            return dta;

        }

        public string timeofday()
        {
            string time = null;
            DateTime now = DateTime.Now;
            int hour = now.Hour;
            int min = now.Minute;
            time = hour.ToString() + ":" + min.ToString();
            return time;
        }

        public DataTable search_historydata(string name)
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from history_info where Title like '" + name + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            mysqlserverconnection.Close();
            return dt;
        }

        public DataTable display_hospitaldata()
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from hospital_info";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            MySqlDataAdapter dataadp = new MySqlDataAdapter(cmd);
            dataadp.Fill(dta);
            mysqlserverconnection.Close();
            return dta;

        }

        public DataTable search_hospital_data(string name, string number, int choice)
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (choice == 1)
            {
                cmd.CommandText = "select * from hospital_info where hospitalname like '" + name + "'";
            }
            else
            {
                cmd.CommandText = "select * from hospital_info where phonenumber like '" + number + "'";
            }

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            mysqlserverconnection.Close();
            return dt;
        }

        public DataTable select_donordata(string id, string name, int choice)
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (choice == 1)
            {
                cmd.CommandText = "select * from donor_info where fullname like  '" + name + "'";
            }
            else
            {
                cmd.CommandText = "select * from donor_info where id = '" + id + "'";
            }

            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            MySqlDataAdapter dataadp = new MySqlDataAdapter(cmd);
            dataadp.Fill(dta);
            mysqlserverconnection.Close();
            return dta;

        }
        public void update_ok(int ok, string name)
        {
            if (ok == 1)
            {
                MySqlConnection mysqlserverconnection = start_connection();
                mysqlserverconnection.Open();
                MySqlCommand cmd = mysqlserverconnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string time = timeofday();
                string update = "Donor data updated";
                cmd.CommandText = "insert INTO history_info (Time,Title,Action)VALUES('" + time + "','" + name + "', '" + update + "' )";
                cmd.ExecuteNonQuery();
                mysqlserverconnection.Close();
            }

        }

        public void update_donorinfo(int id, string name, string bloodtype, string mobileno, string address, string email, string password, string gender, string regular, string height, string weight)
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update donor_info set fullname= IFNULL(NULLIF('" + name + "', ''),fullname) ,"
            + "bloodtype= IFNULL(NULLIF('" + bloodtype + "',''),bloodtype) ,"
            + "mobilenumber= IFNULL(NULLIF('" + mobileno + "',''),mobilenumber) ,"
            + "address= IFNULL(NULLIF('" + address + "',''),address), "
            + "email= IFNULL(NULLIF('" + email + "',''),email), "
            + "password= IFNULL(NULLIF('" + password + "',''),password),"
            + "gender= IFNULL(NULLIF('" + gender + "',''),gender),"
            + "regular= IFNULL(NULLIF('" + regular + "',''),regular),"
            + "height= IFNULL(NULLIF('" + height + "',''),height),"
            + "weight= IFNULL(NULLIF('" + weight + "',''),weight)"
            + "where id ='" + id + "'";
            cmd.ExecuteNonQuery();
            mysqlserverconnection.Close();
        }

        public void updatehospital_ok(int ok, string name)
        {
            if (ok == 1)
            {
                MySqlConnection mysqlserverconnection = start_connection();
                mysqlserverconnection.Open();
                MySqlCommand cmd = mysqlserverconnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string time = timeofday();
                string update = "Hospital data updated";
                cmd.CommandText = "insert INTO history_info (Time,Title,Action)VALUES('" + time + "','" + name + "', '" + update + "' )";
                cmd.ExecuteNonQuery();
                mysqlserverconnection.Close();
            }

        }

        public void update_hospitalinfo(string name, string mobileno, string address, string email, string password)
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update hospital_info set hospitalname= IFNULL(NULLIF('" + name + "', ''),hospitalname) ,"
            + "phonenumber= IFNULL(NULLIF('" + mobileno + "',''),phonenumber) ,"
            + "address= IFNULL(NULLIF('" + address + "',''),address), "
            + "email= IFNULL(NULLIF('" + email + "',''),email), "
            + "password= IFNULL(NULLIF('" + password + "',''),password)"
            + "where hospitalname ='" + name + "'";
            cmd.ExecuteNonQuery();
            mysqlserverconnection.Close();
        }

        public DataTable stock_view()
        {

            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from donor_info";
            cmd.ExecuteNonQuery();
            DataTable data = new DataTable();
            MySqlDataAdapter dt = new MySqlDataAdapter(cmd);
            dt.Fill(data);
            mysqlserverconnection.Close();
            return data;

        }

        // for login purpose

        public string login_donor(string email, string password)
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select email and regular from donor_info where email = '" + email + "' and password = '" + password + "' ";

            cmd.ExecuteNonQuery();
            DataTable data = new DataTable();
            MySqlDataAdapter dt = new MySqlDataAdapter(cmd);
            dt.Fill(data);
            string e = data.Rows.Count.ToString();
            mysqlserverconnection.Close();
            if (e == null)
            {
                return e;
            }
            else
            {
                return e;
            }

        }

        public string login_hospital(string email, string password)
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select email and password from hospital_info where email = '" + email + "' and password = '" + password + "' ";

            cmd.ExecuteNonQuery();
            DataTable data = new DataTable();
            MySqlDataAdapter dt = new MySqlDataAdapter(cmd);
            dt.Fill(data);
            string e = data.Rows.Count.ToString();
            mysqlserverconnection.Close();
            if (e == null)
            {
                return e;
            }
            else
            {
                return e;
            }

        }

        public DataTable find_donor(string email)
        {

            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from donor_info where email = '" + email + "' ";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            MySqlDataAdapter dataadp = new MySqlDataAdapter(cmd);
            dataadp.Fill(dta);
            mysqlserverconnection.Close();
            return dta;

        }
        public DataTable find_hospital(string email)
        {

            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from hospital_info where email = '" + email + "' ";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            MySqlDataAdapter dataadp = new MySqlDataAdapter(cmd);
            dataadp.Fill(dta);
            mysqlserverconnection.Close();
            return dta;

        }

        public DataTable display_update()
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from update_info";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            MySqlDataAdapter dataadp = new MySqlDataAdapter(cmd);
            dataadp.Fill(dta);
            mysqlserverconnection.Close();
            return dta;
        }

        public void request_form(string name, string date, int aplus, int aminus, int bplus, int bminus, int abplus, int abminus, int oplus, int ominus)
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand command = mysqlserverconnection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "insert INTO request_info (Name,Date,AP,AN,BP,BN,ABP,ABN,OP,ONE) VALUES('" + name + "','" + date + "','" + aplus + "','" + aminus + "','" + bplus + "','" + bminus + "','" + abplus + "','" + abminus + "','" + oplus + "','" + ominus + "');";

            command.ExecuteNonQuery();
            mysqlserverconnection.Close();
        }

        

        public DataTable display_request()
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from request_info";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            MySqlDataAdapter dataadp = new MySqlDataAdapter(cmd);
            dataadp.Fill(dta);
            mysqlserverconnection.Close();
            return dta;
        }

        public DataTable select_eventdata(string organizer, string name, int choice)
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (choice == 0)
            {
                cmd.CommandText = "select * from event_info where e_name like '" + name + "'";
            }
            else
            {
                cmd.CommandText = "select * from event_info where e_organizer like '" + organizer + "'";
            }

            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            MySqlDataAdapter dataadp = new MySqlDataAdapter(cmd);
            dataadp.Fill(dta);
            mysqlserverconnection.Close();
            return dta;

        }

        public void update_eventinfo(int id,string name, string organizer, string address, string time, string date)
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand cmd = mysqlserverconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update event_info set e_name= IFNULL(NULLIF('" + name + "', ''),e_name) ,"
            + "e_organizer= IFNULL(NULLIF('" + organizer + "',''),e_organizer) ,"
            + "e_address= IFNULL(NULLIF('" + address + "',''),e_address), "
            + "e_time= IFNULL(NULLIF('" + time + "',''),e_time), "
            + "e_date= IFNULL(NULLIF('" + date + "',''),e_date)"
            + "where event_id ='" + id + "'";
            cmd.ExecuteNonQuery();
            mysqlserverconnection.Close();
        }

        public void updateevent_ok(int ok, string name)
        {
            if (ok == 1)
            {
                MySqlConnection mysqlserverconnection = start_connection();
                mysqlserverconnection.Open();
                MySqlCommand cmd = mysqlserverconnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string time = timeofday();
                string update = "Event data updated";
                cmd.CommandText = "insert INTO history_info (Time,Title,Action)VALUES('" + time + "','" + name + "', '" + update + "' )";
                cmd.ExecuteNonQuery();
                mysqlserverconnection.Close();
            }

        }


        public void stock_info(string name, string date, int aplus, int aminus, int bplus, int bminus, int abplus, int abminus, int oplus, int ominus, string type)
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand command = mysqlserverconnection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "insert INTO stock_info (Name,Date,AP,AM,BP,BM,ABP,ABM,OP,OM,Type) VALUES('" + name + "','" + date + "','" + aplus + "','" + aminus + "','" + bplus + "','" + bminus + "','" + abplus + "','" + abminus + "','" + oplus + "','" + ominus + "','"+type+"');";
            command.ExecuteNonQuery();
            mysqlserverconnection.Close();
        }


        public DataTable stock_view_hospital(string name)
        {
            MySqlConnection mysqlserverconnection = start_connection();
            mysqlserverconnection.Open();
            MySqlCommand command = mysqlserverconnection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from stock_info where Name = '" + name + "'";
            command.ExecuteNonQuery();
            DataTable dta = new DataTable();
            MySqlDataAdapter dataadp = new MySqlDataAdapter(command);
            dataadp.Fill(dta);
            mysqlserverconnection.Close();
            return dta;
        }
        
    }
}
