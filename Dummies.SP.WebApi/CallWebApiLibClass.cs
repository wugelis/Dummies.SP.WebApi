﻿using Microsoft.SqlServer.Server;
//using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dummies.SP.WebApi
{
    /// <summary>
    /// 開放給 Store Procedure 來 Call Web API 的 C# 實作.
    /// </summary>
    public class CallWebApiLibClass
    {
        /// <summary>
        /// 使用 Get 從 Web Api 方法取得 JSON 資料.
        /// </summary>
        /// <param name="InvokeUrl">Invoke Url</param>
        /// <returns></returns>
        [SqlFunction()]
        public static string GetJsonFromWebApi(string InvokeUrl)
        {
            string JsonResult = string.Empty;

            HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(InvokeUrl);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(responseStream);
            try
            {
                JsonResult = sr.ReadToEnd();
            }
            finally
            {
                sr.Close();
            }
            return JsonResult;
        }
        /// <summary>
        /// 使用 Post 對 Web Api 方法更新 JSON 資料.
        /// </summary>
        /// <param name="InvokeUrl">Invoke Url</param>
        /// <param name="JsonString">Result Json Data</param>
        /// <returns></returns>
        [SqlFunction()]
        public static string PostJsonToWebApi(string InvokeUrl, string JsonInput)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(InvokeUrl);
            request.Method = "POST";
            request.ContentType = "application/json";

            Stream requestStream = request.GetRequestStream();

            try
            {
                byte[] bs = UTF8Encoding.UTF8.GetBytes(JsonInput);
                requestStream.Write(bs, 0, bs.Length);
            }
            finally
            {
                requestStream.Flush();
                requestStream.Close();
            }

            string resultJson = string.Empty;

            try
            {
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(responseStream);

                try
                {
                    resultJson = sr.ReadToEnd();
                }
                finally
                {
                    sr.Close();
                }
            }
            catch(Exception ex)
            {
                resultJson = ex.Message;
            }

            return resultJson;
        }
        //[SqlProcedure()]
        //public IEnumerable GetDataTableByWebApi(string InvokeUrl, string JsonInput)
        //{
        //    string JsonText = PostJsonToWebApi(InvokeUrl, JsonInput);
        //    DataTable dt = JsonConvert.DeserializeObject<DataTable>(JsonInput);
        //    return dt.AsEnumerable();
        //}
    }
}
