/* 此範本是由NuGet自動產生的 */
using Dummies.Core;
using Dummies.ServerComponent;
using Dummies.ServerMethodLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dummies.ServerMethodLibrary1
{
    public class Service : ServerComponentBase
    {
        //請在Login Method裡面撰寫Login邏輯，此名稱與參數不可更改。
        /// <summary>
        /// Login邏輯
        /// </summary>
        /// <param name="UserInfo">使用者相關資訊</param>
        /// <returns></returns>
        [WriteLog(UseLogType.ToFileSystem)]
        [WriteExceptionLog(UseLogType.ToEventLog)]
        [ErrorLevel(LevelType.Fatal)]
        [EnabledAnonymous(true)]
        [ExposeWebAPI(true)]
        public bool Login(UserInfo param)
        {
            return true;
        }

        /// <summary>
        /// 基本範例，取得目前時間
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [WriteLog(UseLogType.ToFileSystem)]
        [WriteExceptionLog(UseLogType.ToEventLog)]
        [ErrorLevel(LevelType.Fatal)]
        [EnabledAnonymous(true), ExposeWebAPI(true)]
        public DateTime GetDateTime(decimal param)
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [WriteLog(UseLogType.ToFileSystem)]
        [WriteExceptionLog(UseLogType.ToEventLog)]
        [ErrorLevel(LevelType.Fatal)]
        [EnabledAnonymous(true), ExposeWebAPI(true)]
        public IEnumerable<ClassRooms> GetAllClassRoom()
        {
            FuJenClassroomModel context = new FuJenClassroomModel();
            var result = from rooms in context.ClassRooms
                         select rooms;

            return result.AsEnumerable();
        }
    }
}