drop view  [tm].[TeamFeedback] 
go

CREATE VIEW [tm].[PersonFeedback] as
SELECT [FeedbackId]
	  ,p.PersonId
      ,p.FirstName,p.Lastname
      ,[CreatedDate]
      ,[Value]
  FROM [tm].[Feedback] f
  inner join tm.Person p
  on f.PersonId=p.PersonId
