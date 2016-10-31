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
            Debug.WriteLine(KnownFolders.GetPath(KnownFolder.Videos));
            return true;
        }
    }
}
