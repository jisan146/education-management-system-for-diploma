
create table student
(
Serial_No int IDENTITY(1,1)not null,
student_id char(15),
student_name char (30),
board_roll char(6),
picture char(5000),
gender char(6),
DOB char(15),
Phone char(11),
Email char(30),
Current_Address char(30),
Permanent_Address char(30),
primary key(student_id))

select *from student

