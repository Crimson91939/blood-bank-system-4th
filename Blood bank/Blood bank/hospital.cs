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
    public partial class hospital : Form
    {
        private mysql_database _servermysql = new mysql_database();
        DataTable data;
        string em;
        public hospital(string user)
        {
            InitializeComponent();
            em = user;
            DataTable data = _servermysql.display_eventdata();
            dataGridView_hospital_showevents.DataSource = data;
            makepanelvisible(1);
        }

        private void button_admin_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn openloginpage = new LogIn();
            openloginpage.ShowDialog();
        }

        public void makepanelvisible(int choice)
        {

            panel_hospital_dashboard.Visible = false;
            panel_hospital_profile.Visible = false;
            panel_hospital_stock.Visible = false;
            panel_hospital_requestlogs.Visible = false;
            panel_hospital_addstock.Visible = false;
            panel_hospital_makerequest.Visible = false;

            if (choice == 1)
            {
                panel_hospital_dashboard.Visible = true;
            }
            else if (choice == 2)
            {
                panel_hospital_profile.Visible = true;
            }
            else if (choice == 3)
            {
                panel_hospital_stock.Visible = true;
            }
            else if (choice== 4)
            {
                panel_hospital_requestlogs.Visible = true;
            }
            else if (choice == 5)
            {
                panel_hospital_addstock.Visible = true;
            }
            else if (choice == 6)
            {
                panel_hospital_makerequest.Visible = true;
            }
        }


        private void button_hospital_dashboard_Click(object sender, EventArgs e)
        {
            DataTable data = _servermysql.display_eventdata();
            dataGridView_hospital_showevents.DataSource = data;
            makepanelvisible(1);
        }

        private void button_hospital_profile_Click(object sender, EventArgs e)
        {
            makepanelvisible(2);
            try
            {
                _servermysql.start_connection();
                try
                {
                   
                    data = _servermysql.find_hospital(em);

                    int id = data.Rows.Count;
                    for (int i = 0; i < id; i++)
                    {
                        
                        label_hospital_name.Text = data.Rows[i]["hospitalname"].ToString();
                        label_hospital_address.Text = data.Rows[i]["address"].ToString();
                        label_hospital_number.Text = data.Rows[i]["phonenumber"].ToString();
                        label_hospital_date.Text = data.Rows[i]["date"].ToString();
                        label_hospital_email.Text = data.Rows[i]["email"].ToString();
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
            makepanelvisible(2);
        }
        public static int bloodap;
        public static int bloodam;
        public static int bloodbp;
        public static int bloodbm;
        public static int bloodabp;
        public static int bloodabm;
        public static int bloodop;
        public static int bloodom;
        public static int bloodap1;
        public static int bloodam1;
        public static int bloodbp1;
        public static int bloodbm1;
        public static int bloodabp1;
        public static int bloodabm1;
        public static int bloodop1;
        public static int bloodom1;
        public static int bloodap2;
        public static int bloodam2;
        public static int bloodbp2;
        public static int bloodbm2;
        public static int bloodabp2;
        public static int bloodabm2;
        public static int bloodop2;
        public static int bloodom2;

        private void button_hospital_stock_Click(object sender, EventArgs e)
        {


            bloodap = 0;
            bloodam = 0;
            bloodbp = 0;
            bloodbm = 0;
            bloodabp = 0;
            bloodabm = 0;
            bloodop = 0;
            bloodom = 0;
            bloodap1 = 0;
            bloodam1 = 0;
            bloodbp1 = 0;
            bloodbm1 = 0;
            bloodabp1 = 0;
            bloodabm1 = 0;
            bloodop1 = 0;
            bloodom1 = 0;
            bloodap2 = 0;
            bloodam2 = 0;
            bloodbp2 = 0;
            bloodbm2 = 0;
            bloodabp2 = 0;
            bloodabm2 = 0;
            bloodop2 = 0;
            bloodom2 = 0;

            try
            {
                _servermysql.start_connection();
                try
                {
                    data = _servermysql.find_hospital(em);
                    int id = data.Rows.Count;
                    for (int i = 0; i < id; i++)
                    {

                        name = data.Rows[i]["hospitalname"].ToString();

                    }
                    
                    DataTable dat = _servermysql.stock_view_hospital(name);
                    
                    int rownum = dat.Rows.Count;
                    
                    for (int i = 0; i < rownum; i++)
                    {
                        
                        string type = dat.Rows[i]["Type"].ToString();
                        if (string.Compare(type, "Add") == 0)
                        {

                            
                            bloodap = Convert.ToInt16(dat.Rows[i]["AP"].ToString());
                           
                            bloodap1 = bloodap1 + bloodap;
                            

                            bloodam = Convert.ToInt16(dat.Rows[i]["AM"].ToString());
                                bloodam1 = bloodam1 + bloodam;
                            
                                bloodbp = Convert.ToInt16(dat.Rows[i]["BP"].ToString());
                                bloodbp1 = bloodbp1 + bloodbp;
                            
                            
                                bloodbm = Convert.ToInt16(dat.Rows[i]["BM"].ToString());
                                bloodbm1 = bloodbm1 + bloodbm;
                            
                                bloodabp = Convert.ToInt16(dat.Rows[i]["ABP"].ToString());
                                bloodabp1 = bloodabp1 + bloodabp;
                            
                                bloodabm = Convert.ToInt16(dat.Rows[i]["ABM"].ToString());
                                bloodabm1 = bloodabm1 + bloodabm;
                            
                                bloodop = Convert.ToInt16(dat.Rows[i]["OP"].ToString());
                                bloodop1 = bloodop1 + bloodop;
                            
                                bloodom = Convert.ToInt16(dat.Rows[i]["OM"].ToString());
                                bloodom1 = bloodom1 + bloodom;
                            

                        }

                        else if (string.Compare(type, "Delete") == 0)
                        {
                                bloodap = Convert.ToInt16(dat.Rows[i]["AP"].ToString());
                                bloodap2 = bloodap2 + bloodap;
                            
                                bloodam = Convert.ToInt16(dat.Rows[i]["AM"].ToString());
                                bloodam2 = bloodam2 + bloodam;
                            
                                bloodbp = Convert.ToInt16(dat.Rows[i]["BP"].ToString());
                                bloodbp2 = bloodbp2 + bloodbp;
                            
                                bloodbm = Convert.ToInt16(dat.Rows[i]["BM"].ToString());
                                bloodbm2 = bloodbm2 + bloodbm;
                            
                                bloodabp = Convert.ToInt16(dat.Rows[i]["ABP"].ToString());
                                bloodabp2 = bloodabp2 + bloodabp;
                            
                                bloodabm = Convert.ToInt16(dat.Rows[i]["ABM"].ToString());
                                bloodabm2 = bloodabm2 + bloodabm;
                            
                                bloodop = Convert.ToInt16(dat.Rows[i]["OP"].ToString());
                                bloodop2 = bloodop2 + bloodop;
                            
                                bloodom = Convert.ToInt16(dat.Rows[i]["OM"].ToString());
                                bloodom2 = bloodom2 + bloodom;
                            

                        }
                        
                    }
                    
                    bloodap = bloodap1 - bloodap2;
                    bloodam = bloodam1 - bloodam2;
                    bloodabp = bloodabp1 - bloodabp2;
                    bloodabm = bloodabm1 - bloodabm2;
                    bloodbp = bloodbp1 - bloodbp2;
                    bloodbm = bloodbm1 - bloodbm2;
                    bloodop = bloodop1 - bloodop2;
                    bloodom = bloodom1 - bloodom2;

                    label_hospital_stockap.Text = Convert.ToString(bloodap);
                    label_hospital_stockam.Text = Convert.ToString(bloodam);
                    label_hospital_stockabp.Text = Convert.ToString(bloodabp);
                    label_hospital_stockabm.Text = Convert.ToString(bloodabm);
                    label_hospital_stockbp.Text = Convert.ToString(bloodbp);
                    label_hospital_stockbm.Text = Convert.ToString(bloodbm);
                    label_hospital_stockop.Text = Convert.ToString(bloodop);
                    label_hospital_stockom.Text = Convert.ToString(bloodom);


                }
                catch
                {
                    MessageBox.Show("No stock found","Warning");
                    
                }
            }
            catch
            {
                _servermysql.end_connection();
            }

            
            makepanelvisible(3);

        }

        private void button_hospital_requestlogs_Click(object sender, EventArgs e)
        {
            try
            {
                _servermysql.start_connection();
                try
                {
                    data = _servermysql.find_hospital(em);
                    int id = data.Rows.Count;
                    for (int i = 0; i < id; i++)
                    {

                        name = data.Rows[i]["hospitalname"].ToString();

                    }
                    DataTable dat = _servermysql.display_request();
                    dataGridView_hospital_requestlist.DataSource = dat;

                }
                catch
                {
                    MessageBox.Show("No stock found", "Warning");
                    dataGridView_hospital_requestlist.Visible = false;
                }
            }
            catch
            {
                _servermysql.end_connection();
            }
           
            makepanelvisible(4);

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            makepanelvisible(6);
        }

        public static int ap;
        public static int bp;
        public static int abp;
        public static int op;
        public static int am;
        public static int bm;
        public static int abm;
        public static int om;
        public static string name;
        private void button3_Click(object sender, EventArgs e)
        {
            
            
            if ( string.IsNullOrEmpty(textBox_hospital_aplus.Text) || string.IsNullOrWhiteSpace(textBox_hospital_aplus.Text) )
            {
                ap = 0;
            }
            else
            {
                ap = Convert.ToInt16(textBox_hospital_aplus.Text);
            }
            
            if (string.IsNullOrEmpty(textBox_hospital_aminus.Text) || string.IsNullOrWhiteSpace(textBox_hospital_aminus.Text))
            {
                am = 0;
            }
            else
            {
                am = Convert.ToInt16(textBox_hospital_aminus.Text);
            }
            if (string.IsNullOrEmpty(textBox_hospital_bplus.Text) || string.IsNullOrWhiteSpace(textBox_hospital_bplus.Text))
            {
                bp = 0;
            }
            else
            {
                bp = Convert.ToInt16(textBox_hospital_bplus.Text);
            }
            
            
            if (string.IsNullOrEmpty(textBox_hospital_bminus.Text) || string.IsNullOrWhiteSpace(textBox_hospital_bminus.Text))
            {
                bm = 0;
            }
            else
            {
                bm = Convert.ToInt16(textBox_hospital_bminus.Text);
            }
            
            if (string.IsNullOrEmpty(textBox_hospital_abplus.Text) || string.IsNullOrWhiteSpace(textBox_hospital_abplus.Text))
            {
                abp = 0;
            }
            else
            {
                abp = Convert.ToInt16(textBox_hospital_abplus.Text);
            }
            
            if (string.IsNullOrEmpty(textBox_hospital_abminus.Text) || string.IsNullOrWhiteSpace(textBox_hospital_abminus.Text))
            {
                abm = 0;
            }
            else
            {
                abm = Convert.ToInt16(textBox_hospital_abminus.Text);
            }
            
            if (string.IsNullOrEmpty(textBox_hospital_oplus.Text) || string.IsNullOrWhiteSpace(textBox_hospital_oplus.Text))
            {
                op = 0;
            }
            else
            {
                op = Convert.ToInt16(textBox_hospital_oplus.Text);
            }
            
            if (string.IsNullOrEmpty(textBox_hospital_ominus.Text) || string.IsNullOrWhiteSpace(textBox_hospital_ominus.Text))
            {
                om = 0;
            }
            else
            {
                om = Convert.ToInt16(textBox_hospital_ominus.Text);
            }
            
           
            DateTime datetemp = dateTimePicker_hospital_requestdate.Value.Date;
            string date = datetemp.ToString("yyyy/MM/dd");

            try
            {
                _servermysql.start_connection();
                try
                {
                    
                    data = _servermysql.find_hospital(em);
                    int id = data.Rows.Count;
                    for (int i = 0; i < id; i++)
                    {

                        name = data.Rows[i]["hospitalname"].ToString();
                        
                    }
                    
                    _servermysql.request_form(name, date, ap, am, bp, bm, abp, abm, op, om);
                    
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

            textBox_hospital_aplus.Clear();
            textBox_hospital_aminus.Clear();
            textBox_hospital_bplus.Clear();
            textBox_hospital_bminus.Clear();
            textBox_hospital_abplus.Clear();
            textBox_hospital_abminus.Clear();
            textBox_hospital_oplus.Clear();
            textBox_hospital_ominus.Clear();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int ap;
            int am;
            int bp; 
            int bm;
            int abp;
            int abm;
            int op;
            int om;

            if (string.IsNullOrEmpty(textBox_hospital_addstock_ap.Text) || string.IsNullOrWhiteSpace(textBox_hospital_addstock_ap.Text))
            {
                ap = 0;
            }
            else
            {
                ap = Convert.ToInt16(textBox_hospital_addstock_ap.Text);
            }

            if (string.IsNullOrEmpty(textBox_hospital_addstock_am.Text) || string.IsNullOrWhiteSpace(textBox_hospital_addstock_am.Text))
            {
                am = 0;
            }
            else
            {
                am = Convert.ToInt16(textBox_hospital_addstock_am.Text);
            }
            if (string.IsNullOrEmpty(textBox_hospital_addstock_bp.Text) || string.IsNullOrWhiteSpace(textBox_hospital_addstock_bp.Text))
            {
                bp = 0;
            }
            else
            {
                bp = Convert.ToInt16(textBox_hospital_addstock_bp.Text);
            }


            if (string.IsNullOrEmpty(textBox_hospital_addstock_bm.Text) || string.IsNullOrWhiteSpace(textBox_hospital_addstock_bm.Text))
            {
                bm = 0;
            }
            else
            {
                bm = Convert.ToInt16(textBox_hospital_addstock_bm.Text);
            }

            if (string.IsNullOrEmpty(textBox_hospital_addstock_abp.Text) || string.IsNullOrWhiteSpace(textBox_hospital_addstock_abp.Text))
            {
                abp = 0;
            }
            else
            {
                abp = Convert.ToInt16(textBox_hospital_addstock_abp.Text);
            }

            if (string.IsNullOrEmpty(textBox_hospital_addstock_abm.Text) || string.IsNullOrWhiteSpace(textBox_hospital_addstock_abm.Text))
            {
                abm = 0;
            }
            else
            {
                abm = Convert.ToInt16(textBox_hospital_addstock_abm.Text);
            }

            if (string.IsNullOrEmpty(textBox_hospital_addstock_op.Text) || string.IsNullOrWhiteSpace(textBox_hospital_addstock_op.Text))
            {
                op = 0;
            }
            else
            {
                op = Convert.ToInt16(textBox_hospital_addstock_op.Text);
            }

            if (string.IsNullOrEmpty(textBox_hospital_addstock_om.Text) || string.IsNullOrWhiteSpace(textBox_hospital_addstock_om.Text))
            {
                om = 0;
            }
            else
            {
                om = Convert.ToInt16(textBox_hospital_addstock_om.Text);
            }

            DateTime datetemp = dateTimePicker_hospital_requestdate.Value.Date;
            string date = datetemp.ToString("yyyy/MM/dd");

            string type = "Add";

            try
            {
                _servermysql.start_connection();
                try
                {

                    data = _servermysql.find_hospital(em);
                    int id = data.Rows.Count;
                    for (int i = 0; i < id; i++)
                    {

                        name = data.Rows[i]["hospitalname"].ToString();

                    }

                    _servermysql.stock_info(name, date, ap, am, bp, bm, abp, abm, op, om, type);
                    
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

            textBox_hospital_addstock_ap.Clear();
            textBox_hospital_addstock_am.Clear();
            textBox_hospital_addstock_bp.Clear();
            textBox_hospital_addstock_bm.Clear();
            textBox_hospital_addstock_abp.Clear();
            textBox_hospital_addstock_abm.Clear();
            textBox_hospital_addstock_op.Clear();
            textBox_hospital_addstock_om.Clear();

        }

        private void button_hospital_addstock_Click(object sender, EventArgs e)
        {
            makepanelvisible(5);
        }

        private void button_hospital_delete_Click(object sender, EventArgs e)
        {
            int ap;
            int am;
            int bp;
            int bm;
            int abp;
            int abm;
            int op;
            int om;

            if (string.IsNullOrEmpty(textBox_hospital_addstock_ap.Text) || string.IsNullOrWhiteSpace(textBox_hospital_addstock_ap.Text))
            {
                ap = 0;
            }
            else
            {
                ap = Convert.ToInt16(textBox_hospital_addstock_ap.Text);
            }

            if (string.IsNullOrEmpty(textBox_hospital_addstock_am.Text) || string.IsNullOrWhiteSpace(textBox_hospital_addstock_am.Text))
            {
                am = 0;
            }
            else
            {
                am = Convert.ToInt16(textBox_hospital_addstock_am.Text);
            }
            if (string.IsNullOrEmpty(textBox_hospital_addstock_bp.Text) || string.IsNullOrWhiteSpace(textBox_hospital_addstock_bp.Text))
            {
                bp = 0;
            }
            else
            {
                bp = Convert.ToInt16(textBox_hospital_addstock_bp.Text);
            }


            if (string.IsNullOrEmpty(textBox_hospital_addstock_bm.Text) || string.IsNullOrWhiteSpace(textBox_hospital_addstock_bm.Text))
            {
                bm = 0;
            }
            else
            {
                bm = Convert.ToInt16(textBox_hospital_addstock_bm.Text);
            }

            if (string.IsNullOrEmpty(textBox_hospital_addstock_abp.Text) || string.IsNullOrWhiteSpace(textBox_hospital_addstock_abp.Text))
            {
                abp = 0;
            }
            else
            {
                abp = Convert.ToInt16(textBox_hospital_addstock_abp.Text);
            }

            if (string.IsNullOrEmpty(textBox_hospital_addstock_abm.Text) || string.IsNullOrWhiteSpace(textBox_hospital_addstock_abm.Text))
            {
                abm = 0;
            }
            else
            {
                abm = Convert.ToInt16(textBox_hospital_addstock_abm.Text);
            }

            if (string.IsNullOrEmpty(textBox_hospital_addstock_op.Text) || string.IsNullOrWhiteSpace(textBox_hospital_addstock_op.Text))
            {
                op = 0;
            }
            else
            {
                op = Convert.ToInt16(textBox_hospital_addstock_op.Text);
            }

            if (string.IsNullOrEmpty(textBox_hospital_addstock_om.Text) || string.IsNullOrWhiteSpace(textBox_hospital_addstock_om.Text))
            {
                om = 0;
            }
            else
            {
                om = Convert.ToInt16(textBox_hospital_addstock_om.Text);
            }

            DateTime datetemp = dateTimePicker_hospital_requestdate.Value.Date;
            string date = datetemp.ToString("yyyy/MM/dd");

            string type = "Delete";

            try
            {
                _servermysql.start_connection();
                try
                {

                    data = _servermysql.find_hospital(em);
                    int id = data.Rows.Count;
                    for (int i = 0; i < id; i++)
                    {

                        name = data.Rows[i]["hospitalname"].ToString();

                    }

                    _servermysql.stock_info(name, date, ap, am, bp, bm, abp, abm, op, om, type);

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
            textBox_hospital_addstock_ap.Clear();
            textBox_hospital_addstock_am.Clear();
            textBox_hospital_addstock_bp.Clear();
            textBox_hospital_addstock_bm.Clear();
            textBox_hospital_addstock_abp.Clear();
            textBox_hospital_addstock_abm.Clear();
            textBox_hospital_addstock_op.Clear();
            textBox_hospital_addstock_om.Clear();
        }

        private void button_back_for_stock_Click(object sender, EventArgs e)
        {


            bloodap = 0;
            bloodam = 0;
            bloodbp = 0;
            bloodbm = 0;
            bloodabp = 0;
            bloodabm = 0;
            bloodop = 0;
            bloodom = 0;
            bloodap1 = 0;
            bloodam1 = 0;
            bloodbp1 = 0;
            bloodbm1 = 0;
            bloodabp1 = 0;
            bloodabm1 = 0;
            bloodop1 = 0;
            bloodom1 = 0;
            bloodap2 = 0;
            bloodam2 = 0;
            bloodbp2 = 0;
            bloodbm2 = 0;
            bloodabp2 = 0;
            bloodabm2 = 0;
            bloodop2 = 0;
            bloodom2 = 0;

            try
            {
                _servermysql.start_connection();
                try
                {
                    data = _servermysql.find_hospital(em);
                    int id = data.Rows.Count;
                    for (int i = 0; i < id; i++)
                    {

                        name = data.Rows[i]["hospitalname"].ToString();

                    }

                    DataTable dat = _servermysql.stock_view_hospital(name);

                    int rownum = dat.Rows.Count;

                    for (int i = 0; i < rownum; i++)
                    {

                        string type = dat.Rows[i]["Type"].ToString();
                        if (string.Compare(type, "Add") == 0)
                        {


                            bloodap = Convert.ToInt16(dat.Rows[i]["AP"].ToString());

                            bloodap1 = bloodap1 + bloodap;


                            bloodam = Convert.ToInt16(dat.Rows[i]["AM"].ToString());
                            bloodam1 = bloodam1 + bloodam;

                            bloodbp = Convert.ToInt16(dat.Rows[i]["BP"].ToString());
                            bloodbp1 = bloodbp1 + bloodbp;


                            bloodbm = Convert.ToInt16(dat.Rows[i]["BM"].ToString());
                            bloodbm1 = bloodbm1 + bloodbm;

                            bloodabp = Convert.ToInt16(dat.Rows[i]["ABP"].ToString());
                            bloodabp1 = bloodabp1 + bloodabp;

                            bloodabm = Convert.ToInt16(dat.Rows[i]["ABM"].ToString());
                            bloodabm1 = bloodabm1 + bloodabm;

                            bloodop = Convert.ToInt16(dat.Rows[i]["OP"].ToString());
                            bloodop1 = bloodop1 + bloodop;

                            bloodom = Convert.ToInt16(dat.Rows[i]["OM"].ToString());
                            bloodom1 = bloodom1 + bloodom;


                        }

                        else if (string.Compare(type, "Delete") == 0)
                        {
                            bloodap = Convert.ToInt16(dat.Rows[i]["AP"].ToString());
                            bloodap2 = bloodap2 + bloodap;

                            bloodam = Convert.ToInt16(dat.Rows[i]["AM"].ToString());
                            bloodam2 = bloodam2 + bloodam;

                            bloodbp = Convert.ToInt16(dat.Rows[i]["BP"].ToString());
                            bloodbp2 = bloodbp2 + bloodbp;

                            bloodbm = Convert.ToInt16(dat.Rows[i]["BM"].ToString());
                            bloodbm2 = bloodbm2 + bloodbm;

                            bloodabp = Convert.ToInt16(dat.Rows[i]["ABP"].ToString());
                            bloodabp2 = bloodabp2 + bloodabp;

                            bloodabm = Convert.ToInt16(dat.Rows[i]["ABM"].ToString());
                            bloodabm2 = bloodabm2 + bloodabm;

                            bloodop = Convert.ToInt16(dat.Rows[i]["OP"].ToString());
                            bloodop2 = bloodop2 + bloodop;

                            bloodom = Convert.ToInt16(dat.Rows[i]["OM"].ToString());
                            bloodom2 = bloodom2 + bloodom;


                        }

                    }

                    bloodap = bloodap1 - bloodap2;
                    bloodam = bloodam1 - bloodam2;
                    bloodabp = bloodabp1 - bloodabp2;
                    bloodabm = bloodabm1 - bloodabm2;
                    bloodbp = bloodbp1 - bloodbp2;
                    bloodbm = bloodbm1 - bloodbm2;
                    bloodop = bloodop1 - bloodop2;
                    bloodom = bloodom1 - bloodom2;

                    label_hospital_stockap.Text = Convert.ToString(bloodap);
                    label_hospital_stockam.Text = Convert.ToString(bloodam);
                    label_hospital_stockabp.Text = Convert.ToString(bloodabp);
                    label_hospital_stockabm.Text = Convert.ToString(bloodabm);
                    label_hospital_stockbp.Text = Convert.ToString(bloodbp);
                    label_hospital_stockbm.Text = Convert.ToString(bloodbm);
                    label_hospital_stockop.Text = Convert.ToString(bloodop);
                    label_hospital_stockom.Text = Convert.ToString(bloodom);


                }
                catch
                {
                    MessageBox.Show("No stock found", "Warning");

                }
            }
            catch
            {
                _servermysql.end_connection();
            }


            makepanelvisible(3);

        }

        private void button_back_for_request_Click(object sender, EventArgs e)
        {
            try
            {
                _servermysql.start_connection();
                try
                {
                    data = _servermysql.find_hospital(em);
                    int id = data.Rows.Count;
                    for (int i = 0; i < id; i++)
                    {

                        name = data.Rows[i]["hospitalname"].ToString();

                    }
                    DataTable dat = _servermysql.display_request();
                    dataGridView_hospital_requestlist.DataSource = dat;

                }
                catch
                {
                    MessageBox.Show("No stock found", "Warning");
                    dataGridView_hospital_requestlist.Visible = false;
                }
            }
            catch
            {
                _servermysql.end_connection();
            }

            makepanelvisible(4);

        }

        private void textBox_hospital_oplus_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void check_letter(TextBox textbox_name, int a)
        {
            
            if (System.Text.RegularExpressions.Regex.IsMatch(textbox_name.Text, "[^0-9]"))
            {
                
                textbox_name.Clear();

                if (a == 1)
                {
                    label_error_for_make.Visible = true;
                    label_error_for_make.Text = "Please enter only numbers";
                }
                else
                {
                    label_error.Visible = true;
                    label_error.Text = "Please enter only numbers";
                }
               
                //   textBox_hospital_aplus.Text = textBox_hospital_aplus.Text.Remove(textBox_hospital_aplus.Text.Length - 1);
                // textBox_hospital_aplus.Clear();

            }
            else
            {
                if (a == 1)
                {
                    label_error_for_make.Text = "";
                }
                else
                {
                    label_error.Text = "";
                }
                

            }
            
        }
        private void validation_data(object sender, EventArgs e)
        {
           // label_error_for_make.Visible = false;
            TextBox event_start = (TextBox)sender;
            check_letter(event_start,1); 
        }

        private void textBox_hospital_addstock_om_TextChanged(object sender, EventArgs e)
        {
            TextBox event_start = (TextBox)sender;
            check_letter(event_start,0);
        }
    }
}
