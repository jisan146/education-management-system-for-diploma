create table teach
(
Serial_No int IDENTITY(1,1)not null,
teacher_id char(15),
semester_no char(2),
course_id char(6),
book_id char(6),

foreign key (teacher_id) references teacher(teacher_id),
foreign key (semester_no) references semester(semester_no),
foreign key(course_id) references course(course_id),
foreign key(book_id) references book(book_id))

select *from teach
