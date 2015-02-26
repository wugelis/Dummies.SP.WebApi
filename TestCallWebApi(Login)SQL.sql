USE [Student]
GO

SELECT [dbo].[PostJsonToWebApi] (
   'http://localhost:1955/api/Dummies.ServerMethodLibrary1/Dummies.ServerMethodLibrary1/Service/Login'
  ,'{
	Id:0,
	LoginName:''Gelis'',
	Password:'''',
	EnglishName:'''',
	ChineseName:'''',
	Email:''gelis.wu@mentortrust.com''
}')

GO


