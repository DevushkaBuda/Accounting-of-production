Create database [CMKUchet]
Drop database [CMKUchet]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AuthHistory]
(
	[Id]                 [INTEGER]IDENTITY(1,1) NOT NULL ,
	[UserId]             [INTEGER]NOT NULL ,
	[DateTime]           [DATE] NOT NULL ,
	[Status]             [bit] NOT NULL 
CONSTRAINT [PK_AuthHistory] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Client]
(
	[id]             [INTEGER] NOT NULL ,
	[Fullname]                 [nvarchar](max) NOT NULL,
	[adress]               [nvarchar](max) NOT NULL,

CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [FinishedProd]
(
	[idProcess]            [INTEGER] NOT NULL ,
	[idNumecl]               [INTEGER] NOT NULL,
	[name]           [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_FinishedProd] PRIMARY KEY CLUSTERED 
(
	[idProcess] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Material]
(
	[id]           [INTEGER] NOT NULL ,
	[name]                 [nvarchar](max) NOT NULL,
	
 CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Nomenclature]
(
	[id]                  [INTEGER] NOT NULL ,
	[name]                 [nvarchar](max) NOT NULL,
	[product_type]         [nvarchar](max) NOT NULL,
	[Process_type]      [nvarchar](max) NOT NULL, 
 CONSTRAINT [PK_Nomenclature] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Order]
(
	[id]                   [INTEGER]IDENTITY(1,1) NOT NULL ,
	[date_order]           [DATE] NOT NULL ,
	[cent]                 [decimal](18, 2) NOT NULL,
	[name]                 [nvarchar](max) NOT NULL,
	[idClient]             [INTEGER] NOT NULL ,
	[idNomencl]            [INTEGER] NOT NULL ,
	[idStatus]             [INTEGER] NOT NULL 
CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO




SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PriceList]
(
	[id]              [INTEGER] IDENTITY(1,1) NOT NULL ,
	[ed_izmer]        [nvarchar](max) NOT NULL,
	[price]           [INTEGER] NOT NULL ,
	[idNomencl]       [INTEGER] NOT NULL 
CONSTRAINT [PK_PriceList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Process]
(
    [id]            [INTEGER]IDENTITY(1,1) NOT NULL ,	
    [date_creation]        [DATE] NOT NULL ,
	[time_creation]        [time] NOT NULL ,
	[date_closing]         [DATE] NOT NULL ,
	[Process_time]      [INTEGER] NOT NULL ,
	[idOrder]              [INTEGER] NOT NULL ,
	[idShop]               [INTEGER] NOT NULL 
CONSTRAINT [PK_Process] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
GO
CREATE TABLE [User]
(
	[id]             [INTEGER]IDENTITY(1,1) NOT NULL ,
	[name]                 [nvarchar](max) NOT NULL,
	[role_id]              [INTEGER] NOT NULL ,
	[login]                [nvarchar](max) NOT NULL,
	[password]             [nvarchar](max) NOT NULL,
	

CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Role]
(
	[id]                  [INTEGER] NOT NULL ,
	[name]                [nvarchar](max) NOT NULL,
	
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Shop]
(
	[id]                   [INTEGER]  NOT NULL ,
	[name]                 [nvarchar](max) NOT NULL,
	[idMaterial]           [INTEGER] NOT NULL 
CONSTRAINT [PK_Shop] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Status]
(
	[id]                 [INTEGER] NOT NULL ,
	[name]               [nvarchar](max) NOT NULL,
CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Employee]
(
	[id]               [INTEGER] NOT NULL ,
	[Fullname]                 [nvarchar](max) NOT NULL,
	
	
	
CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



ALTER TABLE [Shop]  WITH CHECK ADD  CONSTRAINT [FK_Shop_Material] FOREIGN KEY([idMaterial])
REFERENCES [Material] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [Shop] CHECK CONSTRAINT [FK_Shop_Material]
GO


ALTER TABLE [Process]  WITH CHECK ADD  CONSTRAINT [FK_Process_Shop] FOREIGN KEY([idShop])
REFERENCES [Shop] ([id])
GO
ALTER TABLE [Process] CHECK CONSTRAINT [FK_Process_Shop]
GO

ALTER TABLE [FinishedProd]  WITH CHECK ADD  CONSTRAINT [FK_FinishedProd_Process] FOREIGN KEY([idProcess])
REFERENCES [Process] ([id])
GO
ALTER TABLE [FinishedProd] CHECK CONSTRAINT [FK_FinishedProd_Process]
GO


ALTER TABLE [Process]  WITH CHECK ADD  CONSTRAINT [FK_Process_Order] FOREIGN KEY([idOrder])
REFERENCES [Order] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [Process] CHECK CONSTRAINT [FK_Process_Order]
GO

ALTER TABLE [Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Nomenclature] FOREIGN KEY([idNomencl])
REFERENCES [Nomenclature] ([id])
GO
ALTER TABLE [Order] CHECK CONSTRAINT [FK_Order_Nomenclature]
GO



ALTER TABLE [PriceList]  WITH CHECK ADD  CONSTRAINT [FK_PriceList_Nomenclature] FOREIGN KEY([idNomencl])
REFERENCES [Nomenclature] ([id])
GO
ALTER TABLE [PriceList] CHECK CONSTRAINT [FK_PriceList_Nomenclature]
GO

ALTER TABLE [Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Client] FOREIGN KEY([idClient])
REFERENCES [Client] ([id])
GO
ALTER TABLE [Order] CHECK CONSTRAINT [FK_Order_Client]
GO

ALTER TABLE [Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Status] FOREIGN KEY([idStatus])
REFERENCES [Status] ([id])
GO
ALTER TABLE [Order] CHECK CONSTRAINT [FK_Order_Status]
GO


ALTER TABLE [Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_User] FOREIGN KEY([id])
REFERENCES [User] ([id])
GO
ALTER TABLE [Client] CHECK CONSTRAINT [FK_Client_User]
GO

ALTER TABLE [Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_User] FOREIGN KEY([id])
REFERENCES [User] ([id])
GO
ALTER TABLE [Employee] CHECK CONSTRAINT [FK_Employee_User]
GO


ALTER TABLE [AuthHistory]  WITH CHECK ADD  CONSTRAINT [FK_AuthHistory_User] FOREIGN KEY([UserId])
REFERENCES [User] ([id])
GO
ALTER TABLE [AuthHistory] CHECK CONSTRAINT [FK_AuthHistory_User]
GO

ALTER TABLE [User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([role_id])
REFERENCES [Role] ([id])
GO
ALTER TABLE [User] CHECK CONSTRAINT [FK_User_Role]
GO


DBCC CHECKIDENT ('FinishedProd', RESEED, 0)