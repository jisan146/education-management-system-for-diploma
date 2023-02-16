create table payment 
(
Serial_No int IDENTITY(1,1)not null,
student_id char(15),
admin_id char(15),
course_id char(6),
due char(6),
pay char(6),
payment_date char(25),
foreign key(student_id)references student(student_id),
foreign key(admin_id)references administrator(admin_id),
foreign key(course_id)references course(course_id),

)

select *from payment
