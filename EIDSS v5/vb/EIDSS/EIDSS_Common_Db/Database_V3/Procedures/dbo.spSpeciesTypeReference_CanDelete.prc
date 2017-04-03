SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSpeciesTypeReference_CanDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSpeciesTypeReference_CanDelete]
GO


--##SUMMARY Checks if Species Type Reference can be deleted.
--##SUMMARY This procedure is called from Species Type Reference Editor.


--##REMARKS Author: Vdovin
--##REMARKS Create date: 29.09.2010

--##RETURNS 0 if Species Type Reference can't be deleted 
--##RETURNS 1 if Species Type Reference can be deleted 

/*
Example of procedure call:

DECLARE @ID bigint
DECLARE @Result BIT
EXEC spSpeciesTypeReference_CanDelete 1, @Result OUTPUT

Print @Result

*/


CREATE   procedure dbo.spSpeciesTypeReference_CanDelete
	@ID as bigint --##PARAM @ID - farm ID
	,@Result AS BIT OUTPUT --##PARAM  @Result - 0 if case can't be deleted, 1 in other case
as

IF  EXISTS(SELECT * from dbo.tlbSpecies  where idfsSpeciesType = @ID )
	OR
	EXISTS(SELECT * from dbo.tlbAggrDiagnosticActionMTX  where idfsSpeciesType = @ID and intRowStatus = 0)
	OR
	EXISTS(SELECT * from dbo.tlbAggrProphylacticActionMTX  where idfsSpeciesType = @ID and intRowStatus = 0)
	OR
	EXISTS(SELECT * from dbo.tlbAggrVetCaseMTX  where idfsSpeciesType = @ID and intRowStatus = 0)
	OR
	EXISTS(SELECT * from dbo.trtSpeciesTypeToAnimalAge  where idfsSpeciesType = @ID and intRowStatus = 0)
	SET @Result = 0
ELSE
	SET @Result = 1

Return @Result

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
