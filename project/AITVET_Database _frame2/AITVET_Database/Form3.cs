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
    public partial class Form3 : Form
    {
        string imgloc = "",pic,abc;
        public Form3()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox8.Text = comboBox1.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.ImageLocation == "" || textBox1.Text == "" || textBox13.Text == "" || textBox12.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox14.Text == "" || comboBox1.Text == "" || comboBox2.Text == "") { MessageBox.Show("Fill ip all field"); }
            else
            { 
            // textBox21.Text = DateTime.Now.ToString("MMM  dd ,dddd, yyyy hh:mm:ss tt");
            textBox20.Text = dateTimePicker2.Text;
            if (textBox9.Text == "") { MessageBox.Show("insert image"); }
            if (textBox14.Text == "") { MessageBox.Show("salary can't be blank and insert only numeric value"); }
            textBox15.Text = dateTimePicker2.Text;
            if (textBox12.Text.Length < 4) { MessageBox.Show("password length can't <4"); }

            textBox17.Text = comboBox2.Text;
            textBox13.Text = textBox1.Text;
            textBox16.Text = textBox1.Text;
            if (textBox13.Text.Length > 0 && textBox12.Text.Length > 0 && textBox11.Text.Length > 0 && textBox12.Text == textBox10.Text && textBox9.Text != "")
            {
                Class1 dbaccess = new Class1();
                dbaccess.Login_id = textBox13.Text;
                dbaccess.Login_password = textBox12.Text;
                dbaccess.Log_type = textBox11.Text;
                if (dbaccess.DataSaveInTable())
                {
                    button5.Text = "s";


                }
                else
                {
                    button5.Text = "f";
                    //label9.Text = "check teacher id";
                    MessageBox.Show("ID already use");
                }




            }
            else
            {

            }



            /////
            if (button5.Text == "s")
            {
                textBox22.Visible = true;
                dateTimePicker1.Visible = false;
                //label9.Visible = true;
                // textBox7.Text = dateTimePicker1.Text;
                Class1 dbaccess = new Class1();
                dbaccess.Teacher_id = textBox1.Text;
                dbaccess.Teacher_name = textBox2.Text;
                dbaccess.Picture = textBox200.Text;
                    dbaccess.Gender = comboBox1.Text;
                dbaccess.DOB = dateTimePicker1.Text;
                dbaccess.Phone = textBox3.Text;
                dbaccess.Email = textBox4.Text;
                dbaccess.Current_Address = textBox5.Text;
                dbaccess.Permanent_Address = textBox6.Text;
                dbaccess.Insert_By = DateTime.Now.ToString(" MMM dd ,dddd, yyyy hh:mm:ss tt ") + textBox21.Text;


                if (dbaccess.DataSaveInTeacher())
                {
                    //label9.Visible = true;
                    button8.Text = "s";
                    /*this.Hide();
                    at a = new at();
                    a.textBox1.Enabled = false;
                    a.textBox1.Text = textBox1.Text;
                    a.Show();*/

                }
                else
                {
                    //label9.Visible = true;
                    button8.Text = "f";
                }
            }

            /////////////////
            textBox17.Text = comboBox2.Text;
            if (button8.Text == "s")
            {

                Class1 dbaccess = new Class1();
                dbaccess.Department_id = textBox17.Text;
                dbaccess.Teacher_id1 = textBox1.Text;



                dbaccess.Appoint_date = DateTime.Now.ToString(" MMM dd ,dddd, yyyy ");

                dbaccess.Salary = textBox14.Text;



                if (dbaccess.DataSaveInAppoint())
                {
                    //label9.Visible = true;
                    // label9.Text = "submit suceesfull";
                    MessageBox.Show("sucess");
                    int tempa, tempb, tempc;
                    tempa = int.Parse(DateTime.Now.ToString("ssmmss"));
                    tempb = int.Parse(DateTime.Now.ToString("ssssss"));
                    tempc = (tempa + tempb * tempb);

                    Class1 te = new Class1();
                    te.Login_id = textBox1.Text;
                    te.Login_password = tempc.ToString();
                    if (te.DataSaveInTemp()) { }

                    SqlConnection conw = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sdaw = new SqlDataAdapter("update appoint set teacher_id='" + textBox1.Text + "' where teacher_id1='" + textBox1.Text + "'", conw);
                    DataTable dtw = new DataTable();
                    sdaw.Fill(dtw);
                    dataGridView1.DataSource = dtw;

                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("select teacher.teacher_id,teacher_name,image,gender,DOB,Phone,email,Current_Address,Permanent_Address,appoint_date,salary,department_id,picture,Insert_By from teacher,appoint where teacher.teacher_id=appoint.teacher_id and teacher.teacher_id='" + textBox1.Text + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;


                    DataGridViewImageColumn image = new DataGridViewImageColumn();
                    image = (DataGridViewImageColumn)dataGridView1.Columns[2];
                    image.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    button14.PerformClick();
                    textBox18.Text = textBox1.Text;
                    button9.PerformClick();
                    textBox1.Clear();
                    textBox13.Clear();
                    textBox12.Clear();
                    textBox10.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    //comboBox1.Text = "";
                    //comboBox2.Text = "";
                    textBox14.Clear();
                    textBox9.Clear();
                    button5.Text = "";
                    button8.Text = "";
                    pictureBox1.ImageLocation = "";

                    textBox18.Clear();
                 

                }
                else
                {
                    //label9.Visible = true;
                    //label9.Text = "submit fail";
                    MessageBox.Show("Fail");
                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("delete from login_id where login_id='" + textBox1.Text + "' delete from teacher where teacher_id='" + textBox1.Text + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                }
            }
            else { }
            if (textBox12.Text == textBox10.Text)
            {
            }
            else
            {
                MessageBox.Show("Password not match");
                //label9.Text = "Password not match";
                //label9.Visible = true;
            }
        }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1 dbaccess = new Class1();
            dbaccess.Department_id = "";
            if (dbaccess.DataSaveInfilen()) { }
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select max(Serial_no) from filen ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView22.DataSource = dt;
            int art;
            DataGridViewRow row = this.dataGridView22.Rows[0];
            art = int.Parse(row.Cells[0].Value.ToString());
            /*  +art + "__"  */
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files(*.jpg)|*.jpg";
                dlg.Title = "select emp pic";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgloc = dlg.FileName.ToString();
                    pictureBox1.ImageLocation = imgloc;
                    
                    
                    abc = @"\\\\JISANRAHMAN-PC\New folder\" + art + "__" + dlg.SafeFileName.ToString();
                    pic = @"C:\New folder\" + art + "__" + dlg.SafeFileName.ToString();
                    textBox200.Text = art + "__" + dlg.SafeFileName.ToString();
                    File.Copy(imgloc, abc);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            textBox9.Text = imgloc;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Form1 l = new Form1();
            l.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox13.Text.Length > 0 && textBox12.Text.Length > 0 && textBox11.Text.Length > 0 && textBox12.Text == textBox10.Text)
            {
                Class1 dbaccess = new Class1();
                dbaccess.Login_id = textBox13.Text;
                dbaccess.Login_password = textBox12.Text;
                dbaccess.Log_type = textBox11.Text;
                if (dbaccess.DataSaveInTable())
                {
                    button5.Text = "s";
                }
                else
                {
                    button5.Text = "f";
                }

              


            }
            else
            {
                
            }
            if (textBox12.Text == textBox10.Text)
            { }
            else
            {
                button4.Text = "password not match ";
                button4.Visible = true;
                button3.Visible = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aITVETDataSet50.teacher' table. You can move, or remove it, as needed.
            this.teacherTableAdapter2.Fill(this.aITVETDataSet50.teacher);
            // TODO: This line of code loads data into the 'aITVETDataSet43.teacher' table. You can move, or remove it, as needed.
            this.teacherTableAdapter1.Fill(this.aITVETDataSet43.teacher);
            this.MaximizeBox = false;// TODO: This line of code loads data into the 'aITVETDataSet25.department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter1.Fill(this.aITVETDataSet25.department);

            // TODO: This line of code loads data into the 'aITVETDataSet24.teacher' table. You can move, or remove it, as needed.
            //****this.teacherTableAdapter.Fill(this.aITVETDataSet24.teacher);
           
            this.ControlBox = false;
            // TODO: This line of code loads data into the 'aITVETDataSet.department' table. You can move, or remove it, as needed.

            button11.PerformClick();
           textBox22.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
       
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox13.Text = textBox1.Text;
                textBox12.Focus();
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox10.Focus();
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox3.Focus();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox4.Focus();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox5.Focus();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox6.Focus();
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
           
            
                if (e.KeyCode == Keys.Enter)
                    dateTimePicker1.Focus();
            
           
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox14.Focus();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboBox1.Focus();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboBox2.Focus();
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
                textBox14.Focus();
            }
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
           

        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
                

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select teacher.teacher_id,teacher_name,image,gender,DOB,Phone,email,Current_Address,Permanent_Address,appoint_date,salary,department_id,picture,Insert_By,Update_Time as Update_By from teacher,appoint where teacher.teacher_id=appoint.teacher_id and teacher.teacher_id='" + textBox18.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[2];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\AITVET\WindowsFormsApplication3.exe");
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select teacher.teacher_id,teacher_name,image,gender,DOB,Phone,email,Current_Address,Permanent_Address,appoint_date,salary,department_id,picture,Insert_By,Update_Time as Update_By from teacher,appoint where teacher.teacher_id=appoint.teacher_id", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
          

            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[2];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;
            Process[] p = Process.GetProcesses();
            foreach (Process ps in p)
            {
                string s = ps.ProcessName;
                s = s.ToLower();
                if (s.CompareTo("windowsformsapplication3") == 0) { ps.Kill(); }
            }
            //dataGridView1.RowTemplate.Height = 500;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") { 
            // textBox7.Text= dateTimePicker1.Text ;
            //textBox20.Text = dateTimePicker2.Text;
            DialogResult dialogResult = MessageBox.Show("Update this item", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("update teacher set teacher_name='" + textBox2.Text + "',picture='" + textBox200.Text + "',gender='" + comboBox1.Text + "',Phone='" + textBox3.Text + "',Email='" + textBox4.Text + "',Current_Address='" + textBox5.Text + "',Permanent_Address='" + textBox6.Text + "',Update_Time='" + DateTime.Now.ToString(" MMM dd ,dddd, yyyy hh:mm:ss tt ") + textBox21.Text + "' where teacher_id='" + textBox1.Text + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    button13.PerformClick();
                    button14.PerformClick();
                    textBox18.Text = textBox1.Text;
                    button12.PerformClick();
                    textBox18.Clear();
                    textBox1.Clear();
                    textBox13.Clear();
                    textBox12.Clear();
                    textBox10.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    //comboBox1.Text = "";
                    //comboBox2.Text = "";
                    textBox14.Clear();
                    textBox9.Clear();
                    button5.Text = "";
                    button8.Text = "";
                    pictureBox1.ImageLocation = "";

                    textBox18.Clear();


                }
            else if (dialogResult == DialogResult.No)
            {
                    //do something else
                }
            }
            else { MessageBox.Show("select item first"); }




        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                // textBox13.Text = row.Cells[3].Value.ToString();
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
             
                comboBox1.Text = row.Cells[3].Value.ToString();
                textBox22.Text = row.Cells[4].Value.ToString();
                textBox3.Text = row.Cells[5].Value.ToString();
                textBox4.Text = row.Cells[6].Value.ToString();
                textBox5.Text = row.Cells[7].Value.ToString();
                textBox6.Text = row.Cells[8].Value.ToString();
                textBox20.Text = row.Cells[9].Value.ToString();
                textBox14.Text = row.Cells[10].Value.ToString();
                comboBox2.Text = row.Cells[11].Value.ToString();
                textBox200.Text = row.Cells[12].Value.ToString();
                pictureBox1.ImageLocation = @"\\\\JISANRAHMAN-PC\New folder\" + textBox200.Text;
                pic = @"C:\New folder\" + textBox200.Text;
              
                // dateTimePicker1.Text = textBox7.Text;
                //dateTimePicker2.Text = textBox20.Text;
                dateTimePicker1.Visible = false;


                textBox22.Visible = true;




            }



        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select teacher.teacher_id,teacher_name,image,gender,DOB,Phone,email,Current_Address,Permanent_Address,appoint_date,salary,department_id,picture,Insert_By,Update_Time as Update_By from teacher,appoint where teacher.teacher_id=appoint.teacher_id and teacher.teacher_id='" + textBox18.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[2];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;

            int v, a;
            textBox19.Text = dataGridView1.RowCount.ToString();
            v = int.Parse(textBox19.Text);
            a = v - 1;

            textBox19.Text = a.ToString();
            if (textBox19.Text == "1")
            {
                DataGridViewRow row = this.dataGridView1.Rows[0];
                //populate the textbox from specific value of the coordinates of column and row.
                // textBox13.Text = row.Cells[3].Value.ToString();
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                pictureBox1.ImageLocation = row.Cells[12].Value.ToString();

                comboBox1.Text = row.Cells[3].Value.ToString();
                textBox22.Text = row.Cells[4].Value.ToString();
                textBox3.Text = row.Cells[5].Value.ToString();
                textBox4.Text = row.Cells[6].Value.ToString();
                textBox5.Text = row.Cells[7].Value.ToString();
                textBox6.Text = row.Cells[8].Value.ToString();
                textBox20.Text = row.Cells[9].Value.ToString();
                textBox14.Text = row.Cells[10].Value.ToString();
                comboBox2.Text = row.Cells[11].Value.ToString();
            }
            else
            {
               
                textBox1.Clear();
                textBox13.Clear();
                textBox12.Clear();
                textBox10.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                //comboBox1.Text = "";
                //comboBox2.Text = "";
                textBox14.Clear();
                textBox9.Clear();
                button5.Text = "";
                button8.Text = "";
                pictureBox1.ImageLocation = "";

                textBox18.Clear();
            }
        }

        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button12.PerformClick();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("update appoint set appoint_date='" + textBox20.Text + "',salary='" + textBox14.Text + "',department_id='" + comboBox2.Text + "' where teacher_id='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("update teacher set image=BulkColumn FROM Openrowset( Bulk '"+pic+"', Single_Blob) as blob where teacher_id='"+textBox1.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.departmentTableAdapter.FillBy(this.aITVETDataSet.department);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox18.Text = comboBox3.Text;
            button12.PerformClick();
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                textBox18.Text = comboBox3.Text;
                button12.PerformClick();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox18.Text = comboBox3.Text;
            button12.PerformClick();
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox18.Text = comboBox3.Text;
                button12.PerformClick();
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox22.Visible = true;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select teacher.teacher_id,teacher_name,image,gender,DOB,Phone,email,Current_Address,Permanent_Address,appoint_date,salary,department_id,picture,Insert_By,Update_Time as Update_By from teacher,appoint where teacher.teacher_id=appoint.teacher_id and  teacher.teacher_id='" + comboBox5.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[2];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;
            int v, a;
            a = int.Parse(dataGridView1.RowCount.ToString());
            v = a;
            a = v - 1;
            if (a == 1) { DataGridViewRow row = this.dataGridView1.Rows[0];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                pictureBox1.ImageLocation = row.Cells[12].Value.ToString();

                comboBox1.Text = row.Cells[3].Value.ToString();
                textBox22.Text = row.Cells[4].Value.ToString();
                textBox3.Text = row.Cells[5].Value.ToString();
                textBox4.Text = row.Cells[6].Value.ToString();
                textBox5.Text = row.Cells[7].Value.ToString();
                textBox6.Text = row.Cells[8].Value.ToString();
                textBox20.Text = row.Cells[9].Value.ToString();
                textBox14.Text = row.Cells[10].Value.ToString();
                comboBox2.Text = row.Cells[11].Value.ToString();
                a = 0;
            }else {
                textBox1.Clear();
                textBox13.Clear();
                textBox12.Clear();
                textBox10.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                //comboBox1.Text = "";
                //comboBox2.Text = "";
                textBox14.Clear();
                textBox9.Clear();
                button5.Text = "";
                button8.Text = "";
                pictureBox1.ImageLocation = "";

                textBox18.Clear();
            }
          
        }

        private void comboBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                textBox22.Visible = true;
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select teacher.teacher_id,teacher_name,image,gender,DOB,Phone,email,Current_Address,Permanent_Address,appoint_date,salary,department_id,picture,Insert_By,Update_Time as Update_By from teacher,appoint where teacher.teacher_id=appoint.teacher_id and  teacher.teacher_id='" + comboBox5.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[2];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;
            int v, a;
            a = int.Parse(dataGridView1.RowCount.ToString());
            v = a;
            a = v - 1;
                if (a == 1)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[0];
                    textBox1.Text = row.Cells[0].Value.ToString();
                    textBox2.Text = row.Cells[1].Value.ToString();
                    pictureBox1.ImageLocation = row.Cells[12].Value.ToString();

                    comboBox1.Text = row.Cells[3].Value.ToString();
                   // dateTimePicker1.Text = row.Cells[4].Value.ToString();
                    textBox3.Text = row.Cells[5].Value.ToString();
                    textBox4.Text = row.Cells[6].Value.ToString();
                    textBox5.Text = row.Cells[7].Value.ToString();
                    textBox6.Text = row.Cells[8].Value.ToString();
                   textBox20.Text = row.Cells[9].Value.ToString();
                    textBox14.Text = row.Cells[10].Value.ToString();
                    comboBox2.Text = row.Cells[11].Value.ToString();
                    a = 0;
                }
                else
                {
                    textBox1.Clear();
                    textBox13.Clear();
                    textBox12.Clear();
                    textBox10.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    //comboBox1.Text = "";
                    //comboBox2.Text = "";
                    textBox14.Clear();
                    textBox9.Clear();
                    button5.Text = "";
                    button8.Text = "";
                    pictureBox1.ImageLocation = "";

                    textBox18.Clear();
                }
            }
        }

        private void comboBox6_KeyDown(object sender, KeyEventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\AITVET\WindowsFormsApplication3.exe");


            textBox22.Visible = true;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select teacher.teacher_id,teacher_name,image,gender,DOB,Phone,email,Current_Address,Permanent_Address,appoint_date,salary,department_id,picture,Insert_By,Update_Time as Update_By from teacher,appoint where teacher.teacher_id=appoint.teacher_id and  (teacher_name like'" + comboBox6.Text + "%' or teacher_name like'%" + comboBox6.Text + "%' or teacher_name like'%" + comboBox6.Text + "')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[2];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;

            Process[] p = Process.GetProcesses();
            foreach (Process ps in p)
            {
                string s = ps.ProcessName;
                s = s.ToLower();
                if (s.CompareTo("windowsformsapplication3") == 0) { ps.Kill(); }
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\AITVET\WindowsFormsApplication3.exe");
            textBox22.Visible = true;

            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select teacher.teacher_id,teacher_name,image,gender,DOB,Phone,email,Current_Address,Permanent_Address,appoint_date,salary,department_id,picture,Insert_By,Update_Time as Update_By from teacher,appoint where teacher.teacher_id=appoint.teacher_id and  teacher.teacher_id='" + comboBox5.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;


                DataGridViewImageColumn image = new DataGridViewImageColumn();
                image = (DataGridViewImageColumn)dataGridView1.Columns[2];
                image.ImageLayout = DataGridViewImageCellLayout.Stretch;
                int v, a;
                a = int.Parse(dataGridView1.RowCount.ToString());
                v = a;
                a = v - 1;
                if (a == 1)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[0];
                    textBox1.Text = row.Cells[0].Value.ToString();
                    textBox2.Text = row.Cells[1].Value.ToString();
                    pictureBox1.ImageLocation = row.Cells[12].Value.ToString();

                    comboBox1.Text = row.Cells[3].Value.ToString();
                    textBox22.Text = row.Cells[4].Value.ToString();
                    textBox3.Text = row.Cells[5].Value.ToString();
                    textBox4.Text = row.Cells[6].Value.ToString();
                    textBox5.Text = row.Cells[7].Value.ToString();
                    textBox6.Text = row.Cells[8].Value.ToString();
                    textBox20.Text = row.Cells[9].Value.ToString();
                    textBox14.Text = row.Cells[10].Value.ToString();
                    comboBox2.Text = row.Cells[11].Value.ToString();
                    a = 0;
                }
                else
                {
                    textBox1.Clear();
                    textBox13.Clear();
                    textBox12.Clear();
                    textBox10.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    //comboBox1.Text = "";
                    //comboBox2.Text = "";
                    textBox14.Clear();
                    textBox9.Clear();
                    button5.Text = "";
                    button8.Text = "";
                    pictureBox1.ImageLocation = "";

                    textBox18.Clear();
                }

            Process[] p = Process.GetProcesses();
            foreach (Process ps in p)
            {
                string s = ps.ProcessName;
                s = s.ToLower();
                if (s.CompareTo("windowsformsapplication3") == 0) { ps.Kill(); }
            }

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = true;
            textBox1.Clear();
            textBox13.Clear();
            textBox12.Clear();
            textBox10.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            //comboBox1.Text = "";
            //comboBox2.Text = "";
            textBox14.Clear();
            textBox9.Clear();
            button5.Text = "";
            button8.Text = "";
            pictureBox1.ImageLocation = "";

            textBox18.Clear();
            textBox20.Text = "Today";
            textBox22.Visible = false;
           
        }

        
    }
}
