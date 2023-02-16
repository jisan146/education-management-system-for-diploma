create table class(
Serial_No int IDENTITY(1,1)not null,
bilding char(10),
floor char(5),
room char(5),
room_type char(10),
sit char(6),
primary key(room)
)

select *from class
