using System;

namespace URL_Parser
{
    public class URL_Parser
    {
        public static void Main()
        {
            // UPDATE: problem modified by SoftUni
            string[] url = Console.ReadLine()
                .Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            string protocol = "";
            string server = "";
            string resource = "";
            int startResourceParsing = 2;   // thanks to tihomirj
            if (url[0].Contains(":"))
            {
                protocol = url[0].Replace(":", "");
                server = url[1];
            }
            else
            {
                server = url[0];
                startResourceParsing--;
            }
            for (int i = startResourceParsing; i < url.Length; i++)
                resource = string.Join("/", resource, url[i]);
            if (resource.Length > 1)
                resource = resource.Remove(0, 1);
            Console.WriteLine("[protocol] = \"{0}\"", protocol);
            Console.WriteLine("[server] = \"{0}\"", server);            
            Console.WriteLine("[resource] = \"{0}\"", resource);
        }
    }
}