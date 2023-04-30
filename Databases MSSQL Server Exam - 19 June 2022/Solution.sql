--Databases MSSQL Server Exam - 19 June 2022- Time needed 1h 15 min
--01. DLL
CREATE TABLE Owners(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
Address VARCHAR(50)
)

CREATE TABLE AnimalTypes(
Id INT IDENTITY PRIMARY KEY,
AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages(
Id INT IDENTITY PRIMARY KEY,
AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE Animals(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(30) NOT NULL,
BirthDate DATE NOT NULL,
OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages(
CageId INT NOT NULL FOREIGN KEY REFERENCES Cages(Id),
AnimalId INT NOT NULL FOREIGN KEY REFERENCES Animals(Id),
PRIMARY KEY (CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments(
Id INT IDENTITY PRIMARY KEY,
DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
Address VARCHAR(50),
AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
DepartmentId INT NOT NULL FOREIGN KEY REFERENCES VolunteersDepartments(Id)
)

--02. Insert
INSERT INTO Volunteers(Name, PhoneNumber, Address, AnimalId, DepartmentId) VALUES
('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
('Dimitur Stoev', '0877564223', NULL, 42, 4),
('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO Animals(Name, BirthDate, OwnerId, AnimalTypeId) VALUES
('Giraffe', '2018-09-21', 21, 1),
('Harpy Eagle', '2015-04-17', 15, 3),
('Hamadryas Baboon', '2017-11-02', NULL, 1),
('Tuatara', '2021-06-30', 2, 4)

--03. Update
UPDATE Animals
SET OwnerId = (Select Id From Owners where Name = 'Kaloqn Stoqnov')
Where OwnerId is null

--04. Delete
DELETE FROM Volunteers
WHERE DepartmentId = (Select Id from VolunteersDepartments where DepartmentName = 'Education program assistant' )

DELETE FROM VolunteersDepartments
WHERE DepartmentName = 'Education program assistant'

--05. Volunteers
SELECT Name, PhoneNumber, Address, AnimalId, DepartmentId FROM Volunteers
ORDER BY Name ASC, AnimalId ASC, DepartmentId ASC

--06. Animals data
SELECT Name, AnimalType, FORMAT (BirthDate, 'dd.MM.yyyy') BirthDate  FROM Animals a
LEFT OUTER JOIN AnimalTypes at on at.Id = a.AnimalTypeId
ORDER BY Name ASC

--07. Owners and Their Animals
 SELECT TOP(5) o.Name, COUNT(o.Id) CountOfAnimals FROM Animals a
INNER JOIN Owners O on o.Id = a.OwnerId
group by o.Name
ORDER BY COUNT(o.Id) DESC, O.Name

--08. Owners, Animals and Cages
SELECT CONCAT(o.Name, '-', a.Name) OwnersAnimals, o.PhoneNumber, ac.CageId FROM Owners o
INNER JOIN Animals a ON a.OwnerId = o.Id
INNER JOIN AnimalTypes at ON at.Id = a.AnimalTypeId
INNER JOIN AnimalsCages ac ON ac.AnimalId = a.Id
WHERE at.AnimalType = 'Mammals'
ORDER BY o.Name, a.Name DESC

--09. Volunteers in Sofia
SELECT v.Name,v.PhoneNumber,  TRIM(SUBSTRING(Address,CHARINDEX(',',Address,0)+1,LEN(Address))) Address FROM Volunteers v
INNER JOIN VolunteersDepartments vd ON vd.Id = v.DepartmentId and vd.DepartmentName = 'Education program assistant'
WHERE SUBSTRING(Address,0,CHARINDEX(',',Address,0)) LIKE '%Sofia%'
ORDER BY Name

--10. Animals for Adoption
SELECT Name, YEAR(BirthDate) BirthYear, AnimalType FROM Animals a 
INNER JOIN AnimalTypes at ON at.Id = a.AnimalTypeId
WHERE OwnerId IS NULL AND DATEDIFF ( year , BirthDate , '2022-01-01')   < 5 and at.AnimalType != 'Birds'
ORDER BY Name

--11. All Volunteers in a Department
GO
CREATE FUNCTION udf_GetVolunteersCountFromADepartment(@VolunteersDepartment VARCHAR (30))
RETURNS INT
AS
BEGIN	
	RETURN(SELECT COUNT(v.Id) FROM VolunteersDepartments vd
	INNER JOIN Volunteers v ON v.DepartmentId = vd.Id
	WHERE DepartmentName = @VolunteersDepartment)
END
GO

--12. Animals with Owner or Not
GO
CREATE PROC usp_AnimalsWithOwnersOrNot
		(@AnimalName VARCHAR(30))
AS
BEGIN
	SELECT a.Name, ISNULL(o.Name, 'For adoption' ) FROM Animals a
	LEFT JOIN Owners o ON o.Id = a.OwnerId
	WHERE a.Name = @AnimalName
END
GO