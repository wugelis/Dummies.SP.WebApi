using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dummies.SP.WebApi;

namespace CallWebApiUnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //string JsonInput = "1";
            //CallWebApiLibClass web = new CallWebApiLibClass();
            string JsonResult = CallWebApiLibClass.GetJsonFromWebApi("http://localhost:4612/api/ClassRooms");
            Assert.AreNotEqual(JsonResult, string.Empty);
        }
        [TestMethod]
        public void TestGetAllClassRoom()
        {
            string JsonResult = CallWebApiLibClass.PostJsonToWebApi("http://localhost:1955/api/Dummies.ServerMethodLibrary1/Dummies.ServerMethodLibrary1/Service/GetAllClassRoom", "");
            Assert.AreNotEqual(JsonResult, string.Empty);
        }
        [TestMethod]
        public void TestLoginMethod()
        {
            string JsonInput = @"{
Id:0,
    LoginName:'Gelis',
    Password:'',
    EnglishName:'',
    ChineseName:'',
    Email:'gelis.wu@mentortrust.com'
}";

            string JsonResult = CallWebApiLibClass.PostJsonToWebApi(
                "http://localhost:1955/api/Dummies.ServerMethodLibrary1/Dummies.ServerMethodLibrary1/Service/Login",
                JsonInput);

            Assert.AreNotEqual(JsonResult, string.Empty);
        }
    }
}
