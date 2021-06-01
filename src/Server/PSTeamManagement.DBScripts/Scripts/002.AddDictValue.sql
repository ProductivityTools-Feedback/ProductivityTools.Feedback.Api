
CREATE PROCEDURE [tm].[AddDictValue]
 	 @DictionaryName VARCHAR(20),
	 @Key VARCHAR(10),
	 @Value VARCHAR(20)
AS
BEGIN
	DECLARE @dictoinaryId VARCHAR
	SELECT @dictoinaryId=DictonaryId FROM [tm].[Dictionary] WHERE [Name]=@DictionaryName

	INSERT INTO [tm].DictValue(DictonaryId,[Key],[Value])
	VALUES (@dictoinaryId,@Key,@Value)
END
