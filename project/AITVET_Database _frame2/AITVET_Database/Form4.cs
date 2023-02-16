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
    public partial class Form4 : Form
    {
        string imgloc = "",pic,abc;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            if (textBox13.Text == textBox11.Text) { 
            if (textBox1.Text == "" || textBox14.Text == "" || textBox13.Text == "" || textBox11.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox14.Text == "" || comboBox1.Text == "" || comboBox2.Text == "") { MessageBox.Show("Fill ip all field"); }
            else
            {
                if (pictureBox1.ImageLocation == "") { pictureBox1.ImageLocation = textBox18.Text; abc = textBox18.Text; imgloc = textBox18.Text; pic = textBox18.Text; }
                textBox15.Text = dateTimePicker1.Text;
                textBox17.Text = dateTimePicker2.Text;
                textBox14.Text = textBox1.Text;
                textBox8.Text = comboBox1.Text;

                if (textBox14.Text.Length > 0 && textBox13.Text.Length > 0 && textBox12.Text.Length > 0 && textBox13.Text == textBox11.Text)
                {
                    Class1 dbaccess = new Class1();
                    dbaccess.Login_id = textBox14.Text;
                    dbaccess.Login_password = textBox13.Text;
                    dbaccess.Log_type = textBox12.Text;
                    if (dbaccess.DataSaveInTable())
                    {
                        button4.Text = "s";


                    }
                    else
                    {
                        button4.Text = "f";
                    }



                }
                else
                {
                }


                if (button4.Text == "s")
                {



                    textBox7.Text = dateTimePicker1.Text;
                    Class1 dbaccess = new Class1();
                    dbaccess.Student_id = textBox1.Text;
                    dbaccess.Student_name = textBox2.Text;
                    dbaccess.Picture = textBox200.Text;
                    dbaccess.Gender = comboBox1.Text;
                    dbaccess.DOB = dateTimePicker1.Text;
                    dbaccess.Phone = textBox3.Text;
                    dbaccess.Email = textBox4.Text;
                    dbaccess.Current_Address = textBox5.Text;
                    dbaccess.Permanent_Address = textBox6.Text;
                    dbaccess.Board_roll = textBox10.Text;
                    dbaccess.Insert_By = DateTime.Now.ToString(" MMM dd ,dddd, yyyy hh:mm:ss tt ") + textBox16.Text;
                    dbaccess.Admission_date = DateTime.Now.ToString(" MMM dd ,dddd, yyyy ");




                    if (dbaccess.DataSaveInStudent())
                    {
                        ///////

                        /////
                        Class1 dbaccess1 = new Class1();
                        dbaccess1.Student_id = textBox1.Text;
                        dbaccess1.Course_id = comboBox2.Text;





                        if (dbaccess1.DataSaveInTake_course())
                        {
                            if (pictureBox1.ImageLocation == "") { pictureBox1.ImageLocation = textBox18.Text; abc = textBox18.Text; imgloc = textBox18.Text; pic = textBox18.Text; }
                            button10.PerformClick();
                            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                            SqlDataAdapter sda = new SqlDataAdapter("update student set image=BulkColumn FROM Openrowset( Bulk '" + pic + "', Single_Blob) as blob where student_id='" + textBox1.Text + "'", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                            SqlConnection con2 = new SqlConnection(Properties.Settings.Default._ConnectionString);
                            SqlDataAdapter sda2 = new SqlDataAdapter("select student.student_id,board_roll,image,student_name,gender,Phone,email,Current_Address,Permanent_Address,picture,DOB,take_course.course_id,course_name,Insert_By,Update_Time as Update_By from student,take_course,course where student.student_id=take_course.student_id and take_course.course_id=course.course_id and student.student_id='" + textBox1.Text + "' ", con2);
                            DataTable dt2 = new DataTable();
                            sda2.Fill(dt2);
                            dataGridView1.DataSource = dt2;
                            DataGridViewImageColumn image = new DataGridViewImageColumn();
                            image = (DataGridViewImageColumn)dataGridView1.Columns[2];
                            image.ImageLayout = DataGridViewImageCellLayout.Stretch;

                            MessageBox.Show("Submit Successfull");
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox10.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox11.Clear();
                            textBox13.Clear();
                            textBox14.Clear();
                            comboBox1.Text = "";
                            pictureBox1.ImageLocation = "";
                            textBox1.Focus();




                        }
                        else
                        {

                        }

                    }
                    else
                    {
                        MessageBox.Show("Submit Fail");
                    }
                }
                else
                {

                    MessageBox.Show("Login ID already use");
                }

                /*  { }
                  else
                  {

                      MessageBox.Show("password not match");

                  }*/

            }
        }
            else
            {

                MessageBox.Show("password not match");

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

        private void comboBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox8.Text = comboBox1.Text;
            //button1.PerformClick();
        }

        private void button7_Click(object sender, EventArgs e)
        {
        
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'aITVETDataSet46.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.aITVETDataSet46.student);
            this.MaximizeBox = false; SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student.student_id,board_roll,image,student_name,gender,Phone,email,Current_Address,Permanent_Address,picture,DOB,take_course.course_id,course_name,Insert_By,Update_Time as Update_By from student,take_course,course where student.student_id=take_course.student_id and take_course.course_id=course.course_id ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[2];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;
            // TODO: This line of code loads data into the 'aITVETDataSet42.course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.aITVETDataSet42.course);
            this.ControlBox = false;
           // button9.PerformClick();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox14.Text = textBox1.Text;
                textBox13.Focus();
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox11.Focus();
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox10.Focus();
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
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

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox2.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a, b;
            textBox2.Focus();
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select COUNT(student_id) from reads where course_id='"+comboBox2.Text+"' and semester_no='1' and (student_type='re-addmission' or student_type='continue')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            DataGridViewRow row = this.dataGridView2.Rows[0];
            b= int.Parse( row.Cells[0].Value.ToString());
            SqlConnection cong = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdag = new SqlDataAdapter("select sit from course where course_id='" + comboBox2.Text + "'", cong);
            DataTable dtg = new DataTable();
            sdag.Fill(dtg);
            dataGridView2.DataSource = dtg;
            DataGridViewRow rowg = this.dataGridView2.Rows[0];
            a= int.Parse(rowg.Cells[0].Value.ToString());
            a = a - b;
            textBox19.Text = a.ToString();

        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox2.Focus();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
                dateTimePicker1.Focus();
                
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox8.Text = comboBox1.Text;
                button1.PerformClick();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox15.Visible = true;
                dateTimePicker1.Visible = false;
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                 textBox1.Text = row.Cells[0].Value.ToString();
                comboBox2.Text = row.Cells[11].Value.ToString();
                textBox2.Text = row.Cells[3].Value.ToString();
                textBox10.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[5].Value.ToString();
                textBox4.Text = row.Cells[6].Value.ToString();
                textBox5.Text = row.Cells[7].Value.ToString();
                textBox6.Text = row.Cells[8].Value.ToString();
                textBox15.Text = row.Cells[10].Value.ToString();
                comboBox1.Text = row.Cells[4].Value.ToString();
                textBox200.Text = row.Cells[9].Value.ToString();
               // MessageBox.Show(textBox200.Text);
                pictureBox1.ImageLocation = @"\\\\JISANRAHMAN-PC\New folder\" + textBox200.Text;
                pic = @"C:\New folder\" + textBox200.Text;

                // dateTimePicker1.Text = textBox15.Text;
                textBox17.Text= row.Cells[13].Value.ToString(); ;
               // dateTimePicker2.Text = textBox17.Text;

            }
            }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\AITVET\WindowsFormsApplication3.exe");
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student.student_id,board_roll,image,student_name,gender,Phone,email,Current_Address,Permanent_Address,picture,DOB,take_course.course_id,course_name,Insert_By,Update_Time as Update_By from student,take_course,course where student.student_id=take_course.student_id and take_course.course_id=course.course_id ", con);
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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student.student_id,board_roll,image,student_name,gender,Phone,email,Current_Address,Permanent_Address,picture,DOB,take_course.course_id,course_name,Insert_By,Update_Time as Update_By from student,take_course,course where student.student_id=take_course.student_id and take_course.course_id=course.course_id and student.student_id='"+comboBox4.Text+ "' ", con);
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
                textBox15.Visible = true;
                dateTimePicker1.Visible = false;
              
                //populate the textbox from specific value of the coordinates of column and row.
                textBox1.Text = row.Cells[0].Value.ToString();
                comboBox2.Text = row.Cells[11].Value.ToString();
                textBox2.Text = row.Cells[3].Value.ToString();
                textBox10.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[5].Value.ToString();
                textBox4.Text = row.Cells[6].Value.ToString();
                textBox5.Text = row.Cells[7].Value.ToString();
                textBox6.Text = row.Cells[8].Value.ToString();
                textBox15.Text = row.Cells[10].Value.ToString();
                comboBox1.Text = row.Cells[4].Value.ToString();
                pictureBox1.ImageLocation = row.Cells[9].Value.ToString();
                // dateTimePicker1.Text = textBox15.Text;
                textBox17.Text = row.Cells[13].Value.ToString(); ;
                // dateTimePicker2.Text = textBox17.Text;
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox10.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox11.Clear();
                textBox13.Clear();
                textBox14.Clear();
                comboBox1.Text = "";
                pictureBox1.ImageLocation = "";
                textBox1.Focus();
            }
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select student.student_id,board_roll,image,student_name,gender,Phone,email,Current_Address,Permanent_Address,picture,DOB,take_course.course_id,course_name,Insert_By,Update_Time as Update_By from student,take_course,course where student.student_id=take_course.student_id and take_course.course_id=course.course_id and student.student_id='" + comboBox4.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                DataGridViewImageColumn image = new DataGridViewImageColumn();
                image = (DataGridViewImageColumn)dataGridView1.Columns[2];
                image.ImageLayout = DataGridViewImageCellLayout.Stretch;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\AITVET\WindowsFormsApplication3.exe");
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student.student_id,board_roll,image,student_name,gender,Phone,email,Current_Address,Permanent_Address,picture,DOB,take_course.course_id,course_name,Insert_By,Update_Time as Update_By from student,take_course,course where student.student_id=take_course.student_id and take_course.course_id=course.course_id and student.student_id='" + comboBox4.Text + "' ", con);
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

        private void comboBox5_KeyDown(object sender, KeyEventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\AITVET\WindowsFormsApplication3.exe");
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student.student_id,board_roll,image,student_name,gender,Phone,email,Current_Address,Permanent_Address,picture,DOB,take_course.course_id,course_name,Insert_By,Update_Time as Update_By from student,take_course,course where student.student_id=take_course.student_id and take_course.course_id=course.course_id and (student_name like'" + comboBox5.Text + "%' or student_name like'%" + comboBox5.Text + "%' or student_name like'%" + comboBox5.Text + "') ", con);
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

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Want to update this item?", "warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                
           
                textBox17.Text = dateTimePicker2.Text;
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("update student set  board_roll='" + textBox10.Text + "',gender='" + comboBox1.Text + "',Phone='" + textBox3.Text + "',Email='" + textBox4.Text + "',Current_Address='" + textBox5.Text + "',Permanent_Address='" + textBox6.Text + "',student_name='" + textBox2.Text + "',picture='" + textBox200.Text + "',Update_Time='" + DateTime.Now.ToString("MMM  dd ,dddd, yyyy hh:mm:ss tt ") + textBox16.Text + "' where student_id='" + textBox1.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                    if (pictureBox1.ImageLocation == ""||textBox200.Text=="") { pictureBox1.ImageLocation = textBox18.Text; abc = textBox18.Text; imgloc = textBox18.Text; pic = textBox18.Text; }
                    SqlConnection con1 = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda1 = new SqlDataAdapter("update student set image=BulkColumn FROM Openrowset( Bulk '" + pic + "', Single_Blob) as blob where student_id='" + textBox1.Text + "'", con1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                dataGridView1.DataSource = dt1;
                //////

               
                //////


                SqlConnection con2 = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda2 = new SqlDataAdapter("select student.student_id,board_roll,image,student_name,gender,Phone,email,Current_Address,Permanent_Address,picture,DOB,take_course.course_id,course_name,Insert_By,Update_Time as Update_By from student,take_course,course where student.student_id=take_course.student_id and take_course.course_id=course.course_id and student.student_id='" + textBox1.Text + "' ", con2);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                dataGridView1.DataSource = dt2;
                DataGridViewImageColumn image = new DataGridViewImageColumn();
                image = (DataGridViewImageColumn)dataGridView1.Columns[2];
                image.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox10.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox11.Clear();
                    textBox13.Clear();
                    textBox14.Clear();
                    comboBox1.Text = "";
                    pictureBox1.ImageLocation = "";
                    textBox1.Focus();

                }
            else if (dialogResult == DialogResult.No)
            {
                    //do something else
                }
            }
            else { MessageBox.Show("select data first"); }//do something
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox17.Text = "Today";
            textBox15.Visible = false;
            dateTimePicker1.Visible = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox10.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox11.Clear();
            textBox13.Clear();
            textBox14.Clear();
            comboBox1.Text = "";
            pictureBox1.ImageLocation = "";
            textBox1.Focus();
           

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Class1 dbaccess22 = new Class1();
            dbaccess22.Student_id = textBox1.Text;
            dbaccess22.Semester_no = "1";



            dbaccess22.Course_id = comboBox2.Text; ;
            dbaccess22.Student_type = "Continue";
            dbaccess22.Admission_date = "Register Date" + DateTime.Now.ToString(" MMM dd ,dddd, yyyy ");
            if (dbaccess22.DataSaveInRead())
            {


                Class1 d = new Class1();
                d.Insert_By = DateTime.Now.ToString(" MMM dd ,dddd, yyyy hh:mm:ss tt ") + textBox16.Text;
                d.Student_id = textBox1.Text;
                if (d.DataSaveInRead1()) { } else { }


            }
            else
            {
               
            }
        }
    }
}
