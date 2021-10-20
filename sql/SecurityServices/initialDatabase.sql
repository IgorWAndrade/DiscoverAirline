USE [DiscoverAirlineEnterpriseDB]

BEGIN TRAN INIT1

--- Actions
GO
SET IDENTITY_INSERT [dbo].[Actions] ON 
GO
INSERT [dbo].[Actions] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (1, N'Post', CAST(N'2021-10-13T23:51:56.7866667' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Actions] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (2, N'Get', CAST(N'2021-10-13T23:51:56.7866667' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Actions] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (3, N'Put', CAST(N'2021-10-13T23:51:56.7866667' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Actions] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (4, N'Patch', CAST(N'2021-10-13T23:51:56.7866667' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Actions] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (5, N'Delete', CAST(N'2021-10-13T23:51:56.7866667' AS DateTime2), 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[Actions] OFF
---Services
GO
SET IDENTITY_INSERT [dbo].[Services] ON 
GO
INSERT [dbo].[Services] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (1, N'Customer', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Services] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (2, N'Empoyee', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Services] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (3, N'Miles', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Services] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (4, N'Payment', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Services] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (5, N'Security', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Services] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (6, N'Trip', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Services] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (7, N'Notification', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Services] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (8, N'Report', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[Services] OFF
---Users
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Email], [Cpf], [Password], [CreatedDate], [Active], [UpdateDate]) VALUES (3, N'user@example.com', N'112.059.236-40', N'U3RyaW5nMTIz', CAST(N'2021-10-13T23:46:15.6511700' AS DateTime2), 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Profiles] ON 
GO
INSERT [dbo].[Profiles] ([Id], [UserId], [CreatedDate], [Active], [UpdateDate]) VALUES (1, 3, CAST(N'2021-10-13T23:46:26.3101468' AS DateTime2), 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[Profiles] OFF

-- COMMIT TRAN INIT1
-- ROLLBACK