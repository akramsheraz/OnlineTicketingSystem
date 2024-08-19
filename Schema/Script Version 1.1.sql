CREATE TABLE Events (
    EventId INT PRIMARY KEY IDENTITY(1001,1),
    Title VARCHAR(255) NOT NULL,
    Description VARCHAR(MAX),
	Category VARCHAR(255) ,
	Date DATETIME NOT NULL,
    Time TIME NOT NULL,
    VenueId int references Venue,
    Status varchar(16) NOT NULL,
	UserId int ,
    InsertionTimestamp DATETIME NOT NULL DEFAULT GETDATE()   
);


drop table Events

CREATE TABLE Seats (
    SeatId INT PRIMARY KEY IDENTITY(20001,1),
    VenueId INT,
    SeatNumber VARCHAR(32),
	Enclosure VARCHAR(32),
	RowNumber VARCHAR(32),  		
	UserId int,
	InsertionTimestamp DATETIME NOT NULL DEFAULT GETDATE()   
);


CREATE TABLE Tickets (
    TicketId INT PRIMARY KEY IDENTITY(300001,1),
    EventId INT NOT NULL,
    SeatId INT,    
    status varchar(16) default 'available', 
    Price DECIMAL(10, 2) NOT NULL,
    InsertionTimestamp DATETIME NOT NULL DEFAULT GETDATE()  
);


CREATE TABLE Venue (
    VenueId INT PRIMARY KEY IDENTITY(1001,1),   
    Name varchar(128) , 
    Address varchar(Max) , 
    InsertionTimestamp DATETIME NOT NULL DEFAULT GETDATE()  
);
