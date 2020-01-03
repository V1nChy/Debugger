using UnityEngine;
using System.Diagnostics;
using GFW;
using System.Reflection;
using Debugger = LuaInterface.Debugger;

public static class LogManagerExtension
{
    private static Assembly ms_Assembly;
    private static string GetLogTag(object obj)
    {
        return obj.GetType().Name;
    }
    private static string GetLogCallerMethod()
    {
        StackTrace stackTrace = new StackTrace(2, false);
        if (stackTrace != null)
        {
            if (null == LogManagerExtension.ms_Assembly)
            {
                LogManagerExtension.ms_Assembly = typeof(Debugger).Assembly;
            }
            for (int i = 0; i < stackTrace.FrameCount; i++)
            {
                StackFrame frame = stackTrace.GetFrame(i);
                MethodBase method = frame.GetMethod();
                if (method.Module.Assembly != LogManagerExtension.ms_Assembly)
                {
                    return method.Name;
                }
            }
        }
        return "";
    }

    public static void Log(this object obj, string str)
    {
        LogManager.Log(LogManagerExtension.GetLogTag(obj), LogManagerExtension.GetLogCallerMethod(), str);
    }
    public static void Log(this object obj, string str, params object[] param)
    {

        LogManager.Log(LogManagerExtension.GetLogTag(obj), LogManagerExtension.GetLogCallerMethod(), str, param);
    }
    public static void LogWarning(this object obj, string str)
    {
        LogManager.LogWarning(LogManagerExtension.GetLogTag(obj), LogManagerExtension.GetLogCallerMethod(), str);
    }
    public static void LogWarning(this object obj, string str, params object[] param)
    {
        LogManager.LogWarning(LogManagerExtension.GetLogTag(obj), LogManagerExtension.GetLogCallerMethod(), str, param);
    }
    public static void LogError(this object obj, string str)
    {
        LogManager.LogWarning(LogManagerExtension.GetLogTag(obj), LogManagerExtension.GetLogCallerMethod(), str);
    }
    public static void LogError(this object obj, string str, params object[] param)
    {
        LogManager.LogWarning(LogManagerExtension.GetLogTag(obj), LogManagerExtension.GetLogCallerMethod(), str, param);
    }
}