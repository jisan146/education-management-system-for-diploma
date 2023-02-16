create table department
(
Serial_No int IDENTITY(1,1)not null,
department_id char(6),
department_name char(20),
primary key(department_id),

)

select *from department