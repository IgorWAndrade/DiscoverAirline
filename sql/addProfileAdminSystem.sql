
SELECT * FROM Roles

SELECT * FROM Services

SELECT * FROM RoleServices


--INSERT INTO [dbo].[Roles]
--           ([Name]
--           ,[CreatedDate])
--     VALUES
--           ('Admin'
--           ,GETDATE())
--GO

--INSERT INTO RoleServices
--(RoleId, ServiceId, CreatedDate)
--VALUES
--(1,1,GETDATE()),
--(1,2,GETDATE()),
--(1,3,GETDATE()),
--(1,4,GETDATE()),
--(1,5,GETDATE()),
--(1,6,GETDATE()),
--(1,7,GETDATE()),
--(1,8,GETDATE())

SELECT * FROM Services

SELECT * FROM Controllers

SELECT * FROM ServiceControllers

--INSERT INTO Controllers
--(Name, CreatedDate)
--VALUES
--('AuthorizationController', GETDATE())

--INSERT INTO ServiceControllers
--(ServiceId,ControllerId,CreatedDate)
--VALUES
--(5,1,GETDATE())

SELECT * FROM Controllers

SELECT * FROM Actions

SELECT * FROM ControllerActions

--INSERT INTO ControllerActions
--(ControllerId,ActionId,CreatedDate)
--VALUES
--(1,2,GETDATE())

SELECT * FROM Roles

SELECT * FROM Profiles

SELECT * FROM ProfileRoles

--INSERT INTO ProfileRoles
--(ProfileId,RoleId,CreatedDate)
--VALUES
--(1,1,GETDATE())