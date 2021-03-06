USE [PizzaShop]
GO
/****** Object:  Table [dbo].[Ingredient]    Script Date: 25.12.2019 18:21:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Measure] [int] NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pizza]    Script Date: 25.12.2019 18:21:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pizza](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Pizza] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipe]    Script Date: 25.12.2019 18:21:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Time] [datetime] NOT NULL,
	[Persons] [int] NOT NULL,
 CONSTRAINT [PK_Recipe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeItems]    Script Date: 25.12.2019 18:21:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IngredientId] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[Measure] [int] NOT NULL,
	[RecipeId] [int] NOT NULL,
 CONSTRAINT [PK_RecipeItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 25.12.2019 18:21:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PizzaId] [int] NOT NULL,
	[OrderedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Ingredient] ON 

INSERT [dbo].[Ingredient] ([Id], [Name], [Measure], [Amount]) VALUES (1, N'Tomatoes', 1, 10)
INSERT [dbo].[Ingredient] ([Id], [Name], [Measure], [Amount]) VALUES (2, N'Tinned tomatoes', 1, 10)
INSERT [dbo].[Ingredient] ([Id], [Name], [Measure], [Amount]) VALUES (3, N'Salt', 1, 1)
INSERT [dbo].[Ingredient] ([Id], [Name], [Measure], [Amount]) VALUES (4, N'Olive oil', 1, 1)
INSERT [dbo].[Ingredient] ([Id], [Name], [Measure], [Amount]) VALUES (5, N'Fresh basil', 1, 1)
SET IDENTITY_INSERT [dbo].[Ingredient] OFF
ALTER TABLE [dbo].[Pizza]  WITH CHECK ADD  CONSTRAINT [FK_Pizza_Recipe] FOREIGN KEY([Id])
REFERENCES [dbo].[Recipe] ([Id])
GO
ALTER TABLE [dbo].[Pizza] CHECK CONSTRAINT [FK_Pizza_Recipe]
GO
ALTER TABLE [dbo].[RecipeItems]  WITH CHECK ADD  CONSTRAINT [FK_RecipeItems_Ingredient] FOREIGN KEY([IngredientId])
REFERENCES [dbo].[Ingredient] ([Id])
GO
ALTER TABLE [dbo].[RecipeItems] CHECK CONSTRAINT [FK_RecipeItems_Ingredient]
GO
ALTER TABLE [dbo].[RecipeItems]  WITH CHECK ADD  CONSTRAINT [FK_RecipeItems_Recipe] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipe] ([Id])
GO
ALTER TABLE [dbo].[RecipeItems] CHECK CONSTRAINT [FK_RecipeItems_Recipe]
GO
ALTER TABLE [dbo].[Table]  WITH CHECK ADD  CONSTRAINT [FK_Table_Pizza] FOREIGN KEY([PizzaId])
REFERENCES [dbo].[Pizza] ([Id])
GO
ALTER TABLE [dbo].[Table] CHECK CONSTRAINT [FK_Table_Pizza]
GO
