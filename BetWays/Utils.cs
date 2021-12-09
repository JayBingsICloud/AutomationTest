using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutomationTest
{
    public class Utils
    {
        public static void CreateDir(string dir)
        {

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

        }
    }
}
