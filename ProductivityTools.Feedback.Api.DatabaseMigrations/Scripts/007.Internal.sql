
  CREATE TABLE [tm].[Internal] 
  (
	InternalId INT PRIMARY KEY IDENTITY(1,1),
	PersonId INT NOT NULL,
	CreatedDate DATETIME NOT NULL,
	[Value] VARCHAR(1000)

	CONSTRAINT FK_Internal_Person FOREIGN KEY (PersonId) REFERENCES [tm].[Person](PersonId)
  )
