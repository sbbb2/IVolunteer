USE [iVolunteer]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 10/09/2014 20:56:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [varchar](20) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[DisplayName] [varchar](10) NULL,
	[IsGoogle] [bit] NULL,
	[Sex] [char](1) NOT NULL,
	[DOB] [varchar](10) NOT NULL,
	[Address1] [varchar](50) NULL,
	[Address2] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[ZipCode] [int] NULL,
	[Emailid] [varchar](50) NULL,
	[phone] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserLog]    Script Date: 10/09/2014 20:56:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserLog](
	[UserId] [varchar](20) NOT NULL,
	[IsGoogle] [bit] NULL,
	[RequestId] [int] NULL,
	[isVolunteer] [int] NULL,
	[Credibility] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Request]    Script Date: 10/09/2014 20:56:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Request](
	[RequestID] [int] NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[DateTime] [varchar](20) NOT NULL,
	[Location] [varchar](100) NOT NULL,
	[RequesterId] [varchar](20) NOT NULL,
	[VolunteerId] [varchar](20) NULL,
	[Status] [varchar](10) NOT NULL,
	[RespondedDateTime] [varchar](20) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login]    Script Date: 10/09/2014 20:56:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[UserId] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AuthenticateUser]    Script Date: 10/09/2014 20:56:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*Procedure to authenticate a User
Jagadish_T
Oct 9, 2014
*/


CREATE proc [dbo].[AuthenticateUser](
@Userid varchar(20),
@password varchar(20)
)
as
begin

	if exists (select [UserId] from dbo.[Login] where UserId = @Userid)
	begin
		if exists (select [Password] from dbo.[Login] where UserId = @Userid and [Password] = @password)
		begin
			select 'OK'
		end
		else
		begin	
			select 'Invalid Password'
		end
		
	end
	else
	begin
		select 'Invalid Username'
	end
end

--exec AuthenticateUser 'Jagadish','123'
--select COUNT(0) from dbo.[Login] where UserId = 'Jagadish'
GO
