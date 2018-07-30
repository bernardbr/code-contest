namespace CodeContest.Core.Delphi
{
    using System.Diagnostics;
    using System.IO;
    using System;

    using CodeContest.Core.Generics;

    /// <inheritdoc />
    public class DelphiExecutor : BaseExecutor, IExecutor
    {
        /// <summary>
        /// Initializes a new instance of <see cref="DelphiExecutor"/>
        /// </summary>
        public DelphiExecutor() : base(new DelphiBuilder())
        {
        }        
    }
}