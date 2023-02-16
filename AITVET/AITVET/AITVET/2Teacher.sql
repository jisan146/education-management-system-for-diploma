
create table teacher
(
Serial_No int IDENTITY(1,1)not null,
teacher_id char(15),
teacher_name char (30),
picture char(5000),
gender char(6),
DOB char(15),
Phone char(11),
Email char(30),
Current_Address char(30),
Permanent_Address char(30),
primary key(teacher_id))

select *from teacher

