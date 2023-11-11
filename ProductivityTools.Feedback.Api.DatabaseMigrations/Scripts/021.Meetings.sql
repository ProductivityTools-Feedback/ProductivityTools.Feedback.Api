CREATE TABLE [tm].[Meeting] (
  [MeetingId] int IDENTITY (1,1) NOT NULL
, [Date] datetime NOT NULL
, [Subject] ntext NULL
, [BeforeNotes] ntext NULL
, [DuringNotes] ntext NULL
, [AfterNotes] ntext NULL
, CONSTRAINT [PK_Meeting] PRIMARY KEY ([MeetingId])
);
