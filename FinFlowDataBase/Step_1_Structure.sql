create database Finflow
go
use Finflow
go
/*Перевод (Remittance):
	1. Id (string(guid))
	2. Code (string)
	3. Status (string)
	4. Sender (Sender)
	5. Receiver (Receiver)
	6. Funds (Funds)*/

/*Отправитель/Получатель (Sender/Receiver)
	1. Id (int)
	2. Name (string)
	3. Surname (string)
	4. DateOfBirth (date)*/

/*Средства (Funds)
	1. SendAmount (decimal)
	2. SendCurrency (int ISO 4217)
	3. ReceiveAmount (decimal)
	4. ReceiveCurrency (int ISO 4217)
	5. Rate (decimal)*/

/*Перевод может иметь 5 статусов (=> - что можно сделать):
	1. Created (Создан). => Sent, Canceled
	2. Sent (Отправлен). => Refunded, Paid
	3. Refunded (Возвращен).
	4. Paid (Выплачен).
	5. Canceled (Отменен).*/
--drop table c_status
--drop table l_linkStatus
--drop table person
--drop table Remittance
--drop table Funds
--drop table Remittance_state_log

create table c_status
(
	c_status_id int primary key,
	[name] varchar(50) null
)
go
create table l_linkStatus
(
	l_linkStatus int primary key identity(1,1),
	c_status_id_current int not null references c_status(c_status_id),
	c_status_id_new int not null references c_status(c_status_id)
)
go
create table person
(
	person_id int primary key identity(1,1),
	[Name] varchar(50) NULL,
	Surname varchar(50) null,
	DateOfBirth date null
)
go
CREATE table Remittance
(
	Remittance_Id uniqueidentifier DEFAULT newid() primary key,
	Code varchar(50) null,
	c_status_id int not null references c_status(c_status_id),
	Sender_id int not null references person(person_id),
	Receiver_id int not null references person(person_id),
)
go
create table Funds
(
	Funds_id int primary key identity(1,1),
	SendAmount decimal not null,
	SendCurrency int not null,
	ReceiveAmount decimal not null,
	ReceiveCurrency int not null,
	Rate decimal(18,6) not null,
	Remittance_Id uniqueidentifier not null references Remittance(Remittance_id)
)
go

create table Remittance_state_log
(
	Remittance_state_log int primary key identity(1,1),
	Remittance_Id uniqueidentifier not null foreign key references Remittance(Remittance_Id),
	c_status_id int not null foreign key references c_status(c_status_id),
	datetime_modify datetime default getdate()
)
--select * from c_status
insert into c_status(c_status_id, [name])values(1,'Created')
insert into c_status(c_status_id, [name])values(2,'Sent')
insert into c_status(c_status_id, [name])values(3,'Refunded')
insert into c_status(c_status_id, [name])values(4,'Paid')
insert into c_status(c_status_id, [name])values(5,'Canceled')

--select * from l_linkStatus
insert into l_linkStatus (c_status_id_current, c_status_id_new) values (1,2)
insert into l_linkStatus (c_status_id_current, c_status_id_new) values (1,5)
insert into l_linkStatus (c_status_id_current, c_status_id_new) values (2,3)
insert into l_linkStatus (c_status_id_current, c_status_id_new) values (2,4)