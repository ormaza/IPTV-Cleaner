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
            bool next = false;
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("http://mmds.fun:8880/get.php?username=73783163&password=84419772&type=m3u_plus&output=m3u8");
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