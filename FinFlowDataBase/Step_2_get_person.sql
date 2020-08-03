USE [Finflow]
GO
/****** Object:  StoredProcedure [dbo].[get_person]    Script Date: 03.08.2020 13:49:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER procedure [dbo].[get_person]
(
	@person_id int = null	
)
AS 
BEGIN
	
	SELECT
			person_id,
			Name,
			Surname,
			DateOfBirth
	FROM	person
	WHERE	person_id = @person_id
		

END