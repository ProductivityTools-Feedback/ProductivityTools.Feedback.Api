
  CREATE TABLE [tm].[Feedback] 
  (
	FeedbackId INT PRIMARY KEY IDENTITY(1,1),
	PersonId INT NOT NULL,
	CreatedDate DATETIME NOT NULL,
	[Value] VARCHAR(1000)

	CONSTRAINT FK_Feedback_Person FOREIGN KEY (PersonId) REFERENCES [tm].[Person](PersonId)
  )
