﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiPlex
{
    using Microsoft.Win32;

    public class CodeSnippet
    {

        public static string LocateEXE(String filename)
        {
            String path = Environment.GetEnvironmentVariable("path");
            String[] folders = path.Split(';');
            foreach (String folder in folders)
            {
                if (File.Exists(folder + filename))
                {
                    return folder + filename;
                }
                else if (File.Exists(folder + "\\" + filename))
                {
                    return folder + "\\" + filename;
                }
            }

            return String.Empty;
        }

        public static bool IsApplicationInstalled(string p_name)
        {
            string displayName;
            RegistryKey key;
            var programs = new List<string>();

            // search in: CurrentUser
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }
            }
            var resultInCurrentUser = key.GetSubKeyNames().FirstOrDefault(keyName => (key.OpenSubKey(keyName).GetValue("DisplayName") as String).Contains(p_name));

            // search in: LocalMachine_32
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    break;
                    return true;
                }
            }
            
            //var resultInLocalMachine32 = key.GetSubKeyNames().FirstOrDefault(keyName => (key.OpenSubKey(keyName).GetValue("DisplayName") as String).Contains(p_name));

            string d;
            //var list =
            //    key.GetSubKeyNames()
            //        .Where(keyName => (key.OpenSubKey(keyName).GetValue("DisplayName") as String)
            //        .Equals(p_name, StringComparison.OrdinalIgnoreCase));

            // search in: LocalMachine_64
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }
            }
            var resultInLocalMachine64 = key.GetSubKeyNames().FirstOrDefault(keyName => (key.OpenSubKey(keyName).GetValue("DisplayName") as String).Contains(p_name));

            // NOT FOUND
            return false;
        }

        public static void func(string exe)
        {
            string rootDirectory = System.IO.DriveInfo.GetDrives()[0].RootDirectory.FullName;

            string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);


            string[] files = Directory.GetFiles(
                        programFiles,
                        exe, SearchOption.AllDirectories);

            return;
        }

        public static string ProgramFilesx86()
        {
            if (8 == IntPtr.Size
                || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            return Environment.GetEnvironmentVariable("ProgramFiles");
        }

        public static bool Run()
        {
            var downloadFolder = DefaultSettingsProvider.DownloadFolder;
            var plexMovieFolder = DefaultSettingsProvider.PlexMovieFolder;
            var plexTvShowFolder = DefaultSettingsProvider.PlexTvShowFolder;

            var deee = Environment.GetEnvironmentVariable("ProgramW6432");
            var geee = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            var feee = Environment.ExpandEnvironmentVariables("%ProgramFiles%");



            //var d = IsApplicationInstalled("Plex Media Server");
            string path = null;
            //func("Filebot.exe");
            func("filebot.exe");
            //func("Plex Media Server.exe");
            return true;
        }
    }
}
