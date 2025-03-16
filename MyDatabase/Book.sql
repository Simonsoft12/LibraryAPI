CREATE TABLE [dbo].[Book]
(
    Id INT IDENTITY(1,1) PRIMARY KEY,             
    Title NVARCHAR(100) NOT NULL,               
    Author NVARCHAR(100) NOT NULL,              
    ISBN NVARCHAR(20) NOT NULL,                    
    StatusId INT NOT NULL DEFAULT 1 CHECK (StatusId IN (1, 2, 3, 4)) 
);
GO
CREATE INDEX IX_Book_Title ON [dbo].[Book] (Title);
GO
CREATE INDEX IX_Book_Author ON [dbo].[Book] (Author);
GO
CREATE INDEX IX_Book_ISBN ON [dbo].[Book] (ISBN);

GO
ALTER TABLE [dbo].[Book]
ADD CONSTRAINT UQ_Book_ISBN UNIQUE (ISBN);