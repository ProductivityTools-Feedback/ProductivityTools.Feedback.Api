CREATE TABLE [tm].Dictionary
(
	DictonaryId INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(20)
)

CREATE TABLE [tm].DictValue
(
	DictonaryId INT,
	DictValueId INT PRIMARY KEY IDENTITY(1,1),
	[Key] VARCHAR(10),
	[Value] VARCHAR(20)
	CONSTRAINT FK_DictValue_Dictionary FOREIGN KEY (DictonaryId) REFERENCES [tm].Dictionary(DictonaryId),
	CONSTRAINT FK_DictValue_Unique UNIQUE(DictonaryId,[Key])
)

INSERT INTO [tm].[Dictionary]([Name]) VALUES('Event')


CREATE TABLE [tm].[Person]
(
	PersonId INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(20) NOT NULL,
	Lastname VARCHAR(20) NOT NULL,
	Initials VARCHAR(4) NOT NULL,
	Category VARCHAR(10) NOT NULL,
)

CREATE TABLE [tm].[WorkTime]
(
	WorkTimeId INT PRIMARY KEY IDENTITY(1,1),
	PersonId INT NOT NULL,
	CreatedDate DATETIME NOT NULL,
	EventTypeId INT,
	Lunch BIT,

	CONSTRAINT FK_Worktime_Person FOREIGN KEY (PersonId) REFERENCES [tm].Person(PersonId),
	CONSTRAINT FK_WorkTime_DictValue FOREIGN KEY (EventTypeID) REFERENCES [tm].DictValue(DictValueId)
)

