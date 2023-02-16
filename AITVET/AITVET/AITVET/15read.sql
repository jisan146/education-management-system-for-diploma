create table reads
(
Serial_No int IDENTITY(1,1)not null,
student_id char(15),
semester_no char(2),
course_id char(6),
student_type char(15),
admission_date char(25),
foreign key(student_id)references student(student_id),
foreign key(semester_no)references semester(semester_no),
foreign key(course_id)references course(course_id)
)

select *from reads

