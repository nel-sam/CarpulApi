SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[AllCarpoolObjects] as
SELECT Carpools.[Id]
      ,CONCAT(CarpoolOwner.FirstName, ' ', CarpoolOwner.LastName) as [Owner]
      ,CarpoolOwner.Email as 'Owner Email'
      ,Campuses.Name as Campus
      ,Addresses.StreetNumber
      ,Addresses.City
      ,Addresses.[State]
      ,Addresses.ZipCode
      ,Certs.ExpDate
  FROM [dbo].[Carpools]
  INNER JOIN Campuses on Campuses.Id = Carpools.CampusId
  INNER JOIN (
                SELECT CarpoolId, Max(ExpiryDate) as ExpDate 
                FROM Certificates 
                Group By CarpoolId
                ) as Certs on Certs.CarpoolId = Carpools.Id
  INNER JOIN (
                SELECT FirstName, LastName, CarpoolId, Email FROM Users
                INNER JOIN UserTypes on UserTypes.Id = Users.UserTypeId
                Where UserTypes.[Type] = 'Carpool Owner'
                ) As CarpoolOwner on CarpoolOwner.CarpoolId = Carpools.Id
INNER JOIN Addresses on Addresses.Id = Campuses.AddressId

GO
