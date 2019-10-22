using System;
using System.Text;

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
            ParseStringToADIFQSO(ParseThisString);
        }

        /// <summary>
        /// Populate this ADIFQSO with this QSO string.
        /// </summary>
        /// <param name="ParseThisString"></param>
        public void ParseStringToADIFQSO(string ParseThisString)
        {
            this.PullApartLine(ParseThisString, false);

            //// The terminating <eor> is optional when parsing.
            //string[] tokens = ParseThisString.Split('<');  // Use "<" to determine where the token starts.

            //// loop through each token
            //foreach (string token in tokens)
            //{
            //    if (token.ToUpper()!="EOR>")  /* ignore terminating token */
            //        this.Add(new Token("<" + token, false));  // Add "<" to make it a complete token.  The .Split() call removes this character.
            //}
        }

        /// <summary>
        /// Return the QSO as a proper ADIF string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //StringBuilder retQSORecord = new StringBuilder();
            //foreach (Token thisToken in this)
            //{
            //    retQSORecord.Append(thisToken.ToString());
            //}
            //retQSORecord.Append("<eor>");
            return base.ToString() + "<eor>";
        }
    }
}
