// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileBot.cs" company="something">
// Something
// </copyright>
// <summary>
//   Wrapper class for filebot.exe CLI manipulation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable All
namespace PiPlex
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Wrapper class for filebot.exe CLI manipulation
    /// </summary>
    public class FileBot
    {
        /// <summary>
        /// Gets the subtitles form filebot subtitles provider
        /// </summary>
        /// <param name="path">The path of the video file</param>
        /// <returns>The result of the download operation</returns>
        public static bool GetSubtitles(string path)
        {
            try
            {
                //TODO: put fileBotExePath in settings
                var fileBotExePath = @"C:\Program Files\FileBot\filebot.exe";
                Process process = new Process();
                process.StartInfo.FileName = fileBotExePath;
                process.StartInfo.Arguments = "-get-subtitles " + '"' + path + '"';
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
                    Debug.WriteLine(error);
                    Logger.Warning("FileBot:GetSubtitles", "No subtitles found for: " + Path.GetFileName(path));
                    return false;
                }
                Logger.Info("FileBot:GetSubtitles", "Subtitles found: " + Path.GetFileNameWithoutExtension(path) + ".srt");
                return true;
            }
            catch (Exception exception)
            {
                Logger.Error("FileBot:GetSubtitles", exception.Message);
                return false;
            }
        }
    }
}
