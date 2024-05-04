CREATE DATABASE TouristAgency;

--Databases MSSQL Server Regular Exam - 15 Oct 2023- Time needed 1h 55 min
--01. DLL

CREATE TABLE Countries(
Id INT IDENTITY PRIMARY KEY,
Name NVARCHAR(50) NOT NULL
);

CREATE TABLE Rooms(
Id INT IDENTITY PRIMARY KEY,
Type VARCHAR(40) NOT NULL,
Price DECIMAL(18, 2) NOT NULL,
BedCount INT NOT NULL CHECK (BedCount BETWEEN 0 AND 10)
);

CREATE TABLE Destinations(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
);

CREATE TABLE Hotels(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
DestinationId INT NOT NULL FOREIGN KEY REFERENCES Destinations(Id)
);

CREATE TABLE Tourists(
Id INT IDENTITY PRIMARY KEY,
Name NVARCHAR(80) NOT NULL,
PhoneNumber VARCHAR(20) NOT NULL,
Email VARCHAR(80),
CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
);

CREATE TABLE Bookings(
Id INT IDENTITY PRIMARY KEY,
ArrivalDate DATETIME2 NOT NULL,
DepartureDate DATETIME2 NOT NULL,
AdultsCount INT NOT NULL CHECK (AdultsCount BETWEEN 1 AND 10),
ChildrenCount INT NOT NULL CHECK (ChildrenCount BETWEEN 0 AND 9),
TouristId INT NOT NULL FOREIGN KEY REFERENCES Tourists(Id),
HotelId INT NOT NULL FOREIGN KEY REFERENCES Hotels(Id),
RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id)
);

CREATE TABLE HotelsRooms(
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	PRIMARY KEY(HotelId, RoomId)
);

--02. Insert
INSERT INTO Tourists([Name], PhoneNumber, Email, CountryId)
VALUES
	('John Rivers',	'653-551-1555',	'john.rivers@example.com',	6),
	('Adeline Aglaé',	'122-654-8726',	'adeline.aglae@example.com',	2),
	('Sergio Ramirez',	'233-465-2876',	's.ramirez@example.com',	3),
	('Johan Müller',	'322-876-9826',	'j.muller@example.com',	7),
	('Eden Smith',	'551-874-2234',	'eden.smith@example.com', 6);

INSERT INTO Bookings(ArrivalDate, DepartureDate, AdultsCount, ChildrenCount, TouristId, HotelId, RoomId)
VALUES
	('2024-03-01',	'2024-03-11',	1,	0,	21,	3,	5),
	('2023-12-28',	'2024-01-06',	2,	1,	22,	13,	3),
	('2023-11-15',	'2023-11-20',	1,	2,	23,	19,	7),
	('2023-12-05',	'2023-12-09',	4,	0,	24,	6,	4),
	('2024-05-01',	'2024-05-07',	6,	0,	25,	14,	6);

--03. Update
UPDATE Bookings
SET DepartureDate = DATEADD(DAY, 1, DepartureDate)
Where DATEPART(YEAR,ArrivalDate) = '2023' AND DATEPART(MONTH,ArrivalDate) = '12';

UPDATE Tourists
SET Email = NULL
WHERE NAME LIKE '%MA%';

--04. Delete
DELETE FROM Bookings
WHERE TouristId IN (SELECT Id FROM Tourists WHERE NAME LIKE '%Smith')

DELETE FROM Tourists
WHERE NAME LIKE '%Smith';

--drop table, import again values
USE master;
DROP DATABASE TouristAgency;
CREATE DATABASE TouristAgency;
USE TouristAgency;

--05. Bookings by Price of Room and Arrival Date
SELECT FORMAT(b.ArrivalDate, 'yyyy-MM-dd') AS ArrivalDate, AdultsCount, ChildrenCount FROM Bookings b
INNER JOIN Rooms r on r.Id = b.RoomId
ORDER BY r.Price DESC, ArrivalDate;

--06. Hotels by Count of Bookings
SELECT h.Id, h.Name FROM Hotels h
INNER JOIN HotelsRooms hr on hr.HotelId = h.Id
INNER JOIN Rooms r on r.Id = hr.RoomId AND r.Type = 'VIP Apartment'
ORDER BY (SELECT COUNT(b.Id) FROM Bookings b WHERE b.HotelId = h.Id) DESC;

--07. Tourists without Bookings
SELECT Id, Name, PhoneNumber FROM Tourists t
WHERE t.Id NOT IN (SELECT TouristId FROM Bookings b WHERE TouristId = t.Id )
ORDER BY NAME;

--08. First 10 Bookings
SELECT TOP(10) h.Name HotelName, d.Name DestinationName, c.Name CountryName FROM (SELECT b.Id, b.HotelId, b.ArrivalDate FROM Bookings b WHERE  b.ArrivalDate < '2023-12-31' and b.HotelId % 2 != 0) sel
LEFT JOIN Hotels h on h.Id = sel.HotelId
LEFT JOIN Destinations d on d.Id = h.DestinationId
LEFT JOIN Countries c on c.Id = d.CountryId
ORDER BY c.Name, sel.ArrivalDate;

--09. Tourists booked in Hotels
SELECT h.Name HotelName, r.Price RoomPrice FROM Tourists t
INNER JOIN Bookings b on  t.Name NOT LIKE '%EZ' AND b.TouristId = t.Id
INNER JOIN Hotels h on h.Id = b.HotelId
INNER JOIN Rooms r on r.Id = b.RoomId
ORDER BY r.Price DESC;

--10. Hotels Revenue
Select h.Name HotelName, HotelRevenue from (
select HotelId,SUM(DATEDIFF(day,ArrivalDate, DepartureDate) * r.Price) HotelRevenue from Bookings b
inner join Rooms r on r.Id = b.RoomId
group by HotelId
) res
inner join Hotels h on h.Id = res.HotelId
order by res.HotelRevenue DESC

--11. Rooms with Tourists
GO
CREATE FUNCTION udf_RoomsWithTourists(@name VARCHAR (40))
RETURNS INT
AS
BEGIN	
	RETURN(SELECT SUM(AdultsCount + ChildrenCount) FROM Bookings b
INNER JOIN Rooms r ON r.Id = b.RoomId AND r.Type = @name)
END
GO

--12. Search for Tourists from a Specific Country
GO
CREATE PROC usp_SearchByCountry
		(@country VARCHAR(50))
AS
BEGIN
	SELECT t.Name, t.PhoneNumber , t.Email, COUNT(b.Id) CountOfBookings FROM Bookings b
	INNER JOIN Tourists t ON t.Id = b.TouristId
	INNER JOIN Countries c on c.Id = t.CountryId AND c.Name = @country
	GROUP BY t.Name, t.PhoneNumber, t.Email
	ORDER BY t.Name, COUNT(b.Id) DESC
END

