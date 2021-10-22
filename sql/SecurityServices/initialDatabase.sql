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
---Access
GO
SET IDENTITY_INSERT [dbo].[Access] ON 
GO
INSERT [dbo].[Access] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (1, N'AccessController', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Access] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (2, N'ActionController', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Access] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (3, N'ApplicationController', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Access] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (4, N'AuthenticationController', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Access] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (5, N'AuthorizationController', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Access] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (6, N'RoleController', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Access] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (7, N'UserController', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[Access] OFF
---Applications
GO
SET IDENTITY_INSERT [dbo].[Applications] ON 
GO
INSERT [dbo].[Applications] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (1, N'Customer', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Applications] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (2, N'Empoyee', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Applications] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (3, N'Miles', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Applications] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (4, N'Payment', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Applications] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (5, N'Security', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Applications] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (6, N'Trip', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Applications] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (7, N'Notification', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Applications] ([Id], [Name], [CreatedDate], [Active], [UpdateDate]) VALUES (8, N'Report', CAST(N'2021-10-13T23:49:02.1833333' AS DateTime2), 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[Applications] OFF
--Role
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([Id], [Name], [BusinessName], [CreatedDate], [Active], [UpdateDate]) VALUES (1, N'Admin', N'Admin', GETDATE(), 1, NULL);
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
---Users
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Email], [Cpf], [Password], [CreatedDate], [Active], [UpdateDate], [RoleId]) VALUES (1, N'admin@discoverairline.com', N'112.059.236-40', N'U3RyaW5nMTIz', CAST(N'2021-10-13T23:46:15.6511700' AS DateTime2), 1, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO

--Authorizations
INSERT INTO Authorizations (RoleId, AccessId, ApplicationId, Active, CreatedDate)
SELECT R.Id, Ac.Id, Ap.Id, R.Active, GETDATE()  FROM Roles R, Access Ac, Applications Ap

--AuthorizationsActions
INSERT INTO ActionAuthorization(ActionsId, AuthorizationsId)
SELECT Ac.Id, A.Id FROM Authorizations A, Actions Ac

-- COMMIT TRAN INIT1
-- ROLLBACK