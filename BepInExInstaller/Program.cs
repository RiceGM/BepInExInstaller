using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BepInExInstaller
{
    internal class Program
    {
        static readonly string bepInString = "https://github.com/BepInEx/BepInEx/releases/download/v5.4.21/BepInEx_x64_5.4.21.0.zip";

        static void Main(string[] args)
        {
            if (args.Length == 0) return;

            if (!File.Exists(Path.Combine(Path.GetDirectoryName(args[0]), "winhttp.dll")))
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(bepInString, "BepInEx.zip");
                }

                ZipFile.ExtractToDirectory("BepInEx.zip", Path.GetDirectoryName(args[0]));
                File.Delete("BepInEx.zip");
            }

            Environment.Exit(0);
        }
    }
}
