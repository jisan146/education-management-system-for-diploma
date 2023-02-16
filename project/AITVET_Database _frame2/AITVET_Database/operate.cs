using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace AITVET_Database
{
    public partial class operate : Form
    {
        int a, b, c, d;
        public operate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 n = new Form1();
            n.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Text = comboBox7.Text + ":" + comboBox8.Text + ":" + comboBox9.Text;
            textBox6.Text = comboBox12.Text + ":" + comboBox11.Text + ":" + comboBox10.Text;
            button5.PerformClick();
            if (textBox11.Text == "1") { MessageBox.Show("Already insert "); }else {

            if (comboBox7.Text != "HH" && comboBox8.Text != "MM" && comboBox12.Text != "HH" && comboBox11.Text != "MM")
            {

                a = int.Parse(comboBox7.Text);
                b = int.Parse(comboBox8.Text);
                c = int.Parse(comboBox12.Text);
                d = int.Parse(comboBox11.Text);
            }
            if (a <= 12 && b <= 60 && c <= 12 && d <= 60)
            {
                if (comboBox9.Text == "AM" || comboBox9.Text == "PM" && comboBox10.Text == "AM" || comboBox10.Text == "PM")
                {
                    if (comboBox7.Text != "HH" && comboBox8.Text != "MM" && comboBox9.Text != "TT" && comboBox12.Text != "HH" && comboBox11.Text != "MM" && comboBox10.Text != "TT" && (comboBox9.Text == "AM" || comboBox9.Text == "PM") && (comboBox10.Text == "AM" || comboBox10.Text == "PM"))
                    {
                        textBox5.Text = comboBox7.Text + ":" + comboBox8.Text + ":" + comboBox9.Text;
                        textBox6.Text = comboBox12.Text + ":" + comboBox11.Text + ":" + comboBox10.Text;
                        textBox1.Text = comboBox6.Text;
                        textBox2.Text = comboBox1.Text;
                        textBox3.Text = comboBox2.Text;
                        textBox4.Text = comboBox3.Text;
                        textBox8.Text = comboBox4.Text;
                        textBox7.Text = comboBox5.Text;
                        label9.Visible = true;
                            button9.PerformClick();
                        Class1 dbaccess = new Class1();
                        dbaccess.Teacher_id = textBox1.Text;
                        dbaccess.Book_id = textBox2.Text;

                        dbaccess.Day = textBox8.Text;

                        dbaccess.Course_id = textBox3.Text;
                        dbaccess.Semester_no = textBox4.Text;
                        dbaccess.Start_time = textBox5.Text;
                        dbaccess.End_time = textBox6.Text;
                        dbaccess.Room = textBox7.Text;
                            dbaccess.Class_type = comboBox88.Text;
                            dbaccess.S = textBox22.Text;
                            dbaccess.E = textBox23.Text;
                            dbaccess.Sm = comboBox8.Text;
                            dbaccess.Em =comboBox11.Text;



                            if (dbaccess.DataSaveInOperate())
                            {

                                // label9.Text = "submit suceessfull ";
                                MessageBox.Show("succesfull");
                                comboBox6.Focus();
                                SqlConnection conh = new SqlConnection(Properties.Settings.Default._ConnectionString);
                                SqlDataAdapter sdah = new SqlDataAdapter("select *from teach where teacher_id='" + comboBox6.Text + "' and semester_no='" + comboBox3.Text + "' and course_id='" + comboBox2.Text + "' and book_id='" + comboBox1.Text + "'", conh);
                                DataTable dth = new DataTable();
                                sdah.Fill(dth);
                                dataGridView4.DataSource = dth;
                                int a;
                                a = int.Parse(dataGridView4.RowCount.ToString());
                                a = a - 1;
                                if (a == 0) { 
                                ////// /////
                                Class1 dbaccess1 = new Class1();
                                dbaccess1.Teacher_id = comboBox6.Text;
                                dbaccess1.Semester_no = comboBox3.Text;



                                dbaccess1.Course_id = comboBox2.Text;

                                dbaccess1.Book_id = comboBox1.Text;



                                if (dbaccess1.DataSaveInTeach())
                                {

                                    // label9.Text = "submit suceessfull ";


                                }
                                else
                                {
                                    //label9.Text = "submit fail ";
                                }
                            }
            /////////////

                            }
                            else
                        {
                            // label9.Text = "submit fail ";
                            MessageBox.Show("Fail");
                        }
                        SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                            SqlDataAdapter sda = new SqlDataAdapter("select room,operate.teacher_id,operate.book_id,operate.course_id,teacher_name,book_name,course_name,semester_no,class_type,start_time,end_time,day from teacher,book, operate,course where  teacher.teacher_id=operate.teacher_id and book.book_id=operate.book_id and course.course_id=operate.course_id and room='" + comboBox5.Text + "' and operate.teacher_id='" + comboBox6.Text + "'and operate.book_id='" + comboBox1.Text + "'and operate.course_id='" + comboBox2.Text + "'and semester_no='" + comboBox3.Text + "' and day='" + comboBox4.Text + "' and start_time='" + textBox5.Text + "' and end_time='" + textBox6.Text + "'", con);
                            DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                            DataGridViewColumn column1 = dataGridView1.Columns[0];
                            column1.Width = 50;
                            DataGridViewColumn column = dataGridView1.Columns[6];
                            column.Width = 80;
                            DataGridViewColumn colum = dataGridView1.Columns[2];
                            colum.Width = 50;
                        }
                    else { MessageBox.Show("Check time format"); }
                }
                else { MessageBox.Show("Check time "); }
            }
            else { MessageBox.Show("Check time "); }
        }
        }

        private void operate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aITVETDataSet60._class' table. You can move, or remove it, as needed.
            this.classTableAdapter1.Fill(this.aITVETDataSet60._class);
            // TODO: This line of code loads data into the 'aITVETDataSet59.semester' table. You can move, or remove it, as needed.
            this.semesterTableAdapter1.Fill(this.aITVETDataSet59.semester);
            // TODO: This line of code loads data into the 'aITVETDataSet58.course' table. You can move, or remove it, as needed.
            this.courseTableAdapter1.Fill(this.aITVETDataSet58.course);
            // TODO: This line of code loads data into the 'aITVETDataSet57.book' table. You can move, or remove it, as needed.
            this.bookTableAdapter1.Fill(this.aITVETDataSet57.book);
            // TODO: This line of code loads data into the 'aITVETDataSet56.teacher' table. You can move, or remove it, as needed.
            this.teacherTableAdapter2.Fill(this.aITVETDataSet56.teacher);
            this.MaximizeBox = false; button3.PerformClick();
            // TODO: This line of code loads data into the 'aITVETDataSet33.teacher' table. You can move, or remove it, as needed.
            ///**this.teacherTableAdapter1.Fill(this.aITVETDataSet33.teacher);
            // TODO: This line of code loads data into the 'aITVETDataSet32.teacher' table. You can move, or remove it, as needed.
            this.teacherTableAdapter.Fill(this.aITVETDataSet32.teacher);
            this.ControlBox = false;
            // TODO: This line of code loads data into the 'aITVETDataSet5._class' table. You can move, or remove it, as needed.
            this.classTableAdapter.Fill(this.aITVETDataSet5._class);
            // TODO: This line of code loads data into the 'aITVETDataSet4.semester' table. You can move, or remove it, as needed.
            this.semesterTableAdapter.Fill(this.aITVETDataSet4.semester);
            // TODO: This line of code loads data into the 'aITVETDataSet3.course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.aITVETDataSet3.course);
            // TODO: This line of code loads data into the 'aITVETDataSet1.book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.aITVETDataSet1.book);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\AITVET\WindowsFormsApplication3.exe");
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select room,operate.teacher_id,operate.book_id,operate.course_id,teacher_name,book_name,course_name,semester_no,class_type,start_time,end_time,day from teacher,book, operate,course where teacher.teacher_id=operate.teacher_id and book.book_id=operate.book_id and course.course_id=operate.course_id ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewColumn column1 = dataGridView1.Columns[0];
            column1.Width = 50;
            DataGridViewColumn column = dataGridView1.Columns[7];
            column.Width = 80;
            DataGridViewColumn colum = dataGridView1.Columns[2];
            colum.Width = 50;
            DataGridViewColumn colum0 = dataGridView1.Columns[3];
            colum0.Width = 60;
            DataGridViewColumn column00 = dataGridView1.Columns[1];
            column00.Width = 80;
            DataGridViewColumn column010 = dataGridView1.Columns[8];
            column010.Width = 80;
            DataGridViewColumn column0100 = dataGridView1.Columns[9];
            column0100.Width = 80;
            Process[] p = Process.GetProcesses();
            foreach (Process ps in p)
            {
                string s = ps.ProcessName;
                s = s.ToLower();
                if (s.CompareTo("windowsformsapplication3") == 0) { ps.Kill(); }
            }
        }

        private void comboBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboBox1.Focus();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) comboBox2.Focus();
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) comboBox3.Focus();
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) comboBox4.Focus();
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) comboBox7.Focus();
        }

        private void comboBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) comboBox8.Focus();
        }

        private void comboBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) comboBox9.Focus();
        }

        private void comboBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) comboBox12.Focus();
        }

        private void comboBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) comboBox11.Focus();
        }

        private void comboBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) comboBox10.Focus();
        }

        private void comboBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) comboBox5.Focus();
        }

        private void comboBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) comboBox88.Focus();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select *from operate where room='"+comboBox5.Text+ "' and teacher_id='" + comboBox6.Text + "'and book_id='" + comboBox1.Text + "'and course_id='" + comboBox2.Text + "'and semester_no='" + comboBox3.Text + "' and day='" + comboBox4.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            int v, a;
            textBox11.Text = dataGridView2.RowCount.ToString();
            v = int.Parse(textBox11.Text);
            a = v - 1;

            textBox11.Text = a.ToString();
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select room,operate.teacher_id,operate.book_id,operate.course_id,teacher_name,book_name,course_name,class_type,semester_no,start_time,end_time,day from teacher,book, operate,course where teacher.teacher_id=operate.teacher_id and book.book_id=operate.book_id and course.course_id=operate.course_id and operate.book_id='" + comboBox14.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                DataGridViewColumn column1 = dataGridView1.Columns[0];
                column1.Width = 50;
                DataGridViewColumn column = dataGridView1.Columns[6];
                column.Width = 80;
                DataGridViewColumn colum = dataGridView1.Columns[2];
                colum.Width = 50;
            
        }

        private void comboBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select room,operate.teacher_id,operate.book_id,operate.course_id,teacher_name,book_name,course_name,semester_no,class_type,start_time,end_time,day from teacher,book, operate,course where teacher.teacher_id=operate.teacher_id and book.book_id=operate.book_id and course.course_id=operate.course_id and operate.book_id='" + comboBox14.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                DataGridViewColumn column1 = dataGridView1.Columns[0];
                column1.Width = 50;
                DataGridViewColumn column = dataGridView1.Columns[6];
                column.Width = 80;
                DataGridViewColumn colum = dataGridView1.Columns[2];
                colum.Width = 50;
            }
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select room,operate.teacher_id,operate.book_id,operate.course_id,teacher_name,book_name,course_name,semester_no,class_type,start_time,end_time,day from teacher,book, operate,course where teacher.teacher_id=operate.teacher_id and book.book_id=operate.book_id and course.course_id=operate.course_id and day='" + comboBox15.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewColumn column1 = dataGridView1.Columns[0];
            column1.Width = 50;
            DataGridViewColumn column = dataGridView1.Columns[6];
            column.Width = 80;
            DataGridViewColumn colum = dataGridView1.Columns[2];
            colum.Width = 50;
        }

        private void comboBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select room,operate.teacher_id,operate.book_id,operate.course_id,teacher_name,book_name,course_name,class_type,semester_no,start_time,end_time,day from teacher,book, operate,course where teacher.teacher_id=operate.teacher_id and book.book_id=operate.book_id and course.course_id=operate.course_id and day='" + comboBox15.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                DataGridViewColumn column1 = dataGridView1.Columns[0];
                column1.Width = 50;
                DataGridViewColumn column = dataGridView1.Columns[6];
                column.Width = 80;
                DataGridViewColumn colum = dataGridView1.Columns[2];
                colum.Width = 50;
            }

        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select room,operate.teacher_id,operate.book_id,operate.course_id,teacher_name,book_name,course_name,class_type,semester_no,start_time,end_time,day from teacher,book, operate,course where teacher.teacher_id=operate.teacher_id and book.book_id=operate.book_id and course.course_id=operate.course_id and teacher_name='" + comboBox16.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewColumn column1 = dataGridView1.Columns[0];
            column1.Width = 50;
            DataGridViewColumn column = dataGridView1.Columns[6];
            column.Width = 80;
            DataGridViewColumn colum = dataGridView1.Columns[2];
            colum.Width = 50;
        }

        private void comboBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select room,operate.teacher_id,operate.book_id,operate.course_id,teacher_name,book_name,course_name,class_type,semester_no,start_time,end_time,day from teacher,book, operate,course where teacher.teacher_id=operate.teacher_id and book.book_id=operate.book_id and course.course_id=operate.course_id and teacher_name='" + comboBox16.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                DataGridViewColumn column1 = dataGridView1.Columns[0];
                column1.Width = 50;
                DataGridViewColumn column = dataGridView1.Columns[6];
                column.Width = 80;
                DataGridViewColumn colum = dataGridView1.Columns[2];
                colum.Width = 50;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox12.Text != "admin               ")
                MessageBox.Show("You don't have permission");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Delete all", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DialogResult dialogResult1 = MessageBox.Show("Recormation for delete all data from this table", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult1 == DialogResult.Yes)
                    {
                        SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                        SqlDataAdapter sda = new SqlDataAdapter("delete from operate", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView3.DataSource = dt;
                        button7.PerformClick();
                        button3.PerformClick();
                    }
                    else if (dialogResult1 == DialogResult.No)
                    {
                        //do something else
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
              
              
            }
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("delete from teach", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView3.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) { 

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //populate the textbox from specific value of the coordinates of column and row.
             textBox14.Text = row.Cells[0].Value.ToString();
                textBox15.Text = row.Cells[1].Value.ToString();
                textBox16.Text = row.Cells[2].Value.ToString();
                textBox17.Text = row.Cells[3].Value.ToString();
                textBox18.Text = row.Cells[7].Value.ToString();
                textBox19.Text = row.Cells[9].Value.ToString();
                textBox20.Text = row.Cells[10].Value.ToString();
                textBox21.Text = row.Cells[11].Value.ToString();


                DialogResult dialogResult = MessageBox.Show("Delete this item", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("delete  from  operate where   room='" + textBox14.Text + "' and teacher_id='" + textBox15.Text + "'and book_id='" + textBox16.Text + "'and course_id='" + textBox17.Text + "'and semester_no='" + textBox18.Text + "' and day='" + textBox21.Text + "' and start_time='" + textBox19.Text + "' and end_time='" + textBox20.Text + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    button8.PerformClick();
                    button3.PerformClick();
                    //dataGridView1.DataSource = dt; //do something
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection conh = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdah = new SqlDataAdapter("select *from operate where  teacher_id='" + textBox15.Text + "'and book_id='" + textBox16.Text + "'and course_id='" + textBox17.Text + "'and semester_no='" + textBox18.Text + "'", conh);
            DataTable dth = new DataTable();
            sdah.Fill(dth);
            dataGridView4.DataSource = dth;
            int a;
            a = int.Parse(dataGridView4.RowCount.ToString());
            a = a - 1;
            if (a > 1) { }else
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("delete  from  teach where    teacher_id='" + textBox15.Text + "'and book_id='" + textBox16.Text + "'and course_id='" + textBox17.Text + "'and semester_no='" + textBox18.Text + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
            }
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int a, b;
            a = int.Parse(comboBox7.Text);
            b = int.Parse(comboBox8.Text);
            if (comboBox9.Text == "PM") { a = a + 12; }
            textBox22.Text = a.ToString() ;
            int c, d;
            c = int.Parse(comboBox12.Text);
            d = int.Parse(comboBox11.Text);
            if (comboBox10.Text == "PM") { c = c + 12; }
            textBox23.Text = c.ToString();

        }

        private void comboBox88_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button2.PerformClick();
        }

        private void comboBox88_SelectedIndexChanged(object sender, EventArgs e)
        {
             button2.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select room,operate.teacher_id,operate.book_id,operate.course_id,teacher_name,book_name,course_name,semester_no,class_type,start_time,end_time,day from teacher,book, operate,course where teacher.teacher_id=operate.teacher_id and book.book_id=operate.book_id and course.course_id=operate.course_id and operate.teacher_id='" + comboBox13.Text + "' and day='"+comboBox15.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewColumn column1 = dataGridView1.Columns[0];
            column1.Width = 50;
            DataGridViewColumn column = dataGridView1.Columns[6];
            column.Width = 80;
            DataGridViewColumn colum = dataGridView1.Columns[2];
            colum.Width = 50;
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select room,operate.teacher_id,operate.book_id,operate.course_id,teacher_name,book_name,course_name,semester_no,class_type,start_time,end_time,day from teacher,book, operate,course where teacher.teacher_id=operate.teacher_id and book.book_id=operate.book_id and course.course_id=operate.course_id and operate.teacher_id='" + comboBox13.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewColumn column1 = dataGridView1.Columns[0];
            column1.Width = 50;
            DataGridViewColumn column = dataGridView1.Columns[6];
            column.Width = 80;
            DataGridViewColumn colum = dataGridView1.Columns[2];
            colum.Width = 50;
        }

        private void comboBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select room,operate.teacher_id,operate.book_id,operate.course_id,teacher_name,book_name,course_name,semester_no,class_type,start_time,end_time,day from teacher,book, operate,course where teacher.teacher_id=operate.teacher_id and book.book_id=operate.book_id and course.course_id=operate.course_id and operate.teacher_id='" + comboBox13.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                DataGridViewColumn column1 = dataGridView1.Columns[0];
                column1.Width = 50;
                DataGridViewColumn column = dataGridView1.Columns[6];
                column.Width = 80;
                DataGridViewColumn colum = dataGridView1.Columns[2];
                colum.Width = 50;
            }
        }
    }
}
