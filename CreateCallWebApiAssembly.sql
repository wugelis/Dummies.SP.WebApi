use [Student]

ALTER DATABASE [Student] SET TRUSTWORTHY ON

CREATE ASSEMBLY [Dummies.SP.WebApi]
FROM 'D:\Gelis Documents\MentorTrust\³¥§øÃÒ¨é\SourceCode\Dummies.SP.WebApi\Dummies.SP.WebApi\bin\Debug\Dummies.SP.WebApi.dll'
WITH permission_set = UNSAFE;
GO

CREATE function GetJsonFromWebApi
(
    @InvokeUrl nvarchar(MAX)
) RETURNS nvarchar(MAX)
WITH EXECUTE AS OWNER
AS 
EXTERNAL NAME [Dummies.SP.WebApi].[Dummies.SP.WebApi.CallWebApiLibClass].GetJsonFromWebApi
GO

CREATE function PostJsonToWebApi
(
    @InvokeUrl nvarchar(MAX),
	@JsonInput nvarchar(MAX)
) RETURNS nvarchar(MAX) AS 
EXTERNAL NAME [Dummies.SP.WebApi].[Dummies.SP.WebApi.CallWebApiLibClass].PostJsonToWebApi
GO

EXEC sp_configure 'clr enabled', '1';
GO
RECONFIGURE;
GO
