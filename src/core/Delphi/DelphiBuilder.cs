namespace core.Delphi
{
    using System.Diagnostics;
    using System.IO;
    using System;

    /// <summary>
    /// Delphi code builder.
    /// </summary>
    public class DelphiBuilder : IBuilder
    {
        /// <summary>
        /// The code header.
        /// </summary>
        const string CODE_HEADER = @"
        program Console;
        {{$APPTYPE CONSOLE}}

        {0}
        ";

        /// <inheritdoc />
        public string Build(string code)
        {
            var session = Guid.NewGuid().ToString();

            var codeToExec = string.Format(CODE_HEADER, code);
            var path = $@"C:\temp\{session}";
            Directory.CreateDirectory(path);
            var file = $@"{path}\Console.dpr";
            File.WriteAllText(file, codeToExec);

            var p = Process.Start("dcc32.exe", file);
            p.WaitForExit();

            return $@"{path}\Console.exe";
        }
    }
}