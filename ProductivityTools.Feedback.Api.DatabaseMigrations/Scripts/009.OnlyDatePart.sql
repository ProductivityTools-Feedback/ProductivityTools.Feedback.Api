﻿CREATE FUNCTION tm.OnlyDatePart(@input DATETIME)
RETURNS DATE
AS BEGIN
    DECLARE @RESULT DATE
    SET @RESULT = convert (date ,@input)
    RETURN @RESULT
END