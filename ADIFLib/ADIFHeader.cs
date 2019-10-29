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
        /// Instantiate ADIFHeader with header pre text and a collection of name/data items.
        /// </summary>
        /// <param name="HeaderPreText"></param>
        /// <param name="TagNameDataListForThisQSO"></param>
        public ADIFHeader(string HeaderPreText, TokenNameDataList TagNameDataListForThisQSO)
        {
            this.HeaderPreText = HeaderPreText;
            foreach (TokenNameData anItem in TagNameDataListForThisQSO)
            {
                this.Add(new Token(anItem.TagName, anItem.Data));
            }
        }

        public void Add(TokenNameData NewItem)
        {
            InternalAdd(NewItem);
        }

        private void InternalAdd(TokenNameData NewItem)
        {
            //here
        }

        /// <summary>
        /// Populate this ADIFHeader with this header string.
        /// </summary>
        /// <param name="ParseThisString"></param>
        public void ParseStringToADIFHeader(string ParseThisString)
        {
            int ltPosition = ParseThisString.IndexOf('<');
            if (ltPosition == -1 && ParseThisString != "") /* no less-than found but there is something in the string */
            {
                HeaderPreText = ParseThisString;  // Just pretext in the header.
            }
            else
            {
                if (ltPosition > 0)
                {
                    HeaderPreText = ParseThisString.Substring(0, ltPosition);
                    this.PullApartLine(ParseThisString.Substring(ltPosition), true);
                }
                else
                {
                    this.PullApartLine(ParseThisString, true);
                }
            }
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

