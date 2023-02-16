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
    public partial class vr : Form
    {
        int co,ts,fffff; float s1, s2, s3, s4, s5, s6, s7, s8,avg;
        string tec=""; int si,s, mul, id;
        int rowc;
        public vr()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id, theory_continous,theory_final,practical_continous,practical_final,grade_point,grade,total,c*cn as Subject_mark,result.book_id as subject_id,book_name as Subject_name,semester_no,type,published from result,book where book.book_id=result.book_id and teacher_id='" + textBox1.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id, theory_continous, theory_final, practical_continous, practical_final, grade_point, grade, total, c * cn as Subject_mark, result.book_id as subject_id, book_name as Subject_name, semester_no, type, published from result, book where book.book_id = result.book_id and student_id ='" + textBox2.Text+ "' and Published='Published' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id, theory_continous,theory_final,practical_continous,practical_final,grade_point,grade,total,c*cn as Subject_mark,result.book_id as subject_id,book_name as Subject_name,semester_no,type,published from result,book where book.book_id=result.book_id and teacher_id='" + textBox1.Text+"' and result.book_id='"+textBox4.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select result.student_id,book_id as subject_id, theory_continous,theory_final,practical_continous,practical_final,type,published,total,grade_point,grade,semester_no from result,student,reads where result.student_id=student.student_id and student.student_id=reads.student_id and teacher_id='" + textBox1.Text+"'  and result.student_id='"+textBox5.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id, theory_continous,theory_final,practical_continous,practical_final,grade_point,grade,total,c*cn as Subject_mark,result.book_id as subject_id,book_name as Subject_name,semester_no,type,published from result,book where book.book_id=result.book_id and student_id='" + textBox2.Text + "' and semester_no='"+textBox3.Text+ "' and Published='Published'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
           
            co= int.Parse(dataGridView1.RowCount.ToString());
            co = co - 1;
            int fg;
            fg = int.Parse(dataGridView1.RowCount.ToString());
            fg= fg - 1;
            button16.PerformClick();
            button15.PerformClick();
            button11.PerformClick();
            button10.PerformClick();
            if (fg==0) { textBox9.Clear();
               
            }
            button19.PerformClick();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id, theory_continous,theory_final,practical_continous,practical_final,grade_point,grade,total,c*cn as Subject_mark,result.book_id as subject_id,book_name as Subject_name,semester_no,type,published from result,book where book.book_id=result.book_id and student_id='" + textBox2.Text + "' and result.book_id='"+textBox6.Text+ "' and Published='Published'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select result.student_id,book_id as subject_id, theory_continous,theory_final,practical_continous,practical_final,type,published,total,grade_point,grade,semester_no from result,student,reads where result.student_id=student.student_id and student.student_id=reads.student_id and teacher_id='" + textBox1.Text + "'  and grade='"+textBox7.Text+"' and book_id='"+textBox8.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void vr_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; this.ControlBox = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id, theory_continous, theory_final, practical_continous, practical_final, grade_point, grade, total, c * cn as Subject_mark, result.book_id as subject_id, book_name as Subject_name, semester_no, type, published from result, book where book.book_id = result.book_id ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (rowc > 0) { 
            if (textBox2.Text != "" && textBox3.Text != "")
            {

                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select course_id from reads where student_id='" + textBox2.Text + "' and semester_no='" + textBox3.Text + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;

                DataGridViewRow row1 = this.dataGridView2.Rows[0];
                tec = row1.Cells[0].Value.ToString();
            }

            SqlConnection conr = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdar = new SqlDataAdapter("select count(book_id) from course_has where course_id='" + tec + "' and semester_no='" + textBox3.Text + "'", conr);
            DataTable dtr = new DataTable();
            sdar.Fill(dtr);
            dataGridView2.DataSource = dtr;
            string s = "";
            DataGridViewRow row2 = this.dataGridView2.Rows[0];
            s = row2.Cells[0].Value.ToString();
            if (s != "0" || s != "")
            {
                ts = int.Parse(row2.Cells[0].Value.ToString());
            }
        }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id,semester_no,grade_point from  gpa where grade_point!='' order by semester_no", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView3.DataSource = dt;
            DataGridViewColumn column1 = dataGridView3.Columns[0];
            column1.Width = 60;
            DataGridViewColumn column2 = dataGridView3.Columns[1];
            column2.Width = 80;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            button24.PerformClick();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView4.Rows[id];
            if (id <= mul - 1)
            {
                textBox3.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[0].Value.ToString();

                button4.PerformClick();
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("update result set g='1' where student_id='" + textBox2.Text + "' and semester_no='" + textBox3.Text + "' and Published='Published'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);


                id = id + 1;
               
            }
            else if (id > mul - 1)
            {
                id = 0; timer2.Enabled = false;si = 0; textBox3.Clear(); textBox2.Clear();textBox9.Clear();
               
                button20.PerformClick();
                button2.PerformClick();
                Process[] p = Process.GetProcesses();
                foreach (Process ps in p)
                {
                    string s = ps.ProcessName;
                    s = s.ToLower();
                    if (s.CompareTo("windowsformsapplication3") == 0) { ps.Kill(); }
                }


            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id,semester_no,grade_point from  gpa where grade_point!=''and student_id='" + textBox13.Text + "' order by semester_no ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView3.DataSource = dt;
            DataGridViewColumn column1 = dataGridView3.Columns[0];
            column1.Width = 60;
            DataGridViewColumn column2 = dataGridView3.Columns[1];
            column2.Width = 80;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("(select student_id,semester_no from result  where g='0') union(select student_id,semester_no from result  where g='0')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView4.DataSource = dt;
            mul = int.Parse(dataGridView4.RowCount.ToString());
            mul = mul - 1;
            id = 0;
            timer2.Enabled = true;
            System.Diagnostics.Process.Start(@"C:\AITVET\WindowsFormsApplication3.exe");



        }

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("After published you can not unpublished result. Press yes for update", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("update result set published='published' where published='allow' and  type like'Semester%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
                button9.PerformClick();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id, theory_continous,theory_final,practical_continous,practical_final,grade_point,grade,total,c*cn as Subject_mark,result.book_id as subject_id,book_name as Subject_name,semester_no,type,published from result,book where book.book_id=result.book_id and student_id='" + textBox2.Text + "' and Published='Published' and (Type like'r%' or Type like'semester%') ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id,book_id as subject_id, theory_continous,theory_final,practical_continous,practical_final,type,published,total,grade_point,grade,semester_no from result where student_id='" + textBox2.Text + "' and semester_no='" + textBox3.Text + "' and Published='Published' and grade_point='000'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;

            fffff = int.Parse(dataGridView2.RowCount.ToString());
            fffff = fffff - 1;
            //MessageBox.Show(fffff.ToString());
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select course_id from reads where student_id='" + textBox2.Text + "' and semester_no='" + textBox3.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;

            
            rowc = int.Parse(dataGridView2.RowCount.ToString());
            rowc= rowc - 1;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select course_id from reads where student_id='" + textBox2.Text + "' and semester_no='8' and student_type='pass' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;


            rowc = int.Parse(dataGridView2.RowCount.ToString());
            rowc = rowc - 1;
            if (rowc>0)
            {
                timer1.Enabled = true;
                textBox3.Text = "0";
                textBox3.Visible = false;
            } else { textBox10.Text = "";
                timer1.Enabled = false;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            int i;
           
            i = int.Parse(textBox3.Text);
            i = i + 1;
            textBox3.Text = i.ToString();
            if (textBox9.Text =="") { textBox9.Text = "0"; }
            if (textBox3.Text=="1") { s1 = float.Parse(textBox9.Text) ; s1 = (s1*5)/100; }
            if (textBox3.Text == "2") { s2 = float.Parse(textBox9.Text); s2 = (s2 * 5) / 100; }
            if (textBox3.Text == "3") { s3 = float.Parse(textBox9.Text); s3 = (s3 * 5) / 100; }
            if (textBox3.Text == "4") { s4 = float.Parse(textBox9.Text); s4 = (s4 * 10) / 100; }
            if (textBox3.Text == "5") { s5 = float.Parse(textBox9.Text); s5 = (s5 * 10) / 100; }
            if (textBox3.Text == "6") { s6 = float.Parse(textBox9.Text); s6 = (s6 * 20) / 100; }
            if (textBox3.Text == "7") { s7 = float.Parse(textBox9.Text); s7 = (s7 * 15) / 100; }
            if (textBox3.Text == "8") { s8 = float.Parse(textBox9.Text); s8 = (s8 * 10) / 100; }
            button4.PerformClick();
            if (i == 9) { textBox3.Clear();timer1.Enabled = false;textBox3.Visible = true;
                textBox12.Text = "S1= "+s1.ToString() + " S2= " + s2.ToString() + " S3 = " + s3.ToString() + " S4= " + s4.ToString() + " S5= " + s5.ToString() + " S6= " + s6.ToString() + " S7= " + s7.ToString() + " S8= " + s8.ToString();
                avg = s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8;
                textBox10.Text = avg.ToString();
            }
          
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button18.PerformClick();
            button4.PerformClick();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select  * from gpa  where student_id='" + textBox2.Text + " ' and  semester_no='" + textBox3.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            int fg;
            fg = int.Parse(dataGridView2.RowCount.ToString());
            fg = fg - 1;
           // MessageBox.Show(fg.ToString());
            if (fg > 0) {
                SqlConnection conu = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sdau = new SqlDataAdapter("update gpa set grade_point='"+textBox9.Text+"' where student_id='" + textBox2.Text + " ' and  semester_no='" + textBox3.Text + "'", conu);
                DataTable dtu = new DataTable();
                sdau.Fill(dtu);
                dataGridView2.DataSource = dtu;
            } else if (fg == 0)
            { 

            Class1 d = new Class1();
            d.Student_id = textBox2.Text;
            d.Semester_no = textBox3.Text;
            d.Grade_point = textBox9.Text;
            if (d.DataSaveIngpa()) { }
            { }
        }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id, theory_continous,theory_final,practical_continous,practical_final,grade_point,grade,total,c*cn as Subject_mark,result.book_id as subject_id,book_name as Subject_name,semester_no,type,published from result,book where book.book_id=result.book_id and student_id='" + textBox2.Text + "' and Published='Published' and Type like'Class%'  ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button10_Click(object sender, EventArgs e)
        {if(co>0)
            { 
            SqlConnection conp = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdap = new SqlDataAdapter("select sum(c) from book ,result where  book.book_id=result.book_id and student_id='" + textBox2.Text + "' and semester_no='" + textBox3.Text + "' and Published='Published' and grade_point>0 and (Type like'r%' or Type like'semester%') ", conp);
            DataTable dtp = new DataTable();
            sdap.Fill(dtp);
            dataGridView2.DataSource = dtp;
           
                string tttl="";
            DataGridViewRow row1 = this.dataGridView2.Rows[0];
                tttl = row1.Cells[0].Value.ToString();
               
                if (tttl!="") { s = int.Parse(row1.Cells[0].Value.ToString()); }
               


            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select teacher_id,result.book_id as subject_id,c as Credit, theory_continous,theory_final,practical_continous,practical_final,type,published,total,grade_point,grade,semester_no from book,result where book.book_id=result.book_id and student_id='" + textBox2.Text + "' and semester_no='" + textBox3.Text + "' and Published='Published' and grade_point>0 and (Type like'r%' or Type like'semester%') ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            int a;
            a = int.Parse(dataGridView2.RowCount.ToString());
            a = a - 1;
            int  i;

            float g,p,c, d = 0;
          
            if (a > 0)
            {




                for (i = 0; i < a; i++)
                {
                    DataGridViewRow row = this.dataGridView2.Rows[i];
                    c = int.Parse(row.Cells[2].Value.ToString());
                    p = float.Parse(row.Cells[10].Value.ToString());
                    d = (d + (c * p));
                }
                g = d / s;
                textBox9.Text = g.ToString();
                    if (fffff > 0) { textBox9.Text = "F"; } else if(fffff ==0) { textBox9.Text = g.ToString(); }
                }
               
           if (a < ts) { textBox9.Text = ""; }
        }
            if (fffff > 0) { textBox9.Text = "0"; }
        }
    }
}
