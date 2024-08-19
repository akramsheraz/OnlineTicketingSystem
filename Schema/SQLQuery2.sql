CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Email NVARCHAR(255) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),  
    CreatedByUserId int references users,
    InsertionTimestamp DATETIME NOT NULL DEFAULT GETDATE() 
);

CREATE TABLE userProfile (
    UserId INT PRIMARY KEY,
    address VARCHAR(255) ,
    contactnumber VARCHAR(255),    
    InsertionTimestamp DATETIME NOT NULL DEFAULT GETDATE() 
);


CREATE TABLE Events (
    EventId INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    Date DATETIME NOT NULL,
    Time TIME NOT NULL,
    VenueId int NOT NULL,
    Status varchar(16) NOT NULL,
	UserId int references users,
    InsertionTimestamp DATETIME NOT NULL DEFAULT GETDATE()   
);



CREATE TABLE Seats (
    SeatId INT PRIMARY KEY IDENTITY(20001,1),
    VenueId INT,
    SeatNumber VARCHAR(10),
	Enclosure VARCHAR(10),
	RowNumber VARCHAR(10),  		
	UserId int,
	InsertionTimestamp DATETIME NOT NULL DEFAULT GETDATE()   
);

CREATE TABLE Tickets (
    TicketId INT PRIMARY KEY IDENTITY(1,1),
    EventId INT NOT NULL,
    SeatId INT,
    UserId INT,
    IsAvailable BIT NOT NULL DEFAULT 1,
    Price DECIMAL(10, 2) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME,
    FOREIGN KEY (EventId) REFERENCES Events(EventId),
    FOREIGN KEY (SeatId) REFERENCES Seats(SeatId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);


create table TicketBooking
(	
	BookingId INT PRIMARY KEY IDENTITY(1,1),
    EventId INT  ,
    TicketId INT,
    UserId INT,
	venueId int,
	Amount decimal,
	PaymentMethod varchar(16),
	PaymentStatus varchar(16),
	InsertionTimestamp DATETIME NOT NULL DEFAULT GETDATE() ,
	FOREIGN KEY (EventId) REFERENCES Events(EventId),
    FOREIGN KEY (TicketId) REFERENCES Tickets(TicketId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)	
);

