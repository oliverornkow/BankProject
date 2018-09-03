Use BGBank
go

if exists(select * from sys.procedures where name = 'Add_Data')
begin
drop procedure Add_Data
end
go

CREATE PROC Add_Data
@fornavn nvarchar(50),
@efternavn nvarchar(50),
@cpr int,
@adresse nvarchar(255),
--@etage nvarchar(255),
@postnr int,
@by nvarchar(255)
AS
	begin transaction
	if not exists(select postnr, [by] from Adresse where PostNr = @postnr )
	begin
	INSERT INTO Adresse(PostNr, [By])
	VALUES (@postnr, @by);
	end
	commit;
	
	begin transaction
	INSERT INTO Person(Fornavn, Efternavn, Oprettelsesdato, Adresse, CPR, PostNr)
	VALUES (@fornavn, @efternavn, GETDATE(), @adresse, @cpr, @postnr )
	commit;

	select * from Person
	Select * from Adresse