using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transcribr
{
    class DocumentMaker
    {
        public static string FormattedDocumment(List<Slide> s, List<Captions> c)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{s[0].header}:\n");
            int p1 = 1, p2 = 0;
            while (true)
            {
                if (p2 == c.Count)
                    return sb.ToString();
                if (p1 == s.Count)
                {
                    sb.Append(c[p2].content);
                    p2++;
                }
                else
                {
                    Slide next_s = s[p1];
                    Captions curr_c = c[p2];
                    if (curr_c.timeStamp > next_s.timeStamp)
                    {
                        sb.AppendLine("\n\n");
                        sb.Append($"{next_s.header}:\n");
                        p1++;
                    }
                    else
                    {
                        sb.Append($" {c[p2].content}");
                        p2++;
                    }
                }

            }
        }
    }
}
