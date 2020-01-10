using UnityEngine;
using LuaInterface;

namespace GFW
{
    public class LogMgr
    {
        private static bool m_UseLog = false;
        public static bool EnableLog
        {
            get
            {
                return LogMgr.m_UseLog;
            }
            set
            {
                LogMgr.m_UseLog = value;
                Debugger.useLog = value;
                Debug.unityLogger.logEnabled = value;
            }
        }

        public static void Log(string tag, string methodName, string message)
        {
            if (LogMgr.EnableLog)
            {
                Debugger.Log(tag, methodName, message);
            }
        }
        public static void Log(string tag, string methodName, string str, params object[] param)
        {
            if (LogMgr.EnableLog)
            {
                Debugger.Log(tag, methodName, str, param);
            }
        }
        public static void Log(string message)
        {
            if (LogMgr.EnableLog)
            {
                Debugger.Log(message);
            }
        }
        public static void Log(string str, params object[] param)
        {
            if (LogMgr.EnableLog)
            {
                Debugger.Log(str, param);
            }
        }

        public static void LogWarning(string tag, string methodName, string message)
        {
            if (LogMgr.EnableLog)
            {
                Debugger.LogWarning(tag, methodName, message);
            }
        }
        public static void LogWarning(string tag, string methodName, string str, params object[] param)
        {
            if (LogMgr.EnableLog)
            {
                Debugger.LogWarning(tag, methodName, str, param);
            }
        }
        public static void LogWarning(string message)
        {
            if (LogMgr.EnableLog)
            {
                Debugger.LogWarning(message);
            }
        }
        public static void LogWarning(string str, params object[] param)
        {
            if (LogMgr.EnableLog)
            {
                Debugger.LogWarning(str, param);
            }
        }

        public static void LogError(string tag, string methodName, string message)
        {
            if (LogMgr.EnableLog)
            {
                Debugger.LogError(tag, methodName, message);
            }
        }
        public static void LogError(string tag, string methodName, string str, params object[] param)
        {
            if (LogMgr.EnableLog)
            {
                Debugger.LogError(tag, methodName, str, param);
            }
        }
        public static void LogError(string message)
        {
            if (LogMgr.EnableLog)
            {
                Debugger.LogError(message);
            }
        }
        public static void LogError(string str, params object[] param)
        {
            if (LogMgr.EnableLog)
            {
                Debugger.LogError(str, param);
            }
        }
    }
}
