create proc prcDivision 
	@a INT,
	@b INT
AS
BEGIN
	BEGIN TRY
		Set @a = 5;
		Set @b = @a / 0
		Print @b 
	END TRY
	BEGIN CATCH
		Print 'Error is :- '
		Print ERROR_MESSAGE()
	END CATCH
END
GO

Exec prcDivision 12,0
GO
