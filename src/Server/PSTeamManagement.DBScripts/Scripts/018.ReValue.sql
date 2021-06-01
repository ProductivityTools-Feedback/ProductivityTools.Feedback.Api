ALTER TABLE [tm].[One2One] ADD [ReFeedback] VARCHAR(maX)

EXEC sp_rename '[tm].[One2One].[Value]', 'Feedback', 'COLUMN';  