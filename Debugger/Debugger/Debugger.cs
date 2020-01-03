using UnityEngine;
using System;
using System.Text;
using LuaInterface;
using ILogger = LuaInterface.ILogger;

namespace LuaInterface
{
    public static class Debugger
    {
        public static bool useLog = true;
        public static string threadStack = string.Empty;
        public static ILogger logger = null;

        private static CString sb = new CString(256);

        static Debugger()
        {
            for (int i = 24; i < 70; i++)
            {
                StringPool.PreAlloc(i, 2);
            }
        }

        //减少gc alloc
        static string GetLogFormat(string msg, string tag = null, string methodName = null)
        {
            DateTime time = DateTime.Now;
            sb.Clear();
            sb.Append(ConstStringTable.GetTimeIntern(time.Hour))
                .Append(":")
                .Append(ConstStringTable.GetTimeIntern(time.Minute))
                .Append(":")
                .Append(ConstStringTable.GetTimeIntern(time.Second))
                .Append(".")
                .Append(time.Millisecond)
                .Append("-")
                .Append(Time.frameCount % 999)
                .Append(" ");
            if (!string.IsNullOrEmpty(tag) && !string.IsNullOrEmpty(methodName))
            {
                sb.Append(tag).Append("::").Append(methodName).Append("() ");
            }
            sb.Append(msg);

            String dest = StringPool.Alloc(sb.Length);
            sb.CopyToString(dest);
            return dest;
        }

        public static void Log(string tag, string methodName, string str)
        {
            str = GetLogFormat(str, tag, methodName);

            if (useLog)
            {
                Debug.Log(str);
            }
            else if (logger != null)
            {
                //普通log节省一点记录堆栈性能和避免调用手机系统log函数
                logger.Log(str, string.Empty, LogType.Log);
            }

            StringPool.Collect(str);
        }
        public static void Log(string tag, string methodName, string str, params object[] param)
        {
            string s = string.Format(str, param);
            Log(tag, methodName, s);
        }
        public static void Log(string str)
        {
            str = GetLogFormat(str);

            if (useLog)
            {
                Debug.Log(str);
            }
            else if (logger != null)
            {
                //普通log节省一点记录堆栈性能和避免调用手机系统log函数
                logger.Log(str, string.Empty, LogType.Log);
            }

            StringPool.Collect(str);
        }
        public static void Log(object message)
        {
            Log(message.ToString());
        }
        public static void Log(string str, object arg0)
        {
            string s = string.Format(str, arg0);
            Log(s);
        }
        public static void Log(string str, object arg0, object arg1)
        {
            string s = string.Format(str, arg0, arg1);
            Log(s);
        }
        public static void Log(string str, object arg0, object arg1, object arg2)
        {
            string s = string.Format(str, arg0, arg1, arg2);
            Log(s);
        }
        public static void Log(string str, params object[] param)
        {
            string s = string.Format(str, param);
            Log(s);
        }

        public static void LogWarning(string tag, string methodName, string str)
        {
            str = GetLogFormat(str, tag, methodName);

            if (useLog)
            {
                Debug.LogWarning(str);
            }
            else if (logger != null)
            {
                string stack = StackTraceUtility.ExtractStackTrace();
                logger.Log(str, stack, LogType.Warning);
            }

            StringPool.Collect(str);
        }
        public static void LogWarning(string tag, string methodName, string str, params object[] param)
        {
            string s = string.Format(str, param);
            LogWarning(tag, methodName, s);
        }
        public static void LogWarning(string str)
        {
            str = GetLogFormat(str);

            if (useLog)
            {
                Debug.LogWarning(str);
            }
            else if (logger != null)
            {
                string stack = StackTraceUtility.ExtractStackTrace();
                logger.Log(str, stack, LogType.Warning);
            }

            StringPool.Collect(str);
        }
        public static void LogWarning(object message)
        {
            LogWarning(message.ToString());
        }
        public static void LogWarning(string str, object arg0)
        {
            string s = string.Format(str, arg0);
            LogWarning(s);
        }
        public static void LogWarning(string str, object arg0, object arg1)
        {
            string s = string.Format(str, arg0, arg1);
            LogWarning(s);
        }
        public static void LogWarning(string str, object arg0, object arg1, object arg2)
        {
            string s = string.Format(str, arg0, arg1, arg2);
            LogWarning(s);
        }
        public static void LogWarning(string str, params object[] param)
        {
            string s = string.Format(str, param);
            LogWarning(s);
        }

        public static void LogError(string tag, string methodName, string str)
        {
            str = GetLogFormat(str, tag, methodName);

            if (useLog)
            {
                Debug.LogError(str);
            }
            else if (logger != null)
            {
                string stack = StackTraceUtility.ExtractStackTrace();
                logger.Log(str, stack, LogType.Error);
            }

            StringPool.Collect(str);
        }
        public static void LogError(string tag, string methodName, string str, params object[] param)
        {
            string s = string.Format(str, param);
            LogError(tag, methodName, s);
        }
        public static void LogError(string str)
        {
            str = GetLogFormat(str);

            if (useLog)
            {
                Debug.LogError(str);
            }
            else if (logger != null)
            {
                string stack = StackTraceUtility.ExtractStackTrace();
                logger.Log(str, stack, LogType.Error);
            }

            StringPool.Collect(str);
        }
        public static void LogError(object message)
        {
            LogError(message.ToString());
        }
        public static void LogError(string str, object arg0)
        {
            string s = string.Format(str, arg0);
            LogError(s);
        }
        public static void LogError(string str, object arg0, object arg1)
        {
            string s = string.Format(str, arg0, arg1);
            LogError(s);
        }
        public static void LogError(string str, object arg0, object arg1, object arg2)
        {
            string s = string.Format(str, arg0, arg1, arg2);
            LogError(s);
        }
        public static void LogError(string str, params object[] param)
        {
            string s = string.Format(str, param);
            LogError(s);
        }

        public static void LogException(Exception e)
        {
            threadStack = e.StackTrace;
            string str = GetLogFormat(e.Message);

            if (useLog)
            {
                Debug.LogError(str);
            }
            else if (logger != null)
            {
                logger.Log(str, threadStack, LogType.Exception);
            }

            StringPool.Collect(str);
        }
        public static void LogException(string str, Exception e)
        {
            threadStack = e.StackTrace;
            str = GetLogFormat(str + e.Message);

            if (useLog)
            {
                Debug.LogError(str);
            }
            else if (logger != null)
            {
                logger.Log(str, threadStack, LogType.Exception);
            }

            StringPool.Collect(str);
        }
    }
}