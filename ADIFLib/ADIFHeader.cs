using System;

/// <summary>
/// ADIF Header Class
/// </summary>

namespace ADIFLib
{
    public class ADIFHeader : TokenCollection
    {
        /// <summary>
        /// Instantiate ADIFHeader with no initial population.
        /// </summary>
        public ADIFHeader()
        { }

        /// <summary>
        /// Instantiate ADIFHeader with an initial QSO string to parse.
        /// </summary>
        /// <param name="ParseThisString"></param>
        public ADIFHeader(string ParseThisString)
        {
            ParseStringToADIFHeader(ParseThisString);
        }

        /// <summary>
        /// Populate this ADIFHeader with this header string.
        /// </summary>
        /// <param name="ParseThisString"></param>
        public void ParseStringToADIFHeader(string ParseThisString)
        {
            this.PullApartLine(ParseThisString, false);
        }

        /// <summary>
        /// Return the Header as a proper ADIF string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + "<eoh>";
        }
    }
}

