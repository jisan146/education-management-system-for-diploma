using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;



namespace AITVET_Database
{
    class Class1
    {
        private string _id;
        private string _Temp_Teacher_ID;
        private string e;
        private string _e;
        private string _sm;
        private string _em;
     
        private string _type; private string _published;
        private string _file;
        private string _cn;
        private string _f;
        private string _teacher_id1;
        private string _Insert_By;
        private string _Update_Time;
        private string _s;
        private string _appoint_date;
        private string _salary;
        private string _book_id;
        private string _book_name;
        private string _t;
        private string _p;
        private string _c;

        private string _course_id;

        private string _course_name;
        private string _course_credit;
        private string _course_fees;
            
        private string _login_id;
        private string _login_password;
        private string _log_type;
        private string _teacher_id;
        private string _teacher_name;
        private string _DOB;
        private string _Phone;
        private string _Email;
        private string _Current_Address;
        private string _Permanent_Address;
        private string _gender;
        private string _picture;
        private string _student_id;
        private string _student_name;
        private string _board_roll;
        private string _admin_id;
        private string _admin_name;
        private string _semester_no;

        private string _buliding;
        private string _building;
            private string _floor;
            private string _room_type;
            private string _sit;
            private string _room;




        private SqlConnection con;

        public string Login_id
        {
            get
            {
                return _login_id;
            }

            set
            {
                _login_id = value;
            }
        }

        public string Login_password
        {
            get
            {
                return _login_password;
            }

            set
            {
                _login_password = value;
            }
        }

        public string Log_type
        {
            get
            {
                return _log_type;
            }

            set
            {
                _log_type = value;
            }
        }

        public string Teacher_id
        {
            get
            {
                return _teacher_id;
            }

            set
            {
                _teacher_id = value;
            }
        }

        public string Teacher_name
        {
            get
            {
                return _teacher_name;
            }

            set
            {
                _teacher_name = value;
            }
        }

        public string DOB
        {
            get
            {
                return _DOB;
            }

            set
            {
                _DOB = value;
            }
        }

        public string Phone
        {
            get
            {
                return _Phone;
            }

            set
            {
                _Phone = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
            }
        }

        public string Current_Address
        {
            get
            {
                return _Current_Address;
            }

            set
            {
                _Current_Address = value;
            }
        }

        public string Permanent_Address
        {
            get
            {
                return _Permanent_Address;
            }

            set
            {
                _Permanent_Address = value;
            }
        }

        public string Gender
        {
            get
            {
                return _gender;
            }

            set
            {
                _gender = value;
            }
        }

        public string Picture
        {
            get
            {
                return _picture;
            }

            set
            {
                _picture = value;
            }
        }

        public string Student_id
        {
            get
            {
                return _student_id;
            }

            set
            {
                _student_id = value;
            }
        }

        public string Student_name
        {
            get
            {
                return _student_name;
            }

            set
            {
                _student_name = value;
            }
        }

        public string Board_roll
        {
            get
            {
                return _board_roll;
            }

            set
            {
                _board_roll = value;
            }
        }

        public string Admin_id
        {
            get
            {
                return _admin_id;
            }

            set
            {
                _admin_id = value;
            }
        }

        public string Admin_name
        {
            get
            {
                return _admin_name;
            }

            set
            {
                _admin_name = value;
            }
        }

        public string Buliding
        {
            get
            {
                return _buliding;
            }

            set
            {
                _buliding = value;
            }
        }

        public string Floor
        {
            get
            {
                return _floor;
            }

            set
            {
                _floor = value;
            }
        }

        public string Room_type
        {
            get
            {
                return _room_type;
            }

            set
            {
                _room_type = value;
            }
        }

        public string Sit
        {
            get
            {
                return _sit;
            }

            set
            {
                _sit = value;
            }
        }

        public string Room
        {
            get
            {
                return _room;
            }

            set
            {
                _room = value;
            }
        }

        public string Building
        {
            get
            {
                return _building;
            }

            set
            {
                _building = value;
            }
        }

        public string Semester_no
        {
            get
            {
                return _semester_no;
            }

            set
            {
                _semester_no = value;
            }
        }

        public string Course_id
        {
            get
            {
                return _course_id;
            }

            set
            {
                _course_id = value;
            }
        }

        public string Course_name
        {
            get
            {
                return _course_name;
            }

            set
            {
                _course_name = value;
            }
        }

        public string Course_credit
        {
            get
            {
                return _course_credit;
            }

            set
            {
                _course_credit = value;
            }
        }

        public string Course_fees
        {
            get
            {
                return _course_fees;
            }

            set
            {
                _course_fees = value;
            }
        }

        public string Book_id
        {
            get
            {
                return _book_id;
            }

            set
            {
                _book_id = value;
            }
        }

        public string Book_name
        {
            get
            {
                return _book_name;
            }

            set
            {
                _book_name = value;
            }
        }

        public string T
        {
            get
            {
                return _t;
            }

            set
            {
                _t = value;
            }
        }

        public string P
        {
            get
            {
                return _p;
            }

            set
            {
                _p = value;
            }
        }

        public string C
        {
            get
            {
                return _c;
            }

            set
            {
                _c = value;
            }
        }

        public string Department_id
        {
            get
            {
                return _department_id;
            }

            set
            {
                _department_id = value;
            }
        }

        public string Department_name
        {
            get
            {
                return _department_name;
            }

            set
            {
                _department_name = value;
            }
        }

        public string Appoint_date
        {
            get
            {
                return _appoint_date;
            }

            set
            {
                _appoint_date = value;
            }
        }

        public string Salary
        {
            get
            {
                return _salary;
            }

            set
            {
                _salary = value;
            }
        }

        public string Start_time
        {
            get
            {
                return _start_time;
            }

            set
            {
                _start_time = value;
            }
        }

        public string End_time
        {
            get
            {
                return _end_time;
            }

            set
            {
                _end_time = value;
            }
        }

        public string Class_date
        {
            get
            {
                return _class_date;
            }

            set
            {
                _class_date = value;
            }
        }

        public string Class_type
        {
            get
            {
                return _class_type;
            }

            set
            {
                _class_type = value;
            }
        }

        public string Sender_id
        {
            get
            {
                return _sender_id;
            }

            set
            {
                _sender_id = value;
            }
        }

        public string Receiver_id
        {
            get
            {
                return _receiver_id;
            }

            set
            {
                _receiver_id = value;
            }
        }

        public string Information
        {
            get
            {
                return _information;
            }

            set
            {
                _information = value;
            }
        }

        public string Receive_date
        {
            get
            {
                return _receive_date;
            }

            set
            {
                _receive_date = value;
            }
        }

        public string Receive_time
        {
            get
            {
                return _receive_time;
            }

            set
            {
                _receive_time = value;
            }
        }

        public string Student_type
        {
            get
            {
                return _student_type;
            }

            set
            {
                _student_type = value;
            }
        }

        public string Admission_type
        {
            get
            {
                return _admission_type;
            }

            set
            {
                _admission_type = value;
            }
        }

        public string Admission_date
        {
            get
            {
                return _admission_date;
            }

            set
            {
                _admission_date = value;
            }
        }

        public string Pay
        {
            get
            {
                return _pay;
            }

            set
            {
                _pay = value;
            }
        }

        public string Due
        {
            get
            {
                return _due;
            }

            set
            {
                _due = value;
            }
        }

        public string Payment_date
        {
            get
            {
                return _payment_date;
            }

            set
            {
                _payment_date = value;
            }
        }

        public string Pay_date
        {
            get
            {
                return _pay_date;
            }

            set
            {
                _pay_date = value;
            }
        }

       

        public string Theory_continous
        {
            get
            {
                return _theory_continous;
            }

            set
            {
                _theory_continous = value;
            }
        }

        public string Theory_final
        {
            get
            {
                return _theory_final;
            }

            set
            {
                _theory_final = value;
            }
        }

        public string Practical_continous
        {
            get
            {
                return _practical_continous;
            }

            set
            {
                _practical_continous = value;
            }
        }

        public string Practical_final
        {
            get
            {
                return _practical_final;
            }

            set
            {
                _practical_final = value;
            }
        }

        public string Total
        {
            get
            {
                return _total;
            }

            set
            {
                _total = value;
            }
        }

        public string Grade_point
        {
            get
            {
                return _grade_point;
            }

            set
            {
                _grade_point = value;
            }
        }

        public string Grade
        {
            get
            {
                return _grade;
            }

            set
            {
                _grade = value;
            }
        }

        public string Day
        {
            get
            {
                return _day;
            }

            set
            {
                _day = value;
            }
        }

        public string Room_name
        {
            get
            {
                return _room_name;
            }

            set
            {
                _room_name = value;
            }
        }

        public string Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
            }
        }

        public string Fine
        {
            get
            {
                return _fine;
            }

            set
            {
                _fine = value;
            }
        }

        public string Exam_fee
        {
            get
            {
                return _exam_fee;
            }

            set
            {
                _exam_fee = value;
            }
        }

        public string Comment
        {
            get
            {
                return _comment;
            }

            set
            {
                _comment = value;
            }
        }

        public string S
        {
            get
            {
                return _s;
            }

            set
            {
                _s = value;
            }
        }

        public string Insert_By
        {
            get
            {
                return _Insert_By;
            }

            set
            {
                _Insert_By = value;
            }
        }

        public string Update_Time
        {
            get
            {
                return _Update_Time;
            }

            set
            {
                _Update_Time = value;
            }
        }

        public string Teacher_id1
        {
            get
            {
                return _teacher_id1;
            }

            set
            {
                _teacher_id1 = value;
            }
        }

        public string File
        {
            get
            {
                return _file;
            }

            set
            {
                _file = value;
            }
        }

        public string F
        {
            get
            {
                return _f;
            }

            set
            {
                _f = value;
            }
        }

        public string Cn
        {
            get
            {
                return _cn;
            }

            set
            {
                _cn = value;
            }
        }

        public string Published
        {
            get
            {
                return _published;
            }

            set
            {
                _published = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public string E
        {
            get
            {
                return _e;
            }

            set
            {
                _e = value;
            }
        }

        public string Sm
        {
            get
            {
                return _sm;
            }

            set
            {
                _sm = value;
            }
        }

        public string Em
        {
            get
            {
                return _em;
            }

            set
            {
                _em = value;
            }
        }

        public string Temp_Teacher_ID
        {
            get
            {
                return _Temp_Teacher_ID;
            }

            set
            {
                _Temp_Teacher_ID = value;
            }
        }

        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string G
        {
            get
            {
                return g;
            }

            set
            {
                g = value;
            }
        }

        public Class1()
        {
            con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            if (con.State != ConnectionState.Open)
            {
                
                con.Open();
                
            }else {  }

        }
        

        public bool DataSaveInTable()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into login_id(login_id,login_password,log_type)values(@Login_id,@Log_password,@Log_type)";
            cmd.Parameters.AddWithValue("@Login_id", _login_id);
            cmd.Parameters.AddWithValue("@Log_password", _login_password);
            cmd.Parameters.AddWithValue("@Log_type", _log_type);

            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool DataSaveInTemp()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into temp(login_id,login_password)values(@Login_id,@Log_password)";
            cmd.Parameters.AddWithValue("@Login_id", _login_id);
            cmd.Parameters.AddWithValue("@Log_password", _login_password);
           

            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }



        public bool QueryInTeacher()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select *from teacher where teacher_id=@Teacher_id";

            cmd.Parameters.AddWithValue("@Teacher_id", _teacher_id);
            
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                reader.Read();
                _teacher_id = reader["Teacher_id"].ToString();
                 _teacher_name= reader["Teacher_name"].ToString();
                 _Phone= reader["Phone"].ToString();
                 _Email= reader["Email"].ToString();
                 _Current_Address= reader["Current_Address"].ToString();
                 _Permanent_Address= reader["Permanent_Address"].ToString();
                 _picture= reader["Picture"].ToString();
                 _gender= reader["Gender"].ToString();
                 _DOB= reader["DOB"].ToString();
                return true;
            }
            catch (Exception)
            {
                reader.Close();
                return false;
            }
        }
        public bool QueryInoo()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select *from operate where teacher_id=@Teacher_id and course_id=@Course_id and semester_no=@Semester_no and book_id=@Book_id and class_type=@Class_type and day=@Day";

            cmd.Parameters.AddWithValue("@Teacher_id", _teacher_id);
            cmd.Parameters.AddWithValue("@Course_id", _course_id);
            cmd.Parameters.AddWithValue("@Semester_no",_semester_no);
            cmd.Parameters.AddWithValue("@Book_id", _book_id);
            cmd.Parameters.AddWithValue("@Class_type", _class_type);
            cmd.Parameters.AddWithValue("@Day", _day);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                reader.Read();
                _room = reader["Room"].ToString();
                _book_id= reader["Book_id"].ToString();
                _course_id = reader["Course_id"].ToString();
                _semester_no = reader["Semester_no"].ToString();
                _class_type = reader["Class_type"].ToString();
                _day = reader["Day"].ToString();
                _end_time = reader["End_time"].ToString();
                _start_time = reader["Start_time"].ToString();
                _s = reader["S"].ToString();
                _e = reader["E"].ToString();
                _sm = reader["Sm"].ToString();
                _em = reader["Em"].ToString();

                return true;
            }
            catch (Exception)
            {
                reader.Close();
                return false;
            }
        }


        public bool QueryInStudent()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select *from student where Student_id=@Student_id";

            cmd.Parameters.AddWithValue("@Student_id", _student_id);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                reader.Read();
                _student_id = reader["Student_id"].ToString();
                _student_name = reader["Student_name"].ToString();
                _Phone = reader["Phone"].ToString();
                _Email = reader["Email"].ToString();
                _Current_Address = reader["Current_Address"].ToString();
                _Permanent_Address = reader["Permanent_Address"].ToString();
                _picture = reader["Picture"].ToString();
                _gender = reader["Gender"].ToString();
                _DOB = reader["DOB"].ToString();
                _board_roll = reader["Board_roll"].ToString();
                return true;
            }
            catch (Exception)
            {
                reader.Close();
                return false;
            }
        }


        public bool QueryInAdmin()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select *from administrator where Admin_id=@Admin_id";

            cmd.Parameters.AddWithValue("@Admin_id", _admin_id);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                reader.Read();
                _admin_id = reader["Admin_id"].ToString();
                _admin_name = reader["Admin_name"].ToString();
                _Phone = reader["Phone"].ToString();
                _Email = reader["Email"].ToString();
                _Current_Address = reader["Current_Address"].ToString();
               
                _picture = reader["Picture"].ToString();
                
                
                return true;
            }
            catch (Exception)
            {
                reader.Close();
                return false;
            }
        }

        public bool DataSaveInStudent()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into student(student_id,board_roll,student_name,picture,gender,DOB,Phone,Email,Current_Address,Permanent_Address,Insert_By,admission_date)values(@Student_id,@Board_roll,@Student_name,@Picture,@Gender,@DOB,@Phone,@Email,@Current_Address,@Permanent_Address,@Insert_By,@Admission_date)";
            cmd.Parameters.AddWithValue("@Student_id", _student_id);
            cmd.Parameters.AddWithValue("@Student_name", _student_name);
            cmd.Parameters.AddWithValue("@Picture", _picture);
            cmd.Parameters.AddWithValue("@Gender", _gender);
            cmd.Parameters.AddWithValue("@DOB", _DOB);
            cmd.Parameters.AddWithValue("@Phone", _Phone);
            cmd.Parameters.AddWithValue("@Email", _Email);
            cmd.Parameters.AddWithValue("@Current_Address", _Current_Address);
            cmd.Parameters.AddWithValue("@Permanent_Address", _Permanent_Address);
            cmd.Parameters.AddWithValue("@Board_roll", _board_roll);
            cmd.Parameters.AddWithValue("@Insert_By", _Insert_By);
            cmd.Parameters.AddWithValue("@Admission_date", _admission_date);


            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }



        public bool DataSaveInAdmin()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into administrator(admin_id,admin_name,picture,Phone,Email,Current_Address,s,Insert_By,Update_Time)values(@Admin_id,@Admin_name,@Picture,@Phone,@Email,@Current_Address,@S,@Insert_By,@Update_Time)";
            cmd.Parameters.AddWithValue("@Admin_id",_admin_id);
            cmd.Parameters.AddWithValue("@Admin_name",_admin_name);
            cmd.Parameters.AddWithValue("@Picture", _picture);
            
            cmd.Parameters.AddWithValue("@Phone", _Phone);
            cmd.Parameters.AddWithValue("@Email", _Email);
            cmd.Parameters.AddWithValue("@Current_Address", _Current_Address);
            cmd.Parameters.AddWithValue("@S", _s);
            cmd.Parameters.AddWithValue("@Insert_By", _Insert_By);
            cmd.Parameters.AddWithValue("@Update_Time", _Update_Time);

            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool DataSaveInSemester()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into semester(semester_no)values(@Semester_no)";
            cmd.Parameters.AddWithValue("@Semester_no", _semester_no);
            

            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool DataSaveInSemester1()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from  semester where semester_no=@Semester_no";
            cmd.Parameters.AddWithValue("@Semester_no", _semester_no);


            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        private string _room_name;


        public bool DataSaveInClass()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into class(building,floor,room_type,room,sit,room_name)values(@Building,@Floor,@Room_type,@Room,@Sit,@Room_name)";
            cmd.Parameters.AddWithValue("@Building", _building);
            cmd.Parameters.AddWithValue("@Floor", _floor);
            cmd.Parameters.AddWithValue("@Room_type", _room_type);

            cmd.Parameters.AddWithValue("@Sit", _sit);
            cmd.Parameters.AddWithValue("@Room",_room);
            cmd.Parameters.AddWithValue("@Room_name", _room_name);


            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool DataSaveInClass1()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from class where room=@Room";
           
            cmd.Parameters.AddWithValue("@Room", _room);
           


            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }

        public bool DataSaveInAppoint()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into appoint(department_id,teacher_id1,appoint_date,salary)values(@Department_id,@Teacher_id1,@Appoint_date,@Salary)";
            cmd.Parameters.AddWithValue("@Department_id", _department_id);
            cmd.Parameters.AddWithValue("@Teacher_id1", _teacher_id1);
            cmd.Parameters.AddWithValue("@Appoint_date", _appoint_date);

            cmd.Parameters.AddWithValue("@Salary", _salary);
           


            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool DataSaveInfilen()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into filen(department_id)values(@Department_id)";
            cmd.Parameters.AddWithValue("@Department_id", _department_id);



            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool DataSaveInm()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into m(id)values(@Id)";
            cmd.Parameters.AddWithValue("@Id", Id);



            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }


        public bool DataSaveInTeach()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into teach(teacher_id,semester_no,course_id,book_id)values(@Teacher_id,@Semester_no,@Course_id,@Book_id)";
            cmd.Parameters.AddWithValue("@Teacher_id",_teacher_id);
            cmd.Parameters.AddWithValue("@Semester_no", _semester_no);
            cmd.Parameters.AddWithValue("@Course_id", _course_id);

            cmd.Parameters.AddWithValue("@Book_id",_book_id);



            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool upinread()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update reads set student_type=@Student_type where student_id=@Student_id and semester_no=@Semester_no and course_id=@Course_id";//update login_id set login_password=@Login_password where login_id=@Login_id

            cmd.Parameters.AddWithValue("@Student_type", _student_type);
            cmd.Parameters.AddWithValue("@Student_id", _student_id);
            cmd.Parameters.AddWithValue("@Semester_no", _semester_no);
            cmd.Parameters.AddWithValue("@Course_id", _course_id);


            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DataSaveIncourse_has()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into course_has(course_id,semester_no,book_id)values(@Course_id,@Semester_no,@Book_id)";
            cmd.Parameters.AddWithValue("@Course_id", _course_id);
            cmd.Parameters.AddWithValue("@Semester_no", _semester_no);
            cmd.Parameters.AddWithValue("@Book_id",_book_id);

       



            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }


        private string _start_time;
        private string _end_time;
        private string _class_date;
        private string _class_type;

        private string _sender_id;
            private string _receiver_id;
            private string _information;
            private string _receive_date;
            private string _receive_time;
        
        public bool DataSaveInEmail()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into email(sender_id,receiver_id,information,receive_date,receive_time,semester_no,course_id,status,f)values(@Sender_id,@Receiver_id,@Information,@Receive_date,@Receive_time,@Semester_no,@Course_id,@Status,@F)";
            cmd.Parameters.AddWithValue("@Sender_id", _sender_id);
            cmd.Parameters.AddWithValue("@Receiver_id",_receiver_id);
            cmd.Parameters.AddWithValue("@Information", _information);
            cmd.Parameters.AddWithValue("@Receive_date", _receive_date);
            cmd.Parameters.AddWithValue("@Receive_time",_receive_time);
            cmd.Parameters.AddWithValue("@Semester_no", _semester_no);
            cmd.Parameters.AddWithValue("@Course_id", _course_id);
            cmd.Parameters.AddWithValue("@Status", _status);
            cmd.Parameters.AddWithValue("@F", _f);





            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool DataSaveInEmail12()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into email1(sender_id,receiver_id,information,receive_date,receive_time,semester_no,course_id,status,s)values(@Sender_id,@Receiver_id,@Information,@Receive_date,@Receive_time,@Semester_no,@Course_id,@Status,@S)";
            cmd.Parameters.AddWithValue("@Sender_id", _sender_id);
            cmd.Parameters.AddWithValue("@Receiver_id", _receiver_id);
            cmd.Parameters.AddWithValue("@Information", _information);
            cmd.Parameters.AddWithValue("@Receive_date", _receive_date);
            cmd.Parameters.AddWithValue("@Receive_time", _receive_time);
            cmd.Parameters.AddWithValue("@Semester_no", _semester_no);
            cmd.Parameters.AddWithValue("@Course_id", _course_id);
            cmd.Parameters.AddWithValue("@Status", _status);
            cmd.Parameters.AddWithValue("@S", _s);





            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool DataSaveInEmail1()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into email(sender_id,receiver_id,information,receive_date,receive_time,status)values(@Sender_id,@Receiver_id,@Information,@Receive_date,@Receive_time,@Status)";
            cmd.Parameters.AddWithValue("@Sender_id", _sender_id);
            cmd.Parameters.AddWithValue("@Receiver_id", _receiver_id);
            cmd.Parameters.AddWithValue("@Information", _information);
            cmd.Parameters.AddWithValue("@Receive_date", _receive_date);
            cmd.Parameters.AddWithValue("@Receive_time", _receive_time);
            
           
            cmd.Parameters.AddWithValue("@Status", _status);





            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }



        public bool DataSaveInBook()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into book(book_id,book_name,t,p,c,cn)values(@Book_id,@Book_name,@T,@P,@C,@Cn)";
            cmd.Parameters.AddWithValue("@Book_id", _book_id);
            cmd.Parameters.AddWithValue("@Book_name", _book_name);
            cmd.Parameters.AddWithValue("@T", _t);

            cmd.Parameters.AddWithValue("@P", _p);
            cmd.Parameters.AddWithValue("@C", _c);
            cmd.Parameters.AddWithValue("@Cn", _cn);


            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool DataSaveInBook1()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from book where book_id=@Book_id";
            cmd.Parameters.AddWithValue("@Book_id", _book_id);
           
            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }



        }
        public bool DataSaveIng()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into g(student_id,semester_no)values(@Student_id,@Semester_no)";
            cmd.Parameters.AddWithValue("@Student_id",_student_id);
            cmd.Parameters.AddWithValue("@Semester_no", _semester_no);

            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }



        }
        private String _student_type;
        private string _admission_type;
        private string _admission_date;
        public bool DataSaveInRead()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into reads(student_id,semester_no,course_id,student_type,admission_date)values(@Student_id,@Semester_no,@Course_id,@Student_type,@Admission_date)";
            cmd.Parameters.AddWithValue("@Student_id",_student_id);
            cmd.Parameters.AddWithValue("@Semester_no", _semester_no);
            cmd.Parameters.AddWithValue("@Course_id", _course_id);

            cmd.Parameters.AddWithValue("@Student_type",_student_type );
            cmd.Parameters.AddWithValue("@Admission_date", _admission_date);


            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool DataSaveInRead1()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update reads set Insert_By=@Insert_By where student_id=@Student_id ";
            cmd.Parameters.AddWithValue("@Insert_By",_Insert_By);
            cmd.Parameters.AddWithValue("@Student_id", _student_id);




            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        private string _pay;
        private string _exam_fee;
        private string _fine;
        private string _due;
        private string _payment_date;
        private string _comment;
        public bool DataSaveInPay()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into payment(student_id,admin_id,course_id,pay,due,payment_date,exam_fee,fine,semester_no,comment)values(@Student_id,@Admin_id,@Course_id,@Pay,@Due,@Payment_date,@Exam_fee,@Fine,@Semester_no,@Comment)";
            cmd.Parameters.AddWithValue("@Student_id", _student_id);
            cmd.Parameters.AddWithValue("@Admin_id",_admin_id);
            cmd.Parameters.AddWithValue("@Course_id", _course_id);

            cmd.Parameters.AddWithValue("@Pay",_pay);
            cmd.Parameters.AddWithValue("@Due",_due );
            cmd.Parameters.AddWithValue("@Payment_date",_payment_date);
            cmd.Parameters.AddWithValue("@Exam_fee", _exam_fee);
            cmd.Parameters.AddWithValue("@Fine", _fine);
            cmd.Parameters.AddWithValue("@Semester_no", _semester_no);
            cmd.Parameters.AddWithValue("@Comment", _comment);


            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        private string _day;
        public bool DataSaveInOperate()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into operate(room,teacher_id,book_id,course_id,semester_no,day,start_time,end_time,class_type,s,e,sm,em)values(@Room,@Teacher_id,@Book_id,@Course_id,@Semester_no,@Day,@Start_time,@End_time,@Class_type,@S,@E,@Sm,@Em)";
            cmd.Parameters.AddWithValue("@Room",_room );
            cmd.Parameters.AddWithValue("@Teacher_id",_teacher_id);
            cmd.Parameters.AddWithValue("@Book_id",_book_id);

            cmd.Parameters.AddWithValue("@Course_id",_course_id);
            cmd.Parameters.AddWithValue("@Semester_no",_semester_no);
            cmd.Parameters.AddWithValue("@Day", _day);
            cmd.Parameters.AddWithValue("@Start_time",_start_time);
            cmd.Parameters.AddWithValue("@End_time",_end_time );
            cmd.Parameters.AddWithValue("@Class_type", _class_type);
            cmd.Parameters.AddWithValue("@S", _s);
            cmd.Parameters.AddWithValue("@E",_e);
            cmd.Parameters.AddWithValue("@Sm", _sm);
            cmd.Parameters.AddWithValue("@Em", _em);


            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        private string _status;
        public bool DataSaveInA()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into attendence(student_id,book_id,class_type,teacher_id,start_time,end_time,class_date,status,Temp_Teacher_ID)values(@Student_id,@Book_id,@Class_type,@Teacher_id,@Start_time,@End_time,@Class_date,@Status,@Temp_Teacher_ID)";
            cmd.Parameters.AddWithValue("@Student_id",_student_id);
            cmd.Parameters.AddWithValue("@Book_id",_book_id);
            cmd.Parameters.AddWithValue("@Class_type",_class_type);
            cmd.Parameters.AddWithValue("@Teacher_id",_teacher_id);
            cmd.Parameters.AddWithValue("@Start_time",_start_time);
            cmd.Parameters.AddWithValue("@End_time",_end_time);
            cmd.Parameters.AddWithValue("@Class_date",_class_date);
            cmd.Parameters.AddWithValue("@Status",_status);
            cmd.Parameters.AddWithValue("@Temp_Teacher_ID", _Temp_Teacher_ID);



            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool DataSaveInExpart()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into expart(teacher_id,book_id)values(@Teacher_id,@Book_id)";
            cmd.Parameters.AddWithValue("@Book_id", _book_id);
            cmd.Parameters.AddWithValue("@Teacher_id", _teacher_id);



            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool updateadmin()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update administrator set email=@Email ,  phone=@Phone, current_address=@Current_address  where admin_id=@Admin_id";
            cmd.Parameters.AddWithValue("@Phone", _Phone);
            cmd.Parameters.AddWithValue("@Email", _Email);
            cmd.Parameters.AddWithValue("@Current_address",_Current_Address );
            cmd.Parameters.AddWithValue("@Admin_id", _admin_id );





            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }

        private string _department_id;
        private string _department_name;
        public bool DataSaveInDepartment()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into department(department_id,department_name)values(@Department_id,@Department_name)";
            cmd.Parameters.AddWithValue("@Department_id",_department_id);
            cmd.Parameters.AddWithValue("@Department_name",_department_name);
       

           


            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool DataSaveInDepartment1()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from  department where department_id=@Department_id";
            cmd.Parameters.AddWithValue("@Department_id", _department_id);
           





            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool DataSaveInTake_course()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into take_course(student_id,course_id)values(@Student_id,@Course_id)";
            cmd.Parameters.AddWithValue("@Student_id",_student_id);
            cmd.Parameters.AddWithValue("@Course_id",_course_id);





            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }


        public bool DataSaveInCourse()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into course(course_id,course_name,course_credit,course_fees,sit)values(@Course_id,@Course_name,@Course_credit,@Course_fees,@Sit)";
            cmd.Parameters.AddWithValue("@Course_id", _course_id);
            cmd.Parameters.AddWithValue("@Course_name", _course_name);
            cmd.Parameters.AddWithValue("@Course_credit", _course_credit);

            cmd.Parameters.AddWithValue("@Course_fees", _course_fees);
            cmd.Parameters.AddWithValue("@Sit", _sit);


            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool DataSaveInCourse1()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from course where course_id=@Course_id";
            cmd.Parameters.AddWithValue("@Course_id", _course_id);
           


            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        private string _theory_continous;
            private string _theory_final;
            private string _practical_continous;
            private string _practical_final;
            private string _total;
            private string _grade_point;
            private string _grade;
        private string g;
        public bool DataSaveInResult()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into result(student_id,book_id,theory_continous,theory_final,practical_continous,practical_final,total,grade_point,grade,teacher_id,type,published,semester_no,g)values(@Student_id,@Book_id,@Theory_continous,@Theory_final,@Practical_continous,@Practical_final,@Total,@Grade_point,@Grade,@Teacher_id,@Type,@Published,@Semester_no,@G)";
            cmd.Parameters.AddWithValue("@Student_id", _student_id );
            cmd.Parameters.AddWithValue("@Book_id", _book_id );
            cmd.Parameters.AddWithValue("@Theory_continous", _theory_continous );
            cmd.Parameters.AddWithValue("@Theory_final", _theory_final);
            cmd.Parameters.AddWithValue("@Practical_continous", _practical_continous);
            cmd.Parameters.AddWithValue("@Practical_final", _practical_final);
            cmd.Parameters.AddWithValue("@Total", _total );
            cmd.Parameters.AddWithValue("@Grade", _grade);
            cmd.Parameters.AddWithValue("@Grade_point", _grade_point);
            cmd.Parameters.AddWithValue("@Teacher_id", _teacher_id);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Published", _published);
            cmd.Parameters.AddWithValue("@Semester_no", _semester_no);
            cmd.Parameters.AddWithValue("@G", g);


            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool DataSaveIngpa()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into gpa(student_id,semester_no,grade_point)values(@Student_id,@Semester_no,@Grade_point)";
            cmd.Parameters.AddWithValue("@Student_id", _student_id);
            cmd.Parameters.AddWithValue("@Semester_no", _semester_no);
            cmd.Parameters.AddWithValue("@Grade_point", _grade_point);
            

            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool DataSaveInper()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into percent1(student_id,semester_no,s,book_id,teacher_id)values(@Student_id,@Semester_no,@S,@Book_id,@Teacher_id)";
            cmd.Parameters.AddWithValue("@Student_id", _student_id);
            cmd.Parameters.AddWithValue("@Semester_no", _semester_no);
            cmd.Parameters.AddWithValue("@S", _s);
            cmd.Parameters.AddWithValue("@Book_id", _book_id);
            cmd.Parameters.AddWithValue("@Teacher_id", _teacher_id);


            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        private string _pay_date;
        public bool DataSaveInSalary()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into salary(teacher_id1,admin_id,pay,due,pay_date)values(@Teacher_id1,@Admin_id,@Pay,@Due,@Pay_date)";
            cmd.Parameters.AddWithValue("@Teacher_id1",_teacher_id1);
            cmd.Parameters.AddWithValue("@Admin_id",_admin_id);
            

            cmd.Parameters.AddWithValue("@Pay", _pay);
            cmd.Parameters.AddWithValue("@Due", _due);
            cmd.Parameters.AddWithValue("@Pay_date",_pay_date);


            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }





        public bool DataSaveInTeacher()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into teacher(teacher_id,teacher_name,picture,gender,DOB,Phone,Email,Current_Address,Permanent_Address,Insert_By)values(@Teacher_id,@Teacher_name,@Picture,@Gender,@DOB,@Phone,@Email,@Current_Address,@Permanent_Address,@Insert_By)";
            cmd.Parameters.AddWithValue("@Teacher_id", _teacher_id);
            cmd.Parameters.AddWithValue("@Teacher_name", _teacher_name);
            cmd.Parameters.AddWithValue("@Picture", _picture);
            cmd.Parameters.AddWithValue("@Gender", _gender);
            cmd.Parameters.AddWithValue("@DOB", _DOB);
            cmd.Parameters.AddWithValue("@Phone", _Phone);
            cmd.Parameters.AddWithValue("@Email", _Email);
            cmd.Parameters.AddWithValue("@Current_Address", _Current_Address);
            cmd.Parameters.AddWithValue("@Permanent_Address", _Permanent_Address);
            cmd.Parameters.AddWithValue("@Insert_By", _Insert_By);

            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }

        public bool DataDeleInTable()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update login_id set log_type='c' where login_id=@Login_id";

            cmd.Parameters.AddWithValue("@Login_id", _login_id);
            // cmd.Parameters.AddWithValue("@Email1", _email);
            //cmd.Parameters.AddWithValue("@Mobile", _mobile);

            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DataDeleInTable1()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update login_id set log_type=@Log_type where login_id=@Login_id";

            cmd.Parameters.AddWithValue("@Login_id", _login_id);
            cmd.Parameters.AddWithValue("@Log_type", _log_type);
            // cmd.Parameters.AddWithValue("@Email1", _email);
            //cmd.Parameters.AddWithValue("@Mobile", _mobile);

            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool QueryInBook()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select *from book where book_id=@Book_id";

            cmd.Parameters.AddWithValue("@Book_id", _book_id);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                reader.Read();
                _book_id = reader["book_id"].ToString();
                _c = reader["c"].ToString();
                _p = reader["p"].ToString();
                _t = reader["t"].ToString();
                _cn= reader["cn"].ToString();
                return true;
               
            }
            catch (Exception)
            {
                reader.Close();
                return false;
            }
        }
        public bool QueryInPayment()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select SUM(pay) as pay from payment where student_id=@Student_id";

            cmd.Parameters.AddWithValue("@Student_id", _student_id);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                reader.Read();
                _pay = reader["pay"].ToString();
              
                return true;

            }
            catch (Exception)
            {
                reader.Close();
                return false;
            }
        }
        public bool QueryInOp()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select *from reads where student_id=@Student_id and student_type='continue' or student_type='Re_admission'";//student_id='jisan-'//and student_type='continue' and semester_no='2'

            cmd.Parameters.AddWithValue("@Student_id", _student_id);
          
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                reader.Read();
                _semester_no = reader["semester_no"].ToString();
                _course_id = reader["course_id"].ToString();
                
                return true;
            }
            catch (Exception)
            {
                reader.Close();
                return false;
            }
        }
        public bool QueryInTable()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from login_id where login_id=@Login_id and login_password=@Login_password";

            cmd.Parameters.AddWithValue("@Login_id", _login_id);
            cmd.Parameters.AddWithValue("@Login_password", _login_password);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                reader.Read();
                _login_id = reader["login_id"].ToString();
                _login_password = reader["login_password"].ToString();
                _log_type = reader["log_type"].ToString();
                return true;
            }
            catch (Exception)
            {
                reader.Close();
                return false;
            }
        }
        public bool QueryInTempt()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from temp where login_id=@Login_id and login_password=@Login_password";

            cmd.Parameters.AddWithValue("@Login_id", _login_id);
            cmd.Parameters.AddWithValue("@Login_password", _login_password);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                reader.Read();
                _login_id = reader["login_id"].ToString();
              
                return true;
            }
            catch (Exception)
            {
                reader.Close();
                return false;
            }
        }
        public bool QueryInread()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from reads where student_id=@Student_id and (student_type='Continue' or student_type='Re_admission')";

            cmd.Parameters.AddWithValue("@Student_id", _student_id);
           
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                reader.Read();
                _course_id = reader["course_id"].ToString();
                _semester_no = reader["semester_no"].ToString();
                
                return true;
            }
            catch (Exception)
            {
                reader.Close();
                return false;
            }
        }
        public bool QueryInTable1()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from login_id where login_id=@Login_id ";

            cmd.Parameters.AddWithValue("@Login_id", _login_id);
           
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                reader.Read();
               
                _login_password = reader["login_password"].ToString();
               
                return true;
            }
            catch (Exception)
            {
                reader.Close();
                return false;
            }
        }
        public bool QueryInTemp()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from temp where login_id=@Login_id ";

            cmd.Parameters.AddWithValue("@Login_id", _login_id);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                reader.Read();

                _login_password = reader["login_password"].ToString();

                return true;
            }
            catch (Exception)
            {
                reader.Close();
                return false;
            }
        }
        public bool QueryInTables()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select *from student where student_id=@Student_id ";

            cmd.Parameters.AddWithValue("@Student_id", _student_id);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                reader.Read();

                _student_id = reader["student_id"].ToString();

                return true;
            }
            catch (Exception)
            {
                reader.Close();
                return false;
            }
        }
        public bool QueryInTablet()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select *from teacher where teacher_id=@Teacher_id";

            cmd.Parameters.AddWithValue("@Teacher_id", _teacher_id);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                reader.Read();

                _teacher_id = reader["teacher_id"].ToString();

                return true;
            }
            catch (Exception)
            {
                reader.Close();
                return false;
            }
        }

        public bool QueryInTablea()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select *from administrator where admin_id=@Admin_id";

            cmd.Parameters.AddWithValue("@Admin_id", _admin_id);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                reader.Read();

                _admin_id = reader["admin_id"].ToString();

                return true;
            }
            catch (Exception)
            {
                reader.Close();
                return false;
            }
        }
        public bool QueryInCourse()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select *from course where course_id=@Course_id";

            cmd.Parameters.AddWithValue("@Course_id", _course_id);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                reader.Read();
                 _course_id= reader["course_id"].ToString();
                 _course_name= reader["course_name"].ToString();
                _course_fees = reader["course_fees"].ToString();
                _course_credit = reader["course_credit"].ToString();
                _sit= reader["sit"].ToString();
                return true;
            }
            catch (Exception)
            {
                reader.Close();
                return false;
            }
        }
        public bool QueryInAppoint()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from appoint where teacher_id=@Teacher_id";

            cmd.Parameters.AddWithValue("@Teacher_id", _teacher_id);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                reader.Read();
                _department_id = reader["department_id"].ToString();
               _teacher_id = reader["teacher_id"].ToString();
                _appoint_date = reader["appoint_date"].ToString();
                _salary= reader["salary"].ToString();
                
                return true;
            }
            catch (Exception)
            {
                reader.Close();
                return false;
            }
        }
        public bool DataUpdateInTable()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update login_id set login_password=@Login_password where login_id=@Login_id";//update login_id set login_password=@Login_password where login_id=@Login_id

            cmd.Parameters.AddWithValue("@Login_id", _login_id);
            cmd.Parameters.AddWithValue("@login_password", _login_password);
           // cmd.Parameters.AddWithValue("@Mobile", _mobile);

            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DataupInEmail()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update email set status=@Status where sender_id=@Sender_id and receiver_id=@Receiver_id and receive_date=@Receive_date and information=@Information";
              
            cmd.Parameters.AddWithValue("@Sender_id", _sender_id);
            cmd.Parameters.AddWithValue("@Receiver_id", _receiver_id);
            cmd.Parameters.AddWithValue("@Information", _information);
            cmd.Parameters.AddWithValue("@Receive_date", _receive_date);
            cmd.Parameters.AddWithValue("@Status", _status);

            //  cmd.Parameters.AddWithValue("@Status", _status);




            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool DataupInEmail1()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update email set status=@Status where sender_id=@Sender_id and    semester_no=@Semester_no and course_id=@Course_id     and receive_date=@Receive_date and information=@Information";

            cmd.Parameters.AddWithValue("@Sender_id", _sender_id);
          
            cmd.Parameters.AddWithValue("@Information", _information);
            cmd.Parameters.AddWithValue("@Receive_date", _receive_date);

             cmd.Parameters.AddWithValue("@Status", _status);

            cmd.Parameters.AddWithValue("@Semester_no", _semester_no);
            cmd.Parameters.AddWithValue("@Course_id", _course_id);


            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }

    }
}
