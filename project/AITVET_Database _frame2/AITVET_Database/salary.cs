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
    public partial class salary : Form
    {
        public salary()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            


            Class1 dbaccess = new Class1();
            
            //dbaccess.Department_id = textBox2.Text;
            dbaccess.Teacher_id = textBox6.Text;
           // dbaccess.Admin_id = textBox4.Text;
           // dbaccess.Salary = textBox5.Text;

            if (dbaccess.QueryInAppoint())
            {
           
                textBox3.Text = dbaccess.Department_id;
                textBox6.Text = dbaccess.Teacher_id;
                textBox5.Text = dbaccess.Admin_id;
                textBox4.Text = dbaccess.Salary;
                label7.Visible = true;
                label7.Text = "query suceess";
               // button2.Visible = true;
               // button1.Visible = false;
            }
            else
            {
                label7.Visible = true;
                label7.Text = "query Fail";
                // textBox4.Text = textBox1.Text; 
            }
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button2.Visible = false;
            button1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox9.Text = "deliver";
            textBox11.Text = DateTime.Now.ToString("dddd, dd MMM, yyyy hh:mm:ss tt");
           // int value1, value2, result = 0;
           /* value1 = int.Parse(textBox4.Text);
            value2 = int.Parse(textBox9.Text);
            result = value1 - value2;
            textBox10.Text = result.ToString();*/
            label7.Visible = true;

            Class1 dbaccess = new Class1();
            dbaccess.Admin_id = textBox12.Text;
            dbaccess.Teacher_id1 = textBox6.Text;
            
            dbaccess.Pay = textBox9.Text;
            dbaccess.Due = textBox10.Text;
            dbaccess.Pay_date = textBox11.Text;




            if (dbaccess.DataSaveInSalary())
            {

                label7.Text = "submit suceessfull ";
            
                // button3.Visible = true;
                // button2.Visible = false;

            }
            else
            {
                label7.Text = "submit fail ";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
           
            this.Hide();
        }

        private void salary_Load(object sender, EventArgs e)
        {
           
            button6.PerformClick();
            // TODO: This line of code loads data into the 'aITVETDataSet64.appoint' table. You can move, or remove it, as needed.
            this.appointTableAdapter.Fill(this.aITVETDataSet64.appoint);
            this.MaximizeBox = false; this.ControlBox = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select MAX(salary)as maximum_salary, MIN(salary) as minimum_salary, AVG(salary)as average_salary, SUM(salary)as total_salary from appoint", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select teacher_id1 as ID,salary,department_id,appoint_date,Update_by from appoint", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select *from salary", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select salary.teacher_id,admin_id,salary,pay as Status,due as Deliver_by,pay_date as payment_date from salary,appoint where appoint.teacher_id=salary.teacher_id and salary.teacher_id='" + textBox1.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select max(salary) from appoint", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            
            DataGridViewRow row = this.dataGridView1.Rows[0];
            textBox13.Text = row.Cells[0].Value.ToString();

            SqlConnection conq = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdaq = new SqlDataAdapter("select teacher_id1 as ID,salary,department_id,appoint_date,Update_by from appoint where salary='" + textBox13.Text+"'", conq);
            DataTable dtq = new DataTable();
            sdaq.Fill(dtq);
            dataGridView1.DataSource = dtq;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select min(salary) from appoint", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            DataGridViewRow row = this.dataGridView1.Rows[0];
            textBox13.Text = row.Cells[0].Value.ToString();

            SqlConnection conq = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdaq = new SqlDataAdapter("select teacher_id1 as ID,salary,department_id,appoint_date ,Update_by from appoint where salary='" + textBox13.Text + "'", conq);
            DataTable dtq = new DataTable();
            sdaq.Fill(dtq);
            dataGridView1.DataSource = dtq;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conq = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdaq = new SqlDataAdapter("select teacher_id1 as ID,salary,department_id,appoint_date ,Update_by from appoint where teacher_id1='" + comboBox1.Text + "'", conq);
            DataTable dtq = new DataTable();
            sdaq.Fill(dtq);
            dataGridView1.DataSource = dtq;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlConnection conq = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdaq = new SqlDataAdapter("select teacher_id1 as ID,salary,department_id,appoint_date ,Update_by from appoint where salary between '" + textBox14.Text+ "' and '" + textBox15.Text + "' ", conq);
            DataTable dtq = new DataTable();
            sdaq.Fill(dtq);
            dataGridView1.DataSource = dtq;
        }

        private void button10_Click(object sender, EventArgs e)
        {

            // textBox17.Text = a.ToString();


            if (comboBox1.Text != textBox17.Text)
            {

                SqlConnection conq = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sdaq = new SqlDataAdapter("update appoint set update_by='" + DateTime.Now.ToString("MMM dd ,dddd, yyyy hh:mm:ss tt ") + textBox12.Text + "', salary='" + textBox16.Text + "' where teacher_id1='" + comboBox1.Text + "' ", conq);
                DataTable dtq = new DataTable();
                sdaq.Fill(dtq);
                dataGridView1.DataSource = dtq;
                SqlConnection conqv = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sdaqv = new SqlDataAdapter("update administrator set update_time='" + DateTime.Now.ToString("MMM dd ,dddd, yyyy hh:mm:ss tt ") + textBox12.Text + "', s='" + textBox16.Text + "' where admin_id='" + comboBox1.Text + "' ", conqv);
                DataTable dtqv = new DataTable();
                sdaqv.Fill(dtqv);
                dataGridView1.DataSource = dtqv;
                SqlConnection conqa = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sdaqa = new SqlDataAdapter("select teacher_id1 as ID,salary,department_id,appoint_date ,Update_by from appoint where teacher_id1='" + comboBox1.Text + "' ", conq);
                DataTable dtqa = new DataTable();
                sdaqa.Fill(dtqa);
                dataGridView1.DataSource = dtqa;
            }
            else {MessageBox.Show("you can not update your sallary"); }
            
           

           

        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlConnection conq = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdaq = new SqlDataAdapter("update appoint set update_by='" +  DateTime.Now.ToString("MMM dd ,dddd, yyyy hh:mm:ss tt ")+textBox12.Text  + "', salary=salary+'" + textBox16.Text+"' ", conq);
            DataTable dtq = new DataTable();
            sdaq.Fill(dtq);
            dataGridView1.DataSource = dtq;
            SqlConnection conqa = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdaqa = new SqlDataAdapter("select teacher_id1 as ID,salary,department_id,appoint_date,Update_by  from appoint ", conqa);
            DataTable dtqa = new DataTable();
            sdaqa.Fill(dtqa);
            dataGridView1.DataSource = dtqa;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SqlConnection conq = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdaq = new SqlDataAdapter("update appoint set update_by='" +  DateTime.Now.ToString("MMM dd ,dddd, yyyy hh:mm:ss tt ")+textBox12.Text  + "', salary=salary +'" + textBox16.Text + "' where salary between '" + textBox14.Text + "' and '" + textBox15.Text + "' ", conq);
            DataTable dtq = new DataTable();
            sdaq.Fill(dtq);
            dataGridView1.DataSource = dtq;
            SqlConnection conqa = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdaqa = new SqlDataAdapter("select teacher_id1 as ID,salary,department_id,appoint_date ,Update_by from appoint where salary between '" + textBox14.Text + "' and '" + textBox15.Text + "' ", conqa);
            DataTable dtqa = new DataTable();
            sdaqa.Fill(dtqa);
            dataGridView1.DataSource = dtqa;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SqlConnection conq = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdaq = new SqlDataAdapter("select teacher_id1 as ID,salary,department_id,appoint_date ,Update_by from appoint where teacher_id1='" + textBox17.Text + "'", conq);
            DataTable dtq = new DataTable();
            sdaq.Fill(dtq);
            dataGridView1.DataSource = dtq;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
    }

