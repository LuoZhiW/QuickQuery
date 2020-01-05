using System;
using System.IO;

namespace QuickQuery.ORM
{
    /// <summary>
    /// 日志操作类。
    /// </summary>
    public class Log
    {
        private static object writelock = new object();

        /// <summary>
        /// 正常模式,启用后会自动写日志
        /// </summary>
        public static bool IsNormal = false;

        /// <summary>
        /// 日志文件夹
        /// </summary>
        public static string LogFolder
        {
            get;
            set;
        }

        /// <summary>
        /// 日志路径
        /// </summary>
        /// <returns></returns>
        private static string GetPath(string type)
        {
            string text = Log.LogFolder;
            bool flag = text == null;
            if (flag)
            {
                text = AppDomain.CurrentDomain.BaseDirectory;
            }
            bool flag2 = !text.EndsWith("\\");
            if (flag2)
            {
                text += "\\";
            }
            bool flag3 = !Directory.Exists(text);
            if (flag3)
            {
                Directory.CreateDirectory(text);
            }
            return string.Format("{0}{1}_{2}.log", text, DateTime.Now.ToString("yyyy-MM-dd"), type);
        }

        /// <summary>
        /// 将指定字符串中的格式项替换为指定数组中相应对象的字符串表示形式。文件格式[yyyy-MM-dd_系统日志.log]。
        /// </summary>
        /// <param name="format"> 复合格式字符串。</param>
        /// <param name="args">一个对象数组，其中包含零个或多个要设置格式的对象。</param>
        public static void Write(string format, params object[] args)
        {
            bool isNormal = Log.IsNormal;
            if (isNormal)
            {
                object obj = Log.writelock;
                lock (obj)
                {
                    try
                    {
                        string arg = string.Empty;
                        bool flag2 = format.Contains("{0}") && args != null && args.Length != 0;
                        if (flag2)
                        {
                            arg = string.Format(format, args);
                        }
                        else
                        {
                            arg = format;
                        }
                        File.AppendAllText(Log.GetPath("oq.orm"), string.Format("{0}   [日志内容:{1}]{2}", DateTime.Now, arg, Environment.NewLine));
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}
