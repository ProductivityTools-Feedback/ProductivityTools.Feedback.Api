  CREATE TABLE [tm].[One2One] 
  (
	One2OneId INT PRIMARY KEY IDENTITY(1,1),
	PersonId INT NOT NULL,
	CreatedDate DATETIME NOT NULL,
	[Value] VARCHAR(1000)

	CONSTRAINT FK_One2One_Person FOREIGN KEY (PersonId) REFERENCES [tm].[Person](PersonId)
  )
