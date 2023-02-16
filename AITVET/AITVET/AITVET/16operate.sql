create table operate(Serial_No int IDENTITY(1,1)not null,
room char(5),
teacher_id char(15),
book_id char(6),
course_id char(6),
semester_no char(2),
day char(15),
start_time char(20),
end_time char(20),

foreign key (room)references class(room),
foreign key(teacher_id)references teacher(teacher_id),

foreign key (course_id)references course(course_id),
foreign key (semester_no)references semester(semester_no),
foreign key (book_id)references book(book_id))


select *from operate


