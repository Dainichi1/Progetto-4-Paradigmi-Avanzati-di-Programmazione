CREATE TABLE [dbo].[Risorse](
	[IdRisorsa] [int] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[IdRisorsaTipologia] [int] NOT NULL,
 CONSTRAINT [PK_Risorse] PRIMARY KEY CLUSTERED 
(
	[IdRisorsa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RisorseTipologia]    Script Date: 25/02/2024 10:30:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RisorseTipologia](
	[IdRisorsaTipologia] [int] NOT NULL,
	[NomeTipologia] [varchar](100) NOT NULL,
 CONSTRAINT [PK_RisorseTipologia] PRIMARY KEY CLUSTERED 
(
	[IdRisorsaTipologia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utenti]    Script Date: 25/02/2024 10:30:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti](
	[IdUtente] [int] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Cognome] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Utenti] PRIMARY KEY CLUSTERED 
(
	[IdUtente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Risorse]  WITH CHECK ADD  CONSTRAINT [FK_Risorse_RisorseTipologia] FOREIGN KEY([IdRisorsaTipologia])
REFERENCES [dbo].[RisorseTipologia] ([IdRisorsaTipologia])
GO
ALTER TABLE [dbo].[Risorse] CHECK CONSTRAINT [FK_Risorse_RisorseTipologia]
GO
USE [master]
GO
ALTER DATABASE [Progetto] SET  READ_WRITE 
GO