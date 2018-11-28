program DelphiDefaultProject;
{$APPTYPE CONSOLE}

uses
  SysUtils,
  Forms,
  Windows,
  Classes;

function Solve(): string;
begin
  Result := 'Test';
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

begin
  { TODO: READ CONSOLE }
  lResult := Solve();
  SaveResultToOutput(lResult);
end.

