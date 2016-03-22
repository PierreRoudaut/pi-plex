﻿using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PiPlex
{
    class DurationProvier
    {
        public enum VideoType
        {
            TV_SHOW,
            MOVIE,
            UNDEFINED
        }

        public const int MAX_TV_SHOW_LENGTH = 70; //in minutes
        public const int MINUTE = 60; //in seconds
        public const long NANO_SECONDS = 1000000000; //in 1 second (1 000 000 000)

        public const long MOVIE_THRESHOLD = MAX_TV_SHOW_LENGTH * MINUTE * NANO_SECONDS;

        public static VideoType GetVideoTypeFromDuration(long duration)
        {
            if (duration > 0 && duration < MOVIE_THRESHOLD)
            {
                return VideoType.TV_SHOW;
            }
            else if (duration >= MOVIE_THRESHOLD)
            {
                return VideoType.MOVIE;
            }
            return VideoType.UNDEFINED;
        }

        public static long GetDurationAsNanoSeconds(string filePath)
        {
            long duration;
            try
            {
                using (ShellObject shell = ShellObject.FromParsingName(filePath))
                {
                    IShellProperty prop = shell.Properties.System.Media.Duration; // in 100-nanoseconds unit
                    if (prop == null || prop.ValueAsObject == null)
                    {
                        return 0;
                    }
                    string nb = prop.ValueAsObject.ToString();
                    if (long.TryParse(nb, out duration))
                    {
                        return duration * 100;
                    }
                }

            }
            catch (Exception exception)
            {
                Debug.WriteLine("ERROR calculating file duration: " + exception.Message);
            }
            return 0;
        }
    }
}