using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AITVET_Database
{
    public partial class Result : Form
    {
        int w, x, y, z, w1, x1, y1, z1; int value1, v; int v2, v3, v4, v5, v6,fail;
        public Result()
        {
            InitializeComponent();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
                textBox5.Clear();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { textBox6.Focus();
                textBox6.Clear();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { textBox7.Focus(); textBox7.Clear(); }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id,book_id as subject_id, theory_continous,theory_final,practical_continous,practical_final,type,published,total,grade_point,grade,semester_no from result where  teacher_id='"+textBox2.Text+"' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("After published you can not unpublished result. Press yes for update", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("update result set published='published' where  teacher_id='" + textBox2.Text + "'  and book_id='" + comboBox1.Text + "' and type like'Class%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
                button5.PerformClick();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter) {
                SqlConnection con2 = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda2 = new SqlDataAdapter("select student_id,book_id as subject_id, theory_continous,theory_final,practical_continous,practical_final,type,published,total,grade_point,grade,semester_no from result where  teacher_id='" + textBox2.Text + "' and student_id='" + textBox20.Text + "' ", con2);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                dataGridView2.DataSource = dt2;


                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select  reads.student_id,board_roll,student_name  from student,reads,teach where student.student_id=reads.student_id and reads.course_id=teach.course_id and teach.teacher_id='" + textBox2.Text + "' and (student_type='Continue' or student_type='Re_admission') and teach.course_id='" + comboBox2.Text + "' and reads.semester_no='" + comboBox3.Text + "' and book_id='" + comboBox1.Text + "' and reads.student_id='" + textBox20.Text + "' and reads.semester_no=teach.semester_no", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                this.dataGridView1.Sort(this.dataGridView1.Columns["student_id"], ListSortDirection.Ascending);
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("After Allow you can not  Don't Allow. Press yes for update", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("update result set published='allow' where  teacher_id='" + textBox2.Text + "'  and book_id='" + comboBox1.Text + "' and (type like'Semester%' or type like'r%')", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
                button5.PerformClick();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
        string s,tc,tf,pc,pf,b, t, tt;

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox4.Enabled = true;

                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select student_id,book_id as subject_id, theory_continous,theory_final,practical_continous,practical_final,type,published,total,grade_point,grade,semester_no from result where  teacher_id='" + textBox2.Text + "' and book_id='" + comboBox1.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
                button4.PerformClick();
                Class1 dbaccess = new Class1();
                dbaccess.Book_id = comboBox1.Text;
                // dbaccess.Login_password = textBox2.Text;
                //  dbaccess.Log_type = textBox3.Text;

                if (dbaccess.QueryInBook())
                {
                    textBox12.Text = dbaccess.T;
                    textBox13.Text = dbaccess.P;
                    textBox14.Text = dbaccess.C;
                    textBox11.Text = dbaccess.Cn;



                    // textBox4.Text = dbaccess.Login_id;
                    // textBox3.Text = dbaccess.Log_type;
                    //MessageBox.Show("sucess");
                }
                else
                {
                    //MessageBox.Show("fail");
                    // textBox4.Text = textBox1.Text; 
                }

                int v2, v3, v, vv, bb;
                v2 = int.Parse(textBox14.Text);
                v3 = int.Parse(textBox11.Text);
                v = v2 * v3;
                textBox15.Text = v.ToString();
                vv = int.Parse(textBox12.Text);
                bb = int.Parse(textBox13.Text);
                textBox16.Text = (vv * v3 * .2).ToString();
                w = int.Parse(textBox16.Text);
                textBox17.Text = (vv * v3 * .8).ToString();
                x = int.Parse(textBox17.Text);
                textBox18.Text = (bb * v3 * .5).ToString();
                y = int.Parse(textBox18.Text);
                textBox19.Text = (bb * v3 * .5).ToString();
                z = int.Parse(textBox19.Text);
            }
        }

        private void textBox21_Click(object sender, EventArgs e)
        {
            textBox21.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
           // if (textBox4.Text != ToString() || textBox5.Text != ToString() || textBox6.Text != ToString() || textBox7.Text != ToString() || textBox8.Text != ToString()) { }else { fail = 1; MessageBox.Show(fail.ToString()); }
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                tc= row.Cells[2].Value.ToString();
                tf = row.Cells[3].Value.ToString();
               pc = row.Cells[4].Value.ToString();
                pf = row.Cells[5].Value.ToString();
                b= row.Cells[1].Value.ToString();
                t = row.Cells[6].Value.ToString();
                tt = row.Cells[8].Value.ToString();
               /* textBox4.Text = row.Cells[2].Value.ToString();
                textBox5.Text = row.Cells[3].Value.ToString();
                textBox6.Text = row.Cells[4].Value.ToString();
                textBox7.Text = row.Cells[5].Value.ToString();*/
                textBox15.Clear();
                // MessageBox.Show(tc +tf +pc +pf +b +t +tt);
                button1.Enabled = false;
                button8.Enabled = true; ;

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox21.Text == "Why want to update?" || textBox21.Text == "") { MessageBox.Show("Insert comment"); } else { 
            if (textBox15.Text == "") { MessageBox.Show("Select subject ID"); }
            else
            {

                button2.PerformClick();
                if (textBox7.Enabled != false)
                {
                    if (v2 < ((w * 40) / 100) || v3 < ((x * 40) / 100) || v4 < ((y * 40) / 100) || v5 < ((z * 40) / 100))
                    {
                        textBox9.Text = "00";
                        textBox10.Text = "F";
                    }
                    if (v2 < ((w * 40) / 100)) { textBox4.Text = textBox4.Text + "F"; }
                    if (v3 < ((x * 40) / 100)) { textBox5.Text = textBox5.Text + "F"; }
                    if (v4 < ((y * 40) / 100)) { textBox6.Text = textBox6.Text + "F"; }
                    if (v5 < ((z * 40) / 100)) { textBox7.Text = textBox7.Text + "F"; }
                }
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("update result set type='" + t +" "+textBox21.Text+ DateTime.Now.ToString(" MMM  dd ,dddd, yyyy hh:mm:ss tt") + "', theory_continous='" + textBox4.Text + "', theory_final='" + textBox5.Text + "', practical_continous='" + textBox6.Text + "', practical_final='" + textBox7.Text + "', total='" + textBox8.Text + "' ,grade='" + textBox10.Text + "',grade_point='" + textBox9.Text + "' where student_id='" + textBox1.Text + "'and book_id='" + b + "'and theory_continous='" + tc + "'and theory_final='" + tf + "'and practical_continous='" + pc + "'and practical_final='" + pf + "'and total='" + tt + "'and teacher_id='" + textBox2.Text + "'and type='" + t + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                SqlConnection con5 = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda5 = new SqlDataAdapter("select student_id,book_id as subject_id, theory_continous,theory_final,practical_continous,practical_final,type,published,total,grade_point,grade,semester_no from result where  teacher_id='"+textBox2.Text+"'  and student_id='"+textBox1.Text+"'", con5);
                DataTable dt5 = new DataTable();
                sda5.Fill(dt5);
                dataGridView2.DataSource = dt5;
                //  dataGridView2.DataSource = dt;
                textBox15.Clear();

            }
        }
            textBox21.Text = "Why want to update?";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login_Form l = new Login_Form();
           
            teacher t = new teacher();
            l.textBox4.Text = t.textBox10.Text;
          // t.Show();
            this.Hide();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            
             if(comboBox4.Text== "Semester final"|| comboBox4.Text == "R")
            {
                textBox15.Enabled = false;
                textBox8.Enabled = false;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
            }else
                {
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox15.Enabled = true;
                    textBox8.Enabled = true;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    textBox6.Enabled = false;
                    textBox7.Enabled = false;
                }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox15.Enabled= false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            textBox3.Text = comboBox1.Text;
            

            if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == ""|| textBox4.Text == "Check mark" || textBox5.Text == "Check mark" || textBox6.Text == "Check mark" || textBox7.Text == "Check mark") { }
           else
            {
               
                v2 = int.Parse(textBox4.Text);
                v3 = int.Parse(textBox5.Text);
                v4 = int.Parse(textBox6.Text);
                v5 = int.Parse(textBox7.Text);
                if (textBox7.Enabled != false)
                {
                   /* if (v2 < ((w * 40) / 100) || v3 < ((x * 40) / 100) || v4 < ((y * 40) / 100) || v5 < ((z * 40) / 100))
                    {
                        textBox9.Text = "00";
                        textBox10.Text = "F";
                    }
                    if (v2 < ((w * 40) / 100)) { textBox4.Text = textBox4.Text + "F"; }
                    if (v3 < ((x * 40) / 100)) { textBox5.Text = textBox5.Text + "F"; }
                    if (v4 < ((y * 40) / 100)) { textBox6.Text = textBox6.Text + "F"; }
                    if (v5 < ((z * 40) / 100)) { textBox7.Text = textBox7.Text + "F"; }*/
                }
                if (textBox8.Enabled == false)
                {
                    if (v2 > w) { textBox4.Text = "Check mark"; }
                    if (v3 > x) { textBox5.Text = "Check mark"; }
                    if (v4 > y) { textBox6.Text = "Check mark"; }
                    if (v5 > z) { textBox7.Text = "Check mark"; }
                }

                v6 = v2 + v3 + v4 + v5;

                textBox8.Text = v6.ToString(); }
            if (textBox8.Text == "") { }
            else
            {

               

                v = int.Parse(textBox15.Text);
                value1 = int.Parse(textBox8.Text);
                if (value1 >= ((v * 80) / 100))
                {
                    textBox9.Text = "4";
                    textBox10.Text = "A+";
                }
                else if (value1 >= ((v * 75) / 100))
                {
                    textBox9.Text = "3.75";
                    textBox10.Text = "A";
                }
                else if (value1 >= ((v * 70) / 100))
                {
                    textBox9.Text = "3.5";
                    textBox10.Text = "A-";
                }
                else if (value1 >= ((v * 65) / 100))
                {
                    textBox9.Text = "3.25";
                    textBox10.Text = "B+";
                }
                else if (value1 >= ((v * 60) / 100))
                {
                    textBox9.Text = "3.00";
                    textBox10.Text = "B";
                }
                else if (value1 >= ((v * 55) / 100))
                {
                    textBox9.Text = "2.75";
                    textBox10.Text = "B-";
                }
                else if (value1 >= ((v * 50) / 100))
                {
                    textBox9.Text = "2.50";
                    textBox10.Text = "C+";
                }
                else if (value1 >= ((v * 45) / 100))
                {
                    textBox9.Text = "2.25";
                    textBox10.Text = "C";
                }
                else if (value1 >= ((v * 40) / 100))
                {
                    textBox9.Text = "2.00";
                    textBox10.Text = "D";
                }
                
                else
                {
                    textBox9.Text = "00";
                    textBox10.Text = "F";
                }
                 if (value1 > v)
                {
                    textBox9.Text = "Check mark";
                    textBox8.Text = "Check mark";
                    textBox10.Text = "Check mark";
                }
                else { }
                
            }
            
        }

        private void Result_Load(object sender, EventArgs e)
        {
            button5.PerformClick();
            this.MaximizeBox = false;// TODO: This line of code loads data into the 'aITVETDataSet23.semester' table. You can move, or remove it, as needed.
            this.semesterTableAdapter.Fill(this.aITVETDataSet23.semester);
            // TODO: This line of code loads data into the 'aITVETDataSet22.course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.aITVETDataSet22.course);
            this.ControlBox = false;// TODO: This line of code loads data into the 'aITVETDataSet13.book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.aITVETDataSet13.book);
            this.MinimizeBox = false;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {////
           

            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id,book_id as subject_id, theory_continous,theory_final,practical_continous,practical_final,type,published,total,grade_point,grade,semester_no from result where  teacher_id='" + textBox2.Text + "'and student_id='" + textBox1.Text + "' and book_id='" + comboBox1.Text + "' and type='" + comboBox4.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            int a;
            a = int.Parse(dataGridView2.RowCount.ToString());
            a = a - 1;
            if (a > 0) { MessageBox.Show("Already insert"); }
            else
            {
                ////
                if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox4.Text == "Check mark" || textBox5.Text == "Check mark" || textBox6.Text == "Check mark" || textBox7.Text == "Check mark") { }
                else
                {
                    button2.PerformClick();
                }
                if (value1 <= v && textBox7.Enabled == false) { button2.PerformClick(); }
                if (textBox8.Text == "" || textBox8.Text == "Check mark") { }
                else


                {
                    if (textBox7.Enabled != false)
                    {
                        if (v2 < ((w * 40) / 100) || v3 < ((x * 40) / 100) || v4 < ((y * 40) / 100) || v5 < ((z * 40) / 100))
                        {
                            textBox9.Text = "00";
                            textBox10.Text = "F";
                        }
                        if (v2 < ((w * 40) / 100)) { textBox4.Text = textBox4.Text + "F"; }
                        if (v3 < ((x * 40) / 100)) { textBox5.Text = textBox5.Text + "F"; }
                        if (v4 < ((y * 40) / 100)) { textBox6.Text = textBox6.Text + "F"; }
                        if (v5 < ((z * 40) / 100)) { textBox7.Text = textBox7.Text + "F"; }
                    }
                    Class1 dbaccess = new Class1();
                    dbaccess.Student_id = textBox1.Text;
                    dbaccess.Teacher_id = textBox2.Text;
                    dbaccess.Book_id = textBox3.Text;
                    dbaccess.Theory_continous = textBox4.Text;
                    dbaccess.Theory_final = textBox5.Text;
                    dbaccess.Practical_continous = textBox6.Text;
                    dbaccess.Practical_final = textBox7.Text;
                    dbaccess.Total = textBox8.Text;
                    dbaccess.Grade_point = textBox9.Text;
                    dbaccess.Grade = textBox10.Text;
                    dbaccess.Type = comboBox4.Text;
                    dbaccess.Published = "";
                    dbaccess.G = "0";
                    dbaccess.Semester_no = comboBox3.Text;



                    if (dbaccess.DataSaveInResult())
                    {
                        label11.Visible = true;
                        label11.Text = "submit suceessfull ";
                        SqlConnection cong = new SqlConnection(Properties.Settings.Default._ConnectionString);
                        SqlDataAdapter sdag = new SqlDataAdapter("select student_id,book_id as subject_id, theory_continous,theory_final,practical_continous,practical_final,type,published,total,grade_point,grade,semester_no from result where  teacher_id='" + textBox2.Text + "' and student_id='" + textBox1.Text + "' and book_id='" + comboBox1.Text + "' and type='" + comboBox4.Text + "' ", cong);
                        DataTable dtg = new DataTable();
                        sdag.Fill(dtg);
                        dataGridView2.DataSource = dtg;
                        MessageBox.Show("submit suceessfull ");
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        textBox8.Clear();



                    }
                    else
                    {
                        label11.Visible = true;
                        label11.Text = "submit fail ";
                        MessageBox.Show("submit fail ");
                    }
                }
            }
        
        
        }
            
        

        private void comboBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Enabled = true;
           
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id,book_id as subject_id, theory_continous,theory_final,practical_continous,practical_final,type,published,total,grade_point,grade,semester_no from result where  teacher_id='" + textBox2.Text + "' and book_id='"+comboBox1.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            button4.PerformClick();
            Class1 dbaccess = new Class1();
            dbaccess.Book_id = comboBox1.Text;
            // dbaccess.Login_password = textBox2.Text;
            //  dbaccess.Log_type = textBox3.Text;

            if (dbaccess.QueryInBook())
            {
                textBox12.Text = dbaccess.T;
                textBox13.Text = dbaccess.P;
                textBox14.Text = dbaccess.C;
                textBox11.Text = dbaccess.Cn;

               
                
                // textBox4.Text = dbaccess.Login_id;
                // textBox3.Text = dbaccess.Log_type;
                //MessageBox.Show("sucess");
            }
            else
            {
                //MessageBox.Show("fail");
                // textBox4.Text = textBox1.Text; 
            }

            int v2, v3, v,vv,bb;
            v2 = int.Parse(textBox14.Text);
            v3 = int.Parse(textBox11.Text);
            v = v2 * v3;
            textBox15.Text = v.ToString();
            vv = int.Parse(textBox12.Text);
            bb= int.Parse(textBox13.Text);
            textBox16.Text = (vv * v3 * .2).ToString();
            w = int.Parse(textBox16.Text);
            textBox17.Text = (vv * v3 * .8).ToString();
            x = int.Parse(textBox17.Text);
            textBox18.Text = (bb * v3 * .5).ToString();
            y = int.Parse(textBox18.Text);
            textBox19.Text = (bb* v3 * .5).ToString();
            z = int.Parse(textBox19.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //textBox4.Text = textBox9.Text;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select  reads.student_id,board_roll,student_name  from student,reads,teach where student.student_id=reads.student_id and reads.course_id=teach.course_id and teach.teacher_id='" + textBox2.Text + "' and (student_type='Continue' or student_type='Re_admission') and teach.course_id='" + comboBox2.Text + "' and teach.semester_no='" + comboBox3.Text + "' and book_id='" + comboBox1.Text + "' and reads.semester_no=teach.semester_no", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Sort(this.dataGridView1.Columns["student_id"], ListSortDirection.Ascending);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                textBox1.Text = row.Cells[0].Value.ToString();
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select student_id,book_id as subject_id, theory_continous,theory_final,practical_continous,practical_final,type,published,total,grade_point,grade,semester_no from result where  teacher_id='" + textBox2.Text + "' and student_id='" + textBox1.Text+"' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
                button1.Enabled = true;
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox9.Clear();
                button8.Enabled = false;
            }
        }

        private void comboBox1_RightToLeftChanged(object sender, EventArgs e)
        {

        }
    }
}
/*80% and above           4.00                 A+
75% to 79%                3.75                 A
70% to 74%                3.50                 A-
65% to 69%                3.25                 B+
60% to 64%                3.00                 B
55% to 59%                2.75                 B-
50% to 54%                2.50                 C+
45% to 49%                2.25                 C
40% to 44%                2.00                 D
Below 40%                 0.00                 F*/
