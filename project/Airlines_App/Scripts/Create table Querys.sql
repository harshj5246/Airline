CREATE TABLE [dbo].[Users] (
    [UserName]        VARCHAR (50) NOT NULL,
    [FullName]        VARCHAR (50) NOT NULL,
    [EmailId]         VARCHAR (50) NOT NULL,
    [PhoneNo]         BIGINT       NOT NULL,
    [Gender]          VARCHAR (50) NOT NULL,
    [Password]        VARCHAR (50) NOT NULL,
    [ConfirmPassword] VARCHAR (50) NOT NULL,
    [DOB]             VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserName] ASC),
    UNIQUE NONCLUSTERED ([EmailId] ASC)
);


CREATE TABLE [dbo].[Admin] (
    [UserName] VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NOT NULL,
    UNIQUE NONCLUSTERED ([UserName] ASC),
    FOREIGN KEY ([UserName]) REFERENCES [dbo].[Users] ([UserName])
);

CREATE TABLE [dbo].[Booking] (
    [ticket_id]     INT          IDENTITY (100001, 4) NOT NULL,
    [flight_id]     VARCHAR (50) NOT NULL,
    [UserName]      VARCHAR (50) NOT NULL,
    [Airline_name]  VARCHAR (50) NOT NULL,
    [source]        VARCHAR (50) NOT NULL,
    [destination]   VARCHAR (50) NOT NULL,
    [Total_Amount]  MONEY        NOT NULL,
    [Class]         VARCHAR (50) NOT NULL,
    [Date]          VARCHAR (50) NOT NULL,
    [No_Of_Tickets] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([ticket_id] ASC),
    FOREIGN KEY ([flight_id]) REFERENCES [dbo].[Flight] ([flight_id]),
    FOREIGN KEY ([UserName]) REFERENCES [dbo].[Users] ([UserName])
);

CREATE TABLE [dbo].[Flight] (
    [flight_id]     VARCHAR (50) NOT NULL,
    [Airline_name]  VARCHAR (50) NOT NULL,
    [source]        VARCHAR (50) NOT NULL,
    [designation]   VARCHAR (50) NOT NULL,
    [seat_capacity] INT          NOT NULL,
    [depature]      VARCHAR (50) NOT NULL,
    [arraival_time] VARCHAR (50) NOT NULL,
    [flight_charge] FLOAT (53)   NOT NULL,
    [Seat_Left]     INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([flight_id] ASC)
);


