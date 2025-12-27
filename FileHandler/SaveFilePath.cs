using System;
using System.IO;

namespace diarFly;

public class SaveFilePath
{
    public string Get()
    {
        string Path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);


        if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS() || OperatingSystem.IsFreeBSD())
        {
            Path += "/DiarFlySave.json";
        }
        else if (OperatingSystem.IsWindows())
        {
            Path += @"\DiarFlySave.json";
        }

        return Path;
    }

    public bool Exists()
    {
        if (File.Exists(Get())) return true;
        return false;
    }
}