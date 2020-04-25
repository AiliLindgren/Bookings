drop table Reservation

create table Reservation
(
ID int primary key identity not null,
NumberOfPeople int null,
StartTime datetime2 null,
EndTime datetime2 null,
Contact nvarchar(64) null
)

select* from Reservation