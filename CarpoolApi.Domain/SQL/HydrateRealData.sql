/***************Begin Entity Hydration***************/

Insert Into CampusTypes (
    [Type]
)
VALUES
    (
        'Headquarters'
    ),
    (
        'Satellite'
    )

INSERT Into UserTypes (
    [Type]
)
VALUES
    (
        'Application Administrator'
    ),
    (
        'Carpool Owner'
    ),
    (
        'Carpool Member'
    )

INSERT INTO IncentiveTypes (
    [Description]
)
VALUES
    (
        'Reserved Parking Space'
    ),
    (
        '$100 Gas Card'
    )

Insert INTO Cars (
    [Make]
    ,[Model]
    ,[Year]
    ,[Color]
    ,[LicensePlateNo]
)
VALUES
    (
        'Nissan'
        ,'Xterra'
        ,2007
        ,'Silver'
        ,'123-456'
    ),
    (
        'Honda'
        ,'Accord'
        ,2015
        ,'Black'
        ,'123-789'
    ),
    (
        'Chevy'
        ,'Volt'
        ,2019
        ,'Blue'
        ,'123-932'
    ),
    (
        'Toyota'
        ,'Prius'
        ,2018
        ,'Red'
        ,'123-333'
    )

Insert into Addresses (
    [StreetNumber]
    ,[City]
    ,[State]
    ,[ZipCode]
)
Values 
    (
        '2200 Mission College Blvd.'
        ,'Santa Clara'
        ,'California'
        ,'95054'
    ),
    (
        '3585 SW 198th Avenue'
        ,'Aloha'
        ,'Oregon'
        ,'97078'
    ),
    (
        '19500 NW Gibbs Drive'
        ,'Hillsboro'
        ,'Oregon'
        ,'97006'
    ),
    (
        '6200 NW Casper Pl, Building 12'
        ,'Hillsboro'
        ,'Oregon'
        ,'97124'
    ),
    (
        '2501 NE Century Blvd'
        ,'Hillsboro'
        ,'Oregon'
        ,'97124'
    ),
    (/*Bill Smiths home*/
        '13875 SW Bonnie Brae Ct'
        ,'Beaverton'
        ,'Oregon'
        ,'97005'
    ),
    (/*Catherine Johnsons home*/
        '13456 SW Hawks Beard St'
        ,'Tigard'
        ,'Oregon'
        ,'97223'
    ),
    (/*John Williamsons home*/
        '6547 NE Dogwood St'
        ,'Hillsboro'
        ,'Oregon'
        ,'97124'
    ),
    (/*Kate Ireland home*/
        '610 SW Dennis Ave'
        ,'Hillsboro'
        ,'Oregon'
        ,'97123'
    ),
    (/*Joel Weathersby*/
        '742 NE Caden Ave'
        ,'Hillsboro'
        ,'Oregon'
        ,'97124'
    ),
    (/*Jill Jacobs*/
        '9755 SW Arborcrest Way'
        ,'Portland'
        ,'Oregon'
        ,'97225'
    ),
    (/*Leonard Jones*/
        '2985 SW 121st Ave'
        ,'Beaverton'
        ,'Oregon'
        ,'97005'
    ),
    (/*Stacey Wilson*/
        '2140 SW Briggs Rd'
        ,'Beaverton'
        ,'Oregon'
        ,'97005'
    ),
    (/*Casey Stevenson*/
        '2983 SW Olaf Terrace'
        ,'Beaverton'
        ,'Oregon'
        ,'97006'
    ),
    (/*Adam Justice*/
        '21713 SW Parkin Ln'
        ,'Beaverton'
        ,'Oregon'
        ,'97006'
    ),
    (/*Jennifer Keller*/
        '14929 SW Rosario Ln'
        ,'Tigard'
        ,'Oregon'
        ,'97224'
    ),
    (/*Jessica Wesley*/
        '3303 Lake Grove Ave'
        ,'Lake Oswego'
        ,'Oregon'
        ,'97035'
    ),
    (/*Kyle Stevens*/
        '3715 Division Ct'
        ,'Lake Oswego'
        ,'Oregon'
        ,'97035'
    ),
    (/*Connor Kelly*/
        '2505 Glen Eagles Rd'
        ,'Lake Oswego'
        ,'Oregon'
        ,'97034'
    ),
    (/*Luke Preston*/
        '3833 SW Pasadena St'
        ,'Portland'
        ,'Oregon'
        ,'97219'
    ),
    (/*Nicole Nelson*/
        '18393 Shady Hollow Way'
        ,'West Linn'
        ,'Oregon'
        ,'97068'
    ),
    (/*Ryan Freeman*/
        '19710 Derby St'
        ,'West Linn'
        ,'Oregon'
        ,'97068'
    ),
    (/*Steve Gillen*/
        '18409 Old River Rd'
        ,'West Linn'
        ,'Oregon'
        ,'97068'
    ),
    (/*John Miller*/
        '572 SE 6th Ave'
        ,'Hillsboro'
        ,'Oregon'
        ,'97123'
    ),
    (/*Michelle Lewis*/
        '757 SE 8th Ave'
        ,'Hillsboro'
        ,'Oregon'
        ,'97123'
    )

Insert Into PhoneNumbers (
    [AreaCode]
    ,[Number]
    )
VALUES
    (
        '408'
        ,'7658080'
    ),
    (/*Bill Smiths*/
        '503'
        ,'4089631'
    ),
    (/*Bill Smiths*/
        '503'
        ,'5891345'
    ),
    (/*Catherine Johnson*/
        '503'
        ,'6689346'
    ),
    (/*John Williamson*/
        '503'
        ,'7893645'
    ),
    (/*Kate Ireland*/
        '503'
        ,'8889754'
    ),
    (
        /*Jill Jacobs*/
        '406'
        ,'1238790'
    ),
    (/*Joel Weathersby*/
        '971'
        ,'8239712'
    ),
    (/*Leonard Jones*/
        '971'
        ,'8819756'
    ),
    (/*Stacey Wilson*/
        '503'
        ,'6751409'
    ),
    (/*Casey Stevenson*/
        '971'
        ,'5551290'
    ),
    (/*Adam Justice*/
        '503'
        ,'7761293'
    ),
    (/*Jennifer Keller*/
        '541'
        ,'8801667'
    ),
    (/*Jessica Wesley*/
        '360'
        ,'9918854'
    ),
    (/*Kyle Stevens*/
        '707'
        ,'9926635'
    ),
    (/*Connor Kelly*/
        '503'
        ,'9983336'
    ),
    (/*Luke Preston*/
        '971'
        ,'9944783'
    ),
    (/*Nicole Nelson*/
        '503'
        ,'6675522'
    ),
    (/*Ryan Freeman*/
        '707'
        ,'8874453'
    ),
    (/*Steve Gillen*/
        '503'
        ,'9977712'
    ),
    (/*John Miller*/
        '503'
        ,'7745661'
    ),
    (/*Michelle Lewis*/
        '503'
        ,'8890012'
    )

INSERT INTO Organizations (
    [AddressId]
    ,[PhoneNumberId]
    ,[Name]
)
VALUES
    (
        (SELECT ID FROM Addresses WHERE StreetNumber = '2200 Mission College Blvd.')
        ,(SELECT ID FROM PhoneNumbers Where AreaCode = '408' AND Number = '7658080')
        ,'Intel'
    )

Insert Into Campuses (
    [Name]
    ,[AddressId]
)
VALUES
    (
        'Intel Global Headquarters'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '2200 Mission College Blvd.')
    ),
    (
        'Aloha'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '3585 SW 198th Avenue')
    ),
    (
        'Ambercreek'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '19500 NW Gibbs Drive')
    ),
    (
        'Casper'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '6200 NW Casper Pl, Building 12')
    ),
    (
        'Ronler Acres'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '2501 NE Century Blvd')
    )

INSERT INTO USERS (
    [FirstName]
    ,[LastName]
    ,[CarpoolId]
    ,[Email]
    ,[Password]
    ,[AddressId]
    ,[UserTypeId]
)
VALUES
    (
        'Bill'
        ,'Smith'
        ,NULL
        ,'bill.smith@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '13875 SW Bonnie Brae Ct')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Owner')
    ),
    (
        'Catherine'
        ,'Johnson'
        ,NULL
        ,'catherine.johnson@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '13456 SW Hawks Beard St')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Owner')
    ),
    (
        'John'
        ,'Williamson'
        ,NULL
        ,'john.williamson@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '6547 NE Dogwood St')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Owner')
    ),
    (
        'Kate'
        ,'Ireland'
        ,NULL
        ,'kate.ireland@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '610 SW Dennis Ave')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Owner')
    ),
    (
        'Jill'
        ,'Jacobs'
        ,NULL
        ,'jill.jacobs@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '9755 SW Arborcrest Way')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Member')
    ),
    (
        'Joel'
        ,'Weathersby'
        ,NULL
        ,'joel.Weathersby@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '742 NE Caden Ave')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Member')
    ),
    (
        'Leonard'
        ,'Jones'
        ,NULL
        ,'leonard.jones@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '2985 SW 121st Ave')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Member')
    ),
    (
        'Stacey'
        ,'Wilson'
        ,NULL
        ,'stacey.wilson@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '2140 SW Briggs Rd')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Member')
    ),
    (
        'Casey'
        ,'Stevenson'
        ,NULL
        ,'casey.stevenson@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '2983 SW Olaf Terrace')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Member')
    ),
    (/*Adam Justice*/
        'Adam'
        ,'Justice'
        ,NULL
        ,'adam.justice@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '21713 SW Parkin Ln')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Member')
    ),
    (/*Jennifer Keller*/
        'Jennifer'
        ,'Keller'
        ,NULL
        ,'jennifer.keller@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '14929 SW Rosario Ln')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Member')
    ),
    (/*Jessica Wesley*/
        'Jessica'
        ,'Wesley'
        ,NULL
        ,'jessica.wesley@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '3303 Lake Grove Ave')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Member')
    ),
    (/*Kyle Stevens*/
        'Kyle'
        ,'Stevens'
        ,NULL
        ,'kyle.stevens@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '3715 Division Ct')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Member')
    ),
    (/*Connor Kelly*/
        'Connor'
        ,'Kelly'
        ,NULL
        ,'connor.kelly@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '2505 Glen Eagles Rd')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Member')
    ),
    (/*Luke Preston*/
        'Luke'
        ,'Preston'
        ,NULL
        ,'luke.preston@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '3833 SW Pasadena St')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Member')
    ),
    (/*Nicole Nelson*/
        'Nicole'
        ,'Nelson'
        ,NULL
        ,'nicole.nelson@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '18393 Shady Hollow Way')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Member')
    ),
    (/*Ryan Freeman*/
        'Ryan'
        ,'Freeman'
        ,NULL
        ,'ryan.freeman@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '19710 Derby St')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Member')
    ),
    (/*Steve Gillen*/
        'Steve'
        ,'Gillen'
        ,NULL
        ,'steve.gillen@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '18409 Old River Rd')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Member')
    ),
    (/*John Miller*/
        'John'
        ,'Miller'
        ,NULL
        ,'john.miller@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '572 SE 6th Ave')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Member')
    ),
    (/*Michelle Lewis*/
        'Michelle'
        ,'Lewis'
        ,NULL
        ,'michelle.lewis@intel.com'
        ,'1'
        ,(SELECT ID FROM Addresses WHERE StreetNumber = '757 SE 8th Ave')
        ,(SELECT ID FROM UserTypes WHERE [Type] = 'Carpool Member')
    )
    
/****************End Entity Hydration****************/

/***************Begin Relationship Hydration***************/

Insert Into OrganizationCampuses (
    [OrganizationId]
    ,[CampusId]
)
VALUES 
    (
        (SELECT ID FROM Organizations WHERE [Name] = 'Intel')
        ,(SELECT ID FROM Campuses WHERE [Name] = 'Intel Global Headquarters')
    ),
    (
        (SELECT ID FROM Organizations WHERE [Name] = 'Intel')
        ,(SELECT ID FROM Campuses WHERE [Name] = 'Casper')
    ),
    (
        (SELECT ID FROM Organizations WHERE [Name] = 'Intel')
        ,(SELECT ID FROM Campuses WHERE [Name] = 'Aloha')
    ),
    (
        (SELECT ID FROM Organizations WHERE [Name] = 'Intel')
        ,(SELECT ID FROM Campuses WHERE [Name] = 'Ambercreek')
    ),
    (
        (SELECT ID FROM Organizations WHERE [Name] = 'Intel')
        ,(SELECT ID FROM Campuses WHERE [Name] = 'Ronler Acres')
    )

Insert Into CampusTypeCampuses (
    [CampusId]
    ,[CampusTypeId]
)
VALUES
    (
        (SElECT ID FROM Campuses WHERE [Name] = 'Aloha')
        ,(SElECT ID FROM CampusTypes WHERE [Type] = 'Satellite')
    ),
    (
        (SElECT ID FROM Campuses WHERE [Name] = 'Ambercreek')
        ,(SElECT ID FROM CampusTypes WHERE [Type] = 'Satellite')
    ),
    (
        (SElECT ID FROM Campuses WHERE [Name] = 'Intel Global Headquarters')
        ,(SElECT ID FROM CampusTypes WHERE [Type] = 'Headquarters')
    ),
    (
        (SElECT ID FROM Campuses WHERE [Name] = 'Casper')
        ,(SElECT ID FROM CampusTypes WHERE [Type] = 'Satellite')
    ),
    (
        (SElECT ID FROM Campuses WHERE [Name] = 'Ronler Acres')
        ,(SElECT ID FROM CampusTypes WHERE [Type] = 'Satellite')
    )

Insert Into Carpools (
    [CampusId]
    )
VALUES
    (
        (SELECT ID FROM Campuses WHERE [Name] = 'Casper')
    ),
    (
        (SELECT ID FROM Campuses WHERE [Name] = 'Aloha')
    ),
    (
        (SELECT ID FROM Campuses WHERE [Name] = 'Ambercreek')
    ),
    (
        (SELECT ID FROM Campuses WHERE [Name] = 'Aloha')
    )

INSERT INTO UserCars (
    [UserId]
    ,[CarId]
)
VALUES
    (
        (SELECT ID FROM Users WHERE Email = 'bill.smith@intel.com')
        ,(SELECT ID FROM Cars Where LicensePlateNo = '123-456')
    ),
    (
        (SELECT ID FROM Users WHERE Email = 'catherine.johnson@intel.com')
        ,(SELECT ID FROM Cars Where LicensePlateNo = '123-789')
    ),
    (
        (SELECT ID FROM Users WHERE Email = 'john.williamson@intel.com')
        ,(SELECT ID FROM Cars Where LicensePlateNo = '123-932')
    ),
    (
        (SELECT ID FROM Users WHERE Email = 'kate.ireland@intel.com')
        ,(SELECT ID FROM Cars Where LicensePlateNo = '123-333')
    )

Insert Into UserPhones (
    [PhoneNumberId]
    ,[UserId]
)
VALUES
    (
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '503' AND [Number] = '4089631' )
        ,(SELECT ID FROM Users WHERE Email = 'bill.smith@intel.com')
    ),
    (
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '503' AND [Number] = '5891345' )
        ,(SELECT ID FROM Users WHERE Email = 'bill.smith@intel.com')
    ),
    (
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '503' AND [Number] = '6689346' )
        ,(SELECT ID FROM Users WHERE Email = 'catherine.johnson@intel.com')
    ),
    (
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '503' AND [Number] = '7893645' )
        ,(SELECT ID FROM Users WHERE Email = 'john.williamson@intel.com')
    ),
    (
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '503' AND [Number] = '8889754' )
        ,(SELECT ID FROM Users WHERE Email = 'kate.ireland@intel.com')
    ),
    (
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '406' AND [Number] = '1238790' )
        ,(SELECT ID FROM Users WHERE Email = 'jill.jacobs@intel.com')
    ),
    (
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '971' AND [Number] = '8239712' )
        ,(SELECT ID FROM Users WHERE Email = 'joel.weathersby@intel.com')
    ),
    (
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '971' AND [Number] = '8819756' )
        ,(SELECT ID FROM Users WHERE Email = 'leonard.jones@intel.com')
    ),
    (
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '503' AND [Number] = '6751409' )
        ,(SELECT ID FROM Users WHERE Email = 'stacey.wilson@intel.com')
    ),
    (
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '971' AND [Number] = '5551290' )
        ,(SELECT ID FROM Users WHERE Email = 'casey.stevenson@intel.com')   
    ),
    (/*Adam Justice*/
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '503' AND [Number] = '7761293')
        ,(SELECT ID FROM Users WHERE Email = 'adam.justice@intel.com')  
    ),
    (/*Jennifer Keller*/
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '541' AND [Number] = '8801667')
        ,(SELECT ID FROM Users WHERE Email = 'jennifer.keller@intel.com')
    ),
    (/*Jessica Wesley*/
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '360' AND [Number] = '9918854')
        ,(SELECT ID FROM Users WHERE Email = 'jessica.wesley@intel.com')
    ),
    (/*Kyle Stevens*/
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '707' AND [Number] = '9926635')
        ,(SELECT ID FROM Users WHERE Email = 'kyle.stevens@intel.com')
    ),
    (/*Connor Kelly*/
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '503' AND [Number] = '9983336')
        ,(SELECT ID FROM Users WHERE Email = 'connor.kelly@intel.com')
    ),
    (/*Luke Preston*/
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '971' AND [Number] = '9944783')
        ,(SELECT ID FROM Users WHERE Email = 'luke.preston@intel.com')
    ),
    (/*Nicole Nelson*/
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '503' AND [Number] = '6675522')
        ,(SELECT ID FROM Users WHERE Email = 'nicole.nelson@intel.com')
    ),
    (/*Ryan Freeman*/
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '707' AND [Number] = '8874453')
        ,(SELECT ID FROM Users WHERE Email = 'ryan.freeman@intel.com')
    ),
    (/*Steve Gillen*/
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '503' AND [Number] = '9977712')
        ,(SELECT ID FROM Users WHERE Email = 'steve.gillen@intel.com')
    ),
    (/*John Miller*/
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '503' AND [Number] = '7745661')
        ,(SELECT ID FROM Users WHERE Email = 'john.miller@intel.com')
    ),
    (/*Michelle Lewis*/
        (SELECT ID FROM PhoneNumbers WHERE AreaCode = '503' AND [Number] = '8890012')
        ,(SELECT ID FROM Users WHERE Email = 'michelle.lewis@intel.com')
    )

INSERT INTO Certificates (
    [CreateDate]
    ,[ExpiryDate]
    ,[IncentiveTypeId]
    ,[CarpoolId]
)
VALUES
    (
        Cast('05/03/2019' as [datetime])
        ,Cast('11/03/2019' as [datetime])
        ,(SELECT ID FROM IncentiveTypes WHERE [Description] = 'Reserved Parking Space')
        ,1
    ),
    (
        Cast('12/02/2018' as [datetime])
        ,Cast('05/02/2019' as [datetime])
        ,(SELECT ID FROM IncentiveTypes WHERE [Description] = '$100 Gas Card')
        ,1
    ),
    (
        Cast('04/03/2019' as [datetime])
        ,Cast('10/03/2019' as [datetime])
        ,(SELECT ID FROM IncentiveTypes WHERE [Description] = 'Reserved Parking Space')
        ,2
    ),
    (
        Cast('04/03/2018' as [datetime])
        ,Cast('10/03/2018' as [datetime])
        ,(SELECT ID FROM IncentiveTypes WHERE [Description] = 'Reserved Parking Space')
        ,3
    ),
    (
        Cast('04/03/2019' as [datetime])
        ,Cast('10/03/2019' as [datetime])
        ,(SELECT ID FROM IncentiveTypes WHERE [Description] = '$100 Gas Card')
        ,4
    )

UPDATE Users 
SET CarpoolId = 1
WHERE Email = 'bill.smith@intel.com'

UPDATE Users 
SET CarpoolId = 2
WHERE Email = 'catherine.johnson@intel.com'

UPDATE Users 
SET CarpoolId = 3
WHERE Email = 'john.williamson@intel.com'

UPDATE Users 
SET CarpoolId = 4
WHERE Email = 'kate.ireland@intel.com'


/*
INSERT INTO Requests (
    [CarpoolId]
    ,[UserId]
    ,[Message]
    ,[Approval]
)
VALUES
    (   
        2
        ,(SELECT ID FROM Users WHERE Email = 'TheThreeEyedRaven@TheNorth.com')
        ,'Jon, Arya is making fun of me and wont let me join her carpool, can I join yours?'
        ,0
    ),
    (
        5
        ,(SELECT ID FROM Users WHERE Email = 'KingSlayer@TheSevenKingdoms.com')
        ,'Hey Arya, I knew your mom, can I join your carpool?'
        ,2
    ),
    (
        5
        ,(SELECT ID FROM Users WHERE Email = 'SwordMaker@TheSevenKingdoms.com')
        ,'Uh... Could I get a lift?'
        ,1
    ),
    (
        4
        ,(SELECT ID FROM Users WHERE Email = 'DoItForTheMoney@TheSevenKingdoms.com')
        ,'I am all for saving the planet, but we may want to go somewhere other than the red keep...'
        ,0
    )*/
/****************End Relationship Hydration****************/