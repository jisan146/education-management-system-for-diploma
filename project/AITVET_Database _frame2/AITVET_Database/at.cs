using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AITVET_Database
{
    public partial class at : Form
    {
        public at()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 dbaccess = new Class1();
            dbaccess.Department_id = comboBox2.Text;
            dbaccess.Teacher_id = textBox1.Text;



            dbaccess.Appoint_date = textBox15.Text;

            dbaccess.Salary = textBox14.Text;



            if (dbaccess.DataSaveInAppoint())
            {

                textBox1.Enabled = true;
                this.Hide();
                Form3 f = new Form3();
                f.Show();

            }
            else
            {

            }
        }

        private void at_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;// TODO: This line of code loads data into the 'aITVETDataSet20.department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.aITVETDataSet20.department);
            this.ControlBox = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox13.Text != "") { 
            if (textBox13.Text != "admin")
            {
                DialogResult dialogResult = MessageBox.Show("One email send to your admin if you show this password. Are you want? ", "warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {


                    Class1 dbaccess1 = new Class1();
                    dbaccess1.Login_id = textBox13.Text;


                    if (dbaccess1.QueryInTable1())
                    {


                        MessageBox.Show(dbaccess1.Login_password);
                        textBox3.Text = "not read";




                        Class1 dbaccess = new Class1();
                        dbaccess.Sender_id = textBox2.Text;
                        dbaccess.Receiver_id = "admin";


                        dbaccess.Status = textBox3.Text;


                        dbaccess.Information = "ID   " + textBox13.Text + "  password show";
                        dbaccess.Receive_date = DateTime.Now.ToString("MMM  dd ,dddd, yyyy hh:mm:ss tt");
                            dbaccess.Receive_time = DateTime.Now.ToString("HH:mm:ss tt");

                        if (dbaccess.DataSaveInEmail1())
                        {
                                textBox13.Text = "Insert ID for Know Password or modify";
                                textBox7.Text = " Temp Teacher_id";

                        }
                        else
                        {

                        }

                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else { MessageBox.Show("you don't have permission for this"); }
        }else { MessageBox.Show("insert login id first"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {






        }

        private void button4_Click(object sender, EventArgs e)
        { if (textBox13.Text == "")
            { MessageBox.Show("insert Login_id first"); }
            else {

                DialogResult dialogResult = MessageBox.Show("Close this account", "warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (textBox13.Text == "admin")
                    {
                        MessageBox.Show("you don't have permission");
                    }

                    else
                    {
                        Class1 dbaccess = new Class1();
                        dbaccess.Login_id = textBox13.Text;
                        //  dbaccess.Login_password = textBox2.Text;
                        //  dbaccess.Log_type = textBox3.Text;

                        if (dbaccess.DataDeleInTable())
                        {
                            textBox3.Text = "not read";




                            Class1 dbaccess1 = new Class1();
                            dbaccess1.Sender_id = textBox2.Text;
                            dbaccess1.Receiver_id = "admin";


                            dbaccess1.Status = textBox3.Text;


                            dbaccess1.Information = "ID   " + textBox13.Text + "  Close";
                            dbaccess1.Receive_date = DateTime.Now.ToString("MMM  dd ,dddd, yyyy hh:mm:ss tt");
                            dbaccess1.Receive_time = DateTime.Now.ToString("HH:mm:ss tt");

                            if (dbaccess1.DataSaveInEmail1())
                            {
                                textBox13.Text = "Insert ID for Know Password or modify";
                                textBox7.Text = " Temp Teacher_id";

                            }
                            else
                            {

                            }
                            textBox13.Text = "Insert ID for Know Password or modify";
                            textBox7.Text = " Temp Teacher_id";
                            MessageBox.Show("sucess and activity send to admin");
                        }
                        else
                        {
                            MessageBox.Show("fail");
                        }
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
               
        } }

        private void button5_Click(object sender, EventArgs e)
        {
            button6.PerformClick();
            if (textBox13.Text == "")
            { MessageBox.Show("insert Login_id first"); }
            else
            {

                DialogResult dialogResult = MessageBox.Show("IF you Re-open this account one email send to admin. Are you want this?", "warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (textBox13.Text == "admin")
                    {
                        MessageBox.Show("you don't have permission");
                    }

                    else
                    {
                        Class1 dbaccess = new Class1();
                        dbaccess.Login_id = textBox13.Text;
                        dbaccess.Log_type = comboBox1.Text;
                        //  dbaccess.Login_password = textBox2.Text;
                        //  dbaccess.Log_type = textBox3.Text;

                        if (dbaccess.DataDeleInTable1())
                        {
                            MessageBox.Show("sucess");
                            textBox3.Text = "not read";




                            Class1 dbaccess00 = new Class1();
                            dbaccess00.Sender_id = textBox2.Text;
                            dbaccess00.Receiver_id = "admin";


                            dbaccess00.Status = textBox3.Text;


                            dbaccess00.Information = "ID   " + textBox13.Text + "   Re-open";
                            dbaccess00.Receive_date = DateTime.Now.ToString("MMM  dd ,dddd, yyyy hh:mm:ss tt");
                            dbaccess00.Receive_time = DateTime.Now.ToString("HH:mm:ss tt");

                            if (dbaccess00.DataSaveInEmail1())
                            {
                                textBox13.Text = "Insert ID for Know Password or modify";
                                textBox7.Text = " Temp Teacher_id";

                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            MessageBox.Show("fail");
                        }
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            Class1 dbaccess = new Class1();
            dbaccess.Student_id = textBox13.Text;
           

            if (dbaccess.QueryInTables())
            {

                textBox4.Text = dbaccess.Student_id;
               

            }
            else
            {
               
            }

            Class1 dbaccess1 = new Class1();
            dbaccess1.Teacher_id = textBox13.Text;


            if (dbaccess1.QueryInTablet())
            {

                textBox5.Text = dbaccess1.Teacher_id;


            }
            else
            {

            }


            Class1 dbaccess2 = new Class1();
            dbaccess2.Admin_id = textBox13.Text;


            if (dbaccess2.QueryInTablea())
            {

                textBox6.Text = dbaccess2.Admin_id;


            }
            else
            {

            }

            if (textBox4.Text != "")
            {
                comboBox1.Text = "";
                comboBox1.Text = "Student";
            }
            else if (textBox5.Text != "")


            {
                comboBox1.Text = "";
                comboBox1.Text = "Teacher";
            }
            else if (textBox6.Text != "")


            {
                comboBox1.Text = "";
                comboBox1.Text = "Admin";
            }
            else if (textBox13.Text == "")
                MessageBox.Show("inser Login ID first");
            else { MessageBox.Show("No ID found"); }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox13.Text != "")
            {
                if (textBox13.Text != "admin")
                {
                    DialogResult dialogResult = MessageBox.Show("One email send to your admin if you show this password. Are you want? ", "warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {


                        Class1 dbaccess1 = new Class1();
                        dbaccess1.Login_id = textBox13.Text;


                        if (dbaccess1.QueryInTemp())
                        {


                          //  MessageBox.Show(dbaccess1.Login_password);
                            textBox3.Text = "not read";




                            Class1 dbaccess = new Class1();
                            dbaccess.Sender_id = textBox2.Text;
                            dbaccess.Receiver_id = "admin";


                            dbaccess.Status = textBox3.Text;


                            dbaccess.Information = "ID   " + textBox13.Text + "  Temp password show";
                            dbaccess.Receive_date = DateTime.Now.ToString("MMM  dd ,dddd, yyyy hh:mm:ss tt");
                            dbaccess.Receive_time = DateTime.Now.ToString("HH:mm:ss tt");

                            if (dbaccess.DataSaveInEmail1())
                            {
                                Class1 dbaccess2 = new Class1();
                                dbaccess2.Sender_id = textBox2.Text;
                                dbaccess2.Receiver_id = textBox7.Text;


                                dbaccess2.Status = textBox3.Text;


                                dbaccess2.Information = "ID   " + textBox13.Text + "  Temp password =  "+ dbaccess1.Login_password;
                                dbaccess2.Receive_date = DateTime.Now.ToString("MMM  dd ,dddd, yyyy hh:mm:ss tt");
                                dbaccess2.Receive_time = DateTime.Now.ToString("HH:mm:ss tt");
                                if (dbaccess2.DataSaveInEmail1()) {
                                    textBox13.Text = "Insert ID for Know Password or modify";
                                    textBox7.Text = " Temp Teacher_id";
                                } else { }


                            }
                            else
                            {

                            }

                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }
                else { MessageBox.Show("you don't have permission for this"); }
            }
            else { MessageBox.Show("insert login id first"); }
        }

        private void textBox13_Click(object sender, EventArgs e)
        {
            textBox13.Clear();
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
        }
    }
}
