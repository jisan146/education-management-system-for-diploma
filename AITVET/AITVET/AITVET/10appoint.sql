create table appoint
(
Serial_No int IDENTITY(1,1)not null,
department_id char(6),
teacher_id char(15),
appoint_date char(25),
salary numeric(6),
foreign key(department_id) references department(department_id),

foreign key(teacher_id) references teacher(teacher_id),
)


select *from appoint