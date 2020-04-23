Create table Reservation
(ID int primary key identity not null,
Date nvarchar (10) not null,
Time nvarchar (5) not null,
NumberOfPeople int not null,
Contact nvarchar (64) not null,
)

--Datetime2
--EndTime field

Insert into Reservation
Values
('22.04.2020', '12.00', 1, 'email@email.com')

Select *
From Reservation