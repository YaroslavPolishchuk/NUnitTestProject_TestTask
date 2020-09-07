using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RestApiAdMixer.FileWrite
{
    public static class FilePath
    {
        static string path = Assembly.GetCallingAssembly().CodeBase;
        static string actualPath = path.Substring(0, path.LastIndexOf("bin"));
        static string projectPath = new Uri(actualPath).LocalPath;

        static string reportPath = projectPath + "Reports";

        public static string GetPath()
        {
            return reportPath;
        }


    }
}
