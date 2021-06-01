CREATE TABLE [tm].[MeetingsPerson] (
  [MeetingId] int not null,
  [PersonId] Int not null,
  CONSTRAINT [PK_MeetingContact] PRIMARY KEY ([MeetingId],[PersonId]),
  CONSTRAINT [FK_MeetingContact_Meeting] FOREIGN KEY ([MeetingId]) REFERENCES [tm].Meeting(MeetingId),
  CONSTRAINT [FK_MeetingContact_Person] FOREIGN KEY ([PersonId]) REFERENCES [tm].Person([PersonId])
)