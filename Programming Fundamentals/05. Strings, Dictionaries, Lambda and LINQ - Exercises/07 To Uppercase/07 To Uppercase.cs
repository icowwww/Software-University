using System;
using System.Collections.Generic;

namespace To_Uppercase
{
    public class To_Uppercase
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string resultText = "";
            List<string> tags = new List<string>();
            tags.Add("<upcase>");
            tags.Add("</upcase>");
            int i = 0;
            int tagIndexStart = -1;
            int tagIndexEnd = -1;

            while (i < text.Length)
            {
                tagIndexStart = text.IndexOf(tags[0], i);
                tagIndexEnd = text.IndexOf(tags[1], i);
                if (tagIndexStart == -1) break;
                // add regular text
                resultText += text.Substring(i, tagIndexStart - i);
                // add uppercase text
                resultText += text.Substring(tagIndexStart + tags[0].Length,
                                             tagIndexEnd - tagIndexStart - tags[0].Length)
                                            .ToUpper();
                i = tagIndexEnd + tags[1].Length;
            }
            // add remaining text
            if (tagIndexStart == -1 && i < text.Length)
                resultText += text.Substring(i, text.Length - i);
            Console.WriteLine(resultText);
        }
    }
}