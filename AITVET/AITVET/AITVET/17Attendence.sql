create table attendence
(
Serial_No int IDENTITY(1,1)not null,
student_id char(15),
book_id char(6),
class_type char(10),
teacher_id char(15),
start_time char(25),
end_time char(25),
class_date char(25),
status char(1),
foreign key(student_id) references student(student_id),
foreign key(book_id) references book(book_id),
foreign key(teacher_id) references teacher(teacher_id),)

select *from attendence

