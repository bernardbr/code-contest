namespace CodeContest.Core.Generics
{
    using System.Diagnostics;
    using System.IO;

    /// <inheritdoc />
    public abstract class BaseBuilder : IBuilder
    {
        /// <inheritdoc />
        public bool Build(string session, string code, out string binaryPath, out string message)
        {
            var path = $@"C:\temp\{session}";
            Directory.CreateDirectory(path);

            var startInfo = this.GetBuilderProcessStartInfo(path, code, out binaryPath);
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;

            var p = Process.Start(startInfo);
            var stdoutx = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            if (p.ExitCode != 0)
            {
                message = stdoutx;
                return false;
            }

            message = "Success";
            return true;
        }

        /// <summary>
        /// Gets a instance of <see cref="ProcessStartInfo" /> that has been configured to be build.
        /// </summary>
        /// <param name="path">The path of project.</param>
        /// <param name="code"></param>
        /// <param name="binaryPath"></param>
        /// <returns>An instance of <see cref="ProcessStartInfo" />.</returns>
        protected abstract ProcessStartInfo GetBuilderProcessStartInfo(string path,string code, out string binaryPath);
    }
}
