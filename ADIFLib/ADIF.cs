using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Main ADIF Class
/// This is the parent class of ADIFLib.
/// </summary>

namespace ADIFLib
{
    public class ADIF
    {






        /// <summary>
        /// Get ADIFLib version.
        /// </summary>
        public string Version
        {
            get
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fileVerInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                return fileVerInfo.FileVersion;
            }
        }
    }
}
