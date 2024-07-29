USE [BollywoodHubDB]
GO

/****** Object:  Table [dbo].[User]    Script Date: 28/07/2024 07:58:33 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Movie]    Script Date: 28/07/2024 07:58:55 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movie](
	[id] [uniqueidentifier] NOT NULL,
	[genre_ids] [nvarchar](max) NULL,
	[title] [nvarchar](max) NULL,
	[overview] [nvarchar](max) NULL,
	[release_date] [nvarchar](max) NULL,
	[vote_average] [decimal](18, 2) NULL,
	[vote_count] [int] NULL,
	[poster_path] [nvarchar](max) NULL,
	[original_language] [nvarchar](max) NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Favorites]    Script Date: 28/07/2024 07:59:13 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Favorites](
	[Id] [uniqueidentifier] NOT NULL,
	[user_id] [int] NOT NULL,
	[movie_id] [int] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[Moviesid] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Favorites] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_Movie_Moviesid] FOREIGN KEY([Moviesid])
REFERENCES [dbo].[Movie] ([id])
GO

ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_Movie_Moviesid]
GO

ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_User_UserId]
GO

