USE [NewRecruiteeBank]
GO
/****** Object:  Table [dbo].[Ranking]    Script Date: 07/14/2015 09:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ranking](
	[RankingId] [nchar](5) NOT NULL,
	[RankingName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Ranking] PRIMARY KEY CLUSTERED 
(
	[RankingId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Income]    Script Date: 07/14/2015 09:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Income](
	[IncomeId] [nchar](5) NOT NULL,
	[IncomeDescription] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Income] PRIMARY KEY CLUSTERED 
(
	[IncomeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Education]    Script Date: 07/14/2015 09:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Education](
	[EducationId] [nchar](5) NOT NULL,
	[EducationDescription] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Education] PRIMARY KEY CLUSTERED 
(
	[EducationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 07/14/2015 09:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [nchar](5) NOT NULL,
	[CategoryName] [varchar](20) NOT NULL,
	[CategoryDescription] [varchar](100) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Age]    Script Date: 07/14/2015 09:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Age](
	[AgeId] [nchar](5) NOT NULL,
	[AgeDescription] [varchar](20) NOT NULL,
 CONSTRAINT [PK_AgeInterval] PRIMARY KEY CLUSTERED 
(
	[AgeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Skill]    Script Date: 07/14/2015 09:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Skill](
	[SkillId] [nchar](5) NOT NULL,
	[SkillName] [varchar](20) NOT NULL,
	[SkillDescription] [varchar](100) NULL,
 CONSTRAINT [PK_Skill] PRIMARY KEY CLUSTERED 
(
	[SkillId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[SelectRankingById]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectRankingById]
	-- Add the parameters for the stored procedure here
	(
		@RankingId varchar(10)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Ranking
	WHERE RankingId = @RankingId
END
GO
/****** Object:  StoredProcedure [dbo].[SelectIncomeById]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectIncomeById]
	(
		@IncomeId varchar(10)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Income
	WHERE Income.IncomeId = @IncomeId
END
GO
/****** Object:  StoredProcedure [dbo].[SelectEducationById]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectEducationById]
	(
		@EducationId varchar(10)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Education
	WHERE Education.EducationId = @EducationId
END
GO
/****** Object:  StoredProcedure [dbo].[SelectCategoryById]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectCategoryById]
	-- Add the parameters for the stored procedure here
	(
		@CategoryId varchar(10)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Category
	WHERE Category.CategoryId = @CategoryId
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllSkill]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllSkill]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Skill
END
GO
/****** Object:  StoredProcedure [dbo].[SelectSkillById]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectSkillById]
	-- Add the parameters for the stored procedure here
	(
		@SkillId varchar(10)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Skill
	WHERE SkillId = @SkillId
END
GO
/****** Object:  Table [dbo].[Recruitee]    Script Date: 07/14/2015 09:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recruitee](
	[RecruiteeId] [uniqueidentifier] NOT NULL,
	[RankingId] [nchar](5) NULL,
	[RankingValue] [numeric](18, 14) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[FirstName] [varchar](30) NULL,
	[LastName] [varchar](30) NULL,
	[Gender] [nchar](1) NULL,
	[AgeId] [nchar](5) NULL,
	[EducationId] [nchar](5) NULL,
	[IncomeId] [nchar](5) NULL,
 CONSTRAINT [PK_Recruitee] PRIMARY KEY CLUSTERED 
(
	[RecruiteeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[SelectAllRanking]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllRanking]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Ranking
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllIncome]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllIncome]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Income
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllEducation]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllEducation]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Education
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllCategory]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllCategory]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Category
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllAge]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllAge]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Age
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAgeById]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAgeById]
	(
		@AgeId varchar(10)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Age
	WHERE Age.AgeId = @AgeId
END
GO
/****** Object:  Table [dbo].[RecruiteeSkill]    Script Date: 07/14/2015 09:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecruiteeSkill](
	[RecruiteeId] [uniqueidentifier] NOT NULL,
	[SkillId] [nchar](5) NOT NULL,
 CONSTRAINT [PK_RecruiteeSkill] PRIMARY KEY CLUSTERED 
(
	[RecruiteeId] ASC,
	[SkillId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecruiteeCategory]    Script Date: 07/14/2015 09:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecruiteeCategory](
	[RecruiteeId] [uniqueidentifier] NOT NULL,
	[CategoryId] [nchar](5) NOT NULL,
 CONSTRAINT [PK_RecruiteeCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC,
	[RecruiteeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[UpdateRecruitee]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateRecruitee] 
	(
		@RecruiteeId varchar(50),
		@RankingId varchar(5),
		@RankingValue numeric(18,14)
	)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

    -- Insert statements for procedure here
	UPDATE Recruitee
	SET RankingValue = @RankingValue, RankingId = @RankingId
	
	WHERE RecruiteeId=@RecruiteeId
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllRecruitee]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllRecruitee]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Recruitee
END
GO
/****** Object:  StoredProcedure [dbo].[SelectRecruiteeById]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectRecruiteeById]
	-- Add the parameters for the stored procedure here
	(
		@RecruiteeId varchar(50)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Recruitee
	WHERE RecruiteeId = @RecruiteeId
END
GO
/****** Object:  StoredProcedure [dbo].[SelectRecruiteeByCategoryId]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectRecruiteeByCategoryId]
	-- Add the parameters for the stored procedure here
	(
		@CategoryId varchar(10)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Recruitee.*
	FROM Recruitee
	INNER JOIN RecruiteeCategory
	ON Recruitee.RecruiteeId = RecruiteeCategory.RecruiteeId
	WHERE RecruiteeCategory.CategoryId = @CategoryId
END
GO
/****** Object:  StoredProcedure [dbo].[SelectRecruiteeBySkillId]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectRecruiteeBySkillId]
	-- Add the parameters for the stored procedure here
	(
		@SkillId varchar(10)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Recruitee.*
	FROM Recruitee
	INNER JOIN RecruiteeSkill
	ON Recruitee.RecruiteeId = RecruiteeSkill.RecruiteeId
	WHERE RecruiteeSkill.SkillId = @SkillId
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllRecruiteeSkill]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllRecruiteeSkill]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM RecruiteeSkill
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllRecruiteeCategory]    Script Date: 07/14/2015 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllRecruiteeCategory]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM RecruiteeCategory
END
GO
/****** Object:  Default [DF_Recruitee_RankingValue]    Script Date: 07/14/2015 09:32:23 ******/
ALTER TABLE [dbo].[Recruitee] ADD  CONSTRAINT [DF_Recruitee_RankingValue]  DEFAULT ((0)) FOR [RankingValue]
GO
/****** Object:  ForeignKey [FK_Recruitee_Age]    Script Date: 07/14/2015 09:32:23 ******/
ALTER TABLE [dbo].[Recruitee]  WITH CHECK ADD  CONSTRAINT [FK_Recruitee_Age] FOREIGN KEY([AgeId])
REFERENCES [dbo].[Age] ([AgeId])
GO
ALTER TABLE [dbo].[Recruitee] CHECK CONSTRAINT [FK_Recruitee_Age]
GO
/****** Object:  ForeignKey [FK_Recruitee_Education]    Script Date: 07/14/2015 09:32:23 ******/
ALTER TABLE [dbo].[Recruitee]  WITH CHECK ADD  CONSTRAINT [FK_Recruitee_Education] FOREIGN KEY([EducationId])
REFERENCES [dbo].[Education] ([EducationId])
GO
ALTER TABLE [dbo].[Recruitee] CHECK CONSTRAINT [FK_Recruitee_Education]
GO
/****** Object:  ForeignKey [FK_Recruitee_Income]    Script Date: 07/14/2015 09:32:23 ******/
ALTER TABLE [dbo].[Recruitee]  WITH CHECK ADD  CONSTRAINT [FK_Recruitee_Income] FOREIGN KEY([IncomeId])
REFERENCES [dbo].[Income] ([IncomeId])
GO
ALTER TABLE [dbo].[Recruitee] CHECK CONSTRAINT [FK_Recruitee_Income]
GO
/****** Object:  ForeignKey [FK_Recruitee_Ranking]    Script Date: 07/14/2015 09:32:23 ******/
ALTER TABLE [dbo].[Recruitee]  WITH CHECK ADD  CONSTRAINT [FK_Recruitee_Ranking] FOREIGN KEY([RankingId])
REFERENCES [dbo].[Ranking] ([RankingId])
GO
ALTER TABLE [dbo].[Recruitee] CHECK CONSTRAINT [FK_Recruitee_Ranking]
GO
/****** Object:  ForeignKey [FK_RecruiteeCategory_Category]    Script Date: 07/14/2015 09:32:23 ******/
ALTER TABLE [dbo].[RecruiteeCategory]  WITH CHECK ADD  CONSTRAINT [FK_RecruiteeCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[RecruiteeCategory] CHECK CONSTRAINT [FK_RecruiteeCategory_Category]
GO
/****** Object:  ForeignKey [FK_RecruiteeCategory_Recruitee]    Script Date: 07/14/2015 09:32:23 ******/
ALTER TABLE [dbo].[RecruiteeCategory]  WITH CHECK ADD  CONSTRAINT [FK_RecruiteeCategory_Recruitee] FOREIGN KEY([RecruiteeId])
REFERENCES [dbo].[Recruitee] ([RecruiteeId])
GO
ALTER TABLE [dbo].[RecruiteeCategory] CHECK CONSTRAINT [FK_RecruiteeCategory_Recruitee]
GO
/****** Object:  ForeignKey [FK_RecruiteeSkill_Recruitee]    Script Date: 07/14/2015 09:32:23 ******/
ALTER TABLE [dbo].[RecruiteeSkill]  WITH CHECK ADD  CONSTRAINT [FK_RecruiteeSkill_Recruitee] FOREIGN KEY([RecruiteeId])
REFERENCES [dbo].[Recruitee] ([RecruiteeId])
GO
ALTER TABLE [dbo].[RecruiteeSkill] CHECK CONSTRAINT [FK_RecruiteeSkill_Recruitee]
GO
/****** Object:  ForeignKey [FK_RecruiteeSkill_Skill]    Script Date: 07/14/2015 09:32:23 ******/
ALTER TABLE [dbo].[RecruiteeSkill]  WITH CHECK ADD  CONSTRAINT [FK_RecruiteeSkill_Skill] FOREIGN KEY([SkillId])
REFERENCES [dbo].[Skill] ([SkillId])
GO
ALTER TABLE [dbo].[RecruiteeSkill] CHECK CONSTRAINT [FK_RecruiteeSkill_Skill]
GO
