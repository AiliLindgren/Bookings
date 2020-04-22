drop table Reservation
Create table Reservation
(ID int primary key identity not null,
Date [Date] not null,
SartTime time not null,
EndTime time (5) not null,
NumberOfPeople int not null,
Contact nvarchar (64) not null,
)

--Datetime2
--EndTime field

Insert into Reservation
Values
('2020-04-22', '12:00', '14:00', 1, 'email2@email2.com')


Select *
From Reservation
