namespace CodeContest.Core.CSharp
{
    using System.Diagnostics;
    using System.IO;

    using CodeContest.Core.Generics;

    /// <inheritdoc />
    public class CSharpBuilder : BaseBuilder, IBuilder
    {
        /// <inheritdoc />
        protected override ProcessStartInfo GetBuilderProcessStartInfo(string path, string code, out string binaryPath)
        {
            var file = $@"{path}\Console.cs";
            File.WriteAllText(file, code);
            binaryPath = $@"{path}\Console.exe";
            var args = $@"/out:{binaryPath} {file}";

            return new ProcessStartInfo(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe", args);
        }
    }
}
