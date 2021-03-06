USE master
GO

IF exists (select * from sysdatabases where name = 'HotelReservation')
	drop database HotelReservation
GO

CREATE DATABASE HotelReservation
GO

USE HotelReservation

CREATE TABLE Customer (
CustomerID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
FirstName VARCHAR (30) NOT NULL,
LastName VARCHAR (30) NOT NULL,
Phone VARCHAR (30) NOT NULL,
Email VARCHAR (30) NOT NULL
)

CREATE TABLE RoomType(
RoomTypeID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
RoomTypeName VARCHAR (MAX) NOT NULL,
RoomCapacity INT NOT NULL
)

CREATE TABLE Room(
RoomID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
RoomNumber   INT NOT NULL,
FloorNumber INT NOT NULL,
RoomTypeID INT FOREIGN KEY REFERENCES RoomType(RoomTypeID)
)



CREATE TABLE RoomRate(
RoomRateID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
RoomTypeID INT NOT NULL,
RoomRate DECIMAL NOT NULL,
CONSTRAINT FK_RoomRate_RoomType 
	FOREIGN KEY (RoomTypeID)
	REFERENCES RoomType(RoomTypeID)
)


CREATE TABLE Promotions(
PromotionID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
PromoRate DECIMAL NOT NULL,
PromotionCode VARCHAR (30) NOT NULL,
PromotionDescription VARCHAR (MAX) NOT NULL
)

CREATE TABLE Amenities(
AmenityID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
AmenityName VARCHAR (30) NOT NULL,
AmenityDescription VARCHAR (MAX) NOT NULL,
)

CREATE TABLE RoomAmenities(
RoomAmenitiesID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
RoomID INT FOREIGN KEY REFERENCES Room(RoomID),
AmenityID INT FOREIGN KEY REFERENCES Amenities (AmenityID)
)

CREATE TABLE AddOns(
AddOnID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
AddOnName VARCHAR (30) NOT NULL,
AddOnDescription VARCHAR (MAX) NOT NULL
)

CREATE TABLE AddOnRates(
 AddOnRateID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
 Rate DECIMAL NOT NULL,
 AddOnID INT NOT NULL,
 CONSTRAINT FK_AddOnRate_AddOn
	FOREIGN KEY (AddOnID)
	REFERENCES AddOns(AddOnID)
)

CREATE TABLE Reservation(
ReservationID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
CustomerID INT NOT NULL,
PromotionID INT NOT NULL,
CONSTRAINT FK_Reservation_Promotions
	FOREIGN KEY (PromotionID)
	REFERENCES Promotions(PromotionID),
CONSTRAINT FK_Reservation_CustomerID
	FOREIGN KEY(CustomerID)
	References Customer(CustomerID)
)

CREATE TABLE Billing(
BillID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
Taxes DECIMAL NOT NULL,
Total DECIMAL NOT NULL,
ReservationID INT NOT NULL,
CONSTRAINT FK_Billing_Reservation
	FOREIGN KEY (ReservationID)
	REFERENCES Reservation(ReservationID)
)

CREATE TABLE BillingDetails(
DetailsID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
BillingID INT FOREIGN KEY REFERENCES Billing(BillID) NOT NULL,
AddOnID INT FOREIGN KEY REFERENCES AddOns(AddOnID) NULL,
RoomRateID INT FOREIGN KEY REFERENCES RoomRate(RoomRateID) NOT NULL,
Total DECIMAL NOT NULL 
)

CREATE TABLE RoomReservation(
RoomReservationID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
RoomID INT FOREIGN KEY REFERENCES Room(RoomID) NOT NULL,
ReservationID INT FOREIGN KEY REFERENCES Reservation(ReservationID) NOT NULL,

)

CREATE TABLE Guest (
GuestID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
FirstName VARCHAR (30) NOT NULL,
LastName VARCHAR (30) NOT NULL,
GuestAge INT NOT NULL,
ReservationID INT FOREIGN KEY REFERENCES Reservation(ReservationID)
)


