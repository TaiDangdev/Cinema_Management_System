
GO

CREATE TABLE CUSTOMER
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    
    -- Tự sinh mã KHxxx từ Id
    IdFormat AS 
      CASE 
        WHEN Id < 1000 THEN 'KH' + RIGHT('000' + CAST(Id AS VARCHAR(3)), 3)
        ELSE 'KH' + CAST(Id AS VARCHAR)
      END PERSISTED,

    FullName NVARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(10) NOT NULL UNIQUE,
    Email VARCHAR(50) NOT NULL,
    Point INT NOT NULL DEFAULT 0,
    Birth SMALLDATETIME NOT NULL,
    RegDate SMALLDATETIME NOT NULL DEFAULT GETDATE(),
    Gender NVARCHAR(20) NOT NULL,
    
    -- Soft delete
    IsDeleted BIT DEFAULT 0
);
GO
