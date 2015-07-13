USE [NewElasticBank]
GO
/****** Object:  Table [dbo].[RecommendedJob]    Script Date: 07/13/2015 14:00:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecommendedJob](
	[JobId] [uniqueidentifier] NOT NULL,
	[RecruiteeId] [uniqueidentifier] NOT NULL,
	[PredictedRankingValue] [numeric](18, 14) NOT NULL,
 CONSTRAINT [PK_RecommendedJob] PRIMARY KEY CLUSTERED 
(
	[JobId] ASC,
	[RecruiteeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 07/13/2015 14:00:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Task](
	[TaskId] [uniqueidentifier] NOT NULL,
	[JobId] [uniqueidentifier] NOT NULL,
	[RecruiteeId] [uniqueidentifier] NOT NULL,
	[TaskDescription] [varchar](100) NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[SelectTaskById]    Script Date: 07/13/2015 14:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectTaskById]
	-- Add the parameters for the stored procedure here
	(
		@TaskId varchar(50)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Task
	WHERE Task.TaskId = @TaskId
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllTask]    Script Date: 07/13/2015 14:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllTask]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Task
END
GO
