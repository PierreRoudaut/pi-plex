using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiPlex
{
    public class CodeSnippet
    {
        public static bool Run()
        {
            try
            {
                var path = @"C:\Users\proud\Videos\MOVIES\American.Horror.Story.S06E07.HDTV.x264-KILLERS.mkv";
                var fileBotExePath = @"C:\Program Files\FileBot\filebot.exe";
                Process process = new Process();
                process.StartInfo.FileName = fileBotExePath;
                process.StartInfo.Arguments = "-get-subtitles " + path;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.Start();

                string error = process.StandardError.ReadToEnd();
                string output = process.StandardOutput.ReadToEnd();

                process.WaitForExit();

                //If error output is not empty
                if (!String.IsNullOrEmpty(error))
                {
                    Logger.Warning("FileBotTests:FetchSubtitlesTest", "No subtitles found for: " + Path.GetFileName(path));
                    return false;
                }
                Logger.Info("FileBotTests:FetchSubtitlesTest", "Subtitles found: " + Path.GetFileNameWithoutExtension(path) + ".srt");
                return true;
            }
            catch (Exception exception)
            {
                Logger.Error("FileBotTests:FetchSubtitlesTest", exception.Message);
                return false;
            }
        }
    }
}
