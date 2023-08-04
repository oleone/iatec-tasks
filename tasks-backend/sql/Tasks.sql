CREATE DATABASE IATecTasks;

GO;

USE IATecTasks;

GO;

CREATE TABLE
    dbo.Tasks(
        Id VARCHAR(28) NOT NULL,
        Title VARCHAR(50) NOT NULL,
        Description VARCHAR(255),
        UserId VARCHAR(28) NOT NULL,
        IsInProgress BOOLEAN NOT NULL,
        IsDone BOOLEAN,
        IsDeleted BOOLEAN,
        CreatedDate TIME,
        UpdatedDate TIME,
    );

GO;