namespace CodeContest.Test.Application
{
    using System;

    using CodeContest.Core.Delphi;
    using CodeContest.Core;

    using NUnit.Framework;

    /// <summary>
    /// The test application for <see cref="DelphiExecutor"/>.
    /// </summary>
    [TestFixture]
    public class DelphiExecutorTest
    {
        /// <summary>
        /// Test: Should execute.
        /// </summary>
        [Test]
        public void ShouldExecute()
        {
            const string code = @"
                program SolveMeFirst;
                {$APPTYPE CONSOLE}

                uses
                  SysUtils,
                  Forms,
                  Windows,
                  Classes,
                  Dialogs;

                function DoSum(pValue1: Int64; pValue2: Int64): Int64;
                begin
                  Result := pValue1 + pValue2;
                end;

                function GetEnvVarValue(const VarName: string): string;
                var
                  BufSize: Integer;
                begin
                  BufSize := GetEnvironmentVariable(PChar(VarName), nil, 0);
                  if BufSize > 0 then
                  begin
                    SetLength(Result, BufSize - 1);
                    GetEnvironmentVariable(PChar(VarName), PChar(Result), BufSize);
                    Exit;
                  end;

                  Result := '';
                end;

                procedure SaveResultToOutput(const pResult: string);
                const
                  OUTPUT_PATH = 'OUTPUT_PATH';
                var
                  lPath: string;
                  lResultWriter: TStrings;
                begin
                  lResultWriter := TStringList.Create();
                  try
                    lPath := GetEnvVarValue(OUTPUT_PATH);
                    if (not DirectoryExists(ExtractFileDir(lPath))) then
                    begin
                      CreateDir(ExtractFileDir(lPath));
                    end;

                    lResultWriter.Add(pResult);
                    lResultWriter.SaveToFile(lPath);
                  finally
                    lResultWriter.Free;
                  end;
                end;

                var
                  lResult: string;
                  lStringNumber: string;
                  lFirstNumber,
                  lSecondNumber: Int64;
                begin
                  Readln(Input, lStringNumber);
                  lFirstNumber := StrToInt64(lStringNumber);
                  Readln(Input, lStringNumber);
                  lSecondNumber := StrToInt64(lStringNumber);
                  lResult := IntToStr(DoSum(lFirstNumber, lSecondNumber));
                  SaveResultToOutput(lResult);
                end.
            ";

            var session = Guid.NewGuid().ToString();

            IExecutor executor = new DelphiExecutor();
            var ret = executor.Execute(session, code, int.MaxValue, "4\n5", out var output, out var message);
            Assert.IsTrue(ret);
            Assert.IsNotEmpty(output);
            Assert.IsEmpty(message);
        }
    }
}
