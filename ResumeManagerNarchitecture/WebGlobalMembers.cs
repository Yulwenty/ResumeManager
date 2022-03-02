using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ResumeManagerNarchitecture
{
    public class WebGlobalMembers
    {
        public static HttpContext CurrentContext
        {
            get { return WebUiHelper.CurrentContext; }
        }

        internal static HttpSessionState CurrentSession
        {
            get
            {
                HttpContext currentContext = CurrentContext;
                return currentContext == null ? null : currentContext.Session;
            }
        }

        //is it okay to use public? original is internal
        public static string CurrentLoginUserName
        {
            get
            {
                HttpSessionState currentSession = CurrentSession;
                if (currentSession == null)
                {
                    return null;
                }
                string value = Convert.ToString(currentSession[FieldNames.UserName]);
                return value;
            }
            set {
                CurrentSession[FieldNames.UserName] = value;
            }
        }
    }
}