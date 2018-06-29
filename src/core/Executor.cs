using System;
using System.Diagnostics;
using System.IO;

namespace core
{
    public static class Executor
    {
        const string CODE_HEADER = @"
        program Console;
        {{$APPTYPE CONSOLE}}

        {0}
        ";

        public static void Do(string code)
        {
            var session = Guid.NewGuid().ToString();
            Build(code, session);
        }

        private static void Build(string code, string session)
        {
            var codeToExec = string.Format(CODE_HEADER, code);
            var path = $@"C:\temp\{session}";
            Directory.CreateDirectory(path);
            var file = $@"{path}\Console.dpr";
            File.WriteAllText(file, codeToExec);

            Process.Start("dcc32.exe", file);
        }
    }
}