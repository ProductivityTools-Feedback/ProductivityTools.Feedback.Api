
## Migration

I restored the DB changing the names
```
RESTORE DATABASE PTFeedback  
FROM DISK = 'c:\backup\PTTeamManagement.bak'
with move 'PTTeamManagement' TO 'C:\Program Files\Microsoft SQL Server\MSSQL16.SQL2022\MSSQL\DATA\PTFeedback.mdf',
 move 'PTTeamManagement_Log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL16.SQL2022\MSSQL\DATA\PTFeedback_log.ldf',
 REPLACE,
 STATS=10
```

I updated the names in the dbup tables:
```
use PTFeedback
 update [tm].[dbUp] set ScriptName=REPLACE(ScriptName,'ProductivityTools.TeamManagement.Api.DatabaseMigrations','ProductivityTools.Feedback.Api.DatabaseMigrations')

```