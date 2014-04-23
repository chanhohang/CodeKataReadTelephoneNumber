using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSReadTelephoneNumber
{
    public class ReadTelephoneNumber
    {
        public ReadTelephoneNumber()
        { }

        public string read(string input, string format)
        {
            TelephoneNumber telephoneNumber= new TelephoneNumber(input, format);
            return telephoneNumber.ToString();
        }

        static void Main(string[] args)
        {
        }
    }

    class Digit
    {
        private static Dictionary<int, string> numberMap = new Dictionary<int, string>();
        private static Dictionary<int, string> countMap = new Dictionary<int, string>();

        static Digit()
        {
            numberMap.Add(0, "zero");
            numberMap.Add(1, "one");
            numberMap.Add(2, "two");
            numberMap.Add(3, "three");
            numberMap.Add(4, "four");
            numberMap.Add(5, "five");
            numberMap.Add(6, "six");
            numberMap.Add(7, "seven");
            numberMap.Add(8, "eight");
            numberMap.Add(9, "nine");

            countMap.Add(1, "");
            countMap.Add(2, "double ");
            countMap.Add(3, "triple ");
            countMap.Add(4, "quadruple ");
            countMap.Add(5, "quintuple ");
            countMap.Add(6, "sextuple ");
            countMap.Add(7, "septuple ");
            countMap.Add(8, "octuple ");
            countMap.Add(9, "nonuple ");
            countMap.Add(10, "decuple ");
        }

        public int Count { get; private set; }
        public int Value { get; private set; }

        public Digit(int value)
        {
            this.Count = 1;
            this.Value = value;
        }

        public void IncreaseCount()
        {
            this.Count++;
        }

        public string ToString()
        {
            return countMap[Count] + numberMap[Value];
        }
    }

    class Group
    {
        private List<Digit> digits { get; set; }

        public Group()
        {
            digits = new List<Digit>();
        }

        public void Add(int value)
        {
            if (digits.Count == 0)
            {
                digits.Add(new Digit(value));
            }
            else
            {
                Digit lastDigit = digits.Last<Digit>();
                if (lastDigit.Value == value)
                {
                    lastDigit.IncreaseCount();
                }
                else
                {
                    digits.Add(new Digit(value));
                }
            }
        }

        public string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Digit digit in digits)
            {
                builder.Append(digit.ToString()).Append(' ');
            }
            return builder.ToString().TrimEnd();
        }
    }

    class TelephoneNumber
    {
        private List<Group> groups { get; set; }
        private string format;

        public TelephoneNumber(string inputString, string formatString)
        {
            groups = new List<Group>();
            string[] formats = formatString.Split('-');
            int index = 0;
            foreach (string format in formats)
            {
                int length = Int32.Parse(format);
                Group group = new Group();
                //string groupString = inputString.Substring(index, length);
                //for (int i = index; i < index+length;i++ )
                while (length-- > 0)
                {
                    char c = inputString[index++];
                    group.Add(c - '0');
                }
                groups.Add(group);
            }
        }

        public string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Group group in groups)
            {
                builder.Append(group.ToString()).Append(' ');
            }
            return builder.ToString().TrimEnd();
        }
    }
}
