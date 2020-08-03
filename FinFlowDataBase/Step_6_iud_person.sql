USE [Finflow]
GO
/****** Object:  StoredProcedure [dbo].[iud_person]    Script Date: 03.08.2020 13:49:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER procedure [dbo].[iud_person]
(
	@iud		int			= 0,
	@person_id	int			output,
	@Name		varchar(50) = null,
	@Surname	varchar(50) = null,
	@DateOfBirth date		= null,

	@code		int			 output,
	@str_result varchar(255) output
)
AS
BEGIN
/****************************************************
*	Описание : iud_person (iud - insert,update, delete) 
*
*	Парметры :	@iud		- действие
*				@person_id	- id person
*				@Name		- имя
*				@Surname	- фамилия
*				@DateOfBirth- дата рождения
*
******************************************************/
	IF @iud = 1
	BEGIN
		INSERT INTO person([Name], Surname, DateOfBirth )		
		VALUES( @Name, @Surname, @DateOfBirth )

		IF @@error <> 0 OR @@ROWCOUNT <> 1
		BEGIN
			SELECT @code = -1, @str_result = 'Ошибка вставки'
		END
		ELSE
		BEGIN
			SELECT @person_id = @@identity
		END

	END
	ELSE IF @iud = 2
	BEGIN
		UPDATE	person
		SET		Name		= @name,
				Surname		= @surname,
				DateOfBirth = @DateOfBirth
		WHERE	person_id	= @person_id

		IF @@error <> 0
		BEGIN
			SELECT @code = -1, @str_result = 'Ошибка обновления'
		END
		ELSE
		BEGIN
			SELECT @code = 0, @str_result = ''
		END
	END
	ELSE IF @iud = 3
	BEGIN
		--				*** иногда лучше проставить статус "удален"
		--update	person
		--set		deleted = 1
		--where		person = @person

		DELETE FROM person 
		WHERE person_id = @person_id

		IF @@error <> 0
		BEGIN
			SELECT @code = -1, @str_result = 'Ошибка удаления'
		END
		ELSE
		BEGIN
			SELECT @code = 0, @str_result = ''
		END
	END
END

