create view [tm].[TeamFeedback] as
SELECT [FeedbackId]
      ,p.FirstName,p.Lastname
      ,[CreatedDate]
      ,[Value]
  FROM [tm].[Feedback] f
  inner join tm.Person p
  on f.PersonId=p.PersonId
