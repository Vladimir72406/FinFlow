USE [Finflow]
GO
/****** Object:  StoredProcedure [dbo].[iud_remittance]    Script Date: 03.08.2020 13:49:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[iud_remittance]
(
	@iud			int = NULL,
	@Remittance_Id	uniqueidentifier OUTPUT,
	@Code			varchar(50) = null,
	@c_status_id	int = null,
	@Sender_id		int = null,
	@Receiver_id	int = NULL,

	@code_result	int output,
	@error			varchar(255) output
)
AS
BEGIN
	IF ISNULL(@iud,0) = 1
	BEGIN

		SELECT @Remittance_Id = newid()
		
		INSERT INTO Remittance (Remittance_Id, Code, c_status_id, Sender_id, Receiver_id)
		VALUES(@Remittance_Id, @Code, @c_status_id, @Sender_id, @Receiver_id)

		IF @@error <> 0 OR @@rowcount <> 1
		BEGIN
			SET @code_result = -1
			SET @error = 'Ошибка вставки в Remittance'
			goto err
		END


		SET @code_result = 0
		SET @error = ''
		goto err


	END

err:

END

	

	