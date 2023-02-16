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
    public partial class vss : Form
    {
        public vss()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id,book_id as Subject_id,semester_no,course_has.course_id as Technology_id from take_course,course_has where take_course.course_id=course_has.course_id and student_id='"+textBox1.Text+"'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void vss_Load(object sender, EventArgs e)
        {
            button1.PerformClick();
            this.MaximizeBox = false; this.ControlBox = false;
        }
    }
}
