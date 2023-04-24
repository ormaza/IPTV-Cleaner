using System;
using System.IO;
using System.Net;

namespace iptv_cleaner
{
    class Program
    {
        public static void Main()
        {
            string[] quality = {"FHD¹","FHD"};
            string line, substr;
			bool next = false;
			
	        //string list_in = "";
            //WebClient client = new WebClient();
            //Stream stream = client.OpenRead(list_in);
            //StreamReader sr = new StreamReader(stream);
			
			StreamReader sr = new StreamReader("list-in.m3u");
            StreamWriter sw = new StreamWriter("list-out.m3u");
			sw.WriteLine("#EXTM3U x-tvg-url=\"http://u.mmds.fun/epg\"");
			
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
                    substr = line.Substring(line.Length-item.Length, item.Length);
                    if(substr == item)
                    {
						substr = line.Replace(" " + substr, "");
                        sw.WriteLine(substr.Trim());
                        next = true;
                        break;
                    }
                }
            }
        }
    }
}