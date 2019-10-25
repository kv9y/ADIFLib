using System;

/// <summary>
/// ADIF Header Class
/// </summary>

namespace ADIFLib
{
    public class ADIFHeader : TokenCollection
    {

        /// <summary>
        /// Text from the header before the first <
        /// </summary>
        public string HeaderPreText = "";

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
            int ltPosition = ParseThisString.IndexOf('<');
            if (ltPosition > 0)
            {
                HeaderPreText = ParseThisString.Substring(0, ltPosition);
                this.PullApartLine(ParseThisString.Substring(ltPosition), true);
            }
            else
                this.PullApartLine( ParseThisString, true);
        }

        /// <summary>
        /// Return the Header as a proper ADIF string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return HeaderPreText + base.ToString() + "<eoh>";
        }
    }
}

