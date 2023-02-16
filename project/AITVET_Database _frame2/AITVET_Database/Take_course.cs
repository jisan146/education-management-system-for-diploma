using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AITVET_Database
{
    public partial class Take_course : Form
    {
        public Take_course()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = comboBox1.Text;
            label1.Visible = true;

            Class1 dbaccess = new Class1();
            dbaccess.Student_id = textBox1.Text;
            dbaccess.Course_id = textBox2.Text;





            if (dbaccess.DataSaveInTake_course())
            {

                label1.Text = "submit suceessfull ";
                Form4 f = new Form4();
                f.Show();
                this.Hide();

            }
            else
            {
                label1.Text = "submit fail ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void Take_course_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; this.ControlBox = false;
            // TODO: This line of code loads data into the 'aITVETDataSet6.course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.aITVETDataSet6.course);
            // TODO: This line of code loads data into the 'aITVETDataSet.department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.aITVETDataSet.department);

        }

       
    }
}
