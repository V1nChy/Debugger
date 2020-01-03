using UnityEngine;
using LuaInterface;

namespace GFW
{
    public class LogManager
    {
        private static bool m_UseLog = false;
        public static bool EnableLog
        {
            get
            {
                return LogManager.m_UseLog;
            }
            set
            {
                LogManager.m_UseLog = value;
                Debugger.useLog = value;
                Debug.unityLogger.logEnabled = value;
            }
        }

        public static void Log(string tag, string methodName, string message)
        {
            if (LogManager.EnableLog)
            {
                Debugger.Log(tag, methodName, message);
            }
        }
        public static void Log(string tag, string methodName, string str, params object[] param)
        {
            if (LogManager.EnableLog)
            {
                Debugger.Log(tag, methodName, str, param);
            }
        }
        public static void Log(string message)
        {
            if (LogManager.EnableLog)
            {
                Debugger.Log(message);
            }
        }
        public static void Log(string str, params object[] param)
        {
            if (LogManager.EnableLog)
            {
                Debugger.Log(str, param);
            }
        }

        public static void LogWarning(string tag, string methodName, string message)
        {
            if (LogManager.EnableLog)
            {
                Debugger.LogWarning(tag, methodName, message);
            }
        }
        public static void LogWarning(string tag, string methodName, string str, params object[] param)
        {
            if (LogManager.EnableLog)
            {
                Debugger.LogWarning(tag, methodName, str, param);
            }
        }
        public static void LogWarning(string message)
        {
            if (LogManager.EnableLog)
            {
                Debugger.LogWarning(message);
            }
        }
        public static void LogWarning(string str, params object[] param)
        {
            if (LogManager.EnableLog)
            {
                Debugger.LogWarning(str, param);
            }
        }

        public static void LogError(string tag, string methodName, string message)
        {
            if (LogManager.EnableLog)
            {
                Debugger.LogError(tag, methodName, message);
            }
        }
        public static void LogError(string tag, string methodName, string str, params object[] param)
        {
            if (LogManager.EnableLog)
            {
                Debugger.LogError(tag, methodName, str, param);
            }
        }
        public static void LogError(string message)
        {
            if (LogManager.EnableLog)
            {
                Debugger.LogError(message);
            }
        }
        public static void LogError(string str, params object[] param)
        {
            if (LogManager.EnableLog)
            {
                Debugger.LogError(str, param);
            }
        }
    }
}
