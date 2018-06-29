namespace core.Delphi
{
    using System.Diagnostics;
    using System.IO;
    using System;

    public class DelphiExecutor : IExecutor
    {
        public void DoTest(string code)
        {
            var delphiBuilder = new DelphiBuilder();
            delphiBuilder.Build(code);
        }
    }
}