create table result 
(
student_id char(15),
book_id char(6),
theory_continous char(3),
theory_final char(3),
practical_continous char(3),
practical_final char(3),
total char(3),
grade_point char(4),
grade char(2),
teacher_id char(15),
foreign key (student_id) references student(student_id),
foreign key (teacher_id) references teacher(teacher_id),
foreign key (book_id) references book(book_id)
)

select *from result