create table salary
(
Serial_No int IDENTITY(1,1)not null,
teacher_id char(15),
admin_id char(15),

pay char(10),
due char(10),
pay_date char(50),
foreign key(teacher_id)references teacher(teacher_id),
foreign key(admin_id)references administrator(admin_id),)



