SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLabSample_CheckAccession]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLabSample_CheckAccession]
GO

CREATE            PROCEDURE dbo.spLabSample_CheckAccession( 
	@idfMaterial AS bigint--,
	--@LANGID NVARCHAR(50)
)
AS

SELECT top 1 * from tlbAccessionIN where idfMaterial = @idfMaterial
	
	if(@@ROWCOUNT > 0) select 'true'; 
	else select 'false';


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

