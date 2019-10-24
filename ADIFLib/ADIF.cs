using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/// <summary>
/// Main ADIF Class
/// This is the parent class of ADIFLib.
/// </summary>

namespace ADIFLib
{
    public class ADIF
    {

        public ADIFHeader TheADIFHeader;
        public ADIFQSOCollection TheQSOs = new ADIFQSOCollection();

        public bool ThrowExceptionOnUnknownLine = false;  // Should an exception be thrown when a non-blank line doesn't end with <eoh> or <eor>?

        /// <summary>
        /// Instantiate an empty ADIF. 
        /// </summary>
        public ADIF()
        {
        }

        /// <summary>
        /// Instantiate an ADIF and populate it from the contents of specified file.
        /// </summary>
        /// <param name="FileName"></param>
        public ADIF(string FileName)
        {
            ReadFromFile(FileName);
        }

        public void SaveToFile(string FileName, bool OverWrite=false)
        {
            if (FileName == "")
            {
                throw new Exception("Filename cannot be empty!");
            }
            else
            {
                // If not overwriting and the file exists, then complain
                if (!OverWrite && File.Exists(FileName))
                {
                    throw new Exception(string.Format("File already exists: {0}", FileName));
                }
                else
                {
                    InternalSaveToFile(FileName, OverWrite); // Now, save to file.
                }
            }
        }

        public void ReadFromFile(string FileName)
        {
            uint lineNumber = 0;

            if (!File.Exists(FileName))
            {
                throw new Exception(string.Format("File does not exist: {0}", FileName));
            }
            else
            {
                using (StreamReader readThisFile = new StreamReader(FileName))
                {
                    string theLine = "";
                    while (!readThisFile.EndOfStream)
                    {
                        theLine = readThisFile.ReadLine().Trim();
                        if (theLine != "")
                        {
                            if (theLine.ToUpper().EndsWith("<EOH>"))
                            {
                                if (TheADIFHeader != null)
                                {
                                    throw new Exception(string.Format("File {0} cannot contain more than one header.  See line {1}", FileName, lineNumber.ToString()));
                                }
                                else
                                {
                                    TheADIFHeader = new ADIFHeader(theLine);  // Add the header.
                                    lineNumber++;
                                }
                            }
                            else
                            {
                                if (theLine.ToUpper().EndsWith("<EOR>"))
                                {
                                    TheQSOs.Add(new ADIFQSO(theLine));
                                    lineNumber++;
                                }
                                else
                                {
                                    // Line does not end with <EOR> or <EOH>.  Throw exception?
                                    if (ThrowExceptionOnUnknownLine)
                                    {
                                        throw new Exception(string.Format("Unknown line in ADIF file {0}:{1}", FileName, lineNumber.ToString()));
                                    }
                                    else
                                    {
                                        lineNumber++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


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

        public override string ToString()
        {
            StringBuilder retCompleteADIF = new StringBuilder();
            retCompleteADIF.Append(TheADIFHeader.ToString()).Append(TheQSOs.ToString());
            return retCompleteADIF.ToString();
        }


        private void InternalSaveToFile(string FileName, bool Overwrite)
        {
            File.WriteAllText(FileName, this.ToString());
        }
    }
}
