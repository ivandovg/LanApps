using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanApp9_1
{
    public class FtpItem
    {
        string rawText;
        string shortName;

        public string RawText { get => rawText; }
        public string ShortName { get => shortName; }

        public bool IsFile
        {
            get => rawText.StartsWith("-");
        }
        public bool IsDirectory
        {
            get => rawText.StartsWith("d");
        }

        public FtpItem(string raw)
        {
            if (string.IsNullOrEmpty(raw))
                throw new ArgumentException("Input string cannot be empty!!!");
            rawText = raw;
            int pos = rawText.LastIndexOf(' ');
            shortName = rawText.Substring(pos + 1);
        }

        public override string ToString()
        {
            return shortName;
        }

        public static implicit operator string(FtpItem item)
        {
            return item.ToString();
        }
    }
}
