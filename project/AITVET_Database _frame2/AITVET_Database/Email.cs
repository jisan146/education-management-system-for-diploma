using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
namespace AITVET_Database
{
    public partial class Email : Form

    {
        int mul,id=0;
        int art;
        string s="",ff="", y="";
        private void timer3_Tick(object sender, EventArgs e)
        {
            button2.PerformClick();

        }
        public Email()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("delete from m ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            timer1.Enabled = false;
          
            this.Hide();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            button25.PerformClick();
            if (mul > 0) { timer7.Enabled = true; }
            if (textBox7.Text!="") { 
          
          

            timer2.Enabled = true;
            textBox3.Text = "not read";
            SqlConnection cong = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdag = new SqlDataAdapter("select *from email where ((receiver_id='" + textBox7.Text + " ' and sender_id='" + textBox8.Text + " ')or(receiver_id='" + textBox8.Text + " ' and sender_id='" + textBox7.Text + " ') )and b='block'", cong);
            DataTable dtg = new DataTable();
            sdag.Fill(dtg);
            dataGridView11.DataSource = dtg;
            int v, a;
            a = int.Parse(dataGridView11.RowCount.ToString());

            a = a - 1;
            if (a > 0) { MessageBox.Show("Block"); } else {

                if (textBox7.Text != "")
                {
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    textBox11.Text = DateTime.Now.ToString("HH:mm:ss tt");
                    textBox10.Text = DateTime.Now.ToString("MMM  dd ,dddd, yyyy hh:mm:ss tt");
                    // label10.Visible = true;

                    Class1 dbaccess = new Class1();
                    dbaccess.Sender_id = textBox8.Text;
                    dbaccess.Receiver_id = textBox7.Text;
                    dbaccess.Semester_no = comboBox2.Text;
                    dbaccess.Course_id = comboBox1.Text;
                    dbaccess.Status = textBox3.Text;


                    dbaccess.Information = textBox9.Text;
                    dbaccess.Receive_date = textBox10.Text;
                    dbaccess.Receive_time = textBox11.Text;
                    dbaccess.F = ff;



                    if (dbaccess.DataSaveInEmail())
                    {
                        MessageBox.Show("send suceesfull");
                        textBox7.Clear();
                        textBox9.Clear();
                        textBox24.Clear();
                        ff = "";
                        // label10.Text = "send suceessfull ";
                        button7.PerformClick();

                    }
                    else
                    {
                        MessageBox.Show("fail");
                        // label10.Text = "send fail ";
                    }
                }
                else
                {
                    // label10.Visible = true;
                    label10.Text = "Not possible ";
                }
            }
            }
            else { if (timer7.Enabled == false) { MessageBox.Show("insert ID"); } }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox9.Multiline = true;
            textBox9.ScrollBars = ScrollBars.Both;
        }

        private void Email_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aITVETDataSet65.course' table. You can move, or remove it, as needed.
            this.courseTableAdapter1.Fill(this.aITVETDataSet65.course);
            this.MinimizeBox = false;
            this.MaximizeBox = false; timer3.Enabled = true;
            button2.PerformClick();
           // this.ControlBox = false;// TODO: This line of code loads data into the 'aITVETDataSet15.semester' table. You can move, or remove it, as needed.
            this.semesterTableAdapter.Fill(this.aITVETDataSet15.semester);
            // TODO: This line of code loads data into the 'aITVETDataSet14.course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.aITVETDataSet14.course);
            /*  SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
              SqlCommand cmd = con.CreateCommand();
              cmd.CommandType = CommandType.Text;
              cmd.CommandText = "select *from email";
              cmd.ExecuteNonQuery();
              DataTable dt = new DataTable();
              SqlDataAdapter sda = new SqlDataAdapter();
              sda.Fill(dt);*/
            Class1 dbaccess = new Class1();
            dbaccess.Student_id = textBox8.Text;
          

            if (dbaccess.QueryInread())
            {

               
                

            }
            else
            {
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            timer1.Enabled = true;
            dataGridView1.Visible = true;
            dataGridView5.Visible = false;
            //dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            this.Refresh();
            Email f = new Email();
            f.Refresh();
            dataGridView1.Refresh();
            SqlConnection cong = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdag = new SqlDataAdapter("update email set sender_id='' where sender_id='' ", cong);
            DataTable dtg = new DataTable();
            sdag.Fill(dtg);
            dataGridView2.DataSource = dtg;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select sender_id,information,receive_date as Receive_Date_Time,status,f as Attach from email where receiver_id='" + textBox8.Text + "' order by Serial_No desc", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            //this.dataGridView1.Sort(this.dataGridView1.Columns["Receive_Date_Time"], ListSortDirection.Descending);
            DataGridViewColumn column1 = dataGridView1.Columns[0];
            column1.Width = 60;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            column2.Width = 160;

            DataGridViewColumn column = dataGridView1.Columns[2];
            column.Width = 160;
            timer3.Enabled = false;
           // dataGridView9.Visible = false;


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Class1 dbaccess = new Class1();
            dbaccess.Department_id = "";
            if (dbaccess.DataSaveInfilen()) { }
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select max(Serial_no) from filen ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView22.DataSource = dt;

            DataGridViewRow row1 = this.dataGridView22.Rows[0];
            art = int.Parse(row1.Cells[0].Value.ToString());
            string p = "";
            if (e.RowIndex >= 0)
            {
                textBox23.Text = "";
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textBox from specific value of the coordinates of column and row.
                // textBox13.Text = row.Cells[3].Value.ToString();
                textBox9.Text = row.Cells[1].Value.ToString();
                textBox4.Text = row.Cells[0].Value.ToString();
                textBox15.Text = row.Cells[0].Value.ToString();
                textBox5.Text = textBox8.Text;
                textBox6.Text = row.Cells[2].Value.ToString();
                textBox16.Text = row.Cells[2].Value.ToString();
                textBox17.Text = row.Cells[3].Value.ToString();
                textBox23.Text= row.Cells[4].Value.ToString();
                textBox24.Text = row.Cells[4].Value.ToString();
                //textBox18.Text = row.Cells[5].Value.ToString();
                //textBox19.Text = row.Cells[6].Value.ToString();
                if (textBox23.Text !="")
                {
                    DialogResult dialogResult = MessageBox.Show(" Dont'worry! our server can't contain any malicious,unwanted program or any harmfull program or file . Want to download ?", "This mail contain file", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        File.Copy(@"\\\\JISANRAHMAN-PC\New folder\"+textBox23.Text, @"C:\AITVET\Email\" + art+textBox23.Text);
                        textBox23.Text = "";
                        MessageBox.Show("Download successfull");
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                } 
                //textBox12.Text = row.Cells[3].Value.ToString();
                //textBox12.Text = textBox8.Text + textBox12.Text;
                timer1.Enabled = false;
                if (textBox9.Text != "" || textBox9.Text == "")
                    timer1.Enabled = true;

                Class1 dbaccess1 = new Class1();
                dbaccess1.Sender_id = textBox4.Text;
                dbaccess1.Receiver_id = textBox5.Text;
                dbaccess1.Information = textBox9.Text;
                dbaccess1.Receive_date = textBox6.Text;
                dbaccess1.Status = "Read " + DateTime.Now.ToString("MMM  dd ,dddd, yyyy hh:mm:ss tt");

                if (dbaccess1.DataupInEmail())
                {

                }
                else
                {

                }

                /* Class1 dbaccess2 = new Class1();
                 dbaccess2.Sender_id = textBox4.Text;
                 dbaccess2.Semester_no = textBox1.Text;
                 dbaccess2.Course_id = textBox2.Text;
                 dbaccess2.Information = textBox9.Text;
                 dbaccess2.Receive_date = textBox6.Text;
                 dbaccess2.Status = textBox12.Text;

                 if (dbaccess2.DataupInEmail1())
                 {

                 }
                 else
                 {
                     MessageBox.Show("");
                 }*/
              /* if(textBox17.Text=="group") { Class1 dbaccess58 = new Class1();
                dbaccess58.Sender_id = textBox15.Text;
                dbaccess58.Receiver_id = textBox8.Text;
                dbaccess58.Semester_no = textBox18.Text;
                dbaccess58.Course_id = textBox19.Text;
                dbaccess58.Status = "group";


                dbaccess58.Information = textBox9.Text;
                dbaccess58.Receive_date = textBox16.Text;
                dbaccess58.Receive_time = DateTime.Now.ToString("MMM  dd ,dddd, yyyy hh:mm:ss tt");



                if (dbaccess58.DataSaveInEmail12())
                { }
                else { }
            }*/
                }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Sort(this.dataGridView1.Columns["Receive_Date_Time"], ListSortDirection.Descending);
          

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox9.Text = DateTime.Now.ToString("MMM  dd ,dddd, yyyy hh:mm:ss tt");  //dddd, MMMM dd, yyyy
            DataGridViewColumn column = dataGridView1.Columns[2];
            column.Width = 200;
            //dataGridView1.AutoSizeColumnsMode =
            //DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;

            textBox3.Text = textBox8.Text;
                textBox11.Text = DateTime.Now.ToString("HH:mm:ss tt");
                textBox10.Text = DateTime.Now.ToString("MMM  dd ,dddd, yyyy hh:mm:ss tt"); 
                label10.Visible = true;

                Class1 dbaccess = new Class1();
                dbaccess.Sender_id = textBox8.Text;
                dbaccess.Receiver_id = "";
                dbaccess.Semester_no = comboBox2.Text;
                dbaccess.Course_id = comboBox1.Text;
            dbaccess.Status = "group";


            dbaccess.Information = textBox9.Text;
                dbaccess.Receive_date = textBox10.Text;
                dbaccess.Receive_time = textBox11.Text;

            dbaccess.F = ff;

            if (dbaccess.DataSaveInEmail())
                {

                //label10.Text = "send suceessfull ";
                MessageBox.Show("send suceesfull");
                textBox9.Clear();
                textBox24.Clear();
                ff = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                button7.PerformClick();
              

            }
                else
                {
                MessageBox.Show("fail");
                // label10.Text = "send fail ";
            }
            
           
        }

     

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView5.Visible = false;
            timer2.Enabled = true;
            timer1.Enabled = false;
            dataGridView3.Visible = true;
          //  dataGridView2.Visible = false;
            dataGridView1.Visible = false;
            Email f = new Email();
            f.Refresh();
            dataGridView3.Refresh();
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select receiver_id,semester_no as receive_semester , course_id as receive_Technology,information,status,receive_date as receive_date_time,f as Attach from email where sender_id='" + textBox8.Text + "' and (receiver_id!=''  or semester_no!='' )order by Serial_No desc", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView3.DataSource = dt;
           // this.dataGridView3.Sort(this.dataGridView3.Columns["receive_date_time"], ListSortDirection.Descending);
            DataGridViewColumn column = dataGridView3.Columns[5];
            column.Width = 220;

         
        }

       /* private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            textBox9.Text = row.Cells[1].Value.ToString();
        }
        */
        private void timer1_Tick(object sender, EventArgs e)
        {
            button6.PerformClick();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            button6.PerformClick();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            textBox13.Multiline = true;
            textBox13.ScrollBars = ScrollBars.Both;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                textBox13.Text = row.Cells[4].Value.ToString();
                textBox20.Text = row.Cells[1].Value.ToString();
                textBox21.Text = row.Cells[2].Value.ToString();
                textBox22.Text = row.Cells[5].Value.ToString();
                textBox24.Text = row.Cells[6].Value.ToString();
                textBox9.Text = row.Cells[3].Value.ToString();
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("(select receiver_id as Seen_By from Email1 where   receive_date = '"+textBox22.Text+"' and semester_no = '"+textBox20.Text+"' and course_id = '"+textBox21.Text+"'and information = '"+textBox9.Text+"' and sender_id = '"+textBox8.Text+ "') intersect (select receiver_id as Seen_By from Email1 where  receive_date = '" + textBox22.Text+"' and semester_no = '"+textBox20.Text+"' and course_id = '"+textBox21.Text+"'and information = '"+textBox9.Text+"' and sender_id = '"+textBox8.Text+"')  ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;


            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select status as New_Email from email where receiver_id='" + textBox8.Text + "' and status='not read'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView4.DataSource = dt;

            int v, a;
            textBox14.Text = dataGridView4.RowCount.ToString();
            v = int.Parse(textBox14.Text);
            a = v - 1;

            textBox14.Text = a.ToString();
            button2.Text = "Inbox"+" ( "+textBox14.Text+" )";

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            button17.PerformClick();
            
          
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int aaa ;
            aaa = int.Parse(textBox25.Text);
            aaa = aaa + 1;
            textBox25.Text = aaa.ToString();
            
            if (textBox25.Text == "9") textBox25.Text = "0";

            if (textBox25.Text == "1") { button9.Visible = true; button13.Visible = false; }
            if (textBox25.Text == "2") { button10.Visible = true; button9.Visible = false; }
            if (textBox25.Text == "3") { button12.Visible = true; button10.Visible = false; }
            if (textBox25.Text == "4") { button11.Visible = true; button12.Visible = false; }
            if (textBox25.Text == "5") { button16.Visible = true; button11.Visible = false; }
            if (textBox25.Text == "6") { button15.Visible = true; button16.Visible = false; }
            if (textBox25.Text == "7") { button14.Visible = true; button15.Visible = false; }
            if (textBox25.Text == "8") { button13.Visible = true; button14.Visible = false; }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
           // dataGridView2.Visible = false;
            dataGridView22.Visible = false; 
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = true;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select sender_id,information,receive_date as Receive_Date_Time,status,f as Attach,semester_no as Only,course_id as Department from email where   (semester_no='" + textBox1.Text + "' or semester_no='all') and (course_id='" + textBox2.Text + "' or course_id='all'or course_id='" + textBox26.Text + "') order by Serial_No desc", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView5.DataSource = dt;
          //  this.dataGridView5.Sort(this.dataGridView5.Columns["Receive_Date_Time"], ListSortDirection.Descending);
            DataGridViewColumn column1 = dataGridView5.Columns[0];
            column1.Width = 60;

            DataGridViewColumn column2 = dataGridView5.Columns[1];
            column2.Width = 160;

            DataGridViewColumn column = dataGridView5.Columns[2];
            column.Width = 160;
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Class1 dbaccess = new Class1();
            dbaccess.Department_id = "";
            if (dbaccess.DataSaveInfilen()) { }
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select max(Serial_no) from filen ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView22.DataSource = dt;

            DataGridViewRow row1 = this.dataGridView22.Rows[0];
            art = int.Parse(row1.Cells[0].Value.ToString());
            string p = "";
            if (e.RowIndex >= 0)
            {
                textBox23.Text = "";
                DataGridViewRow row = this.dataGridView5.Rows[e.RowIndex];
                //populate the textBox from specific value of the coordinates of column and row.
                // textBox13.Text = row.Cells[3].Value.ToString();
                textBox9.Text = row.Cells[1].Value.ToString();
                textBox4.Text = row.Cells[0].Value.ToString();
                textBox15.Text = row.Cells[0].Value.ToString();
                textBox5.Text = textBox8.Text;
                textBox6.Text = row.Cells[2].Value.ToString();
                textBox16.Text = row.Cells[2].Value.ToString();
                textBox17.Text = row.Cells[3].Value.ToString();
                textBox23.Text = row.Cells[4].Value.ToString();
                textBox18.Text = row.Cells[5].Value.ToString();
                textBox19.Text = row.Cells[6].Value.ToString();
                textBox24.Text = row.Cells[4].Value.ToString();
                //SqlDataAdapter sda = new SqlDataAdapter("(select receiver_id as Seen_By, receive_time as Seen_time from Email1 where   receive_date = '"+textBox22.Text+"' and semester_no = '"+textBox20.Text+"' and course_id = '"+textBox21.Text+"'and information = '"+textBox9.Text+"' and sender_id = '"+textBox8.Text+ "')
                SqlConnection conz = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sdaz = new SqlDataAdapter("select serial_no from Email where   receive_date = '"+textBox16.Text+"' and semester_no = '"+textBox18.Text+"' and course_id = '"+textBox19.Text+"'and information = '"+textBox9.Text+"' and sender_id = '"+textBox4.Text+ "' and status='group'",conz);

                DataTable dtz = new DataTable();
                sdaz.Fill(dtz);
                dataGridView7.DataSource = dtz;
                string g;
               
                DataGridViewRow row8 = this.dataGridView7.Rows[0];
                 g= row8.Cells[0].Value.ToString();
                Class1 d = new Class1();
                d.Student_id = textBox8.Text;
                d.Semester_no = g;
                if (d.DataSaveIng()) { }
                if (textBox23.Text != "")
                {
                    DialogResult dialogResult = MessageBox.Show(" Dont'worry! our server can't contain any malicious,unwanted program or any harmfull program or file . Want to download ?", "This mail contain file", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        File.Copy(@"\\\\JISANRAHMAN-PC\New folder\" + textBox23.Text, @"C:\AITVET\Email\" + art + textBox23.Text);
                        textBox23.Text = "";
                        MessageBox.Show("Download successfull");
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }
                //textBox12.Text = row.Cells[3].Value.ToString();
                //textBox12.Text = textBox8.Text + textBox12.Text;
                timer1.Enabled = false;
                if (textBox9.Text != "" || textBox9.Text == "")
                    timer1.Enabled = true;

                Class1 dbaccess1 = new Class1();
                dbaccess1.Sender_id = textBox4.Text;
                dbaccess1.Receiver_id = textBox5.Text;
                dbaccess1.Information = textBox9.Text;
                dbaccess1.Receive_date = textBox6.Text;
                dbaccess1.Status = "Read " + DateTime.Now.ToString("MMM  dd ,dddd, yyyy hh:mm:ss tt");

                if (dbaccess1.DataupInEmail())
                {

                }
                else
                {

                }

                /* Class1 dbaccess2 = new Class1();
                 dbaccess2.Sender_id = textBox4.Text;
                 dbaccess2.Semester_no = textBox1.Text;
                 dbaccess2.Course_id = textBox2.Text;
                 dbaccess2.Information = textBox9.Text;
                 dbaccess2.Receive_date = textBox6.Text;
                 dbaccess2.Status = textBox12.Text;

                 if (dbaccess2.DataupInEmail1())
                 {

                 }
                 else
                 {
                     MessageBox.Show("");
                 }*/
                if (textBox17.Text == "group")
                {
                    Class1 dbaccess58 = new Class1();
                    dbaccess58.Sender_id = textBox15.Text;
                    dbaccess58.Receiver_id = textBox8.Text;
                    dbaccess58.Semester_no = textBox18.Text;
                    dbaccess58.Course_id = textBox19.Text;
                    dbaccess58.Status = "group";

                    dbaccess58.S = g;
                    dbaccess58.Information = textBox9.Text;
                    dbaccess58.Receive_date = textBox16.Text;
                    dbaccess58.Receive_time = DateTime.Now.ToString("MMM  dd ,dddd, yyyy hh:mm:ss tt");



                    if (dbaccess58.DataSaveInEmail12())
                    { }
                    else { }
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int v, a,z,x,y;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select sender_id,information,receive_date as Receive_Date_Time,status,f as Attach,semester_no as Only,course_id as Department from email where   (semester_no='" + textBox1.Text + "' or semester_no='all') and (course_id='" + textBox2.Text + "' or course_id='all' or course_id='" + textBox26.Text + "')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView6.DataSource = dt;
            
            v = int.Parse(dataGridView6.RowCount.ToString());

            a = v - 1;
            SqlConnection conl = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdal = new SqlDataAdapter("(select * from g where student_id='"+textBox8.Text+ "') intersect (select * from g where student_id='" + textBox8.Text + "')", conl);
            DataTable dtl = new DataTable();
            sdal.Fill(dtl);
            dataGridView8.DataSource = dtl;


            z = int.Parse(dataGridView8.RowCount.ToString());

            x = z - 1;
            y = (a - z)+1;
            
                button18.Text = "Group" + " ( " + y.ToString() + " )";
            if (y < 0) { button18.Text = "Group" + " ( " +"0" + " )"; }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            button19.PerformClick();
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            dataGridView9.Visible = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            SqlConnection cong = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdag = new SqlDataAdapter("select *from login_id where login_id='" + textBox7.Text + "' and(log_type='admin' or log_type='teacher' )", cong);
            DataTable dtg = new DataTable();
            sdag.Fill(dtg);
            dataGridView7.DataSource = dtg;
            int v, a;
            a = int.Parse(dataGridView7.RowCount.ToString());

            a = a - 1;
            if (a != 1) { 
            textBox5.Text = a.ToString();
            timer2.Enabled = true;
            textBox3.Text = "not read";
            if (textBox7.Text != "")
            {
                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox11.Text = DateTime.Now.ToString("HH:mm:ss tt");
                textBox10.Text = DateTime.Now.ToString("MMM  dd ,dddd, yyyy hh:mm:ss tt");
                // label10.Visible = true;

                Class1 dbaccess = new Class1();
                dbaccess.Sender_id = textBox8.Text;
                dbaccess.Receiver_id = textBox7.Text;
                    dbaccess.Semester_no = "";
                    dbaccess.Course_id = "";
                dbaccess.Status = "block";


                dbaccess.Information = "";
                dbaccess.Receive_date = textBox10.Text;
                dbaccess.Receive_time = textBox11.Text;
                dbaccess.F = "";



                if (dbaccess.DataSaveInEmail())
                {
                    MessageBox.Show(" suceesfull");
                        SqlConnection conga = new SqlConnection(Properties.Settings.Default._ConnectionString);
                        SqlDataAdapter sdaga = new SqlDataAdapter("update email set b='block ' where sender_id='"+textBox8.Text+"' and receiver_id='"+textBox7.Text+"' ", conga);
                        DataTable dtga = new DataTable();
                        sdaga.Fill(dtga);
                        dataGridView7.DataSource = dtga;
                        // label10.Text = "send suceessfull ";
                        button7.PerformClick();

                }
                else
                {
                    MessageBox.Show("fail");
                    // label10.Text = "send fail ";
                }
            }
            else
            {
                // label10.Visible = true;
                //label10.Text = "Not possible ";
            }
            }
            else {MessageBox.Show("you can't block admin or teacher"); }
        }

        private void button21_Click(object sender, EventArgs e)
        {
           
            SqlConnection conga = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdaga = new SqlDataAdapter("update email set b='' where sender_id='" + textBox8.Text + "' and receiver_id='" + textBox7.Text + "' ", conga);
            DataTable dtga = new DataTable();
            sdaga.Fill(dtga);
            dataGridView7.DataSource = dtga;
            MessageBox.Show(" suceesfull");
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Class1 d = new Class1();
                d.Id = textBox7.Text;
                if (d.DataSaveInm()) { } else { MessageBox.Show("ID not found"); }
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select *from m", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView12.DataSource = dt;
                textBox7.Clear();

            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboBox2.Focus();
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox9.Focus();
        }

        private void dataGridView12_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                DataGridViewRow row = this.dataGridView12.Rows[e.RowIndex];

                textBox7.Text = row.Cells[0].Value.ToString();
                SqlConnection conm = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sdam = new SqlDataAdapter("delete from m where id='"+textBox7.Text+"'", conm);
                DataTable dtm = new DataTable();
                sdam.Fill(dtm);
                
            }
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select *from m", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView12.DataSource = dt;
            textBox7.Clear();
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            
            
            button23.PerformClick();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            //timer7.Enabled = true;
            timer2.Enabled = true;
            textBox3.Text = "not read";
            SqlConnection cong = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdag = new SqlDataAdapter("select *from email where ((receiver_id='" + textBox7.Text + " ' and sender_id='" + textBox8.Text + " ')or(receiver_id='" + textBox8.Text + " ' and sender_id='" + textBox7.Text + " ') )and b='block'", cong);
            DataTable dtg = new DataTable();
            sdag.Fill(dtg);
            dataGridView11.DataSource = dtg;
            int v, a;
            a = int.Parse(dataGridView11.RowCount.ToString());

            a = a - 1;
            if (a > 0) { MessageBox.Show("Block"); }
            else
            {

                if (textBox7.Text != "")
                {
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    textBox11.Text = DateTime.Now.ToString("HH:mm:ss tt");
                    textBox10.Text = DateTime.Now.ToString("MMM  dd ,dddd, yyyy hh:mm:ss tt");
                    // label10.Visible = true;

                    Class1 dbaccess = new Class1();
                    dbaccess.Sender_id = textBox8.Text;
                    dbaccess.Receiver_id = textBox7.Text;
                    dbaccess.Semester_no = comboBox2.Text;
                    dbaccess.Course_id = comboBox1.Text;
                    dbaccess.Status = textBox3.Text;


                    dbaccess.Information = textBox9.Text;
                    dbaccess.Receive_date = textBox10.Text;
                    dbaccess.Receive_time = textBox11.Text;
                    dbaccess.F = ff;



                    if (dbaccess.DataSaveInEmail())
                    {
                      //  MessageBox.Show("send suceesfull");
                       // textBox7.Clear();
                      //  textBox9.Clear();
                        textBox24.Clear();
                      //  ff = "";
                        // label10.Text = "send suceessfull ";
                        button7.PerformClick();

                    }
                    else
                    {
                        MessageBox.Show("fail");
                        // label10.Text = "send fail ";
                    }
                }
                else
                {
                    // label10.Visible = true;
                    label10.Text = "Not possible ";
                }
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select *from m", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView12.DataSource = dt;

            mul = int.Parse(dataGridView12.RowCount.ToString());
            mul = mul - 1 ;
            id = 0;
                
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            textBox9.Clear();
            textBox24.Clear();
        }

        private void button23_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(mul.ToString());
          
            DataGridViewRow row = this.dataGridView12.Rows[id];
            if (id <= mul-1)
            {
                textBox7.Text = row.Cells[0].Value.ToString();

                button24.PerformClick();

                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("delete from m where id='"+textBox7.Text+"'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                id = id + 1;
            }
            else if(id>mul-1) { id = 0;timer7.Enabled = false; SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select *from m", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView12.DataSource = dt;
                textBox7.Clear();
                textBox9.Clear();
                ff = "";
                MessageBox.Show("suceesfull");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            Class1 dbaccess = new Class1();
            dbaccess.Department_id = "";
            if (dbaccess.DataSaveInfilen()) { }
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select max(Serial_no) from filen ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView22.DataSource = dt;
            
            DataGridViewRow row = this.dataGridView22.Rows[0];
            art = int.Parse(row.Cells[0].Value.ToString());
            /*  +art + "__"  */
           
            try
            {
               
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "All Files(*.*)|*.*";
               
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start(@"C:\AITVET\WindowsFormsApplication3.exe");

                    s = dlg.FileName.ToString();
                   
                    ff= art + "__" + dlg.SafeFileName.ToString();
                    y = @"\\\\JISANRAHMAN-PC\New folder\" + art + "__" + dlg.SafeFileName.ToString();
                   // textBox19.Text = @"C:\New folder\" + art + "__" + dlg.SafeFileName.ToString();
                    File.Copy(s, y);
                    timer4.Enabled = false;
                    Process[] p = Process.GetProcesses();
                    foreach (Process ps in p)
                    {
                        string s = ps.ProcessName;
                        s = s.ToLower();
                        if (s.CompareTo("windowsformsapplication3") == 0) { ps.Kill(); }
                    }
                    MessageBox.Show("Upload successfull");
                  //  System.Diagnostics.Process(@"C:\Users\Jisan Rahman\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\bin\Debug\WindowsFormsApplication3.exe");

                    textBox24.Text = ff;
                   
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            

        }
    }
}
