using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// ADIF QSO Class
/// </summary>

namespace ADIFLib
{
    public class ADIFQSO : TokenCollection
    {
        /// <summary>
        /// Instantiate ADIFQSO with no initial population.
        /// </summary>
        public ADIFQSO()
        { }

        /// <summary>
        /// Instantiate ADIFQSO with an initial QSO string to parse.
        /// </summary>
        /// <param name="ParseThisString"></param>
        public ADIFQSO(string ParseThisString)
        {
            //here
        }

        /// <summary>
        /// Populate this ADIFQSO with this QSO string.
        /// </summary>
        /// <param name="ParseThisString"></param>
        public void ParseStringToADIFQSO(string ParseThisString)
        {
            //here
        }

        /// <summary>
        /// Return the QSO as a proper ADIF string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //here - don't forget to end with <eor>.
            return base.ToString();
        }
    }
}
