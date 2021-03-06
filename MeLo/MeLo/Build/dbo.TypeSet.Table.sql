/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [MeLoDB]
GO
SET IDENTITY_INSERT [dbo].[TypeSet] ON 

INSERT [dbo].[TypeSet] ([Id], [Name]) VALUES (1, N'Audio')
INSERT [dbo].[TypeSet] ([Id], [Name]) VALUES (2, N'Video')
INSERT [dbo].[TypeSet] ([Id], [Name]) VALUES (3, N'Picture')
SET IDENTITY_INSERT [dbo].[TypeSet] OFF
