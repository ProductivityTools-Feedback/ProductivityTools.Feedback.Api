﻿ALTER TABLE [tm].[Feedback] ALTER COLUMN [Value] NVARCHAR(1000)
ALTER TABLE [tm].[Feedback] ALTER COLUMN [ReFeedback] NVARCHAR(100)

ALTER TABLE [tm].[Internal] ALTER COLUMN [Value] NVARCHAR(1000)

ALTER TABLE [tm].[One2One] ALTER COLUMN [TopicsToDiscuss] NVARCHAR(MAX)
ALTER TABLE [tm].[One2One] ALTER COLUMN [Feedback] NVARCHAR(MAX)
ALTER TABLE [tm].[One2One] ALTER COLUMN [ReFeedback] NVARCHAR(MAX)

ALTER TABLE [tm].[Person] ALTER COLUMN [FirstName] NVARCHAR(20)
ALTER TABLE [tm].[Person] ALTER COLUMN [Lastname] NVARCHAR(20)


ALTER TABLE [tm].[Success] ALTER COLUMN [Subject] NVARCHAR(200)
ALTER TABLE [tm].[Success] ALTER COLUMN [Value] NVARCHAR(1000)


