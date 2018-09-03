--use master
--create database BGBank;
use BGBank;
--drop table Person;
create table Person (
Fornavn nvarchar(50),
Efternavn nvarchar(50),
Aarstal int,
Adresse nvarchar(50),
CPR int,
primary key(CPR)
);

Insert into Person values ('Jens', 'Eriksen', 1980, 'Telegrafvej 9', 2750);

Select * from Person