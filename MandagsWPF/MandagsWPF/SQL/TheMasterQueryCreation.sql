use master
go

if exists(select * from sys.databases where name = 'BGBank')
begin
drop database BGBank
end
go

create database BGBank
go

use BGBank
go

--if exists(select * from sys.tables where name = 'Person')
--begin
--drop table Person
--end
--go

--if exists(select * from sys.tables where name = 'Adresse')
--begin
--drop table Adresse
--end
--go

--if exists(select * from sys.tables where name = 'Konto')
--begin
--drop table Konto
--end
--go
create table Adresse(
PostNr int primary key,
[By] nvarchar(255)

);
go

create table Person (
Fornavn nvarchar(50),
Efternavn nvarchar(50),
Oprettelsesdato date,
Adresse nvarchar(255),
Etage nvarchar(5),
CPR int,
primary key(CPR),
PostNr int foreign key references Adresse(PostNr)
);
go

create table Konto (
KontoNr int identity (1,1) primary key,
Rente float,
Saldo float,
Oprettelsesdato date,
KundeID int foreign key references Person(CPR)
);
go


--Insert into Adresse (Adresse, Etage, PostNr, [By])
--Values ('Mågevej 22', '2th', '2400', 'København');

--Insert into Person (Oprettelsesdato, Fornavn, Efternavn, Adresse, CPR)
--Values(Getdate(), 'Oliver', 'Ørnkow', 1, 1111);

--Insert into Konto (Oprettelsesdato, Rente, Saldo, KundeID)
--Values(GETDATE(), 2.5, 10000.5, 1111);

Select * from Person

Select * from Adresse

Select * from Konto