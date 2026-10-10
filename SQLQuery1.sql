CREATE TABLE Sushnost (
    Id INT PRIMARY KEY IDENTITY(1,1),   -- автоинкремент, сам будет генерировать 1,2,3...
    Name NVARCHAR(100) NOT NULL,
    Transcendence INT NOT NULL,
    Age INT NOT NULL
);