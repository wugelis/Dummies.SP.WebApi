USE [Student]
GO

--SELECT [dbo].[GetJsonFromWebApi] ('http://localhost:4612/api/ClassRooms') AS JSON_RESULT

SELECT [dbo].[GetJsonFromWebApi] ('http://localhost:1955/api/Dummies.ServerMethodLibrary1/Dummies.ServerMethodLibrary1/Service/GetDateTime') AS JSON_RESULT
GO
