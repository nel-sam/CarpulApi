SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AllRequestObjects] as
SELECT TOP (1000) 
      Users.FirstName
      ,Users.LastName
      ,UserTypes.[Type]
      ,[Message]
      ,CASE
              WHEN [Approval] = 0 THEN 'Pending'
              WHEN [Approval] = 1 THEN 'Approved'
              WHEN [Approval] = 2 THEN 'Rejected'
              WHEN [Approval] = 3 THEN 'Deleted'
        END AS [Status]
      ,requests.[CarpoolId]
      ,CONCAT(CarpoolOwner.FirstName, ' ', CarpoolOwner.LastName) as [Owner] 
  FROM [dbo].[Requests]
  INNER JOIN Users on Users.id = Requests.UserId
  INNER JOIN UserTypes on Users.UserTypeId = UserTypes.Id
  INNER JOIN (
                SELECT FirstName, LastName, CarpoolId FROM Users
                INNER JOIN UserTypes on UserTypes.Id = Users.UserTypeId
                Where UserTypes.[Type] = 'Carpool Owner'
                ) As CarpoolOwner on CarpoolOwner.CarpoolId = Requests.CarpoolId
  --Where Users.FirstName = 'Gendry'
GO
