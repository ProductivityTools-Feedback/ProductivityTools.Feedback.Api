
  CREATE TABLE [tm].[WorkLunch] 
  (
	WorkLunchId INT PRIMARY KEY IDENTITY(1,1),
	Lunch BIT NOT NULL,
	PersonId INT NOT NULL,
	CreatedDate DATETIME NOT NULL,

	CONSTRAINT FK_WorkLunch_Person FOREIGN KEY (PersonId) REFERENCES [tm].[Person](PersonId)
  )


  
  CREATE TABLE [tm].[WorkTimeComment] 
  (
	WorkLunchId INT PRIMARY KEY IDENTITY(1,1),
	Comment VARCHAR(2000),
	PersonId INT NOT NULL,
	CreatedDate DATETIME NOT NULL,

	CONSTRAINT FK_WorkTimeComment_Person FOREIGN KEY (PersonId) REFERENCES [tm].[Person](PersonId)
  )