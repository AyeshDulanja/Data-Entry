using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Members_details
{
    public partial class Form1 : Form
    {
        OleDbCommand cmd;
        OleDbDataReader mdr;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                search();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Input", "");
            }
        }

        private void search()
        {
            if (String.IsNullOrEmpty(txtsearch.Text))
            {
                MessageBox.Show("Enter a Ticket Number to Search");
                txtsearch.Focus();
            }
            else
            {
                connection conn = new connection();
                conn.Connection();
                OleDbDataAdapter sqlda = new OleDbDataAdapter("SELECT * FROM membersdetails WHERE Mem_no LIKE'" + txtsearch.Text + "'", conn.con);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);

                dataGridView1.DataSource = dtbl;

                txtsearch.Clear();
                txtsearch.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtsearch.Clear();
            loaddata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection conn = new connection();
            conn.Connection();
            conn.con.Open();
            cmd = new OleDbCommand("SELECT * FROM membersdetails WHERE Mem_No=" + txtsearch2.Text + "", conn.con);

            try
            {
                OleDbDataReader mdr = cmd.ExecuteReader();
                if (mdr.Read())
                {
                    //txtfullname.text = dt.Rows[0]cells[2].Tostring();
                    
                    txtcomno.Text = mdr["Comp_No"].ToString();
                    txtfullname.Text = mdr["Full_Name"].ToString();
                    txtslip.Text = mdr["Name_Sal"].ToString();
                    txtoaddress.Text = mdr["Office_Add"].ToString();
                    txtoaddressnew.Text = mdr["Office_Add_New"].ToString();
                    txtpaddress.Text = mdr["Private_Address"].ToString();
                    txtadmitd.Text = mdr["Admit_Date"].ToString();
                    txtgender.Text = mdr["Gender"].ToString();

                    txtnic.Text = mdr["NIC_No"].ToString();
                    txtlno.Text = mdr["Leger_No"].ToString();
                    txtserviceno.Text = mdr["Servise_No"].ToString();
                    txtdistrict.Text = mdr["Distrct"].ToString();
                    txtdescrip.Text = mdr["Description"].ToString();
                    txtpaydate.Text = mdr["PaymentDate"].ToString();
                    txtlpa.Text = mdr["LastPaymentAmount"].ToString();
                    txtlp.Text = mdr["AwasanaGewim"].ToString();

                    txtpnoo.Text = mdr["Phone_No_Off"].ToString();
                    txtpnom.Text = mdr["Phone_No_Mob"].ToString();
                    txtpnoh.Text = mdr["Phone_No_Home"].ToString();

                    conn.con.Close();
                }
                else
                {
                    txtsearch2.Text = "";
                    MessageBox.Show("No Data For This Id");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            searchinc();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            connection conn = new connection();
            conn.Connection();
            conn.con.Open();
            //cmd = new OleDbCommand("SELECT * FROM membersdetails WHERE Mem_No='" + txtsearch2.Text + "'", conn.con);
            cmd = new OleDbCommand("SELECT * FROM membersdetails WHERE Mem_No=" + txtsearch3.Text + "", conn.con);

            try
            {
                OleDbDataReader mdr = cmd.ExecuteReader();
                if (mdr.Read())
                {
                    //txtfullname.text = dt.Rows[0]cells[2].Tostring();

                    txtcomno2.Text = mdr["Comp_No"].ToString();
                    txtfullname2.Text = mdr["Full_Name"].ToString();
                    txtslip2.Text = mdr["Name_Sal"].ToString();
                    txtoaddress2.Text = mdr["Office_Add"].ToString();
                    txtoaddressnew2.Text = mdr["Office_Add_New"].ToString();
                    txtpaddress2.Text = mdr["Private_Address"].ToString();
                    txtadmitd2.Text = mdr["Admit_Date"].ToString();
                    txtgender2.Text = mdr["Gender"].ToString();


                    txtnic2.Text = mdr["NIC_No"].ToString();
                    txtlno2.Text = mdr["Leger_No"].ToString();
                    txtserviceno2.Text = mdr["Servise_No"].ToString();
                    txtdistrict2.Text = mdr["Distrct"].ToString();
                    txtdescrip2.Text = mdr["Description"].ToString();
                    txtpaydate2.Text = mdr["PaymentDate"].ToString();
                    txtlpa2.Text = mdr["LastPaymentAmount"].ToString();
                    txtlp2.Text = mdr["AwasanaGewim"].ToString();

                    txtpnoo2.Text = mdr["Phone_No_Off"].ToString();
                    txtpnom2.Text = mdr["Phone_No_Mob"].ToString();
                    txtpnoh2.Text = mdr["Phone_No_Home"].ToString();

                    conn.con.Close();
                }
                else
                {
                    txtsearch3.Text = "";
                    MessageBox.Show("No Data For This Id");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            connection conn = new connection();
            conn.Connection();
            conn.con.Open();

            //cmd = new OleDbCommand("UPDATE membersdetails SET Comp_No,Full_Name,Name_Sal,Office_Add,Office_Add_New,Private_Address,Phone_No_Off,Phone_No_mob,Phone_No_Home,Admit_Date,Gender,NIC_No,Lager_No,Servise_No,District,Description,Payment Date,Last Payment Amount,Awasan Gewim WHERE Mem_No=" + txtsearch3.Text + "", conn.con);



            DialogResult dr = MessageBox.Show("Do you really want to UPDATE this Record?", "Member Details", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                cmd = new OleDbCommand("UPDATE membersdetails SET Mem_No=@Mem_No,Comp_No=@Comp_No,Full_Name=@Full_Name,Name_Sal=@Name_Sal,Office_Add=@Office_Add,Office_Add_New=@Office_Add_New,Private_Address=@Private_Address,Phone_No_Off=@Phone_No_Off,Phone_No_Mob=@Phone_No_Mob,Phone_No_Home=@Phone_No_Home,Admit_Date=@Admit_Date,Gender=@Gender,NIC_No=@NIC_No,Leger_No=@Leger_No,Servise_No=@Servise_No,Distrct=@Distrct,Description=@Description,PaymentDate=@PaymentDate,LastPaymentAmount=@LastPaymentAmount,AwasanaGewim=@AwasanaGewim WHERE Mem_No=" + txtsearch3.Text + "", conn.con);

                cmd.Parameters.AddWithValue("@Mem_No", txtsearch3.Text.Trim());
                cmd.Parameters.AddWithValue("@Comp_No", txtcomno2.Text.Trim());
                cmd.Parameters.AddWithValue("@Full_Name", txtfullname2.Text.Trim());
                cmd.Parameters.AddWithValue("@Name_Sal", txtslip2.Text.Trim());
                cmd.Parameters.AddWithValue("@Office_Add", txtoaddress2.Text.Trim());
                cmd.Parameters.AddWithValue("@Office_Add_New", txtoaddressnew2.Text.Trim());
                cmd.Parameters.AddWithValue("@private_Address", txtpaddress2.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone_No_Off", txtpnoo2.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone_No_Mob", txtpnom2.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone_No_Home", txtpnoh2.Text.Trim());
                cmd.Parameters.AddWithValue("@Admit_Date", txtadmitd2.Text.Trim());
                //cmd.Parameters.AddWithValue("@Gender", cbgender1.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", cbgender1.SelectedItem.ToString().Trim());
                cmd.Parameters.AddWithValue("@NIC_No", txtnic2.Text.Trim());
                cmd.Parameters.AddWithValue("@Leger_No", txtlno2.Text.Trim());
                cmd.Parameters.AddWithValue("@Servise_No", txtserviceno2.Text.Trim());
                cmd.Parameters.AddWithValue("@Distrct", txtdistrict2.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtdescrip2.Text.Trim());
                cmd.Parameters.AddWithValue("@PaymentDate", txtpaydate2.Text.Trim());
                cmd.Parameters.AddWithValue("@LastPaymentAmount", txtlpa2.Text.Trim());
                //cmd.Parameters.AddWithValue("@AwasanaGewim", cblp1.Text.Trim());
                cmd.Parameters.AddWithValue("@AwasanaGewim", cblp1.SelectedItem.ToString().Trim());

                try
                {
                    int affectedRows = cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated", "Memeber Details");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else if (dr == DialogResult.Cancel)
            {
                
            }

            conn.con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            connection conn = new connection();
            conn.Connection();
            conn.con.Open();

            DialogResult dr = MessageBox.Show("Do you really want to DELETE this Record?", "Member Details", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    cmd = new OleDbCommand("DELETE FROM membersdetails WHERE Mem_No=" + txtsearch3.Text + "", conn.con);
                    int affectedRows = cmd.ExecuteNonQuery();


                    txtcomno2.Clear();
                    txtfullname2.Clear();
                    txtslip2.Clear();
                    txtoaddress2.Clear();
                    txtoaddressnew2.Clear();
                    txtpaddress2.Clear();
                    txtadmitd2.Clear();
                    //cb.Clear();

                    txtnic2.Clear();
                    txtlno2.Clear();
                    txtserviceno2.Clear();
                    txtdistrict2.Clear();
                    txtdescrip2.Clear();
                    txtpaydate2.Clear();
                    txtlpa2.Clear();
                    //txtlp2.Clear();

                    txtpnoo2.Clear();
                    txtpnom2.Clear();
                    txtpnoh2.Clear();

                    MessageBox.Show("Successfully Deleted", "Member Details");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Action");
                }
            }
            else if (dr == DialogResult.Cancel)
            {
                //
            }
            conn.con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            connection conn = new connection();
            conn.Connection();
            conn.con.Open();

            DialogResult dr = MessageBox.Show("Do you really want to ADD this Record?", "Member Details", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                cmd = new OleDbCommand("INSERT INTO membersdetails (Mem_No,Comp_No,Full_Name,Name_Sal,Office_Add,Office_Add_New,Private_Address,Phone_No_Off,Phone_No_Mob,Phone_No_Home,Admit_Date,Gender,NIC_No,Leger_No,Servise_No,Distrct,Description,PaymentDate,LastPaymentAmount,AwasanaGewim) VALUES (@Mem_No,@Comp_No,@Full_Name,@Name_Sal,@Office_Add,@Office_Add_New,@Private_Address,@Phone_No_Off,@Phone_No_Mob,@Phone_No_Home,@Admit_Date,@Gender,@NIC_No,@Leger_No,@Servise_No,@Distrct,@Description,@PaymentDate,@LastPaymentAmount,@AwasanaGewim)", conn.con);

                cmd.Parameters.AddWithValue("@Mem_No", txtmemno.Text.Trim());
                cmd.Parameters.AddWithValue("@Comp_No", txtcomno3.Text.Trim());
                cmd.Parameters.AddWithValue("@Full_Name", txtfullname3.Text.Trim());
                cmd.Parameters.AddWithValue("@Name_Sal", txtslip3.Text.Trim());
                cmd.Parameters.AddWithValue("@Office_Add", txtoaddress3.Text.Trim());
                cmd.Parameters.AddWithValue("@Office_Add_New", txtoaddressnew3.Text.Trim());
                cmd.Parameters.AddWithValue("@private_Address", txtpaddress3.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone_No_Off", txtpnoo3.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone_No_Mob", txtpnom3.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone_No_Home", txtpnoh3.Text.Trim());
                cmd.Parameters.AddWithValue("@Admit_Date", txtadmitd3.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", cbgender.SelectedItem.ToString().Trim());
                cmd.Parameters.AddWithValue("@NIC_No", txtnic3.Text.Trim());
                cmd.Parameters.AddWithValue("@Leger_No", txtlno3.Text.Trim());
                cmd.Parameters.AddWithValue("@Servise_No", txtserviceno3.Text.Trim());
                cmd.Parameters.AddWithValue("@Distrct", txtdistrict3.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtdescrip3.Text.Trim());
                cmd.Parameters.AddWithValue("@PaymentDate", txtpaydate3.Text.Trim());
                cmd.Parameters.AddWithValue("@LastPaymentAmount", txtlpa3.Text.Trim());
                cmd.Parameters.AddWithValue("@AwasanaGewim", cblpay.SelectedItem.ToString().Trim());

                txtcomno3.Clear();
                txtfullname3.Clear();
                txtslip3.Clear();
                txtoaddress3.Clear();
                txtoaddressnew3.Clear();
                txtpaddress3.Clear();
                txtadmitd3.Clear();

                txtnic3.Clear();
                txtlno3.Clear();
                txtserviceno3.Clear();
                txtdistrict3.Clear();
                txtdescrip3.Clear();
                txtpaydate3.Clear();
                txtlpa3.Clear();

                txtpnoo3.Clear();
                txtpnom3.Clear();
                txtpnoh3.Clear();

                try
                {
                    int affectedRows = cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Added", "Memeber Details");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else if (dr == DialogResult.Cancel)
            {
                //
            }

            conn.con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtcomno3.Clear();
            txtfullname3.Clear();
            txtslip3.Clear();
            txtoaddress3.Clear();
            txtoaddressnew3.Clear();
            txtpaddress3.Clear();
            txtadmitd3.Clear();

            txtnic3.Clear();
            txtlno3.Clear();
            txtserviceno3.Clear();
            txtdistrict3.Clear();
            txtdescrip3.Clear();
            txtpaydate3.Clear();
            txtlpa3.Clear();

            txtpnoo3.Clear();
            txtpnom3.Clear();
            txtpnoh3.Clear();
        }

        //---------------------------------Functions Begin--------------------------------------------//
        private void loaddata()
        {
            this.Cursor = Cursors.WaitCursor;
            connection conn = new connection();
            conn.Connection();
            OleDbDataAdapter sqlda = new OleDbDataAdapter("SELECT * FROM membersdetails ORDER BY Mem_No DESC", conn.con);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            
            dataGridView1.DataSource = dtbl;
            this.Cursor = Cursors.Default;
        }

        private void searchinc()
        {
            connection conn = new connection();
            conn.Connection();
            conn.con.Open();
            //cmd = new OleDbCommand("SELECT * FROM membersdetails WHERE Mem_No='" + txtsearch2.Text + "'", conn.con);
            cmd = new OleDbCommand("SELECT * FROM membersdetails WHERE NIC_No='" + txtsearchnic.Text + "'", conn.con);
            //cmd = new OleDbCommand("SELECT * FROM membersdetails WHERE Mem_No=" + txtsearch2.Text + "", conn.con);

            try
            {
                OleDbDataReader mdr = cmd.ExecuteReader();
                if (mdr.Read())
                {
                    //txtfullname.text = dt.Rows[0]cells[2].Tostring();

                    txtsearch2.Text = mdr["Mem_No"].ToString();
                    txtcomno.Text = mdr["Comp_No"].ToString();
                    txtfullname.Text = mdr["Full_Name"].ToString();
                    txtslip.Text = mdr["Name_Sal"].ToString();
                    txtoaddress.Text = mdr["Office_Add"].ToString();
                    txtoaddressnew.Text = mdr["Office_Add_New"].ToString();
                    txtpaddress.Text = mdr["Private_Address"].ToString();
                    txtadmitd.Text = mdr["Admit_Date"].ToString();
                    txtgender.Text = mdr["Gender"].ToString();

                    txtnic.Text = mdr["NIC_No"].ToString();
                    txtlno.Text = mdr["Leger_No"].ToString();
                    txtserviceno.Text = mdr["Servise_No"].ToString();
                    txtdistrict.Text = mdr["Distrct"].ToString();
                    txtdescrip.Text = mdr["Description"].ToString();
                    txtpaydate.Text = mdr["PaymentDate"].ToString();
                    txtlpa.Text = mdr["LastPaymentAmount"].ToString();
                    txtlp.Text = mdr["AwasanaGewim"].ToString();

                    txtpnoo.Text = mdr["Phone_No_Off"].ToString();
                    txtpnom.Text = mdr["Phone_No_Mob"].ToString();
                    txtpnoh.Text = mdr["Phone_No_Home"].ToString();

                    conn.con.Close();
                }
                else
                {
                    txtsearch2.Text = "";
                    MessageBox.Show("No Data For This NIC");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void autocomplete()
        {
            connection conn = new connection();
            conn.Connection();
            string sqlquery = "SELECT Mem_No FROM membersdetails";
            OleDbCommand sqlcomm = new OleDbCommand(sqlquery, conn.con);
            conn.con.Open();
            OleDbDataReader sdr = sqlcomm.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
            while (sdr.Read())
            {
                //autotext.Add(sdr.GetString(0));
                autotext.Add(sdr["Mem_No"].ToString());

            }
            txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch.AutoCompleteCustomSource = autotext;

            txtsearch2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtsearch2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch2.AutoCompleteCustomSource = autotext;

            txtsearch3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtsearch3.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch3.AutoCompleteCustomSource = autotext;
            conn.con.Close();
        }

        private void autocomnic()
        {
            connection conn = new connection();
            conn.Connection();
            string sqlquery = "SELECT NIC_No FROM membersdetails";
            OleDbCommand sqlcomm = new OleDbCommand(sqlquery, conn.con);
            conn.con.Open();
            OleDbDataReader sdr = sqlcomm.ExecuteReader();
            AutoCompleteStringCollection autotext1 = new AutoCompleteStringCollection();
            while (sdr.Read())
            {
                //autotext.Add(sdr.GetString(0));
                autotext1.Add(sdr["NIC_No"].ToString());

            }
            txtsearchnic.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtsearchnic.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearchnic.AutoCompleteCustomSource = autotext1;
            conn.con.Close();
        }

        private void autoincrement()
        {
            connection conn = new connection();
            conn.Connection();
            conn.con.Open();
            OleDbDataAdapter sda = new OleDbDataAdapter("SELECT MAX(Mem_No+1) FROM membersdetails", conn.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //int value = int.Parse(dt.Rows[0][0].ToString());
            txtmemno.Text = dt.Rows[0][0].ToString();
        }

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // in miliseconds
            timer1.Start();
        }

        //---------------------------------Functions End--------------------------------------------//

        private void Form1_Load(object sender, EventArgs e)
        {
            loaddata();
            autocomplete();
            autoincrement();
            autocomnic();
            InitTimer();

            cbgender.SelectedIndex = 0;
            cblpay.SelectedIndex = 0;
            cbgender1.SelectedIndex = 0;
            cblp1.SelectedIndex = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            autoincrement();
        }
    }
}
