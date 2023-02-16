create table take_course
(
Serial_No int IDENTITY(1,1)not null,
student_id char(15),
course_id char(6),
primary key(student_id),
foreign key(student_id)references student(student_id),
foreign key(course_id)references course(course_id),


)


select *from take_course