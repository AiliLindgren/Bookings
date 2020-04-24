create table AiliReservation
(
ID int primary key identity not null,
NumberOfPeople int not null,
StartTime datetime2 not null,
EndTime datetime2 not null,
Contact nvarchar(64) not null
)

