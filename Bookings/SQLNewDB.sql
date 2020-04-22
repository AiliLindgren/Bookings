Create table SointuReservation
(ID int primary key identity not null,
NumberOfPeople int not null,
Date Date  not null,
Time time not null,
Contact nvarchar (64) not null,
)

--Insert Into SointuReservation
--Values(1, 1988-08-13, 15:15:00, 'email@email.com')