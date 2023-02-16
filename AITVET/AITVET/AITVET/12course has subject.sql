create table course_has
(Serial_No int IDENTITY(1,1)not null,
course_id char(6),

semester_no char(2),
book_id char(6),
foreign key(course_id) references course(course_id),
foreign key(book_id) references book(book_id),
foreign key(semester_no) references semester(semester_no),

)


select *from course_has


