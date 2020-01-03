using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;

namespace GFW
{
    public class LogViewer : MonoBehaviour
    {
        public class LogInfo
        {
            public string message = null;
            public LogType type = 0;
            public LogInfo(string message, LogType type)
            {
                this.message = message;
                this.type = type;
            }
        }

        private ConsoleWindow m_Console = new ConsoleWindow();
        private ConsoleInput m_Input = new ConsoleInput();

        private Thread m_Thread;
        static readonly object m_lockObject = new object();
        static readonly object m_lockObject2 = new object();
        static Queue<LogInfo> log_list = new Queue<LogInfo>();

        //日志输出路径
        private string output_path = null;
        void Awake()
        {
            string log_dir = System.Environment.CurrentDirectory + "/StreamingAssets/log";
            if (!Directory.Exists(log_dir))
                Directory.CreateDirectory(log_dir);
            output_path = log_dir + "/out_put.txt";
            //每次启动先删除旧的
            if (File.Exists(output_path))
            {
                File.Delete(output_path);
            }

            m_Console.Initialize();
            m_Console.SetTitle("game log");
            Application.logMessageReceived += HandleLog;
            m_Thread = new Thread(OnUpdateThread);
            m_Thread.Start();
        }

        //日志回调
        void HandleLog(string message, string stackTrace, LogType type)
        {
            AddMessage(message, type);
        }

        public void AddMessage(string message, LogType type)
        {
            lock (m_lockObject2)
            {
                LogInfo li = new LogInfo(message, type);
                log_list.Enqueue(li);
            }
        }
        
        //主线程update
        void Update()
        {
            m_Input.Update();
        }

        //多线程update
        void OnUpdateThread()
        {
            while (true)
            {
                lock (m_lockObject)
                {
                    if (log_list.Count > 0)
                    {

                        LogInfo li = log_list.Dequeue();
                        
                        if (li.type == LogType.Warning)
                            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
                        else if (li.type == LogType.Error || li.type == LogType.Exception)
                            System.Console.ForegroundColor = System.ConsoleColor.Red;
                        else
                            System.Console.ForegroundColor = System.ConsoleColor.White;

                        if (System.Console.CursorLeft != 0)
                            m_Input.ClearLine();
                        
                        System.Console.WriteLine(li.message);

                        OnWriteFile(li.message);
                    }
                }
                Thread.Sleep(10);
            }
        }

        void OnWriteFile(string message)
        {
            try
            {
                StreamWriter writer = new StreamWriter(output_path, true, System.Text.Encoding.UTF8);
                writer.WriteLine(message);
                writer.Close();
            }
            catch (Exception e)
            {
                Debug.Log("write game log error :" + e.Message);
            }
        }
        void OnDestroy()
        {
            m_Thread.Abort();
            m_Console.Shutdown();
        }
    }
}
