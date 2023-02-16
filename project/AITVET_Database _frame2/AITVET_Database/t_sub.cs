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
    public partial class t_sub : Form
    {
        public t_sub()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            button2.Enabled = false;
            textBox1.Enabled = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter(" select expart.teacher_id,teacher_name,book_id as subject_id from expart,teacher where teacher.teacher_id=expart.teacher_id", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter(" select expart.teacher_id,teacher_name,book_id as subject_id from expart,teacher where teacher.teacher_id=expart.teacher_id and expart.teacher_id='"+textBox1.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void t_sub_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; this.ControlBox = false;
        }
    }
}
