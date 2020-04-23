--create database NewBookingsDB

create table AiliReservation
(
ID int primary key identity not null,
NumberOfPeople int not null,
[Date] date not null,
StartTime time not null,
EndTime time not null,
created_at DATETIME2 not null,
Contact nvarchar(64) not null
)
