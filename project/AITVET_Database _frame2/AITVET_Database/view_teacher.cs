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
    public partial class view_teacher : Form
    {
        public view_teacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter(" select appoint.teacher_id,teacher_name,gender,Phone,email,Current_Address,Permanent_Address,department_id,appoint_date,salary from teacher,appoint where teacher.teacher_id=appoint.teacher_id", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter(" select appoint.teacher_id,teacher_name,gender,Phone,email,Current_Address,Permanent_Address,department_id,appoint_date,salary from teacher,appoint where teacher.teacher_id=appoint.teacher_id and appoint.teacher_id='"+textBox1.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void view_teacher_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; this.ControlBox = false;
        }
    }
}
