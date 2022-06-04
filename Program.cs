using System;
using System.IO;
using System.Net;

namespace iptv_cleaner
{
    class Program
    {
        public static void Main()
        {
            string[] quality = {"FHD","4K"};
            string line, substr;
	        string list_in = "";
            bool next = false;
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(list_in);
            StreamReader sr = new StreamReader(stream);
            StreamWriter sw = new StreamWriter("list-out.m3u");
            while ((line = sr.ReadLine()) != null)
            {
                if(next) 
                {
                    sw.WriteLine(line);
                    next = false;
                    continue;
                }
                foreach (string item in quality)
                {
                    substr = line.Substring(line.Length-item.Length-1, item.Length);
                    if(substr == item)
                    {
                        sw.WriteLine(line);
                        next = true;
                        break;
                    }
                }
            }
        }
    }
}