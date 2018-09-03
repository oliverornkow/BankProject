use master
go

if exists (select * from sys.Databases where name = 'BGBank')
begin
drop database BGBank
end
go
 
create database BGBank
go 

use BGBank
go



create table Adresse(
ID int identity(1,1) primary key,
Adresse nvarchar(255),
Etage nvarchar(5),
PostNr smallint,
[By] nvarchar(255),
);
go

create table Person (
Fornavn nvarchar(50),
Efternavn nvarchar(50),
oprettelsesdato date,
CPR int,
primary key(CPR),
ADRESSE int foreign key references Adresse(ID)
);
go

create table Konti (
KontoNr int identity (1,1) primary key,
Rente float,
Saldo float,
Oprettelsesdato date,
KundeID int foreign key references Person(CPR)
);




Insert into Adresse (Adresse, Etage, PostNr, [By])
Values ('Mågevej 22', '2th', '2400', 'København');

Insert into Person (Oprettelsesdato, Fornavn, Efternavn, Adresse, CPR)
Values(Getdate(), 'Oliver', 'Ørnkow', 1, 1111);

Insert into Konti (Oprettelsesdato, Rente, Saldo, KundeID)
Values(GETDATE(), 2.5, 10000.5, 1111);

Select Fornavn, Efternavn, CPR, Oprettelsesdato, Adresse.Adresse, Adresse.Etage, Adresse.PostNr, [By]
from Person
inner join Adresse on Person.Adresse = Adresse.ID

--Select * from Adresse

--Select * from Person
--FULL OUTER JOIN Adresse on Person.ADRESSE = Adresse.ID; 

--Select * from Konti
