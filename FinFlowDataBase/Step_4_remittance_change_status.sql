USE [Finflow]
GO
/****** Object:  StoredProcedure [dbo].[remittance_change_status]    Script Date: 03.08.2020 13:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[remittance_change_status]
(
	@Remittance_Id uniqueidentifier = NULL,
	@c_status_id_new int = NULL,
	@code int output,
	@error varchar(255) output
)
AS
BEGIN
	
	DECLARE @c_status_id_current int

	SET @code = 0
	SET @error = ''

	IF @Remittance_Id = NULL
	BEGIN
		SET @code = -1
		SET	@error = 'Не указан @Remittance_Id'
		goto err
	END

	IF ISNULL(@c_status_id_new,0) = 0
	BEGIN
		SET @code = -1
		SET	@error = 'Не указан @c_status_id_new'
		goto err
	END

	IF NOT EXISTS(
		SELECT	1
		FROM	Remittance
		WHERE	Remittance_id = @Remittance_id
	)
	BEGIN
		SET @code = -1
		SET	@error = 'Запись не найдена в Remittance'
		goto err
	END

	SELECT	@c_status_id_current = c_status_id
	FROM	Remittance
	WHERE	Remittance_Id = @Remittance_Id

	IF NOT EXISTS (
		SELECT	1
		FROM	l_linkStatus
		WHERE	c_status_id_current = @c_status_id_current AND
				c_status_id_new	= @c_status_id_new
	)
	BEGIN
		SET @code = -1
		SET	@error = 'Перевод статуса невозможен.'
		goto err
	END

	begin transaction tr_change_status
	
		insert into Remittance_state_log( Remittance_Id, c_status_id, datetime_modify)
		values( @Remittance_Id, @c_status_id_current, getdate())

		if @@error <> 0 or @@rowcount <> 1
		BEGIN
			SET @code = -1
			SET	@error = 'Перевод статуса невозможен.'
			rollback transaction tr_change_status
			goto err
		END

		IF @@IDENTITY > 0
		BEGIN

			UPDATE	Remittance
			SET		c_status_id = @c_status_id_new
			WHERE	Remittance_id = @Remittance_id

		END

	commit transaction tr_change_status

err:

END