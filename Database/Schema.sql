CREATE DATABASE CustomerAccessControl;

USE CustomerAccessControl;

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(15),
    Address NVARCHAR(255),
    City NVARCHAR(50),
    HasAuthorized BIT,
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE OperationCenters (
    CenterID INT PRIMARY KEY IDENTITY(1,1),
    CenterName NVARCHAR(100),
    Address NVARCHAR(255),
    City NVARCHAR(50),
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE CustomerEntries (
    EntryID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
    CenterID INT FOREIGN KEY REFERENCES OperationCenters(CenterID),
    EntryDate DATETIME DEFAULT GETDATE(),
    HasAuthorized BIT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (CenterID) REFERENCES OperationCenters(CenterID)
);

