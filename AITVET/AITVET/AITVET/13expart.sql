create table expart
(
Serial_No int IDENTITY(1,1)not null,
teacher_id char(15),
book_id char(6),
foreign key(teacher_id)references teacher(teacher_id),
foreign key(book_id)references book(book_id)

)

select *from expart
