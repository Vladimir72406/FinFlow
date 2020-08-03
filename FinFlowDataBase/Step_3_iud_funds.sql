USE [Finflow]
GO
/****** Object:  StoredProcedure [dbo].[iud_funds]    Script Date: 03.08.2020 13:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[iud_funds]
(
	@iud			int				= 0,
	@Funds_id		int				output,
	@SendAmount		decimal(18,6)	= 0,
	@SendCurrency	int				= 0,
	@ReceiveAmount  decimal(18,6)	= 0,
	@ReceiveCurrency int			= 0,
	@Rate			decimal(18,6)	= 0,
	@Remittance_Id	uniqueidentifier= NULL,

	@code			int				output,
	@error			varchar(255)	output
)
AS
BEGIN
	
	IF @iud = 1--insert
	BEGIN
		IF @Remittance_Id = null
		BEGIN
			set @code = -1
			set @error = 'Не указан id @Remittance_Id'
			goto err
		END

		IF not exists(
				SELECT 1
				FROM	Remittance
				WHERE	Remittance_Id = @Remittance_Id
		)
		BEGIN
			set @code = -1
			set @error = 'Не существует запись в Remittance_Id'
			goto err
		END

		INSERT INTO Funds(SendAmount,SendCurrency,ReceiveAmount,ReceiveCurrency,Rate,Remittance_Id)
		VALUES(@SendAmount,@SendCurrency,@ReceiveAmount,@ReceiveCurrency,@Rate,@Remittance_Id)

		IF @@error <> 0 or @@rowcount <> 1
		BEGIN
			set @code = -1
			set @error = 'Ошибка создания Funds'
			goto err
		END
		
		set @Funds_id = @@identity
		set @code = 0
		set @error = ''		

	END

err:

END
