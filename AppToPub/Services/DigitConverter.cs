using System;
using System.Collections.Generic;

namespace AbbTools.Services
{
    public class DigitConverter
    {
        
        private string _errorConvert { get; set; }

        public string ErrorConvert { 
            get => _errorConvert;
            private set
            {
                _errorConvert = value;
            }
        }

        Dictionary<string, int> romans = new Dictionary<string, int>{
        { "O" , 0 },  { "I", 1}, { "V", 5}, {"X", 10}, {"L", 50} ,
        { "C", 100 }, { "D", 500 }, { "M", 1000} };

        public string ConvertRomanToInteger(string st)
        {

            if (RomanStringContainsErrors(st)) return "Error";

            st = st.Replace("IIII", "IV");
            st = st.Replace("VV", "X");
            st = st.Replace("XXXX", "XL");
            st = st.Replace("LL", "C");
            int result;
            try
            {
                result = RomanToInteger(st);
            }
            catch (Exception ex)
            {                
                _errorConvert = "Error! Could not convert the value. " + ex.Message;
                return "Error";
            }
            return result.ToString();
        }

        private Boolean RomanStringContainsErrors(string str)
        {
            //I can be placed before V(5) and X to make 4 and 9.
            //X can be placed before L(50) and C to make 40 and 90.
            //C can be placed before D(500) and M to make 400 and 900.
            if (RomanStringContainsIllegalChars(str))
            {
                _errorConvert = "Error. String contains illegal characters";
                return true;
            }

            string[] illegalLetterCombinations = new string[] { "IL", "IC", "ID", "IM", "XD", "XM" };
            foreach (string letterCombintaion in illegalLetterCombinations)
            {
                if (str.Contains(letterCombintaion))
                {
                    _errorConvert = "Error. String contains illegal character combinations";
                    return true;
                }
            }
         
            return false;
        }


        private Boolean RomanStringContainsIllegalChars(string str)
        {
            String[] allowedChars = new String[] { "I", "V", "X", "L", "C", "D", "M" };
            foreach (string c in allowedChars)
            {
                str = str.Replace(c, "");
            }
            if (str.Length > 0) return true;
            return false;
        }

        private int RomanToInteger(string st)
        {
            Dictionary<string, int> romans = new Dictionary<string, int>{
        { "O" , 0 },  { "I", 1}, { "V", 5}, {"X", 10}, {"L", 50} ,
        { "C", 100 }, { "D", 500 }, { "M", 1000} };
            int t = 0;
            for (int i = 0; i < st.Length; i++)
            {
                if (i + 1 < st.Length && romans[st[i].ToString()] < romans[st[i + 1].ToString()])
                {
                    t -= romans[st[i].ToString()];
                }
                else
                {
                    t += romans[st[i].ToString()];
                }
            }
            return t;
        }

    }
}
